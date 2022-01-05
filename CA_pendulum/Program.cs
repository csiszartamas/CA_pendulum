using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_pendulum
{
    internal class Program
    {
        static List<AlbumsClass> Albums = new List<AlbumsClass>();
        static List<TracksClass> Tracks = new List<TracksClass>();
        public static string ConnectionString { private get; set; }
        static void Main(string[] args)
        {
            ConnectionString =
                "Server = (localdb)\\MSSQLLocalDB;" +
                "Database = music;";
            Console.WriteLine("wow");
            LFeltoltes();
            DFeltoltes();
            Console.WriteLine("wow2");
            Console.ReadKey(true);
        }

        private static void DFeltoltes()
        {
            using (var c = new SqlConnection(ConnectionString))
            {
                c.Open();
                foreach (var d in Albums)
                {
                    var r = new SqlCommand(
                        $"INSERT INTO Albums VALUES ('{d.id}', '{d.artist}', '{d.title}', '{d.release}');", c).ExecuteNonQuery();
                }
                foreach (var d in Tracks)
                {
                    var r = new SqlCommand(
                        $"INSERT INTO Tracks VALUES ('{d.title}', '{d.length}', '{d.album}', '{d.url}');", c).ExecuteNonQuery();
                }
            }
        }

        private static void LFeltoltes()
        {
            using (var sr = new StreamReader(@"..\..\res\pendulum.txt", Encoding.UTF8))
            {
                sr.ReadLine();
                string sor = "";
                while (!sor.Contains("[tracks]"))
                {
                    sor = sr.ReadLine();
                    if (!sor.Contains("[tracks]"))
                    {
                        Albums.Add(new AlbumsClass(sor));
                    }
                    else
                    {
                        sr.ReadLine();
                    }
                }
                while (!sr.EndOfStream)
                {
                    Tracks.Add(new TracksClass(sr.ReadLine()));
                } 
            }
        }
    }
}
