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

namespace Personel_Kayitt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JS4DO3I\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select count(*) from Tbl_Personel",baglanti);

            SqlDataReader dr1 = komut1.ExecuteReader();

            while (dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }

            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) from Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                lblEvliPersonel.Text = dr2[0].ToString();
            }

            baglanti.Close();


            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) from Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                lblBekarPersonel.Text = dr3[0].ToString();
            }

            baglanti.Close();

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(PerSehir)) from Tbl_Personel where PerSehir is not null ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();

            while(dr4.Read()){
                lblSehirSayisi.Text = dr4[0].ToString();

            }

            baglanti.Close();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(PerMaas) from Tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();

            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString();
                
            }

            baglanti.Close();

            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("Select avg(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();

            while (dr6.Read())
            {

                lblOrtalamaMaas.Text = dr6[0].ToString();
            }



            baglanti.Close();





        }
    }
}
