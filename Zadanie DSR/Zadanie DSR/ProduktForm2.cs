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
    public partial class ProduktForm2 : Form
    {
        private OracleConnection connection;

        public ProduktForm2()
        {
            InitializeComponent();
            connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak;Password=lubomir_rusnak;");
            connection.Open();
            reload_Table();
        }

                private void planpridat_Click(object sender, EventArgs e)
        {

            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "update produkt set produkt.pocet=produkt.pocet + '" + textpocet.Text + "' where nazov = '" + nazovprodukt.Text + "'";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();

            OracleCommand command2 = connection.CreateCommand();
            command2.CommandText = "update sklad_vyroba set sklad_vyroba.pocet=sklad_vyroba.pocet - '" + textpocet.Text + "' where nazov = '" + nazovprodukt.Text + "'";
            command2.CommandType = CommandType.Text;
            OracleDataReader reader2 = command2.ExecuteReader();
            reader2.Dispose();
            command2.Dispose();
            reload_Table();

        }

        private void insert_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "INSERT INTO PRODUKT(idprodukt, nazov, cena,pocet) VALUES('" + textId.Text + "','" + nazovprodukt.Text + "','" + textcena.Text + "',0 )";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();

        }

        private void delete2_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "delete from produkt where idprodukt ='" + textId.Text + "'";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();


        }
        public void reload_Table()
        {
            //nacitaj zoznam
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from produkt";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            DataGridPlan.DataSource = dataTable;

            reader.Dispose();
            command.Dispose();
        }

        private void id_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textpocet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
