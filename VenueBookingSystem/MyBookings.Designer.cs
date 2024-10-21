namespace VenueBookingSystem
{
    partial class MyBookings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.LblTotalBookings = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStripBooking = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.contextMenuStripBooking.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(452, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "My Bookings";
            // 
            // dgvBookings
            // 
            this.dgvBookings.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(0, 175);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.RowHeadersWidth = 62;
            this.dgvBookings.RowTemplate.Height = 28;
            this.dgvBookings.Size = new System.Drawing.Size(1224, 366);
            this.dgvBookings.TabIndex = 1;
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotal.Location = new System.Drawing.Point(12, 564);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(221, 29);
            this.LabelTotal.TabIndex = 2;
            this.LabelTotal.Text = "Total Booking(s): ";
            // 
            // LblTotalBookings
            // 
            this.LblTotalBookings.AutoSize = true;
            this.LblTotalBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalBookings.Location = new System.Drawing.Point(239, 564);
            this.LblTotalBookings.Name = "LblTotalBookings";
            this.LblTotalBookings.Size = new System.Drawing.Size(58, 29);
            this.LblTotalBookings.TabIndex = 3;
            this.LblTotalBookings.Text = "total";
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(0, 666);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(558, 51);
            this.btnHome.TabIndex = 4;
            this.btnHome.Text = "MainMenu";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(556, 666);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(535, 51);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStripBooking
            // 
            this.contextMenuStripBooking.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripBooking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUpdate,
            this.deleteToolStripMenuItem});
            this.contextMenuStripBooking.Name = "contextMenuStripBooking";
            this.contextMenuStripBooking.Size = new System.Drawing.Size(241, 101);
            // 
            // toolStripUpdate
            // 
            this.toolStripUpdate.Name = "toolStripUpdate";
            this.toolStripUpdate.Size = new System.Drawing.Size(240, 32);
            this.toolStripUpdate.Text = "Update";
            this.toolStripUpdate.Click += new System.EventHandler(this.toolStripUpdate_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MyBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 796);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.LblTotalBookings);
            this.Controls.Add(this.LabelTotal);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.label1);
            this.Name = "MyBookings";
            this.Text = "MyBookings";
            this.Load += new System.EventHandler(this.MyBookings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.contextMenuStripBooking.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.Label LblTotalBookings;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBooking;
        private System.Windows.Forms.ToolStripMenuItem toolStripUpdate;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}