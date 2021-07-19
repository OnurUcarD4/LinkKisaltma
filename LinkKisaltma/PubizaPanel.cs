using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json;
using LinkKisaltma;

namespace LinkKısaltma
{
    public partial class PubizaPanel : Form
    {
        public PubizaPanel()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string apikey;

        private void PubizaPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void PubizaPanel_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Hatalı giriş yaptınız.", "Hata", MessageBoxButtons.OK);
            }

            else
            {
                HttpClient httpClient = new HttpClient();
                var url = $"http://pubiza.com/api.php?token={apikey}&url={textBox1.Text}";
                var response = await httpClient.GetStringAsync(url);
                textBox3.Text = response.ToString();
            }
        }

        private async void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "Önce link oluşturmalısınız.";
                pictureBox3.Enabled = false;
                await Task.Delay(1000);
                textBox3.Text = "";
                pictureBox3.Enabled = true;

            }
            else
            {
                string onceki = textBox3.Text;
                Clipboard.SetText(textBox3.Text.ToString());
                textBox3.Text = "Kopyalandı.";
                await Task.Delay(1000);
                textBox3.Text = onceki;
            }
        }

        private void PubizaPanel_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

}

