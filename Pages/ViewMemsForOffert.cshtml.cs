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
                con = new SqlConnection(connetionString);
                con.Open();
                string query = $"SELECT COUNT(*) FROM OfferMem WHERE OfferId = {OfferId}";
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
            int first = 0;
            con = new SqlConnection(connetionString);
            con.Open(); //Tutaj pokaza� si� b��d �le skonfigurowanej bazy danych. nie ma po��czenia oferta-mem. Mimo wszystko, je�eli zostanie zamontowane, to wystarczy zamieni� MemAuthorId na nazw� id mem�w, OfferId1 na nazw� id ofert, OfferId ma mazw� id tejtabelki poprawionej, oraz OfferMem na nazw� nowej tabelki
            string query = $"SELECT MemId FROM OfferMem WHERE OfferId = {OfferId} ORDER BY OfferMemId OFFSET {copyOfNumMems} ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                first = reader.GetInt32(0);
            }
            reader.Close();
            con.Close();
            con = new SqlConnection(connetionString);
            con.Open();
            query = $"SELECT MemLink FROM Mem WHERE IdMem = {first}";
            SqlCommand cmd2 = new SqlCommand(query, con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                returner = reader2["MemLink"].ToString();
            }
            reader2.Close();
            con.Close();
            return returner;
        }
    }
}
