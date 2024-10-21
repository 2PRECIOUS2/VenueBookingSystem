namespace VenueBookingSystem
{
    partial class UpdateBooking
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTypeOfEvent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCategoryOfVenue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbVenues = new System.Windows.Forms.ComboBox();
            this.btnSelectVenue = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVenueID = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblVenueName = new System.Windows.Forms.Label();
            this.lblVC = new System.Windows.Forms.Label();
            this.lBLVenueCapacity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVenueLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update Booking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type Of Event";
            // 
            // lblTypeOfEvent
            // 
            this.lblTypeOfEvent.AutoSize = true;
            this.lblTypeOfEvent.Location = new System.Drawing.Point(200, 90);
            this.lblTypeOfEvent.Name = "lblTypeOfEvent";
            this.lblTypeOfEvent.Size = new System.Drawing.Size(88, 20);
            this.lblTypeOfEvent.TabIndex = 2;
            this.lblTypeOfEvent.Text = "Event Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Category Of Venue";
            // 
            // lblCategoryOfVenue
            // 
            this.lblCategoryOfVenue.AutoSize = true;
            this.lblCategoryOfVenue.Location = new System.Drawing.Point(200, 138);
            this.lblCategoryOfVenue.Name = "lblCategoryOfVenue";
            this.lblCategoryOfVenue.Size = new System.Drawing.Size(94, 20);
            this.lblCategoryOfVenue.TabIndex = 4;
            this.lblCategoryOfVenue.Text = "Venue Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Start Date Time";
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(181, 199);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(397, 26);
            this.dateTimeStart.TabIndex = 6;
            this.dateTimeStart.Value = new System.DateTime(2024, 10, 9, 22, 25, 33, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "End Date Time";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(181, 260);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(397, 26);
            this.dateTimeEnd.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Capacity";
            // 
            // nudCapacity
            // 
            this.nudCapacity.Location = new System.Drawing.Point(181, 314);
            this.nudCapacity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(397, 26);
            this.nudCapacity.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Venues";
            // 
            // cmbVenues
            // 
            this.cmbVenues.FormattingEnabled = true;
            this.cmbVenues.Location = new System.Drawing.Point(181, 358);
            this.cmbVenues.Name = "cmbVenues";
            this.cmbVenues.Size = new System.Drawing.Size(397, 28);
            this.cmbVenues.TabIndex = 12;
            // 
            // btnSelectVenue
            // 
            this.btnSelectVenue.BackColor = System.Drawing.SystemColors.Window;
            this.btnSelectVenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectVenue.Location = new System.Drawing.Point(349, 414);
            this.btnSelectVenue.Name = "btnSelectVenue";
            this.btnSelectVenue.Size = new System.Drawing.Size(449, 53);
            this.btnSelectVenue.TabIndex = 13;
            this.btnSelectVenue.Text = "Search Other  Venues";
            this.btnSelectVenue.UseVisualStyleBackColor = false;
            this.btnSelectVenue.Click += new System.EventHandler(this.btnSelectVenue_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdate.Location = new System.Drawing.Point(-1, 414);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(351, 53);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Venue ID";
            // 
            // lblVenueID
            // 
            this.lblVenueID.AutoSize = true;
            this.lblVenueID.Location = new System.Drawing.Point(200, 51);
            this.lblVenueID.Name = "lblVenueID";
            this.lblVenueID.Size = new System.Drawing.Size(26, 20);
            this.lblVenueID.TabIndex = 16;
            this.lblVenueID.Text = "ID";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblV.Location = new System.Drawing.Point(404, 61);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(112, 20);
            this.lblV.TabIndex = 17;
            this.lblV.Text = "Venue Name";
            // 
            // lblVenueName
            // 
            this.lblVenueName.AutoSize = true;
            this.lblVenueName.Location = new System.Drawing.Point(604, 61);
            this.lblVenueName.Name = "lblVenueName";
            this.lblVenueName.Size = new System.Drawing.Size(49, 20);
            this.lblVenueName.TabIndex = 18;
            this.lblVenueName.Text = "name";
            // 
            // lblVC
            // 
            this.lblVC.AutoSize = true;
            this.lblVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVC.Location = new System.Drawing.Point(404, 99);
            this.lblVC.Name = "lblVC";
            this.lblVC.Size = new System.Drawing.Size(135, 20);
            this.lblVC.TabIndex = 19;
            this.lblVC.Text = "Venue Capacity";
            // 
            // lBLVenueCapacity
            // 
            this.lBLVenueCapacity.AutoSize = true;
            this.lBLVenueCapacity.Location = new System.Drawing.Point(614, 99);
            this.lBLVenueCapacity.Name = "lBLVenueCapacity";
            this.lBLVenueCapacity.Size = new System.Drawing.Size(18, 20);
            this.lBLVenueCapacity.TabIndex = 21;
            this.lBLVenueCapacity.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(404, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Venue Location";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblVenueLocation
            // 
            this.lblVenueLocation.AutoSize = true;
            this.lblVenueLocation.Location = new System.Drawing.Point(604, 138);
            this.lblVenueLocation.Name = "lblVenueLocation";
            this.lblVenueLocation.Size = new System.Drawing.Size(70, 20);
            this.lblVenueLocation.TabIndex = 23;
            this.lblVenueLocation.Text = "Location";
            // 
            // UpdateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.lblVenueLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lBLVenueCapacity);
            this.Controls.Add(this.lblVC);
            this.Controls.Add(this.lblVenueName);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.lblVenueID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSelectVenue);
            this.Controls.Add(this.cmbVenues);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudCapacity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCategoryOfVenue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTypeOfEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateBooking";
            this.Text = "UpdateBooking";
            this.Load += new System.EventHandler(this.UpdateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTypeOfEvent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCategoryOfVenue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbVenues;
        private System.Windows.Forms.Button btnSelectVenue;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVenueID;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblVenueName;
        private System.Windows.Forms.Label lblVC;
        private System.Windows.Forms.Label lBLVenueCapacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVenueLocation;
    }
}