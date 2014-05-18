using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SeaInventor
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rama Zeta\Documents\SEAInventaris.accdb;Persist Security Info=True;";
                OleDbConnection conDB = new OleDbConnection(constring);
                OleDbCommand cmdDB = new OleDbCommand("SELECT * FROM admin WHERE username = '" + textBox1.Text + "' AND PASSWORD = '" + textBox2.Text + "'",conDB);
                OleDbDataReader rdrDB;

                conDB.Open();

                rdrDB = cmdDB.ExecuteReader();
                int count = 0;
                while (rdrDB.Read())
                {
                    count += 1;

                }
                if (count == 1)
                {
                    MessageBox.Show("Login Success Bro");
                    FormDashboard dashb = new FormDashboard();
                    dashb.Show();
                    this.Hide();
                    conDB.Close();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Login gagal cok");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
