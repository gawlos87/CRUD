using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            FillCombo();
        }

        void FillCombo()
        {
            comboBox1.Items.Clear();
            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gawlos\source\repos\Karta_postaci\Karta_postaci\Database1.mdf;Integrated Security=True";
            string Queary = " select * from employees ;";
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            SqlCommand sqlCommand = new SqlCommand(Queary, sqlConnection);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();


                while (dataReader.Read())
                {
                    string sName = dataReader["name"].ToString();
                    comboBox1.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gawlos\source\repos\Karta_postaci\Karta_postaci\Database1.mdf;Integrated Security=True";
            string Queary = "insert into Employees (ID,name,surname,age) " +
                "values('" + this.id_txt.Text+"','"+this.name_txt.Text+"','"+this.surname_txt.Text+"','"+this.age_txt.Text+"');";
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            SqlCommand sqlCommand = new SqlCommand(Queary, sqlConnection);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                MessageBox.Show("Saved");

                while (dataReader.Read())
                {

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            FillCombo();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gawlos\source\repos\Karta_postaci\Karta_postaci\Database1.mdf;Integrated Security=True";
            string Queary = "Update Employees set ID='" + this.id_txt.Text + "',name='" + this.name_txt.Text + "',surname='" + this.surname_txt.Text + "',age='" + this.age_txt.Text + "' where ID='"+this.id_txt.Text+"';";
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            SqlCommand sqlCommand = new SqlCommand(Queary, sqlConnection);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                MessageBox.Show("Updated");

                while (dataReader.Read())
                {

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            FillCombo();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gawlos\source\repos\Karta_postaci\Karta_postaci\Database1.mdf;Integrated Security=True";
            string Queary = "delete from employees where ID='" + id_txt.Text + "';";
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            SqlCommand sqlCommand = new SqlCommand(Queary, sqlConnection);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                MessageBox.Show("Deleted");

                while (dataReader.Read())
                {

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            FillCombo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string namestr = name_txt.Text;
            comboBox1.Items.Add(namestr);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gawlos\source\repos\Karta_postaci\Karta_postaci\Database1.mdf;Integrated Security=True";
            string Queary = " select * from employees where name='"+comboBox1.Text+"';";
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            SqlCommand sqlCommand = new SqlCommand(Queary, sqlConnection);
            SqlDataReader dataReader;
            try
            {
                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();


                while (dataReader.Read())
                {
                    string sID = dataReader["id"].ToString();
                    string sName = dataReader["name"].ToString();
                    string sSurname = dataReader["surname"].ToString();
                    string sAge = dataReader["age"].ToString(); 

                    id_txt.Text = sID;
                    name_txt.Text = sName;
                    surname_txt.Text = sSurname;
                    age_txt.Text = sAge;


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void load_ButtonDGV_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gawlos\source\repos\Karta_postaci\Karta_postaci\Database1.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("select id, name, surname, age from Employees ;", sqlConnection);

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                sqlDataAdapter.Update(dataTable);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
