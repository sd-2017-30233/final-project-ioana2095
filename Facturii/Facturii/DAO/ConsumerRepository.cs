using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Facturii.DAO
{
    public class ConsumerRepository: IConsumerRepository, IDisposable
    {
        SqlConnection myCommand;
        public ConsumerRepository(string cale)
        {
            myCommand = new SqlConnection(cale);
        }
        public string idRole()
        {
            string queryStr = "Select * from AspNetRoles";
            SqlCommand com = new SqlCommand(queryStr, myCommand);
            com.Connection = myCommand;
            //myCommand.Open();
            SqlDataReader reader;
            try
            {
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Name"].ToString().Equals("consumator"))
                    {
                        String id = reader["Id"].ToString();
                        reader.Close();
                        return id;
                    }
                }

            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            return null;
        }
        public bool IsConsumer(String Id)
        {
            string queryStr = "Select * from AspNetUserRoles where UserId='" + Id + "'";
            SqlCommand com = new SqlCommand(queryStr, myCommand);
            com.Connection = myCommand;
            myCommand.Open();
            SqlDataReader reader;
            string idC = idRole();
            try
            {
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["RoleId"].ToString().Equals(idC))
                    {
                        reader.Close();
                        return true;
                    }
                }

            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            return false;
        }
        public Client extrageInfo(string Id)
        {
            string query = "Select * from Consumer where Id='" + Id + "'";
            SqlCommand comm = new SqlCommand(query, myCommand);
            myCommand.Open();
            comm.Connection = myCommand;
            SqlDataReader reader;
            String nume;
            try
            {
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    nume = reader["Name"].ToString();
                    string[] n = nume.Split(' ');
                    return new Client
                    {
                        Nume = n[0],
                        Prenume = n[1],
                        Adresa = reader["address"].ToString(),
                        Telefon = reader["telefon"].ToString()
                    };
                }
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            return null;
        }
        public IEnumerable<Client> extrageClient(string Nume)
        {
            List<Client> clienti = new List<Client>();
            string query = "Select * from Consumer where Name='" + Nume + "'";
            SqlCommand comm = new SqlCommand(query, myCommand);
           // myCommand.Open();
            comm.Connection = myCommand;
            SqlDataReader reader;
            String nume;
            try
            {
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    nume = reader["Name"].ToString();
                    string[] n = nume.Split(' ');
                    clienti.Add(new Client
                    {
                        Nume = n[0],
                        Prenume = n[1],
                        Adresa = reader["address"].ToString(),
                        Telefon = reader["telefon"].ToString()
                    });
                }
                return clienti;
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            return null;

            
        }
        public bool insert(string nume, string prenume, string adresa, string telefon, List<CompanyInfo> comp, string id)
        {
            string nr = "select count(*)  from Consumer";
            SqlCommand comm = new SqlCommand(nr, myCommand);
            myCommand.Open();
            comm.Connection = myCommand;
            int numarPersoane = (int)comm.ExecuteScalar();
            numarPersoane++;
            string numeDB = nume + " " + prenume;
            string querry = "insert into Consumer(ID_Consumer,Name,telefon,address,Id) values ('" + numarPersoane + "','" + numeDB + "','" + telefon + "','" + adresa + "','" + id + "')";
            SqlCommand comend = new SqlCommand(querry);
            comend.Connection = myCommand;
            comend.ExecuteNonQuery();
            string query = null;
            for (int i = 0; i < comp.Count(); i++)
            {
                if (comp[i].isCheck == true)
                {
                    query = "insert into ConsumerCompany(Name,ID_Consumer) values ('" + comp[i].Nume + "','" + numarPersoane + "')";
                    SqlCommand com = new SqlCommand(query);
                    com.Connection = myCommand;
                    com.ExecuteNonQuery();
                }
            }
            if (querry != null && query != null)
                return true;
            return false;
        }
        public List<InfoClient> print(string Id)
        {
            string querry = "select Name from Company where Id='" + Id + "'";
            SqlCommand com = new SqlCommand(querry, myCommand);
            myCommand.Open();
            com.Connection = myCommand;
            SqlDataReader reader1;
            string numeCompany = null;
            try
            {
                reader1 = com.ExecuteReader();
                while (reader1.Read())
                {
                    numeCompany = reader1["Name"].ToString();
                }
                reader1.Close();
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            List<InfoClient> clienti = new List<InfoClient>();
            string query = "select * from Consumer";
            string que = "select ID_Consumer from ConsumerCompany where Name='" + numeCompany + "'";
            SqlCommand comm = new SqlCommand(query, myCommand);
            comm.Connection = myCommand;
            SqlCommand comanda = new SqlCommand(que, myCommand);
            comanda.Connection = myCommand;
            SqlDataReader reader, reader2;
            string nume;
            List<Int32> idC = new List<int>();
            try
            {
                reader2 = comanda.ExecuteReader();
                while (reader2.Read())
                {
                    idC.Add(Convert.ToInt32(reader2["ID_Consumer"].ToString()));
                }
                reader2.Close();

                reader = comm.ExecuteReader();
                for (int i = 0; i < idC.Count; i++)
                {
                    while (reader.Read())
                    {
                        if (idC[i] == Convert.ToInt32(reader["ID_Consumer"].ToString()))
                        {
                            nume = reader["Name"].ToString();
                            string[] str = nume.Split(' ');
                            clienti.Add(new InfoClient
                            {
                                Nume = str[0],
                                Prenume = str[1],
                                Adresa = reader["address"].ToString(),
                                IdConsumer = Convert.ToInt32(reader["ID_Consumer"].ToString()),
                                Telefon = reader["telefon"].ToString(),
                                isCheck = false
                            });
                        }
                    }
                }
                reader.Close();
                return clienti;
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> print()
        {
            myCommand.Open();
            List<Client> clienti = new List<Client>();
            string query = "select * from Consumer";
            SqlCommand comm = new SqlCommand(query, myCommand);
            comm.Connection = myCommand;
            SqlDataReader reader;
            string nume;
            try
            {
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    nume = reader["Name"].ToString();
                    string[] str = nume.Split(' ');
                    clienti.Add(new Client
                    { Nume = str[0],
                      Prenume=str[1],
                      Adresa= reader["address"].ToString(),
                      Telefon=reader["telefon"].ToString(),
                      IdConsumer=Convert.ToInt16(reader["ID_Consumer"].ToString())

                });
                 }
                reader.Close();
                return clienti;
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            return null;
        }
    }
}