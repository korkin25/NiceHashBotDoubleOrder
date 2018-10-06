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

        private Timer BalanceRefresh;

        public FormDoubleOrder()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "] Orders";

            BalanceRefresh = new Timer();
            BalanceRefresh.Interval = 30 * 1000;
            BalanceRefresh.Tick += new EventHandler(BalanceRefresh_Tick);
            BalanceRefresh.Start();
            BalanceRefresh_Tick(null, null);

            RefreshPoolList();

            foreach (string A in APIWrapper.ALGORITHM_NAME)
                this.AlgorithmComboBox.Items.Add(A);
            AlgorithmComboBox.SelectedIndex = 0;


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

        }

        private void OnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OnTopCheckBox.Checked) this.TopMost = true;
            else if (!OnTopCheckBox.Checked) this.TopMost = false;
        }
    }
}
