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
        private int height;

        public OrderPanel(OrderContainer order)
        {
            this.order = order;
            height = 100;

            panel = new Panel
            {
                Width = 100,
                Height = height,
                Location = new System.Drawing.Point(0, height * position),
                BorderStyle = BorderStyle.FixedSingle,
            };

            panel.Controls.Add(new Label { Text = "Test", Location = new System.Drawing.Point(10, 10) });

            if (order.OrderStats == null)
                panel.BackColor = System.Drawing.Color.Yellow;
            else if (!order.OrderStats.Alive)
                panel.BackColor = System.Drawing.Color.IndianRed;
        }

        public void Place(ref Panel place)
        {
            place.Controls.Add(panel);
        }
    }
}
