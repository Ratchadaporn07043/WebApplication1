using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace WebApplication1.Pages.Rangsit
{
    public class IndexRangsitModel : PageModel
    {
        public List<StockInfo> ListSTOCKS = new List<StockInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:inventory07043.database.windows.net,1433;Initial Catalog=invenntory;Persist Security Info=False;User ID=Ratchadaporn;Password=Ratcha.07043;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM STOCKS WHERE storeid=1";
                    using (SqlCommand command = new SqlCommand(sql,connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        { 
                            while (reader.Read())
                            {
                                StockInfo stockInfo = new StockInfo();
                                stockInfo.itemid = "" + reader.GetInt32(0);
                                stockInfo.item = reader.GetString(1);
                                stockInfo.storeid = reader.GetString(2);
                                stockInfo.supplier = reader.GetString(3);
                                stockInfo.amount = reader.GetString(4);
                                stockInfo.create_at = reader.GetDateTime(5).ToString();

                                ListSTOCKS.Add(stockInfo);
                                       
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception :" + ex.ToString());
            }
        }
            
    }

    public class StockInfo {
        public String itemid;
        public String item;
        public String storeid;
        public String supplier;
        public String amount;
        public String create_at;
    }
}
