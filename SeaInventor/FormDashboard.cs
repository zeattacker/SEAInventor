using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaInventor
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdd fa = new FormAdd();
            fa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormEdit fe = new FormEdit();
            fe.Show();
        }
    }
}
