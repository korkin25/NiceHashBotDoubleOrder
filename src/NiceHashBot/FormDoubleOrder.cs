using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NiceHashBotLib;

namespace NiceHashBot
{
    public partial class FormDoubleOrder : Form
    {
        private Pool[] Pools;
        private bool linked = false;
        private Timer BalanceRefresh, TimerRefresh, OrderTimer;

        double LimitBuffer;
        double MaxPriceBuffer;
        double StartAmount = 0.005;

        //double StartPrice = 0.001;
        double StartPrice = 0;

        int OrderID = 0;

        public FormDoubleOrder()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "] Orders";

            BalanceRefresh = new Timer();
            BalanceRefresh.Interval = 30 * 1000;
            BalanceRefresh.Tick += new EventHandler(BalanceRefresh_Tick);
            BalanceRefresh.Start();
            BalanceRefresh_Tick(null, null);

            TimerRefresh = new Timer();
            TimerRefresh.Interval = 60000;
            TimerRefresh.Tick += new EventHandler(TimerRefresh_Tick);
            TimerRefresh.Start();
            TimerRefresh_Tick(null, null);
            FindOrdersButton.Click += new EventHandler(TimerRefresh_Tick);

            RefreshPoolList();

            foreach (string A in APIWrapper.ALGORITHM_NAME)
                this.AlgorithmComboBox.Items.Add(A);
            AlgorithmComboBox.SelectedIndex = 0;

            if (PoolComboBox.Items.Count > 0)
            PoolComboBox.SelectedIndex = 0;

        }

        private void BalanceRefresh_Tick(object sender, EventArgs e)
        {
            if (!APIWrapper.ValidAuthorization)
            {
                Console.WriteLine("Can not receive balance - Invalid Authorisation");
                return;
            }

            APIBalance Balance = APIWrapper.GetBalance();

            if (Balance == null)
            {
                BalanceLabel.Text = "";
            }
            else
            {
                BalanceLabel.Text = Balance.Confirmed.ToString("F8") + " BTC";
            }
        }

        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            if (!APIWrapper.ValidAuthorization) return;

            OrderContainer[] Orders = OrderContainer.GetAll();
            if (Orders.Length == 0) return;

            OrderID = Orders.Count();
            List<OrderPanel> OrderPanels = new List<OrderPanel>();

            for (int i = 0; i < Orders.Length; i++)
                OrderPanels.Add(new OrderPanel(Orders[i]));

            PositionPanels(ref OrderPanels);

            foreach (OrderPanel panel in OrderPanels)
            {
                if (panel.order.ServiceLocation == 0)
                    //EUOrderPanel.Controls.Add(panel.panel);
                panel.Place(ref EUOrderPanel);
                else if (panel.order.ServiceLocation == 1)
                    //USOrderPanel.Controls.Add(panel.panel);
                panel.Place(ref USOrderPanel);
            }
        }

        private void PositionPanels(ref List<OrderPanel> OrderPanels)
        {
            int pos = 0;
            bool found;

            for (int i = 0; i < OrderPanels.Count; i++)
            {
                if (OrderPanels[i].position != -1) continue;
                OrderPanels[i].position = pos;

                found = false;

                for (int j = i + 1; j < OrderPanels.Count; j++)
                {
                    if (found) continue;
                    if (
                           (OrderPanels[i].order.ServiceLocation != OrderPanels[j].order.ServiceLocation)
                           &&
                           (OrderPanels[i].order.MaxPrice == OrderPanels[j].order.MaxPrice)
                           &&
                           (OrderPanels[i].order.Limit == OrderPanels[j].order.Limit)
                       )
                        {
                            OrderPanels[j].position = pos;
                            pos++;
                            found = true;
                        }
                        
                }
            }
        }

        public void RefreshPoolList()
        {
            PoolComboBox.Items.Clear();

            Pools = PoolContainer.GetAll();
            foreach (Pool P in Pools)
            {
                PoolComboBox.Items.Add(P.Label);
            }
        }


        private void FormDoubleOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.FormDoubleOrderInstance = null;
        }

        private void LinkButton_Click(object sender, EventArgs e)
        {
            linked = linked ? false : true;
            USPanel.Visible = linked ? false : true;
            USPanel.Enabled = linked ? false : true;
            EULabel.Visible = linked ? false : true;
        }

        private void OnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OnTopCheckBox.Checked) this.TopMost = true;
            else if (!OnTopCheckBox.Checked) this.TopMost = false;
        }

        private void USConfirmButton_Click(object sender, EventArgs e)
        {
            if (PoolComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select pool for this order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PoolComboBox.Focus();
                return;
            }

            LimitBuffer = decimal.ToDouble(Convert.ToDecimal(USSpeedTextBox.Text));
            MaxPriceBuffer = decimal.ToDouble(Convert.ToDecimal(USPriceTextBox.Text));

            if (OrderContainer.Add(1, AlgorithmComboBox.SelectedIndex, MaxPriceBuffer, LimitBuffer, Pools[PoolComboBox.SelectedIndex], OrderID, StartPrice, StartAmount, ""))
                OrderID++;
            else
                MessageBox.Show("Error creating order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EUConfirmButton_Click(object sender, EventArgs e)
        {
            if (PoolComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select pool for this order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PoolComboBox.Focus();
                return;
            }

            LimitBuffer = decimal.ToDouble(Convert.ToDecimal(EUSpeedTextBox.Text));
            MaxPriceBuffer = decimal.ToDouble(Convert.ToDecimal(EUPriceTextBox.Text));

            if (OrderContainer.Add(0, AlgorithmComboBox.SelectedIndex, MaxPriceBuffer, LimitBuffer, Pools[PoolComboBox.SelectedIndex], OrderID, StartPrice, StartAmount, ""))
                OrderID++;
            else
                MessageBox.Show("Error creating order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (linked)
            {
                if (OrderContainer.Add(1, AlgorithmComboBox.SelectedIndex, MaxPriceBuffer, LimitBuffer, Pools[PoolComboBox.SelectedIndex], OrderID, StartPrice, StartAmount, ""))
                    OrderID++;
                else
                    MessageBox.Show("Error creating order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
