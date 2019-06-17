using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var un = username_txt.Text;
            var pw = password_txt.Text;
            TryConnect(un, pw);
            //await Task.Run(() => TryConnect(un, pw));
        }

        private void TryConnect(string username, string password)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=DESKTOP-07UG97C;Initial Catalog=Pracownicy;User ID=Gawlos;Password=Hpic123$";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
