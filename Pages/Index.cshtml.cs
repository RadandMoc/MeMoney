using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace MeMoney.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        string connetionString = "Server=(localdb)\\MSSQLLocalDB;Database=MyDb;Trusted_Connection=True;";
        SqlConnection con;
        public bool wykonywacz = true;
        public List<string> mems = new List<string>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (wykonywacz)
            {
                wykonywacz = false;
                con = new SqlConnection(connetionString);
                con.Open();
                string query = "SELECT TOP 20 MemLink FROM Mem ORDER BY IdMem DESC;";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        mems.Add(reader[i].ToString());
                    }
                }
                reader.Close();
                con.Close();
            }
        }

        public string GetMemSrc()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, mems.Count());
            string returner = mems[randomNumber].ToString();
            mems.RemoveAt(randomNumber);
            return returner;
        }

    }
}