using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KutuphaneProje
{
    public partial class Form1 : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
 
        public Form1()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=KutuphaneProje.accdb");
            da = new OleDbDataAdapter("SElect * from kitaplar", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kitaplar");
            dataGridView1.DataSource = ds.Tables["kitaplar"];
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            griddoldur();
        }
 


          private void button1_Click_1(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into kitaplar (kitap_ad,kitap_tur,kitap_yazar) values ('" +tbkitapad.Text+ "','" + tbkitaptur.Text + "','" + tbkitapyazar.Text+ "')";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        
        }
     
        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e) //Tıkladığımda textlere doldur
        {
            tbkitapid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbkitapad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbkitaptur.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbkitapyazar.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update kitaplar set kitap_ad='" + tbkitapad.Text + "',kitap_tur='" + tbkitaptur.Text + "',kitap_yazar='" + tbkitapyazar.Text + "' where kitap_id=" + tbkitapid.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from kitaplar where kitap_id=" + tbkitapid.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }
 
       
        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=KutuphaneProje.accdb");
            da = new OleDbDataAdapter("SElect *from kitaplar where kitap_ad like '" + textBox5.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kitaplar");
            dataGridView1.DataSource = ds.Tables["kitaplar"];
            con.Close();
        }

    
            
        private void button5_Click(object sender, EventArgs e)
        {
            
          
            odunc odunc1   = new odunc(); // from2 nesnesinden bir tane daha türettik
            odunc1.form1id = tbkitapid.Text; // from2 deki property içini değiştirmek
            odunc1.form1ad = tbkitapad.Text;
            odunc1.ShowDialog(); // form2  çağırıldı 
            
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        
      
                     
    }
    }

