using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LinkKisaltma;

namespace LinkKısaltma
{
    public partial class TrLinkGiris : Form
    {
        public TrLinkGiris()
        {
            InitializeComponent();
        }

        private void TrLinkGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        public string apikey;

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Boş alan bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komut = new SqlCommand("Select * From Tbl_Kullanicilar3 where Kullaniciadi=@p1 and Sifre=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    TrLinkPanel frm = new TrLinkPanel();
                    frm.apikey = dr[2].ToString();
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Hatalı Giriş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void TrLinkGiris_Load(object sender, EventArgs e)
        {

        }

        private void TrLinkGiris_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TrLinkKayitOl kyt = new TrLinkKayitOl();
            kyt.Show();
        }
    }
}
