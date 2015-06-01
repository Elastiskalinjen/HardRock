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

        private Form2 form;

        public DBManager(Form2 form)
        {
            this.form = form;
        }

        public void ShowBand()
        {
            form.listBox1.Items.Clear();
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("select BandNamn,Genre,UrsprungsLand from Band", conn))
                    {

                        // läsa
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            form.listBox1.Items.Add("Namn\t\t\tGenre\t\t\tUrsprungsland");
                            while (reader.Read())
                            {

                                form.listBox1.Items.Add(reader.GetValue(0).ToString() + "\t\t" + reader.GetValue(1).ToString() + "\t\t\t" + reader.GetValue(2).ToString());

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
        public void ShowSpelschema()
        {
            form.listBox1.Items.Clear();
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("select Konsert.Dag, Konsert.StartTid, Konsert.SlutTid, Band.BandNamn, Scen.Namn from (Scen inner join Konsert on Scen.ScenID = Konsert.Scen) inner join Band on Konsert.Band = Band.BandID", conn))
                    {

                        // läsa
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            form.listBox1.Items.Add("Dag\t\t\tStarttid\t\t\tSluttid\t\t\tBandnamn\t\t\tScennamn");
                            while (reader.Read())
                            {
                                form.listBox1.Items.Add(reader.GetValue(0).ToString() + "\t\t\t" + reader.GetValue(1).ToString() + "\t\t\t" +
                                    reader.GetValue(2).ToString() + "\t\t\t" + reader.GetValue(3).ToString() + "\t\t\t" + reader.GetValue(4).ToString());
                                
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

        public void InsertAnstalld(string Namn, int PersonNr)
        {
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    //  using (var cmd = new MySqlCommand("Insert Band set Namn=@Namn where AnstId=1", conn))
                    using (var cmd = new MySqlCommand("Insert INTO Anställd VALUES(null, @Namn, @PersonNr)", conn))
                    {
                        // läs på om prepare
                        cmd.Prepare();
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
                    using (var cmd = new MySqlCommand("Insert INTO TelefonNr VALUE(@AnstID, @TelefonNr)", conn))
                    {
                        // läs på om prepare
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@AnstID", AnställdID);
                        cmd.Parameters.AddWithValue("@TelefonNr", TelefonNr);
                       

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
        public void InsertSpelning(string Dag, string StartTid, string SlutTid, int ScenID, int BandID)
        {
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    //  using (var cmd = new MySqlCommand("Insert Band set Namn=@Namn where AnstId=1", conn))
                    using (var cmd = new MySqlCommand("Insert INTO Konsert VALUES(@Dag, @StartTid, @SlutTid, @ScenID, @BandID)", conn))
                    {
                        // läs på om prepare
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Dag", Dag);
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
        public void InsertBand(string Bandnamn, string Genre, int KontaktID, string Land)
        {
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    //  using (var cmd = new MySqlCommand("Insert Band set Namn=@Namn where AnstId=1", conn))
                    using (var cmd = new MySqlCommand("Insert INTO Band VALUE(null, @Bandnamn, @Genre, @KontaktP, @Ursprungsland)", conn))
                    {
                       // läs på om prepare
                        cmd.Prepare();
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
