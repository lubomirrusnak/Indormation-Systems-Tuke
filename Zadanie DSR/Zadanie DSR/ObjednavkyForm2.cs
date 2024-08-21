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
    public partial class ObjednavkyForm2 : Form
    {
        private OracleConnection connection;

        public ObjednavkyForm2()
        {
            InitializeComponent();
            connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=147.232.25.197)(PORT=1523))(CONNECT_DATA=(SID=mis3)));User Id=lubomir_rusnak;Password=lubomir_rusnak;");
            connection.Open();
            reload_Table();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add2_Click(object sender, EventArgs e)
        {

            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "INSERT INTO objednavka(idobjednavka, idzakaznici, stav, datum,ks, idprodukt) VALUES('" + idobjednavkatxt.Text + "','" + idzakazniktxt.Text + "','" + stavtxt.Text + "',CURRENT_TIMESTAMP,'" + pocettxt.Text + "','"+ idprodukttxt.Text + "')";
            //command1.CommandText = "INSERT INTO objednavka(idobjednavka, idzakaznici, stav, datum,ks, idprodukt) VALUES('" + idobjednavkatxt.Text + "','" + idzakazniktxt.Text + "','" + stavtxt.Text + "',CURRENT_TIMESTAMP,'" + pocettxt.Text + "','" + idprodukttxt.Text + "')";

            //command1.CommandText = "INSERT INTO objednavka(idobjednavka, idzakaznici, stav, datum,ks, cena, idprodukt) VALUES('" + idobjednavkatxt.Text + "','" + idzakazniktxt.Text + "','" + stavtxt.Text + "',CURRENT_TIMESTAMP,'" + pocettxt.Text + "',(select cena from produkt where idprodukt='"+ idprodukttxt.Text +"'),'" + idprodukttxt.Text + "')";
            //                                                                                    .CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + mukaText.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  11 ";
            //                                                                                    command1.CommandText = "update sklad_material set sklad_material.stav=sklad_material.stav - '" + mukaText.Text + "' *(select pocet from plan_vyroby where idplan = '" + Textidplan.Text + "') where idsklad_material =  11 ";

            //            insert into objednavka(idobjednavka, idzakaznici, stav, datum, cena, ks, idprodukt)
            //values          (100, '62', 'Vybavená', CURRENT_TIMESTAMP, (select cena from produkt where idprodukt = '41') * 2,'5','41')
            //string query = "insert into plan_vyroby values('" + idPlanText.Text + "','" + nazovplan.Text + "','" + pocetPlanText.Text + "','" + "bednička" + "')";

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
            command.CommandText = "select objednavka.idobjednavka,zakaznici.meno,zakaznici.priezvisko,produkt.nazov,objednavka.stav,objednavka.datum,objednavka.ks,produkt.cena from objednavka inner join produkt on objednavka.idprodukt=produkt.idprodukt inner join zakaznici on objednavka.idzakaznici=zakaznici.idzakaznici";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            DataGridObjednavky.DataSource = dataTable;

            reader.Dispose();
            command.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "delete from objednavka where idobjednavka ='" + idobjednavkatxt.Text + "'";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "UPDATE objednavka set idzakaznici = '" + idzakazniktxt.Text + "', stav = '" + stavtxt.Text + "',datum = CURRENT_TIMESTAMP, ks = '" + pocettxt.Text + "', idprodukt = '" + idprodukttxt.Text + "' where idobjednavka = " + idobjednavkatxt.Text;
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();
            reload_Table();
        }

        private void DataGridObjednavky_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "UPDATE objednavka set stav = 'Vybavená', DATUM = CURRENT_TIMESTAMP where idobjednavka = '" + idobjednavkatxt.Text + "'";
            command1.CommandType = CommandType.Text;
            OracleDataReader reader1 = command1.ExecuteReader();
            reader1.Dispose();
            command1.Dispose();

            OracleCommand command2 = connection.CreateCommand();
            command2.CommandText = "update produkt set produkt.pocet=produkt.pocet - '" + pocettxt.Text + "' where idprodukt = '" + idprodukttxt.Text + "'";
            command2.CommandType = CommandType.Text;
            OracleDataReader reader2 = command2.ExecuteReader();
            reader2.Dispose();
            command2.Dispose();
            reload_Table();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
