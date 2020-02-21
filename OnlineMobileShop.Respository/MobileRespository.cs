using System.Collections.Generic;
using OnlineMobileShop.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OnlineMobileShop.Respository
{
    public class MobileRespository
    {
        public static List<Mobile> mobilelist = new List<Entity.Mobile>();
        string sqlConnection = MobileRespository.GetDBConnection();
        static MobileRespository()
        {

            mobilelist.Add(new Mobile { MobileID = 1, Brand = "Nokia", Model = "y22", Battery = 3000, Price = 6000 });

            mobilelist.Add(new Mobile { MobileID = 2, Brand = "Vivo", Model = "v5", Battery = 4000, Price = 8000 });

            mobilelist.Add(new Mobile { MobileID = 3, Brand = "Oppo", Model = "f1", Battery = 5000, Price = 11000 });
        }
        public IEnumerable<Mobile> GetDetails()
        {
            return mobilelist;
        }

        public bool Add(Mobile mobile)
        {
                using (SqlConnection myConnection = new SqlConnection(sqlConnection))
                {
                    myConnection.Open();
                    string sql = "SP_InsertData";
                    SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Brand", mobile.Brand);
                    sqlCommand.Parameters.AddWithValue("@Model", mobile.Model);
                    sqlCommand.Parameters.AddWithValue("@Battery", mobile.Battery);
                    sqlCommand.Parameters.AddWithValue("@RAM", mobile.RAM);
                    sqlCommand.Parameters.AddWithValue("@ROM", mobile.ROM);
                    sqlCommand.Parameters.AddWithValue("@Price", mobile.Price);
                    int limit = sqlCommand.ExecuteNonQuery();
                    if (limit >= 1)
                    {
                        return true;

                    }
                    return false;
            }
            }
        public static void Delete(int MobileID)
        {
            Mobile mobile = GetMobileID(MobileID);
            if (mobile != null)
                mobilelist.Remove(mobile);
        }

        public static void Update(Mobile mobile)
        {
            Mobile mobilesValue = mobilelist.Find(id => id.MobileID == mobile.MobileID);
            mobilesValue.MobileID = mobile.MobileID;
            mobilesValue.Brand = mobile.Brand;
            mobilesValue.Model = mobile.Model;
            mobilesValue.Battery = mobile.Battery;
            mobilesValue.Price = mobile.Price;
        }
        public static Mobile GetMobileID(int MobileID)
        {
            return mobilelist.Find(id => id.MobileID == MobileID);
        }
        public static string GetDBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineMobileShop"].ConnectionString;
            return connectionString;
        }
    }
}