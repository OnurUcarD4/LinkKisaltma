using LinkKısaltma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkKisaltma
{
    public partial class SecmePaneli : Form
    {
        public SecmePaneli()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PndTLGiris pnd = new PndTLGiris();
            pnd.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PubizaGiris pbz = new PubizaGiris();
            pbz.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TrLinkGiris trz = new TrLinkGiris();
            trz.Show();
            this.Hide();
        }

        private void SecmePaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Sisteme ilk giriş yapan kullanıcılar için yeni kayıt oluşturmanız gerekmektedir. Site üzerinde kullanılan hesaplarınızı kullanamazsınız. Api tokeninizi site hesabınız üzerinden alabilirsiniz. Api tokeni yanlış girerseniz sistem hata verecektir. ","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
