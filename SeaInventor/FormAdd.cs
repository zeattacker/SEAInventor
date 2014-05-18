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
using System.IO;

namespace SeaInventor
{
    public partial class FormAdd : Form
    {
        List<string> _items = new List<string>();
        OpenFileDialog OpenFD = new OpenFileDialog();
        public string pathImg = "";

        public FormAdd()
        {
            InitializeComponent();
            ListLantaiB();
            ListRuang();
            ListLantai();
        }

        private void ListLantaiB()
        {
            try
            {
                string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rama Zeta\Documents\SEAInventaris.accdb;Persist Security Info=True;";
                OleDbConnection conDB = new OleDbConnection(constring);
                conDB.Open();
                OleDbDataReader rdrDB = null;
                OleDbCommand cmdDB = new OleDbCommand("SELECT * FROM lantai", conDB);
                rdrDB = cmdDB.ExecuteReader();

                while (rdrDB.Read())
                {
                    _items.Add(rdrDB["nama"].ToString());
                }

                listBox1.DataSource = _items;
                conDB.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void ListLantai()
        {
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rama Zeta\Documents\SEAInventaris.accdb;Persist Security Info=True;";
            OleDbConnection conDB = new OleDbConnection(constring);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                conDB.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM lantai", conDB);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                adapter.Dispose();
                cmd.Dispose();
                idLantai.DataSource = ds.Tables[0];
                idLantai.ValueMember = "ID";
                idLantai.DisplayMember = "nama";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void ListRuang()
        {
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rama Zeta\Documents\SEAInventaris.accdb;Persist Security Info=True;";
            OleDbConnection conDB = new OleDbConnection(constring);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                conDB.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM ruangan", conDB);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                adapter.Dispose();
                cmd.Dispose();
                idRuangan.DataSource = ds.Tables[0];
                idRuangan.ValueMember = "ID";
                idRuangan.DisplayMember = "ruangan";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rama Zeta\Documents\SEAInventaris.accdb;Persist Security Info=True;";
                OleDbConnection conDB = new OleDbConnection(constring);
                OleDbCommand cmdDB = new OleDbCommand("INSERT INTO lantai (nama) VALUES ('" + textBox1.Text + "')",conDB);
                conDB.Open();

                if (conDB.State == ConnectionState.Open)
                {
                    cmdDB.ExecuteNonQuery();
                    MessageBox.Show("Lantai berhasil ditambahkan");
                    conDB.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rama Zeta\Documents\SEAInventaris.accdb;Persist Security Info=True;";
                OleDbConnection conDB = new OleDbConnection(constring);
                OleDbCommand cmdDB = new OleDbCommand("INSERT INTO ruangan (ruangan,jml_barang,id_lantai) VALUES ('" + textBox2.Text + "',0," + (listBox1.SelectedIndex + 1) + ")", conDB);
                conDB.Open();
                
                if (conDB.State == ConnectionState.Open)
                {
                    cmdDB.ExecuteNonQuery();
                    MessageBox.Show("Ruangan berhasil ditambahkan");
                    conDB.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void addBrng_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBarang_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(pathImg);
                FileStream fs = new FileStream(pathImg, FileMode.Open, FileAccess.Read);
                byte[] bimage = new byte[fs.Length];
                fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rama Zeta\Documents\SEAInventaris.accdb;Persist Security Info=True;";
                OleDbConnection conDB = new OleDbConnection(constring);
                OleDbCommand cmdDB = new OleDbCommand("INSERT INTO barang (NO_SPPA,KD_ASET,NO_ASET,TGL_PERLH,TGL_BUKU,NO_BUKTI,JUMLAH,NPS,NAMA_ASET,ASAL_PEROLEH,TOTAL_RUPIAH,TGL_SPD,TERCATAT,KONDISI,NO_SPD,JNS_BLJ,MERK,DASAR_HARGA,RPH_SPM,ID_RUANG,ID_LANTAI,IMAGES) VALUES ('" + noSppa.Text + "'," + kdAset.Text + ",'" + noAset.Text + "','" + tglPerlh.Text + "','" + tglBuku.Text + "','" + noBukti.Text + "'," + jmlh.Text + ",'" + hargaSatuan.Text + "','" + namaAset.Text + "','" + asalPeroleh.Text + "','" + totalRupiah.Text + "','" + tglSpd.Text + "','" + tercatat.Text + "','" + kondisi.Text + "','" + noS2pd.Text + "'," + jenisBlj.Text + ",'" + merk.Text + "','" + dasarHarga.Text + "','" + rphSpm.Text + "'," + idRuangan.SelectedValue + "," + idLantai.SelectedValue + ",'@imgdata')", conDB);
                cmdDB.Parameters.AddWithValue("@imgdata"
                conDB.Open();

                if (conDB.State == ConnectionState.Open)
                {
                    cmdDB.ExecuteNonQuery();
                    MessageBox.Show("Barang berhasil ditambahkan");
                    conDB.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFD.Filter = "Images only. |*.jpg; *.jpeg; *.png; *.gif;";

            DialogResult dr = OpenFD.ShowDialog();

            pictureBox2.Image = Image.FromFile(OpenFD.FileName);

            if (OpenFD.ShowDialog() == DialogResult.OK)
            {
                pathImg = OpenFD.FileName;
            }
        }
    }
}
