using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid1
{
    public partial class AddSpeedForm3 : Form
    {
        public double segmentID;
        public string station;
        public SpeedRestriction spdin;
        public SpeedRestriction spd;


        public AddSpeedForm3(SpeedRestriction spdin)
        {
            this.spdin = spdin;
            InitializeComponent();

            
            //AddSpeedGridView1.Rows[0].Cells[0].Value = 0;
            SegmentIdlabel1.Text = "Segment Id: " + spdin.Start.SegmentID;
            Stationlabel2.Text = "Станция/перегон: " + spdin.Station;
            AddSpeedGridView1.Rows.Add();
            AddSpeedGridView1.Rows[0].Cells[0].Value = spdin.Start.SegmentID.ToString();
           
        }

        private void OKbutton1_Click(object sender, EventArgs e)
        {
            SaveSpdFromCells();
        }


        private void SaveSpdFromCells()
        {
            AddSpeedGridView1.EndEdit();
            PointOnTrack start1 = new PointOnTrack(spdin.Start);
            if (AddSpeedGridView1.Rows[0].Cells[0].Value != null)
                start1.SegmentID = Convert.ToDouble(AddSpeedGridView1.Rows[0].Cells[0].Value);
            if (AddSpeedGridView1.Rows[0].Cells[1].Value != null)
                start1.PointOnTrackKm = AddSpeedGridView1.Rows[0].Cells[1].Value.ToString();
            if (AddSpeedGridView1.Rows[0].Cells[2].Value != null)
                start1.PointOnTrackPk = Convert.ToDouble(AddSpeedGridView1.Rows[0].Cells[2].Value);
            if (AddSpeedGridView1.Rows[0].Cells[3].Value != null)
                start1.PointOnTrackM = Convert.ToDouble(AddSpeedGridView1.Rows[0].Cells[3].Value);
            PointOnTrack end1 = new PointOnTrack(spdin.End);
            if (AddSpeedGridView1.Rows[0].Cells[0].Value != null)
                end1.SegmentID = Convert.ToDouble(AddSpeedGridView1.Rows[0].Cells[0].Value);
            if (AddSpeedGridView1.Rows[0].Cells[4].Value != null)
                end1.PointOnTrackKm = AddSpeedGridView1.Rows[0].Cells[4].Value.ToString();
            if (AddSpeedGridView1.Rows[0].Cells[5].Value != null)
                end1.PointOnTrackPk = Convert.ToDouble(AddSpeedGridView1.Rows[0].Cells[5].Value);
            if (AddSpeedGridView1.Rows[0].Cells[6].Value != null)
                end1.PointOnTrackM = Convert.ToDouble(AddSpeedGridView1.Rows[0].Cells[6].Value);
            if (AddSpeedGridView1.Rows[0].Cells[7].Value != null)
            {
                spd = new SpeedRestriction(start1, end1, Convert.ToDouble(AddSpeedGridView1.Rows[0].Cells[7].Value));
                spd.PermRestrictionOnlyHeader = Convert.ToBoolean(AddSpeedGridView1.Rows[0].Cells[8].FormattedValue) ? 1 : 0;
                spd.PermRestrictionForEmptyTrain = Convert.ToBoolean(AddSpeedGridView1.Rows[0].Cells[9].FormattedValue) ? 1 : 0;
            }

            DialogResult = DialogResult.OK;
            Close();
        }


        public AddSpeedForm3(
            double segmentID,
            string station
            
        )
        {
            this.segmentID = segmentID;
            this.station = station;
            InitializeComponent();
            SegmentIdlabel1.Text = "Segment Id: " + segmentID.ToString();
            Stationlabel2.Text ="Станция/перегон: " + station;
            AddSpeedGridView1.Rows.Add();
            AddSpeedGridView1.Rows[0].Cells[0].Value = segmentID.ToString();
            
        }

        private void AddSpeedGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // не работает c Alt, Shift и другими нужными клавишами ((
            {
                SaveSpdFromCells();

            }
        }
    }
}
