using MeMoney.DBases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MeMoney.Pages
{
    public class SeeUsersModel : PageModel
    {
        public int CompanyId;
        public string CompanyName;
        public string CompanyManager;
        public string CompanyNIP;
        public string CompanyKRS;
        public bool isCompany;
        public int AuthorId;
        public string AuthorNickName;
        public string AuthorName;
        public string AuthorSecondName;
        public string AuthorBankAccount;
        public bool isAuthor;
        string connetionString = "Server=(localdb)\\MSSQLLocalDB;Database=MyDb;Trusted_Connection=True;";
        SqlConnection con;
        bool loadDatabase = true, loadDatabase2 = true;
        public void OnGet()
        {
            //Company Start
            string query;
            SqlCommand cmd;
            SqlDataReader reader;
            con = new SqlConnection(connetionString);
            con.Open();
            query = "SELECT MAX(IdCompany1) FROM Company";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            if (loadDatabase)
            {
                loadDatabase = false;
                if (reader.Read())
                {
                    CompanyId = reader.GetInt32(0) + 1;
                    if (CompanyId >= 0)
                    {
                        isCompany = true;
                    }
                    else
                        isCompany = false;
                }
            }
            reader.Close();
            con.Close();
            //MemAuthor Start
            con = new SqlConnection(connetionString);
            con.Open();
            query = "SELECT MAX(IdMemAuthor) FROM MemAuthor";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            if (loadDatabase2)
            {
                loadDatabase2 = false;
                if (reader.Read())
                {
                    AuthorId = reader.GetInt32(0) + 1;
                    if (AuthorId >= 0)
                    {
                        isAuthor = true;
                    }
                    else
                        isAuthor = false;
                }
            }
            reader.Close();
            con.Close();
        }

        public string CompanyData()
        {
            isCompany = true;
            CompanyId--;
            if(CompanyId < 0)
                isCompany = false;
            else
            {
                string query;
                SqlCommand cmd;
                SqlDataReader reader;
                con = new SqlConnection(connetionString);
                con.Open();
                query = $"SELECT CompanyName1, Person1, NIP1, KRS1 FROM Company WHERE IdCompany1={CompanyId}";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("CompanyName1")))
                        CompanyName = reader["CompanyName1"].ToString();
                    else
                        CompanyName = "Not added";
                    if (!reader.IsDBNull(reader.GetOrdinal("NIP1")))
                        CompanyNIP = reader["NIP1"].ToString();
                    else
                        CompanyNIP = "Not added";
                    if (!reader.IsDBNull(reader.GetOrdinal("Person1")))
                        CompanyManager = reader["Person1"].ToString();
                    else
                        CompanyManager = "Not added";
                    if (!reader.IsDBNull(reader.GetOrdinal("KRS1")))
                        CompanyKRS = reader["KRS1"].ToString();
                    else
                        CompanyKRS = "Not added";
                }
                else
                    isCompany= false;
                con.Close();
                reader.Close();
            }
            return "";
        }

        public string MemAuthorData()
        {
            isAuthor = true;
            AuthorId--;
            if (AuthorId < 0)
                isAuthor = false;
            else
            {
                string query;
                SqlCommand cmd;
                SqlDataReader reader;
                con = new SqlConnection(connetionString);
                con.Open();
                query = $"SELECT NickName, Imie, Nazwisko, BankAccountNumber FROM MemAuthor WHERE IdMemAuthor={AuthorId}";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("NickName")))
                        AuthorNickName = reader["NickName"].ToString();
                    else
                        AuthorNickName = "Not added";
                    if (!reader.IsDBNull(reader.GetOrdinal("Imie")))
                        AuthorName = reader["Imie"].ToString();
                    else
                        AuthorName = "Not added";
                    if (!reader.IsDBNull(reader.GetOrdinal("Nazwisko")))
                        AuthorSecondName = reader["Nazwisko"].ToString();
                    else
                        AuthorSecondName = "Not added";
                    if (!reader.IsDBNull(reader.GetOrdinal("BankAccountNumber")))
                        AuthorBankAccount = reader["BankAccountNumber"].ToString();
                    else
                        AuthorBankAccount = "Not added";
                }
                else
                    isAuthor = false;
                con.Close();
                reader.Close();
            }
            return "";
        }

    }
}
