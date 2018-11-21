using NiceHashBotLib;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Label IDLabel;

        private int sync = -1;
        public int Sync
        {
            set
            {
                sync = value;
                //IDLabel.Text = "# " + order.ID.ToString() + " (sync with [" + value.ToString() + "])";
            }
            get { return sync; }
        }

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
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
            };

            FillPanel();

            if (order.OrderStats == null)
                panel.BackColor = System.Drawing.Color.Yellow;
            else if (!order.OrderStats.Alive)
                panel.BackColor = System.Drawing.Color.IndianRed;
            else
                panel.BackColor = System.Drawing.Color.LightGreen;
        }

        private void FillPanel()
        {

            IDLabel = new Label
            { 
                Text = "# " + order.ID.ToString(),
                Location = new System.Drawing.Point(5, 7),
                AutoSize = true,
            };
            panel.Controls.Add(IDLabel);
            IDLabel.Click += (o, args) =>
            {
                System.Diagnostics.Process.Start("https://www.nicehash.com/order/" + order.ID.ToString());
            };

            var DeleteButton = new Button
            {
                Text = "X",
                Location = new System.Drawing.Point(170, 3),
                Width = 25,
                BackColor = SystemColors.ButtonFace,
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
                Text = order.MaxPrice.ToString("F4"),
                Location = new System.Drawing.Point(50, 32),
                Width = 50,
            };
            panel.Controls.Add(PriceTextBox);
            PriceTextBox.TextChanged += PriceTextBox_TextChanged;

            if (order.MaxPriceInput != 0)
                PriceTextBox.Text = order.MaxPriceInput.ToString("F4");

            ToolTip currentPriceTooltip = new ToolTip();
            currentPriceTooltip.ToolTipIcon = ToolTipIcon.Info;
            currentPriceTooltip.IsBalloon = true;
            currentPriceTooltip.ShowAlways = true;

            currentPriceTooltip.SetToolTip(PriceTextBox, order.MaxPrice.ToString("F4"));

            var AddBitsTextBox = new TextBox
            {
                Text = "0",
                Location = new System.Drawing.Point(105, 32),
                Width = 30,
            };
            panel.Controls.Add(AddBitsTextBox);
            AddBitsTextBox.TextChanged += AddBitsTextBox_TextChanged;

            if (order.BitsInput != 0)
                AddBitsTextBox.Text = order.BitsInput.ToString();

            panel.Controls.Add(new Label
            {
                Text = "Speed: " + order.OrderStats.Speed + " (" + order.OrderStats.Workers + " workers)",
                Location = new System.Drawing.Point(5, 55),
                AutoSize = true,
            });

            panel.Controls.Add(new Label
            {
                Text = "Availiable BTC: " + order.OrderStats.BTCAvailable,
                Location = new System.Drawing.Point(5, 75),
                AutoSize = true,
            });

            var SetButton = new Button
            {
                Text = "Set",
                Location = new System.Drawing.Point(145, 30),
                Width = 50,
                BackColor = SystemColors.ButtonFace,
            };
            panel.Controls.Add(SetButton);
            SetButton.Click += async (o, args) =>
            {
                await SetValuesAsync();
                TimerRefresh(null, null);
            };
            //SetButton.Click += TimerRefresh;            

            async Task<bool> SetValuesAsync()
            {
                int delayTime = 1900;
                int i = 0;
                bool needDelay = false;

                FormPleaseWait pleaseWait = new FormPleaseWait();
                try
                {
                    pleaseWait.StartPosition = FormStartPosition.CenterScreen;
                    pleaseWait.Show();                   
                }
                catch (Exception ex) { Console.WriteLine(ex); }

                foreach (OrderContainer _order in OrderContainer.GetAll())
                {
                    if (_order.ID == order.ID)
                    {
                        if (_order.Limit != Convert.ToDouble(LimitTextBox.Text))
                        {
                            if (needDelay) await Task.Delay(delayTime);
                            OrderContainer.SetLimit(i, Convert.ToDouble(LimitTextBox.Text));
                            APIWrapper.OrderSetLimit(_order.ServiceLocation, _order.Algorithm, _order.ID, Convert.ToDouble(LimitTextBox.Text));
                            needDelay = true;
                        }

                        if (_order.MaxPrice != Convert.ToDouble(PriceTextBox.Text) + Convert.ToDouble(AddBitsTextBox.Text) * 0.0001)
                        {
                            if (needDelay) await Task.Delay(delayTime);
                            OrderContainer.SetMaxPrice(i, Convert.ToDouble(PriceTextBox.Text) + Convert.ToDouble(AddBitsTextBox.Text) * 0.0001);
                            APIWrapper.OrderSetPrice(_order.ServiceLocation, _order.Algorithm, _order.ID, Convert.ToDouble(PriceTextBox.Text) + Convert.ToDouble(AddBitsTextBox.Text) * 0.0001);
                            needDelay = true;
                            _order.MaxPriceInput = _order.MaxPrice;
                            _order.BitsInput = 0;
                        }

                        if (Sync != -1)
                        {
                            OrderContainer[] Orders = OrderContainer.GetAll();
                            int _i = 0;
                            foreach (OrderContainer _orderSynced in Orders)
                            {
                                if (_orderSynced.ID == Sync)
                                {
                                    if (_orderSynced.Limit != Convert.ToDouble(LimitTextBox.Text))
                                    {
                                        if (needDelay) await Task.Delay(delayTime);
                                        OrderContainer.SetLimit(_i, Convert.ToDouble(LimitTextBox.Text));
                                        APIWrapper.OrderSetLimit(_orderSynced.ServiceLocation, _orderSynced.Algorithm, _orderSynced.ID, Convert.ToDouble(LimitTextBox.Text));
                                        needDelay = true;
                                    }

                                    if (_orderSynced.MaxPrice != Convert.ToDouble(PriceTextBox.Text) + Convert.ToDouble(AddBitsTextBox.Text) * 0.0001)
                                    {
                                        if (needDelay) await Task.Delay(delayTime);
                                        OrderContainer.SetMaxPrice(_i, Convert.ToDouble(PriceTextBox.Text) + Convert.ToDouble(AddBitsTextBox.Text) * 0.0001);
                                        APIWrapper.OrderSetPrice(_orderSynced.ServiceLocation, _orderSynced.Algorithm, _orderSynced.ID, Convert.ToDouble(PriceTextBox.Text) + Convert.ToDouble(AddBitsTextBox.Text) * 0.0001);
                                        needDelay = true;
                                        _orderSynced.MaxPriceInput = _orderSynced.MaxPrice;
                                        _orderSynced.BitsInput = 0;
                                    }

                                    break;
                                }
                                _i++;
                            }
                        }
                    }

                    i++;
                }
                try { pleaseWait.Close(); }
                catch (Exception ex) { Console.WriteLine(ex); }

                return true;
            }

            var RefillButton = new Button
            {
                Text = "Refill",
                Location = new System.Drawing.Point(145, 68),
                Width = 50,
                BackColor = SystemColors.ButtonFace,
            };
            panel.Controls.Add(RefillButton);
            RefillButton.Click += (o, args) =>
            {
                order.OrderStats.Refill(0.005);
            };
            RefillButton.Click += TimerRefresh;
        }

        private void AddBitsTextBox_TextChanged(object sender, EventArgs e)
        {
            order.BitsInput = Convert.ToDouble((sender as TextBox).Text);
        }

        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {
            string line = (sender as TextBox).Text;

            for (int i = 0; i < line.Length; i++)
            {
                if ((char.IsDigit(line[i])) || (line[i] == '.'))
                    continue;

                line = line.Remove(i, 1);
                i--;
            }
            Console.WriteLine(line);
            (sender as TextBox).Text = line;

            order.MaxPriceInput = Convert.ToDouble((sender as TextBox).Text);
        }

        public void Place(ref Panel place, ref Panel SyncOrderPanel)
        {
            if (height * (position + 1) > 400)
            {
                place.Size = new System.Drawing.Size(place.Size.Width, height * (position + 1));
            }                
            else
            {
                place.Size = new System.Drawing.Size(place.Size.Width, 400);
            }               

            panel.Location = new System.Drawing.Point(-1, (height - 1) * position);
            place.Controls.Add(panel);

            if (Sync != -1)
            {
                Button DesyncButton = new Button
                {
                    //Location = new System.Drawing.Point(0, panel.Location.Y + height / 2 - 5),
                    Location = new System.Drawing.Point(0, panel.Location.Y),
                    //Text = "",
                    BackColor = SystemColors.ButtonFace,
                    Height = height,
                    Width = SyncOrderPanel.Width - 2,
                    Image = Properties.Resources.link_icon_black1,
                };
                DesyncButton.Click += (ob, args) =>
                {                    
                    DesyncController.Add(order.ID.ToString(), Sync.ToString());
                };
                DesyncButton.Click += TimerRefresh;
                SyncOrderPanel.Controls.Add(DesyncButton);
            }
        }
    }
}
