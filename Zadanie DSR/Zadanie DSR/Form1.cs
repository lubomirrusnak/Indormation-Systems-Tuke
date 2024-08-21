using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Zadanie_DSR
{
    public partial class Form1 : Form
    {
        private OracleConnection connection;

        public Form1()
        {
            InitializeComponent();
        }


        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak; Password=lubomir_rusnak;");
            connection.Open();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT uzivatel,heslo,pozicia FROM zamestnanci WHERE uzivatel= '" + logname.Text + "' and heslo= '" + password.Text + "'";
            OracleDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                String user = reader.GetString(0);
                String pozicia = reader.GetString(2);
                this.Hide();
                HomeForm obj = new HomeForm(user, pozicia);
                obj.Show();

            }
            reader.Dispose();
            command.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
    

