using Newtonsoft.Json;
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

namespace LinkKısaltma
{
    public partial class TrLinkPanel : Form
    {
        public TrLinkPanel()
        {
            InitializeComponent();
        }

        public string apikey;

        private void TrLinkPanel_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var url = $"https://ay.live/api/?api={apikey}&url={textBox1.Text}&{textBox2.Text}&ct=1";
                var response = httpClient.GetStringAsync(url).Result;
                Root kisalink = JsonConvert.DeserializeObject<Root>(response);

                if (kisalink.status == "success")
                {
                    label1.Text = "Başarılı.";
                    label1.ForeColor = Color.Green;
                    label1.Visible = true;
                    textBox3.Text = kisalink.shortenedUrl.ToString();
                    await Task.Delay(2000);
                    label1.Visible = false;
                }
                else
                {
                    label1.Visible = true;
                    label1.Text = "Başarısız.";
                    label1.ForeColor = Color.Red;
                    await Task.Delay(2000);
                    label1.Visible = false;
                }
            }





            catch
            {
                MessageBox.Show("Bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "Önce link oluşturmalısınız.";
                pictureBox1.Enabled = false;
                await Task.Delay(1000);
                textBox3.Text = "";
                pictureBox1.Enabled = true;

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
    }
}






