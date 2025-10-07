namespace DataGrid1
{
    partial class AddSpeedForm3
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddSpeedGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SegmentIdlabel1 = new System.Windows.Forms.Label();
            this.Stationlabel2 = new System.Windows.Forms.Label();
            this.OKbutton1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddSpeedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.07692F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.92308F));
            this.tableLayoutPanel1.Controls.Add(this.AddSpeedGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SegmentIdlabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Stationlabel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OKbutton1, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.05263F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.94737F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 190);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // AddSpeedGridView1
            // 
            this.AddSpeedGridView1.AllowUserToAddRows = false;
            this.AddSpeedGridView1.AllowUserToDeleteRows = false;
            this.AddSpeedGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddSpeedGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.AddSpeedGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddSpeedGridView1.Location = new System.Drawing.Point(3, 95);
            this.AddSpeedGridView1.Name = "AddSpeedGridView1";
            this.AddSpeedGridView1.Size = new System.Drawing.Size(602, 92);
            this.AddSpeedGridView1.TabIndex = 0;
            this.AddSpeedGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSpeedGridView1_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SegmentID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Км нач";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ПК нач";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "М нач";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Км кон";
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ПК кон";
            this.Column6.Name = "Column6";
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "М кон";
            this.Column7.Name = "Column7";
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "V (км/ч)";
            this.Column8.Name = "Column8";
            this.Column8.Width = 50;
            // 
            // Column9
            // 
            this.Column9.FalseValue = "0";
            this.Column9.HeaderText = "только головой";
            this.Column9.Name = "Column9";
            this.Column9.TrueValue = "-1";
            this.Column9.Width = 65;
            // 
            // Column10
            // 
            this.Column10.FalseValue = "0";
            this.Column10.HeaderText = "для порожнего поезда";
            this.Column10.Name = "Column10";
            this.Column10.TrueValue = "-1";
            this.Column10.Width = 65;
            // 
            // SegmentIdlabel1
            // 
            this.SegmentIdlabel1.AutoSize = true;
            this.SegmentIdlabel1.Location = new System.Drawing.Point(3, 48);
            this.SegmentIdlabel1.Name = "SegmentIdlabel1";
            this.SegmentIdlabel1.Size = new System.Drawing.Size(35, 13);
            this.SegmentIdlabel1.TabIndex = 1;
            this.SegmentIdlabel1.Text = "label1";
            // 
            // Stationlabel2
            // 
            this.Stationlabel2.AutoSize = true;
            this.Stationlabel2.Location = new System.Drawing.Point(3, 0);
            this.Stationlabel2.Name = "Stationlabel2";
            this.Stationlabel2.Size = new System.Drawing.Size(0, 13);
            this.Stationlabel2.TabIndex = 2;
            // 
            // OKbutton1
            // 
            this.OKbutton1.Location = new System.Drawing.Point(611, 95);
            this.OKbutton1.Name = "OKbutton1";
            this.OKbutton1.Size = new System.Drawing.Size(112, 48);
            this.OKbutton1.TabIndex = 3;
            this.OKbutton1.Text = "OK";
            this.OKbutton1.UseVisualStyleBackColor = true;
            this.OKbutton1.Click += new System.EventHandler(this.OKbutton1_Click);
            // 
            // AddSpeedForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 214);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddSpeedForm3";
            this.Text = "Добавить ограничение скорости";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddSpeedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView AddSpeedGridView1;
        private System.Windows.Forms.Label SegmentIdlabel1;
        private System.Windows.Forms.Label Stationlabel2;
        private System.Windows.Forms.Button OKbutton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
    }
}