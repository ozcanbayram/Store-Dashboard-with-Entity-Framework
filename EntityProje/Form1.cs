﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Entity Framework kullanıldı:
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategori = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = kategori;
        }

        private void btnEkle_Click(object sender, EventArgs e) // All debugging is complated.
        {
            Tbl_Kategori t = new Tbl_Kategori();
            t.AD = textBox2.Text;

            if (textBox2.Text == "")
            {
                MessageBox.Show("Eklemek istediğiniz kategoriyi yazınız.");
            }
            else
            {
                db.Tbl_Kategori.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori eklendi.");
            }

            
        }

        private void btnSil_Click(object sender, EventArgs e) //All debugging is complated.
        {
            //id si girilen kategoriyi sildirmek:

            try
            {
                int x = Convert.ToInt32(textBox1.Text);
                var ktgr = db.Tbl_Kategori.Find(x);
                db.Tbl_Kategori.Remove(ktgr);
                db.SaveChanges();
                textBox1.Clear();
                MessageBox.Show("Kategori silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinecek kategoriyi seçiniz ya da id numarasını giriniz.");
            }

            
        }

        private void btnGuncelle_Click(object sender, EventArgs e) // All debugging is complated.
        {

            try
            {
                //id si girilen kategoriyi güncelleme
                int x = Convert.ToInt32(textBox1.Text);
                var ktgr = db.Tbl_Kategori.Find(x);
                ktgr.AD = textBox2.Text;
                db.SaveChanges();
                MessageBox.Show("Kategori güncellendi.");
            }

            catch(Exception ex)
            {
                MessageBox.Show("Güncellemek istediğiniz kategoriyi seçiniz ya da id numarasını giriniz.");
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}