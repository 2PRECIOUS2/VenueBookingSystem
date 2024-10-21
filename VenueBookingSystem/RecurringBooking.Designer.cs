namespace VenueBookingSystem
{
    partial class RecurringBooking
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
            this.cmbCategoryOfVenue = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudRequiredCapacity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.grpFrequencySelection = new System.Windows.Forms.GroupBox();
            this.radWeekly = new System.Windows.Forms.RadioButton();
            this.radDaily = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAvailableVenues = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.StartTime = new System.Windows.Forms.DateTimePicker();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSearchVenue = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpReccurenceDays = new System.Windows.Forms.GroupBox();
            this.radMonday = new System.Windows.Forms.RadioButton();
            this.radTuesday = new System.Windows.Forms.RadioButton();
            this.radWed = new System.Windows.Forms.RadioButton();
            this.radThur = new System.Windows.Forms.RadioButton();
            this.radFriday = new System.Windows.Forms.RadioButton();
            this.radSun = new System.Windows.Forms.RadioButton();
            this.radSat = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequiredCapacity)).BeginInit();
            this.grpFrequencySelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpReccurenceDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(149, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "MAKE A RECURRING VENUE BOOKING";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
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
            "For Tutorials"});
            this.cmbTypeOfEvent.Location = new System.Drawing.Point(301, 68);
            this.cmbTypeOfEvent.Name = "cmbTypeOfEvent";
            this.cmbTypeOfEvent.Size = new System.Drawing.Size(333, 28);
            this.cmbTypeOfEvent.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Category Of Venue";
            // 
            // cmbCategoryOfVenue
            // 
            this.cmbCategoryOfVenue.FormattingEnabled = true;
            this.cmbCategoryOfVenue.Items.AddRange(new object[] {
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
            this.cmbCategoryOfVenue.Location = new System.Drawing.Point(301, 138);
            this.cmbCategoryOfVenue.Name = "cmbCategoryOfVenue";
            this.cmbCategoryOfVenue.Size = new System.Drawing.Size(333, 28);
            this.cmbCategoryOfVenue.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(120, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Required Capacity";
            // 
            // nudRequiredCapacity
            // 
            this.nudRequiredCapacity.Location = new System.Drawing.Point(301, 193);
            this.nudRequiredCapacity.Name = "nudRequiredCapacity";
            this.nudRequiredCapacity.Size = new System.Drawing.Size(333, 26);
            this.nudRequiredCapacity.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Start Date Time";
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(301, 245);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(333, 26);
            this.dateStart.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(120, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "End Date Time";
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(301, 288);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(333, 26);
            this.dateEnd.TabIndex = 10;
            // 
            // grpFrequencySelection
            // 
            this.grpFrequencySelection.Controls.Add(this.radWeekly);
            this.grpFrequencySelection.Controls.Add(this.radDaily);
            this.grpFrequencySelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFrequencySelection.Location = new System.Drawing.Point(680, 68);
            this.grpFrequencySelection.Name = "grpFrequencySelection";
            this.grpFrequencySelection.Size = new System.Drawing.Size(275, 121);
            this.grpFrequencySelection.TabIndex = 11;
            this.grpFrequencySelection.TabStop = false;
            this.grpFrequencySelection.Text = "Frequency Selection";
            // 
            // radWeekly
            // 
            this.radWeekly.AutoSize = true;
            this.radWeekly.Location = new System.Drawing.Point(39, 74);
            this.radWeekly.Name = "radWeekly";
            this.radWeekly.Size = new System.Drawing.Size(91, 24);
            this.radWeekly.TabIndex = 1;
            this.radWeekly.TabStop = true;
            this.radWeekly.Text = "Weekly";
            this.radWeekly.UseVisualStyleBackColor = true;
            this.radWeekly.CheckedChanged += new System.EventHandler(this.radWeekly_CheckedChanged);
            // 
            // radDaily
            // 
            this.radDaily.AutoSize = true;
            this.radDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDaily.Location = new System.Drawing.Point(39, 35);
            this.radDaily.Name = "radDaily";
            this.radDaily.Size = new System.Drawing.Size(73, 24);
            this.radDaily.TabIndex = 0;
            this.radDaily.TabStop = true;
            this.radDaily.Text = "Daily";
            this.radDaily.UseVisualStyleBackColor = true;
            this.radDaily.CheckedChanged += new System.EventHandler(this.radDaily_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(134, 507);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 48);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(120, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "End Time";
            // 
            // cmbAvailableVenues
            // 
            this.cmbAvailableVenues.FormattingEnabled = true;
            this.cmbAvailableVenues.Location = new System.Drawing.Point(301, 451);
            this.cmbAvailableVenues.Name = "cmbAvailableVenues";
            this.cmbAvailableVenues.Size = new System.Drawing.Size(333, 28);
            this.cmbAvailableVenues.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(120, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Start Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(120, 459);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Venues";
            // 
            // StartTime
            // 
            this.StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTime.Location = new System.Drawing.Point(301, 345);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(333, 26);
            this.StartTime.TabIndex = 18;
            // 
            // EndTime
            // 
            this.EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTime.Location = new System.Drawing.Point(301, 399);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(333, 26);
            this.EndTime.TabIndex = 19;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(271, 509);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 48);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnSearchVenue
            // 
            this.btnSearchVenue.Location = new System.Drawing.Point(413, 509);
            this.btnSearchVenue.Name = "btnSearchVenue";
            this.btnSearchVenue.Size = new System.Drawing.Size(119, 48);
            this.btnSearchVenue.TabIndex = 21;
            this.btnSearchVenue.Text = "Search Venue";
            this.btnSearchVenue.UseVisualStyleBackColor = true;
            this.btnSearchVenue.Click += new System.EventHandler(this.btnSearchVenue_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(556, 509);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(99, 46);
            this.btnMainMenu.TabIndex = 22;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grpReccurenceDays
            // 
            this.grpReccurenceDays.Controls.Add(this.radSat);
            this.grpReccurenceDays.Controls.Add(this.radSun);
            this.grpReccurenceDays.Controls.Add(this.radFriday);
            this.grpReccurenceDays.Controls.Add(this.radThur);
            this.grpReccurenceDays.Controls.Add(this.radWed);
            this.grpReccurenceDays.Controls.Add(this.radTuesday);
            this.grpReccurenceDays.Controls.Add(this.radMonday);
            this.grpReccurenceDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReccurenceDays.Location = new System.Drawing.Point(680, 265);
            this.grpReccurenceDays.Name = "grpReccurenceDays";
            this.grpReccurenceDays.Size = new System.Drawing.Size(275, 314);
            this.grpReccurenceDays.TabIndex = 12;
            this.grpReccurenceDays.TabStop = false;
            this.grpReccurenceDays.Text = "Recurrence Days of the Week";
            // 
            // radMonday
            // 
            this.radMonday.AutoSize = true;
            this.radMonday.Location = new System.Drawing.Point(21, 23);
            this.radMonday.Name = "radMonday";
            this.radMonday.Size = new System.Drawing.Size(96, 24);
            this.radMonday.TabIndex = 0;
            this.radMonday.TabStop = true;
            this.radMonday.Text = "Monday";
            this.radMonday.UseVisualStyleBackColor = true;
            // 
            // radTuesday
            // 
            this.radTuesday.AutoSize = true;
            this.radTuesday.Location = new System.Drawing.Point(21, 65);
            this.radTuesday.Name = "radTuesday";
            this.radTuesday.Size = new System.Drawing.Size(101, 24);
            this.radTuesday.TabIndex = 1;
            this.radTuesday.TabStop = true;
            this.radTuesday.Text = "Tuesday";
            this.radTuesday.UseVisualStyleBackColor = true;
            // 
            // radWed
            // 
            this.radWed.AutoSize = true;
            this.radWed.Location = new System.Drawing.Point(21, 112);
            this.radWed.Name = "radWed";
            this.radWed.Size = new System.Drawing.Size(127, 24);
            this.radWed.TabIndex = 2;
            this.radWed.TabStop = true;
            this.radWed.Text = "Wednesday";
            this.radWed.UseVisualStyleBackColor = true;
            // 
            // radThur
            // 
            this.radThur.AutoSize = true;
            this.radThur.Location = new System.Drawing.Point(21, 151);
            this.radThur.Name = "radThur";
            this.radThur.Size = new System.Drawing.Size(107, 24);
            this.radThur.TabIndex = 3;
            this.radThur.TabStop = true;
            this.radThur.Text = "Thursday";
            this.radThur.UseVisualStyleBackColor = true;
            // 
            // radFriday
            // 
            this.radFriday.AutoSize = true;
            this.radFriday.Location = new System.Drawing.Point(21, 194);
            this.radFriday.Name = "radFriday";
            this.radFriday.Size = new System.Drawing.Size(83, 24);
            this.radFriday.TabIndex = 4;
            this.radFriday.TabStop = true;
            this.radFriday.Text = "Friday";
            this.radFriday.UseVisualStyleBackColor = true;
            // 
            // radSun
            // 
            this.radSun.AutoSize = true;
            this.radSun.Location = new System.Drawing.Point(21, 284);
            this.radSun.Name = "radSun";
            this.radSun.Size = new System.Drawing.Size(94, 24);
            this.radSun.TabIndex = 5;
            this.radSun.TabStop = true;
            this.radSun.Text = "Sunday";
            this.radSun.UseVisualStyleBackColor = true;
            // 
            // radSat
            // 
            this.radSat.AutoSize = true;
            this.radSat.Location = new System.Drawing.Point(21, 242);
            this.radSat.Name = "radSat";
            this.radSat.Size = new System.Drawing.Size(106, 24);
            this.radSat.TabIndex = 6;
            this.radSat.TabStop = true;
            this.radSat.Text = "Saturday";
            this.radSat.UseVisualStyleBackColor = true;
            // 
            // RecurringBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(967, 605);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnSearchVenue);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbAvailableVenues);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpReccurenceDays);
            this.Controls.Add(this.grpFrequencySelection);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudRequiredCapacity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCategoryOfVenue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTypeOfEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RecurringBooking";
            this.Text = "RecurringBooking";
            this.Load += new System.EventHandler(this.RecurringBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRequiredCapacity)).EndInit();
            this.grpFrequencySelection.ResumeLayout(false);
            this.grpFrequencySelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpReccurenceDays.ResumeLayout(false);
            this.grpReccurenceDays.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTypeOfEvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategoryOfVenue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudRequiredCapacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.GroupBox grpFrequencySelection;
        private System.Windows.Forms.RadioButton radWeekly;
        private System.Windows.Forms.RadioButton radDaily;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAvailableVenues;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker StartTime;
        private System.Windows.Forms.DateTimePicker EndTime;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSearchVenue;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox grpReccurenceDays;
        private System.Windows.Forms.RadioButton radSat;
        private System.Windows.Forms.RadioButton radSun;
        private System.Windows.Forms.RadioButton radFriday;
        private System.Windows.Forms.RadioButton radThur;
        private System.Windows.Forms.RadioButton radWed;
        private System.Windows.Forms.RadioButton radTuesday;
        private System.Windows.Forms.RadioButton radMonday;
    }
}