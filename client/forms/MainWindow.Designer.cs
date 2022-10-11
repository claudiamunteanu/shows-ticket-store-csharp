
namespace app.client.forms
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSearchShows = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dataGridViewShows = new System.Windows.Forms.DataGridView();
            this.ArtistNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableSeatsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldSeatsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridViewFilteredShows = new System.Windows.Forms.DataGridView();
            this.IdColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtistNameColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HourColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableSeatsColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelBuyerName = new System.Windows.Forms.Label();
            this.textBoxBuyerName = new System.Windows.Forms.TextBox();
            this.numericUpDownNoOfSeats = new System.Windows.Forms.NumericUpDown();
            this.labelNoOfSeats = new System.Windows.Forms.Label();
            this.labelErrors = new System.Windows.Forms.Label();
            this.btnBuyTicket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewFilteredShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownNoOfSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dateTimePicker.Location = new System.Drawing.Point(12, 335);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(240, 30);
            this.dateTimePicker.TabIndex = 1;
            // 
            // btnSearchShows
            // 
            this.btnSearchShows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnSearchShows.Location = new System.Drawing.Point(285, 335);
            this.btnSearchShows.Name = "btnSearchShows";
            this.btnSearchShows.Size = new System.Drawing.Size(145, 41);
            this.btnSearchShows.TabIndex = 2;
            this.btnSearchShows.Text = "Search shows";
            this.btnSearchShows.UseVisualStyleBackColor = true;
            this.btnSearchShows.Click += new System.EventHandler(this.btnSearchShows_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnLogout.Location = new System.Drawing.Point(1111, 331);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(115, 48);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dataGridViewShows
            // 
            this.dataGridViewShows.AllowUserToAddRows = false;
            this.dataGridViewShows.AllowUserToDeleteRows = false;
            this.dataGridViewShows.AllowUserToResizeColumns = false;
            this.dataGridViewShows.AllowUserToResizeRows = false;
            this.dataGridViewShows.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewShows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewShows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.ArtistNameColumn, this.DateTimeColumn, this.PlaceColumn, this.AvailableSeatsColumn, this.SoldSeatsColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewShows.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewShows.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewShows.Name = "dataGridViewShows";
            this.dataGridViewShows.ReadOnly = true;
            this.dataGridViewShows.RowHeadersWidth = 62;
            this.dataGridViewShows.RowTemplate.Height = 28;
            this.dataGridViewShows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShows.Size = new System.Drawing.Size(1214, 308);
            this.dataGridViewShows.TabIndex = 4;
            this.dataGridViewShows.TabStop = false;
            // 
            // ArtistNameColumn
            // 
            this.ArtistNameColumn.HeaderText = "Artist Name";
            this.ArtistNameColumn.MinimumWidth = 8;
            this.ArtistNameColumn.Name = "ArtistNameColumn";
            this.ArtistNameColumn.ReadOnly = true;
            this.ArtistNameColumn.Width = 210;
            // 
            // DateTimeColumn
            // 
            this.DateTimeColumn.HeaderText = "Date & Hour";
            this.DateTimeColumn.MinimumWidth = 8;
            this.DateTimeColumn.Name = "DateTimeColumn";
            this.DateTimeColumn.ReadOnly = true;
            this.DateTimeColumn.Width = 210;
            // 
            // PlaceColumn
            // 
            this.PlaceColumn.HeaderText = "Place";
            this.PlaceColumn.MinimumWidth = 8;
            this.PlaceColumn.Name = "PlaceColumn";
            this.PlaceColumn.ReadOnly = true;
            this.PlaceColumn.Width = 210;
            // 
            // AvailableSeatsColumn
            // 
            this.AvailableSeatsColumn.HeaderText = "Available Seats";
            this.AvailableSeatsColumn.MinimumWidth = 8;
            this.AvailableSeatsColumn.Name = "AvailableSeatsColumn";
            this.AvailableSeatsColumn.ReadOnly = true;
            this.AvailableSeatsColumn.Width = 210;
            // 
            // SoldSeatsColumn
            // 
            this.SoldSeatsColumn.HeaderText = "Sold Seats";
            this.SoldSeatsColumn.MinimumWidth = 8;
            this.SoldSeatsColumn.Name = "SoldSeatsColumn";
            this.SoldSeatsColumn.ReadOnly = true;
            this.SoldSeatsColumn.Width = 210;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelTitle.Location = new System.Drawing.Point(350, 417);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(0, 46);
            this.labelTitle.TabIndex = 7;
            // 
            // dataGridViewFilteredShows
            // 
            this.dataGridViewFilteredShows.AllowUserToAddRows = false;
            this.dataGridViewFilteredShows.AllowUserToDeleteRows = false;
            this.dataGridViewFilteredShows.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFilteredShows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFilteredShows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilteredShows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.IdColumn2, this.DateColumn2, this.ArtistNameColumn2, this.PlaceColumn2, this.HourColumn2, this.AvailableSeatsColumn2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFilteredShows.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewFilteredShows.Location = new System.Drawing.Point(12, 499);
            this.dataGridViewFilteredShows.Name = "dataGridViewFilteredShows";
            this.dataGridViewFilteredShows.ReadOnly = true;
            this.dataGridViewFilteredShows.RowHeadersWidth = 62;
            this.dataGridViewFilteredShows.RowTemplate.Height = 28;
            this.dataGridViewFilteredShows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFilteredShows.Size = new System.Drawing.Size(810, 375);
            this.dataGridViewFilteredShows.TabIndex = 0;
            this.dataGridViewFilteredShows.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFilteredShows_CellClick);
            this.dataGridViewFilteredShows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewFilteredShows_CellFormating);
            // 
            // IdColumn2
            // 
            this.IdColumn2.Frozen = true;
            this.IdColumn2.HeaderText = "Id";
            this.IdColumn2.MinimumWidth = 8;
            this.IdColumn2.Name = "IdColumn2";
            this.IdColumn2.ReadOnly = true;
            this.IdColumn2.Visible = false;
            this.IdColumn2.Width = 8;
            // 
            // DateColumn2
            // 
            this.DateColumn2.Frozen = true;
            this.DateColumn2.HeaderText = "Date";
            this.DateColumn2.MinimumWidth = 8;
            this.DateColumn2.Name = "DateColumn2";
            this.DateColumn2.ReadOnly = true;
            this.DateColumn2.Width = 155;
            // 
            // ArtistNameColumn2
            // 
            this.ArtistNameColumn2.HeaderText = "Artist Name";
            this.ArtistNameColumn2.MinimumWidth = 8;
            this.ArtistNameColumn2.Name = "ArtistNameColumn2";
            this.ArtistNameColumn2.ReadOnly = true;
            this.ArtistNameColumn2.Width = 155;
            // 
            // PlaceColumn2
            // 
            this.PlaceColumn2.HeaderText = "Place";
            this.PlaceColumn2.MinimumWidth = 8;
            this.PlaceColumn2.Name = "PlaceColumn2";
            this.PlaceColumn2.ReadOnly = true;
            this.PlaceColumn2.Width = 155;
            // 
            // HourColumn2
            // 
            this.HourColumn2.HeaderText = "Hour";
            this.HourColumn2.MinimumWidth = 8;
            this.HourColumn2.Name = "HourColumn2";
            this.HourColumn2.ReadOnly = true;
            this.HourColumn2.Width = 155;
            // 
            // AvailableSeatsColumn2
            // 
            this.AvailableSeatsColumn2.HeaderText = "Available Seats";
            this.AvailableSeatsColumn2.MinimumWidth = 8;
            this.AvailableSeatsColumn2.Name = "AvailableSeatsColumn2";
            this.AvailableSeatsColumn2.ReadOnly = true;
            this.AvailableSeatsColumn2.Width = 155;
            // 
            // labelBuyerName
            // 
            this.labelBuyerName.AutoSize = true;
            this.labelBuyerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelBuyerName.Location = new System.Drawing.Point(828, 567);
            this.labelBuyerName.Name = "labelBuyerName";
            this.labelBuyerName.Size = new System.Drawing.Size(146, 29);
            this.labelBuyerName.TabIndex = 2;
            this.labelBuyerName.Text = "Buyer Name";
            // 
            // textBoxBuyerName
            // 
            this.textBoxBuyerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxBuyerName.Location = new System.Drawing.Point(992, 564);
            this.textBoxBuyerName.Name = "textBoxBuyerName";
            this.textBoxBuyerName.Size = new System.Drawing.Size(234, 35);
            this.textBoxBuyerName.TabIndex = 1;
            // 
            // numericUpDownNoOfSeats
            // 
            this.numericUpDownNoOfSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.numericUpDownNoOfSeats.Location = new System.Drawing.Point(1040, 653);
            this.numericUpDownNoOfSeats.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numericUpDownNoOfSeats.Name = "numericUpDownNoOfSeats";
            this.numericUpDownNoOfSeats.Size = new System.Drawing.Size(141, 30);
            this.numericUpDownNoOfSeats.TabIndex = 3;
            this.numericUpDownNoOfSeats.Value = new decimal(new int[] {1, 0, 0, 0});
            // 
            // labelNoOfSeats
            // 
            this.labelNoOfSeats.AutoSize = true;
            this.labelNoOfSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelNoOfSeats.Location = new System.Drawing.Point(828, 652);
            this.labelNoOfSeats.Name = "labelNoOfSeats";
            this.labelNoOfSeats.Size = new System.Drawing.Size(149, 29);
            this.labelNoOfSeats.TabIndex = 4;
            this.labelNoOfSeats.Text = "No. Of Seats";
            // 
            // labelErrors
            // 
            this.labelErrors.AutoSize = true;
            this.labelErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelErrors.Location = new System.Drawing.Point(828, 724);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(0, 25);
            this.labelErrors.TabIndex = 8;
            // 
            // btnBuyTicket
            // 
            this.btnBuyTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnBuyTicket.Location = new System.Drawing.Point(963, 779);
            this.btnBuyTicket.Name = "btnBuyTicket";
            this.btnBuyTicket.Size = new System.Drawing.Size(138, 56);
            this.btnBuyTicket.TabIndex = 5;
            this.btnBuyTicket.Text = "Buy Ticket";
            this.btnBuyTicket.UseVisualStyleBackColor = true;
            this.btnBuyTicket.Click += new System.EventHandler(this.btnBuyTicket_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1238, 894);
            this.Controls.Add(this.labelErrors);
            this.Controls.Add(this.btnBuyTicket);
            this.Controls.Add(this.dataGridViewShows);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.labelNoOfSeats);
            this.Controls.Add(this.btnSearchShows);
            this.Controls.Add(this.numericUpDownNoOfSeats);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBoxBuyerName);
            this.Controls.Add(this.labelBuyerName);
            this.Controls.Add(this.dataGridViewFilteredShows);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewFilteredShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownNoOfSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnSearchShows;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dataGridViewShows;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableSeatsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldSeatsColumn;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridViewFilteredShows;
        private System.Windows.Forms.Label labelBuyerName;
        private System.Windows.Forms.TextBox textBoxBuyerName;
        private System.Windows.Forms.NumericUpDown numericUpDownNoOfSeats;
        private System.Windows.Forms.Label labelNoOfSeats;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.Button btnBuyTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistNameColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HourColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableSeatsColumn2;
    }
}