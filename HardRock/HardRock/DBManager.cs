using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HardRock
{
    class DBManager
    {
        public static string CONNECTION_STRING = @"server=195.178.235.60;userid=ae6804;
            password=samusaran;database=ae6804";


        public DBManager()
        {

            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("select * from Band", conn))
                    {
                        // skriva
                        //cmd.ExecuteNonQuery();

                        // läsa
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {                    
                            while (reader.Read()) {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write(reader.GetValue(i) + " ");
                                    
                                }
                                Console.WriteLine(" ");
                                //reader.GetInt16(7)
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // bra till något kanske
        public List<List<object>> GetBandInfo()
        {
            List<List<object>> table = new List<List<object>>();
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("select * from Band", conn))
                    {
                        // läsa
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<object> row = new List<object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row.Add(reader.GetValue(i));
                                }
                                table.Add(row);
                            }
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return table;
        }

        public void InsertAnstalld(int AnstID, string Namn, int PersonNr)
        {
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    //  using (var cmd = new MySqlCommand("Insert Band set Namn=@Namn where AnstId=1", conn))
                    using (var cmd = new MySqlCommand("Insert INTO Anställd VALUE(@AnstID, @Namn, @PersonNr)", conn))
                    {
                        // läs på om prepare
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@AnstID", AnstID);
                        cmd.Parameters.AddWithValue("@Namn", Namn);
                        cmd.Parameters.AddWithValue("@PersonNr", PersonNr);

                        // skriva
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void InsertTelefonNr(string TelefonNr, int AnställdID)
        {
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    //  using (var cmd = new MySqlCommand("Insert Band set Namn=@Namn where AnstId=1", conn))
                    using (var cmd = new MySqlCommand("Insert INTO TelefonNr VALUE(@telefonNr, @AnstalldID)", conn))
                    {
                        // läs på om prepare
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@telefonNr", TelefonNr);
                        cmd.Parameters.AddWithValue("@AnstalldID", AnställdID);

                        // skriva
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void InsertSpelning(int KonsertID, string StartTid, string SlutTid, int ScenID, int BandID)
        {
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    //  using (var cmd = new MySqlCommand("Insert Band set Namn=@Namn where AnstId=1", conn))
                    using (var cmd = new MySqlCommand("Insert INTO Konsert VALUE(@KonserID, @StartTid, @SlutTid, @ScenID, @BandID)", conn))
                    {
                        // läs på om prepare
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@KonserID", KonsertID);
                        cmd.Parameters.AddWithValue("@StartTid", StartTid);
                        cmd.Parameters.AddWithValue("@SlutTid", SlutTid);
                        cmd.Parameters.AddWithValue("@ScenID", ScenID);
                        cmd.Parameters.AddWithValue("@BandID", BandID);

                        // skriva
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void InsertBand(int BandID, string Bandnamn, string Genre, int KontaktID, string Land)
        {
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    //  using (var cmd = new MySqlCommand("Insert Band set Namn=@Namn where AnstId=1", conn))
                    using (var cmd = new MySqlCommand("Insert INTO Band VALUE(@BandID, @Bandnamn, @Genre, @KontaktP, @Ursprungsland)", conn))
                    {
                       // läs på om prepare
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@BandID", BandID);
                        cmd.Parameters.AddWithValue("@Bandnamn", Bandnamn);
                        cmd.Parameters.AddWithValue("@Genre", Genre);
                        cmd.Parameters.AddWithValue("@KontaktP", KontaktID);
                        cmd.Parameters.AddWithValue("@Ursprungsland", Land);

                        // skriva
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
