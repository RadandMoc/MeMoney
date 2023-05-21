using MeMoney.DBases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MeMoney.Pages
{
    public class ViewOffersModel : PageModel
    {
        //RM
        string connetionString = "Server=(localdb)\\MSSQLLocalDB;Database=MyDb;Trusted_Connection=True;";
        SqlConnection con;
        bool loadDatabase = true;
        public int idOfOffer;
        public int idCompanyOffer;
        public string companyName = "";
        public string companyNIP = "";
        public decimal basicPayment;
        public decimal bonusPayment;
        public decimal residualIncome;
        public string requirement = "";
        public string additionalRequirement = "";
        public DateTime deadline;
        public bool isOffer = false;
        public int startOfferts = 0;

        public void OnGet()
        {
            string query;
            SqlCommand cmd;
            SqlDataReader reader;
            con = new SqlConnection(connetionString);
            con.Open();
            query = "SELECT MAX(Id) FROM Offer";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            if (loadDatabase)
            {
                loadDatabase = false;
                if (reader.Read())
                {
                    idOfOffer = reader.GetInt32(0) +1;
                    if (idOfOffer >= 0)
                    {
                        isOffer = true;
                    }
                }
            }
            reader.Close();
            //Start(loadDatabase);
            if (Wielorazowka() == "false")
                idOfOffer++;
            con.Close();
        }

        public void Start(bool wykonywacz)
        {
            if (wykonywacz)
            {
                wykonywacz = false;
                con.Open();
                string query = "SELECT COUNT(*) FROM Offer";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    idOfOffer = reader.GetInt32(0);
                }
                reader.Close();
                con.Close();
            }
        }

        public string Wielorazowka()
        {
            idOfOffer--;
            if (idOfOffer < 0)
            {
                isOffer = false;
            }
            else
            {
                string query;
                SqlCommand cmd;
                SqlDataReader reader;
                con = new SqlConnection(connetionString);
                con.Open();
                query = $"SELECT IfPaid FROM Offer WHERE Id={idOfOffer}";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetBoolean(reader.GetOrdinal("IfPaid")))
                    {
                        isOffer = true;
                        reader.Close();
                        query = $"SELECT CompanyIdCompany1 FROM Offer WHERE Id={idOfOffer}";
                        cmd = new SqlCommand(query, con);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            idCompanyOffer = reader.GetInt32(0);
                        }
                        reader.Close();
                        query = $"SELECT CompanyName1, NIP1 FROM Company WHERE IdCompany1={idCompanyOffer}";
                        cmd = new SqlCommand(query, con);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("CompanyName1")))
                                companyName = reader["CompanyName1"].ToString();
                            else
                                companyName = "Not added";
                            if (!reader.IsDBNull(reader.GetOrdinal("NIP1")))
                                companyNIP = reader["NIP1"].ToString();
                            else
                                companyNIP = "Not added";
                        }
                        reader.Close();
                        query = $"SELECT BasicSalary, AdditionalSalary, ValidUntil, Condition, AdditionalCondition, MaximalSalary1 FROM Offer WHERE Id={idOfOffer}";
                        cmd = new SqlCommand(query, con);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            basicPayment = (decimal)reader["BasicSalary"];
                            bonusPayment = (decimal)reader["AdditionalSalary"];
                            residualIncome = (decimal)reader["MaximalSalary1"];
                            requirement = reader["Condition"].ToString();
                            additionalRequirement = reader["AdditionalCondition"].ToString();
                            deadline = (DateTime)reader["ValidUntil"];
                        }
                    }
                    else
                        isOffer = false;
                }
                reader.Close();
                con.Close();
            }
            return "";
        }

        //public IActionResult OnGetPartial() => Partial("_OfferBox");
        public string AddOneToStartOffer()
        {
            startOfferts++;
            return "";
        }

        public string RandomMemeToButton()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 5);
            switch (randomNumber)
            {
                case 1:
                    return "https://i.imgflip.com/6c76pg.jpg";
                case 2:
                    return "https://indianmemetemplates.com/wp-content/uploads/Spider-man-whispering.jpg";
                case 3:
                    return "https://m.natemat.pl/76a8420d6f4b0f3f0666fcd2b8fabacc,1050,0,0,0.jpg";
                case 4:
                    return "https://m.natemat.pl/96ddf4e7259c118b0d70b77b012bb109,1050,0,0,0.jpg";
                default:
                    return "";
            }
        }

        public string LoadOffersView()
        {
            return $"https://localhost:7158/MemsView/pv?id={idOfOffer}";
        }

        public string DeleteOffer()
        {
            return $"https://localhost:7158/Offers/Delete?id={idOfOffer}";
        }

    }
}
