using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITYLAYER;
using FACADELAYER;
using BUSINESSLOGICLAYER;
namespace OgrenciNot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void OgrenciListesi()
        {
            List<ENTITYOGRENCI> ListOgr = BLLOGRENCI.LISTELE();
            dataGridView1.DataSource = ListOgr;
            this.Text = "Ogrenci Listesi";
        }
        
        void KulupListesi()
        {
            List<ENTITYKULUP> ListKulup = BLLKULUP.LISTELE();
            cmbOgrKulup.DisplayMember="KULUPAD";
            cmbOgrKulup.ValueMember = "KULUPID";
            cmbOgrKulup.DataSource = ListKulup;
        }

        void KulupListele()
        {
            List<ENTITYKULUP> ListKulup = BLLKULUP.LISTELE();
            dataGridView1.DataSource = ListKulup;
            this.Text = "Kulup Listesi";
        }

        void NotListesi()
        {
            List<ENTITYNOT> ListNot = BLLLNOT.LISTELE();
            dataGridView1.DataSource = ListNot;
            this.Text = "Not Listesi";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OgrenciListesi();
            KulupListesi();
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        { 
            ENTITYOGRENCI ent = new ENTITYOGRENCI();
            ent.AD = txtOgrAd.Text;
            ent.SOYAD = txtOgrSoyad.Text;
            ent.FOTOGRAF = txtOgrFotograf.Text;
            ent.KULUPID = Convert.ToInt16(cmbOgrKulup.SelectedValue);
            BLLOGRENCI.EKLE(ent);
            if (BLLOGRENCI.EKLE(ent) == -1)
            {
                MessageBox.Show("İşlem başarısız. Lütfen kontrol ediniz.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("İşlem başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            OgrenciListesi();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ENTITYOGRENCI ent = new ENTITYOGRENCI();
            ent.AD = txtOgrAd.Text;
            ent.SOYAD = txtOgrSoyad.Text;
            ent.FOTOGRAF = txtOgrFotograf.Text;
            ent.KULUPID = Convert.ToInt16(cmbOgrKulup.SelectedValue);
            ent.ID = Convert.ToUInt16(txtOgrId.Text);
            BLLOGRENCI.GUNCELLE(ent);
            if (BLLOGRENCI.GUNCELLE(ent) == false)
            {
                MessageBox.Show("İşlem başarısız. Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("İşlem başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            OgrenciListesi();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text == "Ogrenci Listesi")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtOgrId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtOgrAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtOgrSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtOgrFotograf.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtKulupId.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            }
            if (this.Text == "Not Listesi")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtOgrId.Text=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtNotId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtOgrAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtOgrSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtSınav1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtSınav2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                txtSınav3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                txtProje.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
                txtOrtalama.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
                txtDurum.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            }
            if(this.Text=="Kulup Listesi")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtKulupId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtKulupAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            }
        }

        private void btnNotListele_Click(object sender, EventArgs e)
        {

            NotListesi();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            OgrenciListesi();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNotGuncelle_Click(object sender, EventArgs e)
        {
            ENTITYNOT ent = new ENTITYNOT();
            ent.OGRID = Convert.ToUInt16(txtNotId.Text);
            ent.SINAV1 = Convert.ToUInt16(txtSınav1.Text);
            ent.SINAV2 = Convert.ToUInt16(txtSınav2.Text);
            ent.SINAV3 = Convert.ToUInt16(txtSınav3.Text);
            ent.PROJE = Convert.ToUInt16(txtProje.Text);
            ent.ORTALAMA = Convert.ToUInt16(txtOrtalama.Text); 
            ent.DURUM = txtDurum.Text;
            BLLLNOT.GUNCELLE(ent);
            if (BLLLNOT.GUNCELLE(ent) == false)
            {
                MessageBox.Show("İşlem başarısız. Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("İşlem başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            NotListesi();


        }

        private void btnNotHesapla_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, proje;
            double ortalama;
            string durum;
            s1 = Convert.ToInt16(txtSınav1.Text);
            s2 = Convert.ToInt16(txtSınav2.Text);
            s3 = Convert.ToInt16(txtSınav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (s1 + s2 + s3 + proje) / 4;
            txtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }
            txtDurum.Text = durum;
        }

        private void btnKulupListele_Click(object sender, EventArgs e)
        {
            KulupListele();
        }

        private void btnKulupKaydet_Click(object sender, EventArgs e)
        {
            ENTITYKULUP ent = new ENTITYKULUP();
            ent.KULUPAD = txtKulupAd.Text;
            if (BLLKULUP.EKLE(ent) == -1)
            {
                MessageBox.Show("İşlem başarısız. Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("İşlem başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            KulupListele();
        }

        private void btnKulupSil_Click(object sender, EventArgs e)
        {
            ENTITYKULUP ent = new ENTITYKULUP();
            ent.KULUPID = Convert.ToInt16(txtKulupId.Text);
            BLLKULUP.SIL(ent.KULUPID);
            KulupListele();
        }

        private void btnKulupGuncelle_Click(object sender, EventArgs e)
        {
            ENTITYKULUP ent = new ENTITYKULUP();
            ent.KULUPID = Convert.ToInt16(txtKulupId.Text);
            ent.KULUPAD = txtKulupAd.Text;
            BLLKULUP.GUNCELLE(ent);
            KulupListele();
        }
    }
}
