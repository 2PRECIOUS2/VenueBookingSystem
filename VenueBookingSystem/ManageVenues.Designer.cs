namespace VenueBookingSystem
{
    partial class ManageVenues
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
            this.txtSearchVenue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVenues = new System.Windows.Forms.ComboBox();
            this.VenueDetailsGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpdateVenue = new System.Windows.Forms.Button();
            this.btnDeleteVenue = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVenueLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbVeneuCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudVenueCapacity = new System.Windows.Forms.NumericUpDown();
            this.txtVenueName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProviderFormInput = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnMainMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VenueDetailsGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVenueCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFormInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search For Venues";
            // 
            // txtSearchVenue
            // 
            this.txtSearchVenue.Location = new System.Drawing.Point(223, 48);
            this.txtSearchVenue.Name = "txtSearchVenue";
            this.txtSearchVenue.Size = new System.Drawing.Size(349, 26);
            this.txtSearchVenue.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtSearchVenue, "Enter the Venue Name (E.g Flower Hall)");
            this.txtSearchVenue.TextChanged += new System.EventHandler(this.txtSearchVenue_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "List Of Veneus";
            // 
            // cmbVenues
            // 
            this.cmbVenues.FormattingEnabled = true;
            this.cmbVenues.Location = new System.Drawing.Point(223, 110);
            this.cmbVenues.Name = "cmbVenues";
            this.cmbVenues.Size = new System.Drawing.Size(349, 28);
            this.cmbVenues.TabIndex = 3;
            this.cmbVenues.SelectedIndexChanged += new System.EventHandler(this.cmbVenues_SelectedIndexChanged);
            // 
            // VenueDetailsGridView
            // 
            this.VenueDetailsGridView.AllowUserToAddRows = false;
            this.VenueDetailsGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VenueDetailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VenueDetailsGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VenueDetailsGridView.Location = new System.Drawing.Point(12, 166);
            this.VenueDetailsGridView.Name = "VenueDetailsGridView";
            this.VenueDetailsGridView.RowHeadersWidth = 62;
            this.VenueDetailsGridView.RowTemplate.Height = 28;
            this.VenueDetailsGridView.Size = new System.Drawing.Size(776, 112);
            this.VenueDetailsGridView.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(284, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Manage Venues";
            // 
            // btnUpdateVenue
            // 
            this.btnUpdateVenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVenue.Location = new System.Drawing.Point(37, 316);
            this.btnUpdateVenue.Name = "btnUpdateVenue";
            this.btnUpdateVenue.Size = new System.Drawing.Size(123, 54);
            this.btnUpdateVenue.TabIndex = 6;
            this.btnUpdateVenue.Text = "Update Venue";
            this.btnUpdateVenue.UseVisualStyleBackColor = true;
            this.btnUpdateVenue.Click += new System.EventHandler(this.btnUpdateVenue_Click);
            // 
            // btnDeleteVenue
            // 
            this.btnDeleteVenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteVenue.Location = new System.Drawing.Point(37, 403);
            this.btnDeleteVenue.Name = "btnDeleteVenue";
            this.btnDeleteVenue.Size = new System.Drawing.Size(123, 52);
            this.btnDeleteVenue.TabIndex = 7;
            this.btnDeleteVenue.Text = "Delete Venue";
            this.btnDeleteVenue.UseVisualStyleBackColor = true;
            this.btnDeleteVenue.Click += new System.EventHandler(this.btnDeleteVenue_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(126, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(143, 43);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVenueLocation);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbVeneuCategory);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudVenueCapacity);
            this.groupBox1.Controls.Add(this.txtVenueName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(303, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 281);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Venue";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtVenueLocation
            // 
            this.txtVenueLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenueLocation.Location = new System.Drawing.Point(214, 174);
            this.txtVenueLocation.Name = "txtVenueLocation";
            this.txtVenueLocation.Size = new System.Drawing.Size(265, 26);
            this.txtVenueLocation.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Venue Location";
            // 
            // cmbVeneuCategory
            // 
            this.cmbVeneuCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeneuCategory.FormattingEnabled = true;
            this.cmbVeneuCategory.Items.AddRange(new object[] {
            "Examination rooms ",
            "Boardrooms ",
            "Auditoriums ",
            "Lecture rooms and halls ",
            "Conference rooms ",
            "Video conference rooms ",
            "Theatres"});
            this.cmbVeneuCategory.Location = new System.Drawing.Point(213, 127);
            this.cmbVeneuCategory.Name = "cmbVeneuCategory";
            this.cmbVeneuCategory.Size = new System.Drawing.Size(266, 28);
            this.cmbVeneuCategory.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "CategoryOfVenue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Venue Capacity";
            // 
            // nudVenueCapacity
            // 
            this.nudVenueCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudVenueCapacity.Location = new System.Drawing.Point(214, 76);
            this.nudVenueCapacity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudVenueCapacity.Name = "nudVenueCapacity";
            this.nudVenueCapacity.Size = new System.Drawing.Size(265, 26);
            this.nudVenueCapacity.TabIndex = 2;
            // 
            // txtVenueName
            // 
            this.txtVenueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenueName.Location = new System.Drawing.Point(214, 25);
            this.txtVenueName.Name = "txtVenueName";
            this.txtVenueName.Size = new System.Drawing.Size(265, 26);
            this.txtVenueName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Venue Name";
            // 
            // errorProviderFormInput
            // 
            this.errorProviderFormInput.ContainerControl = this;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(37, 474);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(123, 55);
            this.btnMainMenu.TabIndex = 10;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // ManageVenues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 593);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeleteVenue);
            this.Controls.Add(this.btnUpdateVenue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VenueDetailsGridView);
            this.Controls.Add(this.cmbVenues);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchVenue);
            this.Controls.Add(this.label1);
            this.Name = "ManageVenues";
            this.Text = "ManageVenues";
            ((System.ComponentModel.ISupportInitialize)(this.VenueDetailsGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVenueCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFormInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchVenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVenues;
        private System.Windows.Forms.DataGridView VenueDetailsGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnUpdateVenue;
        private System.Windows.Forms.Button btnDeleteVenue;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbVeneuCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudVenueCapacity;
        private System.Windows.Forms.TextBox txtVenueName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVenueLocation;
        private System.Windows.Forms.ErrorProvider errorProviderFormInput;
        private System.Windows.Forms.Button btnMainMenu;
    }
}