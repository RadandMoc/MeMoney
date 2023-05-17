using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

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
        public string companyName ="";
        public string companyNIP ="";
        public decimal basicPayment;
        public decimal bonusPayment;
        public decimal residualIncome;
        public string requirement ="";
        public string additionalRequirement ="";
        public DateTime deadline;
        public void OnGet()
        {
            con = new SqlConnection(connetionString);
            Start(loadDatabase);
            string query = $"SELECT IfPaid FROM Offer WHERE Id={idOfOffer}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if(reader.GetBoolean(reader.GetOrdinal("IfPaid")))
                {
                    query = $"SELECT CompanyIdCompany1 FROM Offer WHERE Id={idOfOffer}";
                    cmd = new SqlCommand(query, con);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        idCompanyOffer = reader.GetInt32(0);
                    }
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
            }
            idOfOffer--;
            reader.Close();
        }

        public void Start(bool wykonywacz)
        {
            if(wykonywacz)
            {
                wykonywacz = false;
                con.Open();
                string query = "SELECT COUNT(*) FROM Offer";
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    idOfOffer = reader.GetInt32(0);
                }
                reader.Close();
            }
        }
    }
}
