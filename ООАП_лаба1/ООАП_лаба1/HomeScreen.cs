using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООАП_лаба1
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point LastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;

            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);    
        }
        private void bFlow_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flowers FlowersForm = new Flowers();
            FlowersForm.Show();
        }

        private void bVeg_Click(object sender, EventArgs e)
        {
            this.Hide();
            veg VegForm = new veg();
            VegForm.Show();

        }
    }
}
