using AdoApp.Models;
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

namespace AdoApp
{
    public partial class Form1 : Form
    {
        string conn = "Data Source=PK3-8;Initial Catalog = CarRental; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand command = new SqlCommand("select * from dbo.Cars", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Car> cars = new List<Car>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cars.Add(new Car
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            ModelId = Convert.ToInt32(reader["ModelId"])
                        }
                            );
                    }
                }
            
                connection.Close();
            dataGridView1.DataSource = cars;

        }
    }
}
