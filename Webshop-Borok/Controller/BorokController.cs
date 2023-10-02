using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Webshop_Borok.DataBaseManager;
using MySql.Data.MySqlClient;
using Webshop_Borok.Models;


namespace Webshop_Borok.Controller
{
    public class BorokController : BaseDatabaseManager, ISQL
    {
        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM borok ORDER BY Neve";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Borok egyBor = new Borok();
                    egyBor.termekId = int.Parse(reader["termekId"].ToString());
                    egyBor.neve = reader["neve"].ToString();
                    egyBor.evjarat = int.Parse(reader["evjarat"].ToString());
                    egyBor.urtartalom_liter = int.Parse(reader["urtartalom_liter"].ToString());
                    egyBor.fajta = reader["fajta"].ToString();
                    list.Add(egyBor);
                }
            }
            catch (Exception ex)
            {
                Borok borok = new Borok();
                borok.termekId = 0;
                borok.neve = ex.Message;
                list.Add(borok);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public string Insert(Record record)
        {
            Borok borok = record as Borok;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"INSERT INTO borok (neve, evjarat, urtaltarlom_liter, fajta) VALUES (@neve,@evjarat,@urtaltarlom_liter, @fajta)";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@neve", MySqlDbType.VarChar)).Value = borok.neve;
                cmd.Parameters.Add(new MySqlParameter("@evjarat", MySqlDbType.VarChar)).Value = borok.evjarat;
                cmd.Parameters.Add(new MySqlParameter("@urtaltarlom_liter", MySqlDbType.Int32)).Value = borok.urtartalom_liter;
                cmd.Parameters.Add(new MySqlParameter("@fajta", MySqlDbType.VarChar)).Value = borok.fajta;
                try
                {
                    cmd.Connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            cmd.Parameters.Clear();
            return "Sikeres adattárolás.";
        }

        public string Update(Record record)
        {
            Borok borok = record as Borok;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"UPDATE borok SET neve=@neve,evjarat=@evjarat,urtaltalom_liter=@urtartalom_liter,fajta=@fajta WHERE termekId=@termekId";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@termekId", MySqlDbType.Int32)).Value = borok.termekId;
                cmd.Parameters.Add(new MySqlParameter("@neve", MySqlDbType.VarChar)).Value = borok.neve;
                cmd.Parameters.Add(new MySqlParameter("@evjarat", MySqlDbType.VarChar)).Value = borok.evjarat;
                cmd.Parameters.Add(new MySqlParameter("@urtaltarlom_liter", MySqlDbType.Int32)).Value = borok.urtartalom_liter;
                cmd.Parameters.Add(new MySqlParameter("@fajta", MySqlDbType.VarChar)).Value = borok.fajta;
                cmd.Connection = BaseDatabaseManager.connection;
                try
                {
                    cmd.Connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) 
                    {
                        return ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "Sikeres adatmódosítás";
        }
        public string Delete(int termekId)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"DELETE borok WHERE termekId=@termekId";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@termekId", MySqlDbType.Int32)).Value = termekId;
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return "Nincs ilyen Id-vel rendelkező rekord!";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return "Sikeres adattörlés";

        }
    }
}