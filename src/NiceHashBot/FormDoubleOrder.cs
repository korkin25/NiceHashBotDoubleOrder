using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NiceHashBotLib;

namespace NiceHashBot
{
    public partial class FormDoubleOrder : Form
    {
        private Pool[] Pools;
        private bool linked = false;
        public Timer BalanceRefresh, TimerRefresh, OrderTimer;

        double LimitBuffer;
        double MaxPriceBuffer;
        double StartAmount = 0.005;

        double StartPrice = 0.001;
        //double StartPrice = 0;

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
            AlgorithmComboBox.SelectedIndexChanged += new EventHandler(TimerRefresh_Tick);
            PoolComboBox.SelectedIndexChanged += new EventHandler(TimerRefresh_Tick);

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

        private void Refresh()
        {
            TimerRefresh_Tick(null, null);
            BalanceRefresh_Tick(null, null);
        }

        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            EUOrderPanel.Controls.Clear();
            USOrderPanel.Controls.Clear();
            SyncOrderPanel.Controls.Clear();

            if (!APIWrapper.ValidAuthorization) return;

            //APIWrapper.GetAllOrders();
            OrderContainer[] Orders = OrderContainer.GetAll();
            if (Orders.Count() > OrderID) OrderID = Orders.Count();

            if (Orders.Length == 0) return;
           
            List<OrderPanel> OrderPanels = new List<OrderPanel>();

            for (int i = 0; i < Orders.Length; i++)
                if (Orders[i].Algorithm == AlgorithmComboBox.SelectedIndex)
                    OrderPanels.Add(new OrderPanel(i, Orders[i], new EventHandler(TimerRefresh_Tick)));

            PositionPanels(ref OrderPanels);

            foreach (OrderPanel panel in OrderPanels)
            {
                if (panel.order.ServiceLocation == 0)
                    panel.Place(ref EUOrderPanel, ref SyncOrderPanel);
                else if (panel.order.ServiceLocation == 1)
                    panel.Place(ref USOrderPanel, ref SyncOrderPanel);
            }
            SyncOrderPanel.Height = EUOrderPanel.Height > USOrderPanel.Height ? EUOrderPanel.Height : USOrderPanel.Height;
        }

        private void PositionPanels(ref List<OrderPanel> OrderPanels)
        {
            int pos = 0;
            bool found;

            for (int i = 0; i < OrderPanels.Count; i++)
            {
                if (OrderPanels[i].position != -1) continue;
                OrderPanels[i].position = pos;
                List<string> Desyncs = DesyncController.GetAll();               

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
                           &&
                           ((OrderPanels[i].Sync == -1) && (OrderPanels[j].Sync == -1))
                           &&
                           (
                               (OrderPanels[i].order.OrderStats != null) && (OrderPanels[j].order.OrderStats != null)
                               ||
                               (OrderPanels[i].order.OrderStats == null) && (OrderPanels[j].order.OrderStats == null)
                           )
                           //&&
                           //()
                       )
                        {
                        string checkForth = OrderPanels[i].order.ID.ToString() + ":" + OrderPanels[j].order.ID.ToString();
                        string checkBack  = OrderPanels[j].order.ID.ToString() + ":" + OrderPanels[i].order.ID.ToString();
                        bool quit = false;
                        foreach (string desync in Desyncs)
                        {
                            if ((checkForth == desync) || (checkBack == desync))
                            {
                                quit = true;
                                continue;
                            }
                        }
                        if (quit) continue;

                        OrderPanels[j].position = pos;

                            OrderPanels[i].Sync = OrderPanels[j].order.ID;
                            OrderPanels[j].Sync = OrderPanels[i].order.ID;

                            found = true;
                        }                       
                }
                pos++;
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

        private void FormDoubleOrder_Load(object sender, EventArgs e)
        {
        }

        private async void RemoveAllButton_Click(object sender, EventArgs e)
        {
            bool empty = true;

            OrderContainer[] Orders = OrderContainer.GetAll();
            for (int i = Orders.Length - 1; i >= 0; i--)
                if (Orders[i].Algorithm == AlgorithmComboBox.SelectedIndex)
                    empty = false;
            if (empty) return;

            string algo = APIWrapper.ALGORITHM_NAME[AlgorithmComboBox.SelectedIndex];
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove all [" + algo + "] orders?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FormPleaseWait pleaseWait = new FormPleaseWait();
                try
                {                    
                    pleaseWait.StartPosition = FormStartPosition.CenterScreen;
                    pleaseWait.Show();
                    //
                    await DeleteOrdersAsync(Orders);
                    pleaseWait.Close();
                }
                catch(Exception ex) { Console.WriteLine(ex); }
                
            }
            Refresh();
        }

        private async Task<bool> DeleteOrdersAsync(OrderContainer[] Orders)
        {
            bool wait = false;

            for (int i = Orders.Length - 1; i >= 0; i--)
                if (Orders[i].Algorithm == AlgorithmComboBox.SelectedIndex)
                {
                    if (wait) await Task.Delay(1100);
                    OrderContainer.Remove(i);
                    wait = true;
                }                    
            return true;
        }

        private void OvPriceConfirmButton_Click(object sender, EventArgs e)
        {
            OrderContainer[] Orders = OrderContainer.GetAll();
            for (int i = Orders.Length - 1; i >= 0; i--)
                if (Orders[i].Algorithm == AlgorithmComboBox.SelectedIndex)
                    if (Orders[i].OrderStats != null)
                        Orders[i].MaxPrice = Convert.ToDouble(OvPriceTextBox.Text);
            Refresh();
        }

        private void OvSpeedConfirmButton_Click(object sender, EventArgs e)
        {
            OrderContainer[] Orders = OrderContainer.GetAll();
            for (int i = Orders.Length - 1; i >= 0; i--)
                if (Orders[i].Algorithm == AlgorithmComboBox.SelectedIndex)
                    if (Orders[i].OrderStats != null)
                        Orders[i].Limit = Convert.ToDouble(OvSpeedTextBox.Text);
            Refresh();
        }

        private void FindOrdersButton_Click(object sender, EventArgs e)
        {
            DesyncController.Delete();

            List<Order> orders = new List<Order>();
            foreach (Order order in APIWrapper.GetMyOrders(0, AlgorithmComboBox.SelectedIndex))
            {
                orders.Add(order);
            }
            foreach (Order order in APIWrapper.GetMyOrders(1, AlgorithmComboBox.SelectedIndex))
            {
                orders.Add(order);
            }

            OrderContainer[] localOrders = OrderContainer.GetAll();
            foreach(Order order in orders)
            {
                bool exists = false;
                foreach (OrderContainer orderContainer in localOrders)
                    if (orderContainer.ID == order.ID)
                        exists = true;
                if (!exists)
                    OrderContainer.Add(order.ServiceLocation, order.Algorithm, order.Price, order.SpeedLimit, new Pool(), order.ID, 0.001, 0.005, "");
            }

            Refresh();            
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

            Refresh();
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
            }
            Refresh();
        }
    }
}
