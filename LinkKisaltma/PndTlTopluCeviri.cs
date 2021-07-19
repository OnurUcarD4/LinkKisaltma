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
    public partial class PndTlTopluCeviri : Form
    {
        public PndTlTopluCeviri()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public string apikey;
        public void oku(string line)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var url = $"https://www.pnd.tl/api?api={apikey}&url={line}";
                var response = httpClient.GetStringAsync(url).Result;
                Root kisalink = JsonConvert.DeserializeObject<Root>(response);
                if (kisalink.status == "success")
                {
                    listBox1.Items.Add(kisalink.shortenedUrl);
                }
                else
                {
                    listBox1.Items.Add("Hatalı Url");
                }
            }
            catch
            {
                listBox1.Items.Add("Hatalı Url");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var line2 in richTextBox1.Lines)
            {
                oku(line2);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s1 = "";
            foreach (object item in listBox1.Items) s1 += item.ToString() + "\r\n";
            Clipboard.SetText(s1);
            MessageBox.Show("Linkler panoya kopyalandı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
