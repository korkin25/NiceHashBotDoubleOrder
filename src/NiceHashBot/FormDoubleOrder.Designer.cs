namespace NiceHashBot
{
    partial class FormDoubleOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoubleOrder));
            this.AlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.AlgorithmLabel = new System.Windows.Forms.Label();
            this.PoolComboBox = new System.Windows.Forms.ComboBox();
            this.PoolLabel = new System.Windows.Forms.Label();
            this.BalanceTitleLabel = new System.Windows.Forms.Label();
            this.BalanceLabel = new System.Windows.Forms.Label();
            this.EULabel = new System.Windows.Forms.Label();
            this.USLabel = new System.Windows.Forms.Label();
            this.EUSpeedLabel = new System.Windows.Forms.Label();
            this.USSpeedLabel = new System.Windows.Forms.Label();
            this.EUPriceLabel = new System.Windows.Forms.Label();
            this.USPriceLabel = new System.Windows.Forms.Label();
            this.EUSpeedTextBox = new System.Windows.Forms.TextBox();
            this.EUPriceTextBox = new System.Windows.Forms.TextBox();
            this.USSpeedTextBox = new System.Windows.Forms.TextBox();
            this.USPriceTextBox = new System.Windows.Forms.TextBox();
            this.EUConfirmButton = new System.Windows.Forms.Button();
            this.USConfirmButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.USPanel = new System.Windows.Forms.Panel();
            this.LinkButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FindOrdersLabel = new System.Windows.Forms.Label();
            this.RemoveAllLabel = new System.Windows.Forms.Label();
            this.RemoveAllButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.OvSpeedTextBox = new System.Windows.Forms.TextBox();
            this.OvSpeedConfirmButton = new System.Windows.Forms.Button();
            this.OvSpeedLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OvPriceTextBox = new System.Windows.Forms.TextBox();
            this.OvPriceConfirmButton = new System.Windows.Forms.Button();
            this.OvPriceLabel = new System.Windows.Forms.Label();
            this.FindOrdersButton = new System.Windows.Forms.Button();
            this.OnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.EUOrderPanel = new System.Windows.Forms.Panel();
            this.USOrderPanel = new System.Windows.Forms.Panel();
            this.SyncOrderPanel = new System.Windows.Forms.Panel();
            this.MainOrderPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.USPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.MainOrderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmComboBox.FormattingEnabled = true;
            this.AlgorithmComboBox.Location = new System.Drawing.Point(50, 6);
            this.AlgorithmComboBox.Name = "AlgorithmComboBox";
            this.AlgorithmComboBox.Size = new System.Drawing.Size(70, 21);
            this.AlgorithmComboBox.TabIndex = 3;
            // 
            // AlgorithmLabel
            // 
            this.AlgorithmLabel.AutoSize = true;
            this.AlgorithmLabel.Location = new System.Drawing.Point(0, 10);
            this.AlgorithmLabel.Name = "AlgorithmLabel";
            this.AlgorithmLabel.Size = new System.Drawing.Size(53, 13);
            this.AlgorithmLabel.TabIndex = 4;
            this.AlgorithmLabel.Text = "Algorithm:";
            // 
            // PoolComboBox
            // 
            this.PoolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PoolComboBox.FormattingEnabled = true;
            this.PoolComboBox.Location = new System.Drawing.Point(152, 6);
            this.PoolComboBox.Name = "PoolComboBox";
            this.PoolComboBox.Size = new System.Drawing.Size(70, 21);
            this.PoolComboBox.TabIndex = 5;
            // 
            // PoolLabel
            // 
            this.PoolLabel.AutoSize = true;
            this.PoolLabel.Location = new System.Drawing.Point(124, 10);
            this.PoolLabel.Name = "PoolLabel";
            this.PoolLabel.Size = new System.Drawing.Size(31, 13);
            this.PoolLabel.TabIndex = 6;
            this.PoolLabel.Text = "Pool:";
            // 
            // BalanceTitleLabel
            // 
            this.BalanceTitleLabel.AutoSize = true;
            this.BalanceTitleLabel.Location = new System.Drawing.Point(231, 10);
            this.BalanceTitleLabel.Name = "BalanceTitleLabel";
            this.BalanceTitleLabel.Size = new System.Drawing.Size(49, 13);
            this.BalanceTitleLabel.TabIndex = 7;
            this.BalanceTitleLabel.Text = "Balance:";
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.AutoSize = true;
            this.BalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BalanceLabel.Location = new System.Drawing.Point(275, 10);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(95, 13);
            this.BalanceLabel.TabIndex = 9;
            this.BalanceLabel.Text = "0,0000000 BTC";
            this.BalanceLabel.Click += new System.EventHandler(this.BalanceLabel_Click);
            // 
            // EULabel
            // 
            this.EULabel.AutoSize = true;
            this.EULabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EULabel.Location = new System.Drawing.Point(62, -2);
            this.EULabel.Name = "EULabel";
            this.EULabel.Size = new System.Drawing.Size(43, 25);
            this.EULabel.TabIndex = 10;
            this.EULabel.Text = "EU";
            // 
            // USLabel
            // 
            this.USLabel.AutoSize = true;
            this.USLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.USLabel.Location = new System.Drawing.Point(95, 0);
            this.USLabel.Name = "USLabel";
            this.USLabel.Size = new System.Drawing.Size(43, 25);
            this.USLabel.TabIndex = 11;
            this.USLabel.Text = "US";
            // 
            // EUSpeedLabel
            // 
            this.EUSpeedLabel.AutoSize = true;
            this.EUSpeedLabel.Location = new System.Drawing.Point(23, 15);
            this.EUSpeedLabel.Name = "EUSpeedLabel";
            this.EUSpeedLabel.Size = new System.Drawing.Size(36, 13);
            this.EUSpeedLabel.TabIndex = 12;
            this.EUSpeedLabel.Text = "speed";
            // 
            // USSpeedLabel
            // 
            this.USSpeedLabel.AutoSize = true;
            this.USSpeedLabel.Location = new System.Drawing.Point(59, 17);
            this.USSpeedLabel.Name = "USSpeedLabel";
            this.USSpeedLabel.Size = new System.Drawing.Size(36, 13);
            this.USSpeedLabel.TabIndex = 13;
            this.USSpeedLabel.Text = "speed";
            // 
            // EUPriceLabel
            // 
            this.EUPriceLabel.AutoSize = true;
            this.EUPriceLabel.Location = new System.Drawing.Point(107, 15);
            this.EUPriceLabel.Name = "EUPriceLabel";
            this.EUPriceLabel.Size = new System.Drawing.Size(30, 13);
            this.EUPriceLabel.TabIndex = 14;
            this.EUPriceLabel.Text = "price";
            // 
            // USPriceLabel
            // 
            this.USPriceLabel.AutoSize = true;
            this.USPriceLabel.Location = new System.Drawing.Point(141, 17);
            this.USPriceLabel.Name = "USPriceLabel";
            this.USPriceLabel.Size = new System.Drawing.Size(30, 13);
            this.USPriceLabel.TabIndex = 15;
            this.USPriceLabel.Text = "price";
            // 
            // EUSpeedTextBox
            // 
            this.EUSpeedTextBox.Location = new System.Drawing.Point(1, 30);
            this.EUSpeedTextBox.Name = "EUSpeedTextBox";
            this.EUSpeedTextBox.Size = new System.Drawing.Size(80, 20);
            this.EUSpeedTextBox.TabIndex = 16;
            // 
            // EUPriceTextBox
            // 
            this.EUPriceTextBox.Location = new System.Drawing.Point(83, 30);
            this.EUPriceTextBox.Name = "EUPriceTextBox";
            this.EUPriceTextBox.Size = new System.Drawing.Size(80, 20);
            this.EUPriceTextBox.TabIndex = 17;
            // 
            // USSpeedTextBox
            // 
            this.USSpeedTextBox.Location = new System.Drawing.Point(35, 31);
            this.USSpeedTextBox.Name = "USSpeedTextBox";
            this.USSpeedTextBox.Size = new System.Drawing.Size(80, 20);
            this.USSpeedTextBox.TabIndex = 19;
            // 
            // USPriceTextBox
            // 
            this.USPriceTextBox.Location = new System.Drawing.Point(117, 31);
            this.USPriceTextBox.Name = "USPriceTextBox";
            this.USPriceTextBox.Size = new System.Drawing.Size(80, 20);
            this.USPriceTextBox.TabIndex = 18;
            // 
            // EUConfirmButton
            // 
            this.EUConfirmButton.Location = new System.Drawing.Point(164, 29);
            this.EUConfirmButton.Name = "EUConfirmButton";
            this.EUConfirmButton.Size = new System.Drawing.Size(33, 22);
            this.EUConfirmButton.TabIndex = 20;
            this.EUConfirmButton.Text = "OK";
            this.EUConfirmButton.UseVisualStyleBackColor = true;
            this.EUConfirmButton.Click += new System.EventHandler(this.EUConfirmButton_Click);
            // 
            // USConfirmButton
            // 
            this.USConfirmButton.Location = new System.Drawing.Point(1, 30);
            this.USConfirmButton.Name = "USConfirmButton";
            this.USConfirmButton.Size = new System.Drawing.Size(33, 22);
            this.USConfirmButton.TabIndex = 21;
            this.USConfirmButton.Text = "OK";
            this.USConfirmButton.UseVisualStyleBackColor = true;
            this.USConfirmButton.Click += new System.EventHandler(this.USConfirmButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.LinkButton);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(-1, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 58);
            this.panel1.TabIndex = 23;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.USPanel);
            this.panel6.Location = new System.Drawing.Point(248, -1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 58);
            this.panel6.TabIndex = 29;
            // 
            // USPanel
            // 
            this.USPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.USPanel.Controls.Add(this.USPriceTextBox);
            this.USPanel.Controls.Add(this.USPriceLabel);
            this.USPanel.Controls.Add(this.USSpeedLabel);
            this.USPanel.Controls.Add(this.USConfirmButton);
            this.USPanel.Controls.Add(this.USSpeedTextBox);
            this.USPanel.Controls.Add(this.USLabel);
            this.USPanel.Location = new System.Drawing.Point(-1, -1);
            this.USPanel.Name = "USPanel";
            this.USPanel.Size = new System.Drawing.Size(200, 58);
            this.USPanel.TabIndex = 28;
            // 
            // LinkButton
            // 
            this.LinkButton.Image = global::NiceHashBot.Properties.Resources.link_icon_black1;
            this.LinkButton.Location = new System.Drawing.Point(200, 29);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(47, 23);
            this.LinkButton.TabIndex = 22;
            this.LinkButton.UseVisualStyleBackColor = true;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.EUPriceTextBox);
            this.panel5.Controls.Add(this.EULabel);
            this.panel5.Controls.Add(this.EUPriceLabel);
            this.panel5.Controls.Add(this.EUSpeedLabel);
            this.panel5.Controls.Add(this.EUSpeedTextBox);
            this.panel5.Controls.Add(this.EUConfirmButton);
            this.panel5.Location = new System.Drawing.Point(-1, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 58);
            this.panel5.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.FindOrdersLabel);
            this.panel2.Controls.Add(this.RemoveAllLabel);
            this.panel2.Controls.Add(this.RemoveAllButton);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.FindOrdersButton);
            this.panel2.Location = new System.Drawing.Point(-1, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 41);
            this.panel2.TabIndex = 24;
            // 
            // FindOrdersLabel
            // 
            this.FindOrdersLabel.AutoSize = true;
            this.FindOrdersLabel.Location = new System.Drawing.Point(33, 12);
            this.FindOrdersLabel.Name = "FindOrdersLabel";
            this.FindOrdersLabel.Size = new System.Drawing.Size(44, 13);
            this.FindOrdersLabel.TabIndex = 27;
            this.FindOrdersLabel.Text = "Refresh";
            // 
            // RemoveAllLabel
            // 
            this.RemoveAllLabel.AutoSize = true;
            this.RemoveAllLabel.Location = new System.Drawing.Point(356, 13);
            this.RemoveAllLabel.Name = "RemoveAllLabel";
            this.RemoveAllLabel.Size = new System.Drawing.Size(60, 13);
            this.RemoveAllLabel.TabIndex = 26;
            this.RemoveAllLabel.Text = "Remove all";
            // 
            // RemoveAllButton
            // 
            this.RemoveAllButton.Location = new System.Drawing.Point(415, 4);
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.Size = new System.Drawing.Size(30, 30);
            this.RemoveAllButton.TabIndex = 25;
            this.RemoveAllButton.Text = "X";
            this.RemoveAllButton.UseVisualStyleBackColor = true;
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.OvSpeedTextBox);
            this.panel4.Controls.Add(this.OvSpeedConfirmButton);
            this.panel4.Controls.Add(this.OvSpeedLabel);
            this.panel4.Location = new System.Drawing.Point(101, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(124, 30);
            this.panel4.TabIndex = 24;
            // 
            // OvSpeedTextBox
            // 
            this.OvSpeedTextBox.Location = new System.Drawing.Point(3, 4);
            this.OvSpeedTextBox.Name = "OvSpeedTextBox";
            this.OvSpeedTextBox.Size = new System.Drawing.Size(48, 20);
            this.OvSpeedTextBox.TabIndex = 23;
            // 
            // OvSpeedConfirmButton
            // 
            this.OvSpeedConfirmButton.Location = new System.Drawing.Point(52, 3);
            this.OvSpeedConfirmButton.Name = "OvSpeedConfirmButton";
            this.OvSpeedConfirmButton.Size = new System.Drawing.Size(31, 22);
            this.OvSpeedConfirmButton.TabIndex = 1;
            this.OvSpeedConfirmButton.Text = "OK";
            this.OvSpeedConfirmButton.UseVisualStyleBackColor = true;
            this.OvSpeedConfirmButton.Click += new System.EventHandler(this.OvSpeedConfirmButton_Click);
            // 
            // OvSpeedLabel
            // 
            this.OvSpeedLabel.AutoSize = true;
            this.OvSpeedLabel.Location = new System.Drawing.Point(81, 1);
            this.OvSpeedLabel.Name = "OvSpeedLabel";
            this.OvSpeedLabel.Size = new System.Drawing.Size(40, 26);
            this.OvSpeedLabel.TabIndex = 0;
            this.OvSpeedLabel.Text = "Overall\r\nspeed";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.OvPriceTextBox);
            this.panel3.Controls.Add(this.OvPriceConfirmButton);
            this.panel3.Controls.Add(this.OvPriceLabel);
            this.panel3.Location = new System.Drawing.Point(224, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(124, 30);
            this.panel3.TabIndex = 2;
            // 
            // OvPriceTextBox
            // 
            this.OvPriceTextBox.Location = new System.Drawing.Point(3, 4);
            this.OvPriceTextBox.Name = "OvPriceTextBox";
            this.OvPriceTextBox.Size = new System.Drawing.Size(48, 20);
            this.OvPriceTextBox.TabIndex = 23;
            // 
            // OvPriceConfirmButton
            // 
            this.OvPriceConfirmButton.Location = new System.Drawing.Point(52, 3);
            this.OvPriceConfirmButton.Name = "OvPriceConfirmButton";
            this.OvPriceConfirmButton.Size = new System.Drawing.Size(31, 22);
            this.OvPriceConfirmButton.TabIndex = 1;
            this.OvPriceConfirmButton.Text = "OK";
            this.OvPriceConfirmButton.UseVisualStyleBackColor = true;
            this.OvPriceConfirmButton.Click += new System.EventHandler(this.OvPriceConfirmButton_ClickAsync);
            // 
            // OvPriceLabel
            // 
            this.OvPriceLabel.AutoSize = true;
            this.OvPriceLabel.Location = new System.Drawing.Point(82, 2);
            this.OvPriceLabel.Name = "OvPriceLabel";
            this.OvPriceLabel.Size = new System.Drawing.Size(40, 26);
            this.OvPriceLabel.TabIndex = 0;
            this.OvPriceLabel.Text = "Overall\r\nprice";
            // 
            // FindOrdersButton
            // 
            this.FindOrdersButton.Image = global::NiceHashBot.Properties.Resources.baseline_refresh_black_48dp;
            this.FindOrdersButton.Location = new System.Drawing.Point(3, 5);
            this.FindOrdersButton.Name = "FindOrdersButton";
            this.FindOrdersButton.Size = new System.Drawing.Size(30, 30);
            this.FindOrdersButton.TabIndex = 1;
            this.FindOrdersButton.UseVisualStyleBackColor = true;
            this.FindOrdersButton.Click += new System.EventHandler(this.FindOrdersButton_Click);
            // 
            // OnTopCheckBox
            // 
            this.OnTopCheckBox.AutoSize = true;
            this.OnTopCheckBox.Location = new System.Drawing.Point(383, 9);
            this.OnTopCheckBox.Name = "OnTopCheckBox";
            this.OnTopCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OnTopCheckBox.Size = new System.Drawing.Size(58, 17);
            this.OnTopCheckBox.TabIndex = 27;
            this.OnTopCheckBox.Text = "On top";
            this.OnTopCheckBox.UseVisualStyleBackColor = true;
            this.OnTopCheckBox.CheckedChanged += new System.EventHandler(this.OnTopCheckBox_CheckedChanged);
            // 
            // EUOrderPanel
            // 
            this.EUOrderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EUOrderPanel.Location = new System.Drawing.Point(1, 0);
            this.EUOrderPanel.Name = "EUOrderPanel";
            this.EUOrderPanel.Size = new System.Drawing.Size(200, 400);
            this.EUOrderPanel.TabIndex = 28;
            // 
            // USOrderPanel
            // 
            this.USOrderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.USOrderPanel.Location = new System.Drawing.Point(250, 0);
            this.USOrderPanel.Name = "USOrderPanel";
            this.USOrderPanel.Size = new System.Drawing.Size(200, 400);
            this.USOrderPanel.TabIndex = 29;
            // 
            // SyncOrderPanel
            // 
            this.SyncOrderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SyncOrderPanel.Location = new System.Drawing.Point(200, 0);
            this.SyncOrderPanel.Name = "SyncOrderPanel";
            this.SyncOrderPanel.Size = new System.Drawing.Size(51, 400);
            this.SyncOrderPanel.TabIndex = 30;
            // 
            // MainOrderPanel
            // 
            this.MainOrderPanel.AutoScroll = true;
            this.MainOrderPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MainOrderPanel.Controls.Add(this.USOrderPanel);
            this.MainOrderPanel.Controls.Add(this.EUOrderPanel);
            this.MainOrderPanel.Controls.Add(this.SyncOrderPanel);
            this.MainOrderPanel.Location = new System.Drawing.Point(-2, 130);
            this.MainOrderPanel.Name = "MainOrderPanel";
            this.MainOrderPanel.Size = new System.Drawing.Size(467, 401);
            this.MainOrderPanel.TabIndex = 31;
            // 
            // FormDoubleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 528);
            this.Controls.Add(this.MainOrderPanel);
            this.Controls.Add(this.OnTopCheckBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BalanceLabel);
            this.Controls.Add(this.BalanceTitleLabel);
            this.Controls.Add(this.PoolComboBox);
            this.Controls.Add(this.PoolLabel);
            this.Controls.Add(this.AlgorithmComboBox);
            this.Controls.Add(this.AlgorithmLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDoubleOrder";
            this.Text = "Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDoubleOrder_FormClosing);
            this.Load += new System.EventHandler(this.FormDoubleOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.USPanel.ResumeLayout(false);
            this.USPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.MainOrderPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AlgorithmComboBox;
        private System.Windows.Forms.Label AlgorithmLabel;
        private System.Windows.Forms.ComboBox PoolComboBox;
        private System.Windows.Forms.Label PoolLabel;
        private System.Windows.Forms.Label BalanceTitleLabel;
        private System.Windows.Forms.Label BalanceLabel;
        private System.Windows.Forms.Label EULabel;
        private System.Windows.Forms.Label USLabel;
        private System.Windows.Forms.Label EUSpeedLabel;
        private System.Windows.Forms.Label USSpeedLabel;
        private System.Windows.Forms.Label EUPriceLabel;
        private System.Windows.Forms.Label USPriceLabel;
        private System.Windows.Forms.TextBox EUSpeedTextBox;
        private System.Windows.Forms.TextBox EUPriceTextBox;
        private System.Windows.Forms.TextBox USSpeedTextBox;
        private System.Windows.Forms.TextBox USPriceTextBox;
        private System.Windows.Forms.Button EUConfirmButton;
        private System.Windows.Forms.Button USConfirmButton;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label RemoveAllLabel;
        private System.Windows.Forms.Button RemoveAllButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox OvSpeedTextBox;
        private System.Windows.Forms.Button OvSpeedConfirmButton;
        private System.Windows.Forms.Label OvSpeedLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox OvPriceTextBox;
        private System.Windows.Forms.Button OvPriceConfirmButton;
        private System.Windows.Forms.Label OvPriceLabel;
        private System.Windows.Forms.Button FindOrdersButton;
        private System.Windows.Forms.CheckBox OnTopCheckBox;
        private System.Windows.Forms.Label FindOrdersLabel;
        private System.Windows.Forms.Panel USPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel EUOrderPanel;
        private System.Windows.Forms.Panel USOrderPanel;
        private System.Windows.Forms.Panel SyncOrderPanel;
        private System.Windows.Forms.Panel MainOrderPanel;
        private System.Windows.Forms.Panel panel6;
    }
}