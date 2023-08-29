using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProje
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        //Entity Framework kullanarak istatistiklerimizi oluşturalım:
        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.Tbl_Kategori.Count().ToString();
            label3.Text = db.Tbl_Urun.Count().ToString();
            label5.Text = db.Tbl_Musteri.Count(x => x.DURUM == true).ToString();
            label7.Text = db.Tbl_Musteri.Count(x => x.DURUM == false).ToString();
            label13.Text = db.Tbl_Urun.Sum(y => y.STOK).ToString();
            label21.Text = db.Tbl_Satis.Sum(z => z.FIYAT).ToString()+" TL";
            label11.Text= (from x in db.Tbl_Urun orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            label9.Text= (from x in db.Tbl_Urun orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            label15.Text = db.Tbl_Urun.Count(x => x.KATEGORI == 1).ToString();
            label17.Text = db.Tbl_Urun.Count(x => x.URUNAD == "LAPTOP").ToString();
            label23.Text = (from x in db.Tbl_Musteri select x.SEHIR).Distinct().Count().ToString();
            label19.Text = db.MARKAGETIR().FirstOrDefault();
        }
    }
}