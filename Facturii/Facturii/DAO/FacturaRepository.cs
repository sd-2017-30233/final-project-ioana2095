using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Facturii.DAO
{
    public class FacturaRepository: IFacturaRepository,IDisposable
    {
        SqlConnection myCommand;
        public FacturaRepository(string cale)
        {
            myCommand = new SqlConnection(cale);
        }
        public List<Bill> afisareFacturi(String Id)
        {
            myCommand.Open();
            List<Bill> facturii = new List<Bill>();
            Bill factura = new Models.Bill();
            string nume = null;
            string queryStr = "Select * from Factura";
            string query = "Select * from Consumer where Id='" + Id + "'";
            SqlCommand comm = new SqlCommand(query, myCommand);
            SqlCommand com = new SqlCommand(queryStr, myCommand);
            comm.Connection = myCommand;
            com.Connection = myCommand;
            SqlDataReader reader, reader1;
            int i = 0;
            try
            {
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    nume = reader["Name"].ToString();
                    string[] n = nume.Split(' ');
                    i = Convert.ToInt32(reader["ID_Consumer"].ToString());
                    reader.Close();

                    try
                    {
                        reader1 = com.ExecuteReader();
                        while (reader1.Read())
                        {
                            if (Convert.ToInt32(reader1["IdConsumator"].ToString()) == i)
                            {
                                facturii.Add(new Bill
                                {
                                    NrIdentificare = reader1["IdFactura"].ToString(),
                                    Nume = n[0],
                                    Prenume = n[1],
                                    DataEmiteri = reader1["DataEmitere"].ToString(),
                                    DataScadenta = reader1["DataScadenta"].ToString(),
                                    Consum = (float)Convert.ToDouble(reader1["Consum"].ToString()),
                                    Total = (float)Convert.ToDouble(reader1["Total"].ToString())
                                });
                            }
                        }
                        reader1.Close();
                        return facturii;
                    }
                    catch (SqlException e)
                    {
                        Console.Write(e.Message);
                    }
                }

            }

            catch (SqlException e)
            {
                Console.Write(e.Message);
            }

            return null;
        }
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public bool createBills(IEnumerable<InfoClient> client, string Id)
        {
            Random rnd1 = new Random();
            bool ok = false;
            for (int i = 0; i < client.Count(); i++)
            {
                if (client.ElementAt(i).isCheck)
                {
                    string IdFactura = RandomString(8, false);
                    string DataEmitere = DateTime.Today.Date.ToString();
                    string DataScadenta = DateTime.Today.Date.AddDays(30).ToString();
                    float consum = rnd1.Next(10, 1000);
                    float total = (float)(consum * 1.5);
                    string str = "insert into Factura(IdFactura,IdConsumator,DataEmitere,DataScadenta,Consum,Total) values ('" + IdFactura + "','" + client.ElementAt(i).IdConsumer + "','" + DataEmitere + "','" + DataScadenta + "','" + consum + "','" + total + "')";
                    SqlCommand comend = new SqlCommand(str);
                    myCommand.Open();
                    comend.Connection = myCommand;
                    comend.ExecuteNonQuery();
                    ok = true;
                }
            }
            if (ok == true)
                return true;
            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bill> print()
        {
            myCommand.Open();
            List<Bill> facturii = new List<Bill>();
            Bill factura = new Models.Bill();
            string nume = null;
            string queryStr = "Select * from Factura";
            string query = "Select * from Consumer";
            SqlCommand comm = new SqlCommand(query, myCommand);
            SqlCommand com = new SqlCommand(queryStr, myCommand);
            comm.Connection = myCommand;
            com.Connection = myCommand;
            SqlDataReader reader, reader1;
            int i = 0;
            try
            {
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    nume = reader["Name"].ToString();
                    string[] n = nume.Split(' ');
                    i = Convert.ToInt32(reader["ID_Consumer"].ToString());
                    reader.Close();

                    try
                    {
                        reader1 = com.ExecuteReader();
                        while (reader1.Read())
                        {
                            if (Convert.ToInt32(reader1["IdConsumator"].ToString()) == i)
                            {
                                facturii.Add(new Bill
                                {
                                    NrIdentificare = reader1["IdFactura"].ToString(),
                                    Nume = n[0],
                                    Prenume = n[1],
                                    DataEmiteri = reader1["DataEmitere"].ToString(),
                                    DataScadenta = reader1["DataScadenta"].ToString(),
                                    Consum = (float)Convert.ToDouble(reader1["Consum"].ToString()),
                                    Total = (float)Convert.ToDouble(reader1["Total"].ToString())
                                });
                            }
                        }
                        reader1.Close();
                        return facturii;
                    }
                    catch (SqlException e)
                    {
                        Console.Write(e.Message);
                    }
                }

            }

            catch (SqlException e)
            {
                Console.Write(e.Message);
            }

            return null;
        }

        public IEnumerable<Bill> extrageBill(string Nume)
        {
            List<Bill> facturii = new List<Bill>();
            Bill factura = new Models.Bill();
            string nume = null;
            string queryStr = "Select * from Factura";
            string query = "Select * from Consumer where Nume='" + Nume + "'";
            SqlCommand comm = new SqlCommand(query, myCommand);
            SqlCommand com = new SqlCommand(queryStr, myCommand);
            comm.Connection = myCommand;
            com.Connection = myCommand;
            SqlDataReader reader, reader1;
            int i = 0;
            try
            {
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    nume = reader["Name"].ToString();
                    string[] n = nume.Split(' ');
                    i = Convert.ToInt32(reader["ID_Consumer"].ToString());
                    reader.Close();

                    try
                    {
                        reader1 = com.ExecuteReader();
                        while (reader1.Read())
                        {
                            if (Convert.ToInt32(reader1["IdConsumator"].ToString()) == i)
                            {
                                facturii.Add(new Bill
                                {
                                    NrIdentificare = reader1["IdFactura"].ToString(),
                                    Nume = n[0],
                                    Prenume = n[1],
                                    DataEmiteri = reader1["DataEmitere"].ToString(),
                                    DataScadenta = reader1["DataScadenta"].ToString(),
                                    Consum = (float)Convert.ToDouble(reader1["Consum"].ToString()),
                                    Total = (float)Convert.ToDouble(reader1["Total"].ToString())
                                });
                            }
                        }
                        reader1.Close();
                        return facturii;
                    }
                    catch (SqlException e)
                    {
                        Console.Write(e.Message);
                    }
                }

            }

            catch (SqlException e)
            {
                Console.Write(e.Message);
            }

            return null;
        }
    }
}