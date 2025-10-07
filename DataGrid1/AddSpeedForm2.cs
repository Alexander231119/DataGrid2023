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
    public partial class AddSpeedForm2 : Form
    {
        public SpeedRestriction spd => new SpeedRestriction(0, 0, 0);
        public AddSpeedForm2(SpeedRestriction spdin)
        {
            InitializeComponent();

            tbKMStart.Text = spdin.Start.PointOnTrackKm.ToString();
            tbPkStart.Text = spdin.Start.PointOnTrackPk.ToString();
        }

        private void AddSpeedForm2_Shown(object sender, EventArgs e)
        {
            tbKMStart.Focus();
        }

        private void tbKMStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) 
            {
                var control = (Control)sender;
                var position = tlpCommon.GetPositionFromControl(control);


                var newpoistion = position.Column + (e.KeyCode == Keys.Right ? 1 : -1);
                if (newpoistion < 0) newpoistion = tlpCommon.ColumnCount - 1;
                if (newpoistion == tlpCommon.ColumnCount) newpoistion = 0;

                var newControl = tlpCommon.GetControlFromPosition(newpoistion, 1);
                if (newControl != null) 
                {
                    newControl.Focus();
                    if (newControl is TextBox tb) tb.SelectAll();
                }
            }
        }
    }
}
