using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceHashBot
{
    class OrderPanel
    {
        public int position = -1;
        public OrderContainer order;

        public Panel panel;
        private EventHandler TimerRefresh;
        private int height;
        private int id;

        public OrderPanel(int id, OrderContainer order, EventHandler TimerRefresh)
        {
            this.order = order;
            this.id = id;
            this.TimerRefresh = TimerRefresh;
            height = 100;

            panel = new Panel
            {
                Width = 200,
                Height = height,
                BackColor = System.Drawing.Color.Red,
                BorderStyle = BorderStyle.FixedSingle,
            };

            FillPanel();

            if (order.OrderStats == null)
                panel.BackColor = System.Drawing.Color.Yellow;
            else if (!order.OrderStats.Alive)
                panel.BackColor = System.Drawing.Color.IndianRed;
        }

        private void FillPanel()
        {
            panel.Controls.Add(new Label
            {
                Text = "# " + order.ID.ToString(),
                Location = new System.Drawing.Point(5, 7),
                AutoSize = true,
            });

            var DeleteButton = new Button
            {
                Text = "X",
                Location = new System.Drawing.Point(170, 3),
                Width = 25,
                BackColor = System.Drawing.Color.White,
            };
            panel.Controls.Add(DeleteButton);
            DeleteButton.Click += (o, args) =>
            {
                OrderContainer.Remove(id);
            };
            DeleteButton.Click += TimerRefresh;

            if (order.OrderStats == null) return;

            var LimitTextBox = new TextBox
            {
                Text = order.Limit.ToString(),
                Location = new System.Drawing.Point(5, 32),
                Width = 40,
            };
            panel.Controls.Add(LimitTextBox);

            var PriceTextBox = new TextBox
            {
                Text = order.MaxPrice.ToString(),
                Location = new System.Drawing.Point(50, 32),
                Width = 50,
            };
            panel.Controls.Add(PriceTextBox);

            var AddBitsTextBox = new TextBox
            {
                Text = "0",
                Location = new System.Drawing.Point(105, 32),
                Width = 30,
            };
            panel.Controls.Add(AddBitsTextBox);

            panel.Controls.Add(new Label
            {
                Text = "Availiable BTC: " + order.OrderStats.BTCAvailable,
                Location = new System.Drawing.Point(5, 63),
                AutoSize = true,
            });

            var SetButton = new Button
            {
                Text = "Set",
                Location = new System.Drawing.Point(145, 30),
                Width = 50,
                BackColor = System.Drawing.Color.White,
            };
            panel.Controls.Add(SetButton);
            SetButton.Click += (o, args) =>
            {
                order.Limit = Convert.ToDouble(LimitTextBox.Text);
                order.MaxPrice = Convert.ToDouble(PriceTextBox.Text) + Convert.ToDouble(AddBitsTextBox.Text) * 0.0001;
            };
            SetButton.Click += TimerRefresh;

            var RefillButton = new Button
            {
                Text = "Refill",
                Location = new System.Drawing.Point(145, 57),
                Width = 50,
                BackColor = System.Drawing.Color.White,
            };
            panel.Controls.Add(RefillButton);
            RefillButton.Click += (o, args) =>
            {
                order.OrderStats.Refill(0.005);
            };
            RefillButton.Click += TimerRefresh;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Place(ref Panel place, ref Panel SyncOrderPanel)
        {
            if (height * (position + 1) > 400)
                place.Size = new System.Drawing.Size(place.Size.Width, height * (position + 1));
            else
                place.Size = new System.Drawing.Size(place.Size.Width, 400);

            panel.Location = new System.Drawing.Point(-1, (height - 1) * position);
            place.Controls.Add(panel);
        }
    }
}
