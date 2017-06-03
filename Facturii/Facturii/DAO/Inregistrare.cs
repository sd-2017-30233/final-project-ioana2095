using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Facturii.DAO
{
    public class Inregistrare
    {
        static string cale = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        SqlConnection myCommand = new SqlConnection(cale);
        public bool inregistrare(ICollection<Bill> facturi, string Id)
        {
            string query = "select IdConsumator from Factura where Id='" + Id + "'";
            SqlCommand comm = new SqlCommand(query, myCommand);
            myCommand.Open();
            comm.Connection = myCommand;
            SqlDataReader reader;
            int idC = 0;
            try
            {
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idC = Convert.ToInt32(reader["IdConsumator"].ToString());
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }

            for (int i = 0; i < facturi.Count; i++)
            {
                if (facturi.ElementAt(i).isChecked)
                {
                    string querry = "insert into Inregistrare(IdFactura,IdConsumator) values ('" + facturi.ElementAt(i).NrIdentificare + "','" + idC + "')";
                    SqlCommand comend = new SqlCommand(querry);
                    comend.Connection = myCommand;
                    comend.ExecuteNonQuery();
                    string str = "delete from Factura where IdFactura='" + facturi.ElementAt(i).NrIdentificare + "'";
                    SqlCommand com = new SqlCommand(str);
                    com.Connection = myCommand;
                    com.ExecuteNonQuery();
                }
            }

            return false;
        }
    }
}