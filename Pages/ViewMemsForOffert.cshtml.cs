using MeMoney.DBases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace MeMoney.Pages
{
    public class ViewMemsForOffertModel : PageModel
    {
        public static int offerId;
        public int OfferId;
        private bool wykonywacz = true;
        private string connetionString = "Server=(localdb)\\MSSQLLocalDB;Database=MyDb;Trusted_Connection=True;";
        private SqlConnection con;
        public int numOfMems;
        private int copyOfNumMems;
        public void OnGet()
        {
            OfferId = offerId; 

            if (wykonywacz)
            {
                wykonywacz = false;
                con.Open();
                string query = $"SELECT COUNT(*) FROM OfferMem WHERE OfferId1 = {OfferId}";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    numOfMems = reader.GetInt32(0);
                    copyOfNumMems = numOfMems;
                }
                reader.Close();
                con.Close();
            }
        }

        public string LinkOfMem()
        {
            copyOfNumMems--;
            string returner = "";
            con.Open(); //Tutaj pokaza³ siê b³¹d Ÿle skonfigurowanej bazy danych. nie ma po³¹czenia oferta-mem. Mimo wszystko, je¿eli zostanie zamontowane, to wystarczy zamieniæ MemAuthorId na nazwê id memów, OfferId1 na nazwê id ofert, OfferId ma mazwê id tejtabelki poprawionej, oraz OfferMem na nazwê nowej tabelki
            string query = $"SELECT MemAuthorId FROM OfferMem WHERE OfferId1 = {OfferId} ORDER BY OfferId OFFSET {copyOfNumMems} ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                returner = reader.ToString();
            }
            reader.Close();
            con.Close();
            return returner;
        }
    }
}
