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
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }

        private void get_lantai(string strQuery)
        { 
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rama Zeta\Documents\SEAInventaris.accdb;Persist Security Info=True;";
            OleDbConnection conDB = new OleDbConnection(constring);
            OleDbCommand cmDB = new OleDbCommand(strQuery,conDB);
            OleDbDataAdapter daDB = new OleDbDataAdapter(cmDB);
            conDB.Open();
            cmDB.CommandType = CommandType.Text;
            DataTable dtbl = new DataTable();
            daDB.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 25;
            dataGridView1.Columns[1].HeaderText = "Lantai";
            dataGridView1.Columns[1].Width = 75;

            DataGridViewButtonColumn hapusLantai = new DataGridViewButtonColumn();
            hapusLantai.HeaderText = "Hapus Lantai";
            hapusLantai.Text = "Hapus";
            hapusLantai.UseColumnTextForButtonValue = true;
            hapusLantai.Width = 70;
            dataGridView1.Columns.Add(hapusLantai);
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            get_lantai("SELECT * FROM lantai");
        }
    }
}
