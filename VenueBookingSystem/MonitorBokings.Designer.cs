namespace VenueBookingSystem
{
    partial class MonitorBokings
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMinCapacity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMaxCapacity = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvPastBookings = new System.Windows.Forms.DataGridView();
            this.dgvActiveBookings = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGenerateReports = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVenueName = new System.Windows.Forms.TextBox();
            this.cmbSearchFilters = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewBookings = new System.Windows.Forms.Button();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveBookings)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(433, -6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monitor Bookings";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(173, 102);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(230, 26);
            this.dtpStartDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(597, 103);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(217, 26);
            this.dtpEndDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Min Capacity";
            // 
            // nudMinCapacity
            // 
            this.nudMinCapacity.Location = new System.Drawing.Point(173, 143);
            this.nudMinCapacity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMinCapacity.Name = "nudMinCapacity";
            this.nudMinCapacity.Size = new System.Drawing.Size(230, 26);
            this.nudMinCapacity.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Max Capacity";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(596, 61);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(218, 26);
            this.txtUserID.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "to";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "to";
            // 
            // nudMaxCapacity
            // 
            this.nudMaxCapacity.Location = new System.Drawing.Point(596, 147);
            this.nudMaxCapacity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMaxCapacity.Name = "nudMaxCapacity";
            this.nudMaxCapacity.Size = new System.Drawing.Size(218, 26);
            this.nudMaxCapacity.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(487, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "User ID";
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(173, 194);
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(230, 26);
            this.nudDuration.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Duration";
            // 
            // dgvPastBookings
            // 
            this.dgvPastBookings.AllowUserToAddRows = false;
            this.dgvPastBookings.AllowUserToDeleteRows = false;
            this.dgvPastBookings.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvPastBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPastBookings.Location = new System.Drawing.Point(-2, 588);
            this.dgvPastBookings.Name = "dgvPastBookings";
            this.dgvPastBookings.ReadOnly = true;
            this.dgvPastBookings.RowHeadersWidth = 62;
            this.dgvPastBookings.RowTemplate.Height = 28;
            this.dgvPastBookings.Size = new System.Drawing.Size(1262, 220);
            this.dgvPastBookings.TabIndex = 15;
            // 
            // dgvActiveBookings
            // 
            this.dgvActiveBookings.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvActiveBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveBookings.Location = new System.Drawing.Point(-2, 270);
            this.dgvActiveBookings.Name = "dgvActiveBookings";
            this.dgvActiveBookings.RowHeadersWidth = 62;
            this.dgvActiveBookings.RowTemplate.Height = 28;
            this.dgvActiveBookings.Size = new System.Drawing.Size(1262, 287);
            this.dgvActiveBookings.TabIndex = 16;
            this.dgvActiveBookings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActiveBookings_CellContentClick);
//            this.dgvActiveBookings.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvActiveBookings_CellMouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 560);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "Past Booking(s)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 25);
            this.label11.TabIndex = 18;
            this.label11.Text = "Active Booking(s)";
            // 
            // btnGenerateReports
            // 
            this.btnGenerateReports.Location = new System.Drawing.Point(919, 95);
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.Size = new System.Drawing.Size(144, 54);
            this.btnGenerateReports.TabIndex = 19;
            this.btnGenerateReports.Text = "Go To Generate Reports";
            this.btnGenerateReports.UseVisualStyleBackColor = true;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(919, 155);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(138, 48);
            this.btnMainMenu.TabIndex = 20;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(475, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Venue Name";
            // 
            // txtVenueName
            // 
            this.txtVenueName.Location = new System.Drawing.Point(597, 200);
            this.txtVenueName.Name = "txtVenueName";
            this.txtVenueName.Size = new System.Drawing.Size(217, 26);
            this.txtVenueName.TabIndex = 22;
            // 
            // cmbSearchFilters
            // 
            this.cmbSearchFilters.FormattingEnabled = true;
            this.cmbSearchFilters.Items.AddRange(new object[] {
            "Date",
            "Capacity",
            "Duration",
            "User ID",
            "Venue Name"});
            this.cmbSearchFilters.Location = new System.Drawing.Point(173, 53);
            this.cmbSearchFilters.Name = "cmbSearchFilters";
            this.cmbSearchFilters.Size = new System.Drawing.Size(230, 28);
            this.cmbSearchFilters.TabIndex = 23;
            this.cmbSearchFilters.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Search By:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.dToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 68);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(142, 32);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(142, 32);
            this.dToolStripMenuItem.Text = "Delete";
            this.dToolStripMenuItem.Click += new System.EventHandler(this.dToolStripMenuItem_Click);
            // 
            // btnViewBookings
            // 
            this.btnViewBookings.Location = new System.Drawing.Point(919, 208);
            this.btnViewBookings.Name = "btnViewBookings";
            this.btnViewBookings.Size = new System.Drawing.Size(138, 56);
            this.btnViewBookings.TabIndex = 25;
            this.btnViewBookings.Text = "View Bookings";
            this.btnViewBookings.UseVisualStyleBackColor = true;
            this.btnViewBookings.Click += new System.EventHandler(this.btnViewBookings_Click);
            // 
            // cmbUserType
            // 
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] {
            "Student",
            "Lecturer"});
            this.cmbUserType.Location = new System.Drawing.Point(920, 61);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(138, 28);
            this.cmbUserType.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(844, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "UserTpe";
            // 
            // MonitorBokings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 805);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbUserType);
            this.Controls.Add(this.btnViewBookings);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbSearchFilters);
            this.Controls.Add(this.txtVenueName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnGenerateReports);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvActiveBookings);
            this.Controls.Add(this.dgvPastBookings);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudDuration);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudMaxCapacity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudMinCapacity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label1);
            this.Name = "MonitorBokings";
            this.Text = "MonitorBokings";
            this.Load += new System.EventHandler(this.MonitorBokings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveBookings)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMinCapacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudMaxCapacity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvPastBookings;
        private System.Windows.Forms.DataGridView dgvActiveBookings;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGenerateReports;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVenueName;
        private System.Windows.Forms.ComboBox cmbSearchFilters;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.Button btnViewBookings;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Label label14;
    }
}