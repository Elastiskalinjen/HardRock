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

                    using (var cmd = new MySqlCommand("select * from Anstalld", conn))
                    {
                        // skriva
                        cmd.ExecuteNonQuery();

                        // läsa
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {                    
                                Console.WriteLine(reader.GetValue(0));
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Test(string namn)
        {
            try
            {
                using (var conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("update Anstalld set Namn=@Namn where AnstId=1", conn))
                    {
                       // läs på om prepare
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Namn", namn);

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
