namespace VenueBookingSystem
{
    partial class CreateBooking
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTypeOfEvent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.StartTime = new System.Windows.Forms.DateTimePicker();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnCheckVenue = new System.Windows.Forms.Button();
            this.BtnVeneus = new System.Windows.Forms.Label();
            this.cmbAvailableVenues = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkEquipments = new System.Windows.Forms.CheckBox();
            this.btnSearchEquipments = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(562, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Make A One-Time Venue Booking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type Of Event";
            // 
            // cmbTypeOfEvent
            // 
            this.cmbTypeOfEvent.FormattingEnabled = true;
            this.cmbTypeOfEvent.Items.AddRange(new object[] {
            "To conduct lectures ",
            "To hold society meetings ",
            "For hobbyists ",
            "For conferences or seminars ",
            "For tests/examinations ",
            "For project presentation",
            "For Church and Worship",
            "For Tutorials",
            "For Concerts"});
            this.cmbTypeOfEvent.Location = new System.Drawing.Point(304, 64);
            this.cmbTypeOfEvent.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTypeOfEvent.Name = "cmbTypeOfEvent";
            this.cmbTypeOfEvent.Size = new System.Drawing.Size(363, 30);
            this.cmbTypeOfEvent.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Category of Venue";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Examination rooms ",
            "Boardrooms ",
            "Auditoriums ",
            "Lecture rooms and halls ",
            "Conference rooms ",
            "Video conference rooms ",
            "Theatres ",
            "Sport Hall",
            "Sport Ground",
            "Stadiums"});
            this.cmbCategory.Location = new System.Drawing.Point(304, 116);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(363, 30);
            this.cmbCategory.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Capacity";
            // 
            // nudCapacity
            // 
            this.nudCapacity.Location = new System.Drawing.Point(304, 166);
            this.nudCapacity.Margin = new System.Windows.Forms.Padding(2);
            this.nudCapacity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(363, 28);
            this.nudCapacity.TabIndex = 6;
            this.nudCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 227);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Start Date";
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "2024/09/29 00:35:07";
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(304, 222);
            this.dateStart.Margin = new System.Windows.Forms.Padding(2);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(363, 28);
            this.dateStart.TabIndex = 8;
            this.dateStart.Value = new System.DateTime(2024, 9, 26, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 282);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "End Date";
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "2024/09/29 00:38:37";
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(304, 276);
            this.dateEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(363, 28);
            this.dateEnd.TabIndex = 10;
            this.dateEnd.Value = new System.DateTime(2024, 9, 29, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 342);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Start Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(115, 396);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "End Time";
            // 
            // StartTime
            // 
            this.StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTime.Location = new System.Drawing.Point(304, 337);
            this.StartTime.Margin = new System.Windows.Forms.Padding(2);
            this.StartTime.Name = "StartTime";
            this.StartTime.ShowUpDown = true;
            this.StartTime.Size = new System.Drawing.Size(363, 28);
            this.StartTime.TabIndex = 13;
            this.StartTime.Value = new System.DateTime(2024, 9, 29, 10, 35, 0, 0);
            // 
            // EndTime
            // 
            this.EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTime.Location = new System.Drawing.Point(304, 390);
            this.EndTime.Margin = new System.Windows.Forms.Padding(2);
            this.EndTime.Name = "EndTime";
            this.EndTime.ShowUpDown = true;
            this.EndTime.Size = new System.Drawing.Size(363, 28);
            this.EndTime.TabIndex = 14;
            this.EndTime.Value = new System.DateTime(2024, 9, 29, 0, 31, 0, 0);
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(757, 326);
            this.btnBook.Margin = new System.Windows.Forms.Padding(2);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(121, 54);
            this.btnBook.TabIndex = 15;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click_1);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(757, 405);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(121, 51);
            this.btnMainMenu.TabIndex = 16;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnCheckVenue
            // 
            this.btnCheckVenue.Location = new System.Drawing.Point(757, 168);
            this.btnCheckVenue.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckVenue.Name = "btnCheckVenue";
            this.btnCheckVenue.Size = new System.Drawing.Size(121, 59);
            this.btnCheckVenue.TabIndex = 17;
            this.btnCheckVenue.Text = "Search Venue";
            this.btnCheckVenue.UseVisualStyleBackColor = true;
            this.btnCheckVenue.Click += new System.EventHandler(this.btnCheckVenue_Click);
            // 
            // BtnVeneus
            // 
            this.BtnVeneus.AutoSize = true;
            this.BtnVeneus.Location = new System.Drawing.Point(115, 452);
            this.BtnVeneus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BtnVeneus.Name = "BtnVeneus";
            this.BtnVeneus.Size = new System.Drawing.Size(71, 22);
            this.BtnVeneus.TabIndex = 18;
            this.BtnVeneus.Text = "Venues";
            // 
            // cmbAvailableVenues
            // 
            this.cmbAvailableVenues.FormattingEnabled = true;
            this.cmbAvailableVenues.Location = new System.Drawing.Point(304, 449);
            this.cmbAvailableVenues.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAvailableVenues.Name = "cmbAvailableVenues";
            this.cmbAvailableVenues.Size = new System.Drawing.Size(363, 30);
            this.cmbAvailableVenues.TabIndex = 19;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(115, 505);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 22);
            this.label9.TabIndex = 20;
            this.label9.Text = "Equipments";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(304, 505);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(363, 30);
            this.comboBox1.TabIndex = 21;
            // 
            // chkEquipments
            // 
            this.chkEquipments.AutoSize = true;
            this.chkEquipments.Location = new System.Drawing.Point(305, 548);
            this.chkEquipments.Name = "chkEquipments";
            this.chkEquipments.Size = new System.Drawing.Size(362, 26);
            this.chkEquipments.TabIndex = 22;
            this.chkEquipments.Text = "Would you like to also book equipments?";
            this.chkEquipments.UseVisualStyleBackColor = true;
            // 
            // btnSearchEquipments
            // 
            this.btnSearchEquipments.Location = new System.Drawing.Point(757, 244);
            this.btnSearchEquipments.Name = "btnSearchEquipments";
            this.btnSearchEquipments.Size = new System.Drawing.Size(121, 60);
            this.btnSearchEquipments.TabIndex = 23;
            this.btnSearchEquipments.Text = "Search Equipments";
            this.btnSearchEquipments.UseVisualStyleBackColor = true;
            this.btnSearchEquipments.Click += new System.EventHandler(this.btnSearchEquipments_Click);
            // 
            // CreateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(954, 586);
            this.Controls.Add(this.btnSearchEquipments);
            this.Controls.Add(this.chkEquipments);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbAvailableVenues);
            this.Controls.Add(this.BtnVeneus);
            this.Controls.Add(this.btnCheckVenue);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudCapacity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTypeOfEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateBooking";
            this.Text = "CreateBooking";
            this.Load += new System.EventHandler(this.CreateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTypeOfEvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker StartTime;
        private System.Windows.Forms.DateTimePicker EndTime;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnCheckVenue;
        private System.Windows.Forms.Label BtnVeneus;
        private System.Windows.Forms.ComboBox cmbAvailableVenues;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearchEquipments;
        private System.Windows.Forms.CheckBox chkEquipments;
    }
}