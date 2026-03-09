using DH_Visualizer_v2.Controller;
using DH_Visualizer_v2.Modal;
//using static DH_Visualizer_v2.RobotVisualizerControl;check if this and below lines can be used interchangeble
using DH_Visualizer_v2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DH_Visualizer_v2
{
    public partial class Form1 : Form, IRobotView

    {

        public event EventHandler UpdateRequested;
        
        private RobotVisualizerControl visualize;
        public Form1()
        {
            InitializeComponent();
            visualize =new RobotVisualizerControl();
            elementHost1.Child = visualize;
            

        }



        public void PopulateGrid(List<DHParameter> parameters) {
            DH_Parameter_Grid.Rows.Clear();
            foreach (var p in parameters)
            {
                DH_Parameter_Grid.Rows.Add(p.Theta, p.LinkOffset, p.LinkLength, p.Alpha, p.Jointype.ToString());
            }
        }
        public void UpdateVisualization(List<DHParameter> parameters) {
            visualize.VisualizeRobot(parameters);
        }
        public void ShowError(string message) {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        public List<DHParameter> GetParametersFromGrid(bool animated)
        { var List = new List<DHParameter>();
            foreach (DataGridViewRow row in DH_Parameter_Grid.Rows)
            { if (row.IsNewRow) continue;
            double theta = Convert.ToDouble(row.Cells[0].Value);
            double d = Convert.ToDouble(row.Cells[1].Value);
            double a =Convert.ToDouble(row.Cells[2].Value);
            double alpha=Convert.ToDouble(row.Cells[3].Value);
            string type = (row.Cells[4].Value??"R").ToString();
            jointType Joint_type = type.Equals("R", StringComparison.OrdinalIgnoreCase) ? jointType.R : jointType.P;

                List.Add(new DHParameter() { Theta = theta, LinkOffset = d, LinkLength = a, Alpha = alpha, Jointype = Joint_type });
            }
            return List;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateRequested?.Invoke(this, EventArgs.Empty);
        }

        private void checkBox_Grid_CheckedChanged(object sender, EventArgs e)
        {
            //ShowGrid= checkBox_Grid.Checked;
        }
    }
}
