using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Facturii.Models;
using System.Data.SqlClient;

namespace Facturii.DAO
{
    public class CompanyRepository : ICompanyRepository, IDisposable
    {
        SqlConnection myCommand;
        public CompanyRepository(string cale)
        {
            myCommand = new SqlConnection(cale);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> extrageCompany(string Nume)
        {
            List<Company> clienti = new List<Company>();
            string query = "Select * from Company where Name='" + Nume + "'";
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
                    clienti.Add(new Company
                    {
                        Nume = reader["Name"].ToString(),
                        Adresa = reader["address"].ToString(),
                        Telefon = reader["telefon"].ToString(),
                        NrCont = reader["NrCont"].ToString(),
                        Info = reader["Info"].ToString()
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

        public Company extrageInfoCompany(string Id)
        {
            string query = "Select * from Company where Id='" + Id + "'";
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
                    return new Company
                    {
                        Nume = reader["Name"].ToString(),
                        Adresa = reader["address"].ToString(),
                        Telefon = reader["telefon"].ToString(),
                        NrCont = reader["NrCont"].ToString(),
                        Info= reader["Info"].ToString()

                    };
                }
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            return null;
        }

        public bool insertCompany(string nume, string telefon, string nrCont, string adresa, string info, string Id, string Bank)
        {
            string account = "insert into Account(NrCont,Bank) values('"+nrCont+ "','" +Bank+ "')";
            SqlCommand comm = new SqlCommand(account, myCommand);
            comm.ExecuteNonQuery();
            myCommand.Open();
            string querry = "insert into Company(Name,telefon,NrCont,address,Info,Id) values ('" + nume + "','" + telefon + "','" + nrCont + "','" + adresa + "','"+info+ "','" + Id + "')";
            SqlCommand comend = new SqlCommand(querry);
            comend.Connection = myCommand;
            comend.ExecuteNonQuery();
            if (querry != null )
                return true;
            return false;
        }

        public IEnumerable<Company> print()
        {
            List<Company> clienti = new List<Company>();
            string query = "Select * from Company";
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
                    clienti.Add(new Company
                    {
                        Nume = reader["Name"].ToString(),
                        Adresa = reader["address"].ToString(),
                        Telefon = reader["telefon"].ToString(),
                        NrCont = reader["NrCont"].ToString(),
                        Info = reader["Info"].ToString()
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
    }
}