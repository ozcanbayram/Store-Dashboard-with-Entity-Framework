using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProje
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            //SADECE İSTENİLENLERİN LİSTELENMESİ:
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.Tbl_Kategori.AD,
                                            x.DURUM
                                        }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {


            try
            {

                //Entity Framework kullanarak ürün ekleme:
                Tbl_Urun t = new Tbl_Urun();
                t.URUNAD = txtAd.Text;
                t.MARKA = txtMarka.Text;
                t.STOK = short.Parse(txtStok.Text);
                t.DURUM = true;
                t.KATEGORI = int.Parse(cmbKategori.SelectedValue.ToString());
                t.FIYAT = decimal.Parse(txtFiyat.Text);

                if (txtAd.Text == "" || txtMarka.Text == "" || txtStok.Text == "" || cmbKategori.Text == "" || txtFiyat.Text == "")
                {
                    MessageBox.Show("Eklemek istediğiniz urunun bilgilerini eksiksiz giriniz.");
                }

                else
                {
                    db.Tbl_Urun.Add(t);
                    db.SaveChanges();
                    MessageBox.Show("Ürün sisteme kaydedildi.");
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Ürün bilgilerini kontrol ediniz");
            }


            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txtId.Text);
                var urun = db.Tbl_Urun.Find(x);
                db.Tbl_Urun.Remove(urun);
                db.SaveChanges();
                MessageBox.Show("Ürün silindi.");
            }
            catch( Exception ex )
            {
                MessageBox.Show("Silmek istediğiniz ürünü seçiniz ya da id numarasını giriniz.");
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txtId.Text);
                var urun = db.Tbl_Urun.Find(x);
                urun.URUNAD = txtAd.Text;
                urun.MARKA = txtMarka.Text;
                urun.STOK = short.Parse(txtStok.Text);
                db.SaveChanges();
                MessageBox.Show("Ürün güncellendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncellemek istediğiniz ürünü seçiniz ya da id numarasını giriniz.");
            }

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            //Entity Framework ile Combobox'a kategorileri çağırma.
            var kategoriler = (from x in db.Tbl_Kategori
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }
                               ).ToList();

            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember = "AD";
            cmbKategori.DataSource = kategoriler;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtDurum.Text = "";
            txtFiyat.Text = "";
            txtId.Text = "";
            txtMarka.Text = "";
            txtStok.Text = "";
            cmbKategori.Text = "";
        }
    }
}
