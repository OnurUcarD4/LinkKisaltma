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
    public partial class PndTLpanel : Form
    {
        public PndTLpanel()
        {
            InitializeComponent();
        }

        public string apikey;


        private void PndTLpanel_Load(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.ButtonHighlight;

            comboBox1.Items.Add("Genel Reklam (Kolay)");
            comboBox1.Items.Add("Genel Reklam (Zor)");
            comboBox1.Items.Add("+18 (Kolay)");
            comboBox1.Items.Add("+18 (Zor)");
            comboBox1.Items.Add("Telegram +18");
            comboBox1.Items.Add("Telegram Genel");
        }

        private async void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            PndTlTopluCeviri frm = new PndTlTopluCeviri();

            frm.apikey = apikey;
            frm.Show();
        }

        private void PndTLpanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            int cmb = comboBox1.SelectedIndex;


            try
            {
                var url = $"https://www.pnd.tl/api?api={apikey}&url={textBox1.Text}&category={comboBox1.SelectedIndex + 1}&alias={textBox2.Text}";
                if (cmb >= 4)
                {
                    url = $"https://www.pnd.tl/api?api={apikey}&url={textBox1.Text}&category={comboBox1.SelectedIndex + 2}&alias={textBox2.Text}";
                }
                HttpClient httpClient = new HttpClient();
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
                MessageBox.Show("Url kısmı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
