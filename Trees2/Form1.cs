using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trees2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server = 192.168.1.38;" +
                "user=PC1;" +
                "password=1111;" +
                "port=3306;" +
                "database=trees_zaimov";

            MySqlConnection connect = new MySqlConnection(connectionString);
            if (connect.State==0)
            {
                connect.Open();
            }
            MessageBox.Show("Imash vruzka s Belezireva HeidiSQL");


            string insertQueryText = "INSERT INTO trees_zaimov.Type " +
                "(`name`,`name_bg`) " +
                "VALUES " +
                "(@name,@name_bg)";

            MySqlCommand query = new MySqlCommand(insertQueryText,connect);
            //svurzvane na parametri
            query.Parameters.AddWithValue("@name", txt1.Text);
            query.Parameters.AddWithValue("@name_bg", txtNameBg.Text);

            int result=query.ExecuteNonQuery();
            if (result != 0)
            {
                MessageBox.Show($"dobavi{result} records!!! ");
            }

            connect.Close();
        }
    }
}
