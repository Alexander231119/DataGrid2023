namespace DataGrid1
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.DefSpeedtextBox1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.speedRestrictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPointOnTrackKm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StarPointOnTrackPk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StarPointOnTrackM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndtPointOnTrackKm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndPointOnTrackPk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndPointOnTrackM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedRestrictionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1095, 642);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.DefSpeedtextBox1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(978, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 596);
            this.panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(4, 150);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.Deletebutton1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 121);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.Addbutton1_Click);
            // 
            // DefSpeedtextBox1
            // 
            this.DefSpeedtextBox1.Location = new System.Drawing.Point(4, 3);
            this.DefSpeedtextBox1.Name = "DefSpeedtextBox1";
            this.DefSpeedtextBox1.Size = new System.Drawing.Size(50, 20);
            this.DefSpeedtextBox1.TabIndex = 3;
            this.DefSpeedtextBox1.Text = "80";
            this.DefSpeedtextBox1.Visible = false;
            this.DefSpeedtextBox1.TextChanged += new System.EventHandler(this.DefSpeedtextBox1_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.TestButton3_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(3, 57);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(102, 22);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.Load_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(4, 209);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(101, 23);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Проверить";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 625);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(969, 14);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartSegment,
            this.stationDataGridViewTextBoxColumn,
            this.TrackNumber,
            this.StartPointOnTrackKm,
            this.StarPointOnTrackPk,
            this.StarPointOnTrackM,
            this.EndtPointOnTrackKm,
            this.EndPointOnTrackPk,
            this.EndPointOnTrackM,
            this.valueDataGridViewTextBoxColumn,
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn,
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.speedRestrictionBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(969, 596);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // speedRestrictionBindingSource
            // 
            this.speedRestrictionBindingSource.AllowNew = false;
            this.speedRestrictionBindingSource.DataSource = typeof(DataGrid1.SpeedRestriction);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Start";
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер пути";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // StartSegment
            // 
            this.StartSegment.DataPropertyName = "StartSegment";
            this.StartSegment.HeaderText = "Segment ID";
            this.StartSegment.Name = "StartSegment";
            this.StartSegment.Visible = false;
            // 
            // stationDataGridViewTextBoxColumn
            // 
            this.stationDataGridViewTextBoxColumn.DataPropertyName = "Station";
            this.stationDataGridViewTextBoxColumn.HeaderText = "Станция / Перегон";
            this.stationDataGridViewTextBoxColumn.Name = "stationDataGridViewTextBoxColumn";
            this.stationDataGridViewTextBoxColumn.Width = 180;
            // 
            // TrackNumber
            // 
            this.TrackNumber.DataPropertyName = "TrackNumber";
            this.TrackNumber.HeaderText = "Номер пути";
            this.TrackNumber.Name = "TrackNumber";
            this.TrackNumber.ReadOnly = true;
            this.TrackNumber.Width = 50;
            // 
            // StartPointOnTrackKm
            // 
            this.StartPointOnTrackKm.DataPropertyName = "StartPointOnTrackKm";
            this.StartPointOnTrackKm.HeaderText = "Начало КМ";
            this.StartPointOnTrackKm.Name = "StartPointOnTrackKm";
            this.StartPointOnTrackKm.Width = 70;
            // 
            // StarPointOnTrackPk
            // 
            this.StarPointOnTrackPk.DataPropertyName = "StarPointOnTrackPk";
            this.StarPointOnTrackPk.HeaderText = "Начало ПК";
            this.StarPointOnTrackPk.Name = "StarPointOnTrackPk";
            this.StarPointOnTrackPk.Width = 70;
            // 
            // StarPointOnTrackM
            // 
            this.StarPointOnTrackM.DataPropertyName = "StarPointOnTrackM";
            this.StarPointOnTrackM.HeaderText = "Начало М";
            this.StarPointOnTrackM.Name = "StarPointOnTrackM";
            this.StarPointOnTrackM.Width = 70;
            // 
            // EndtPointOnTrackKm
            // 
            this.EndtPointOnTrackKm.DataPropertyName = "EndtPointOnTrackKm";
            this.EndtPointOnTrackKm.HeaderText = "Конец КМ";
            this.EndtPointOnTrackKm.Name = "EndtPointOnTrackKm";
            this.EndtPointOnTrackKm.Width = 70;
            // 
            // EndPointOnTrackPk
            // 
            this.EndPointOnTrackPk.DataPropertyName = "EndPointOnTrackPk";
            this.EndPointOnTrackPk.HeaderText = "Конец ПК";
            this.EndPointOnTrackPk.Name = "EndPointOnTrackPk";
            this.EndPointOnTrackPk.Width = 70;
            // 
            // EndPointOnTrackM
            // 
            this.EndPointOnTrackM.DataPropertyName = "EndPointOnTrackM";
            this.EndPointOnTrackM.HeaderText = "Конец М";
            this.EndPointOnTrackM.Name = "EndPointOnTrackM";
            this.EndPointOnTrackM.Width = 70;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Скорость км/ч";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Width = 60;
            // 
            // permRestrictionOnlyHeaderDataGridViewTextBoxColumn
            // 
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn.DataPropertyName = "PermRestrictionOnlyHeader";
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn.FalseValue = "0";
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn.HeaderText = "Только головой";
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn.Name = "permRestrictionOnlyHeaderDataGridViewTextBoxColumn";
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn.TrueValue = "1";
            this.permRestrictionOnlyHeaderDataGridViewTextBoxColumn.Width = 50;
            // 
            // permRestrictionForEmptyTrainDataGridViewTextBoxColumn
            // 
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn.DataPropertyName = "PermRestrictionForEmptyTrain";
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn.FalseValue = "0";
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn.HeaderText = "для порожнего поезда";
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn.Name = "permRestrictionForEmptyTrainDataGridViewTextBoxColumn";
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn.TrueValue = "1";
            this.permRestrictionForEmptyTrainDataGridViewTextBoxColumn.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 642);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Постоянные ограничения сорости";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedRestrictionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox DefSpeedtextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.BindingSource speedRestrictionBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartPointOnTrackKm;
        private System.Windows.Forms.DataGridViewTextBoxColumn StarPointOnTrackPk;
        private System.Windows.Forms.DataGridViewTextBoxColumn StarPointOnTrackM;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndtPointOnTrackKm;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndPointOnTrackPk;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndPointOnTrackM;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn permRestrictionOnlyHeaderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn permRestrictionForEmptyTrainDataGridViewTextBoxColumn;
    }
}

