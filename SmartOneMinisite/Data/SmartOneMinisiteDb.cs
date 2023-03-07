using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SmartOneMinisite.Data
{
   public class SmartOneMinisiteDb
   {
      public int AddSignupEmail(IConfiguration configuration, String SignupEmail)
      {
         bool IsDbAvailable = DbAvailableStatus(configuration);
         int resultInt = -1;

         if (IsDbAvailable)
         {
            String DbConnectionString = configuration.GetConnectionString("DbConnectionStrDev");
            using (SqlConnection conn = new SqlConnection(DbConnectionString))
            {
               conn.Open();
               string sql = "AddUpdateSmartOneMinisiteSignupEmail";

               using (SqlCommand cmd = new SqlCommand(sql, conn))
               {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@SignupEmail", SignupEmail);
                   object result = cmd.ExecuteScalar();//{-1: A problem has occurred, 0: Saved successfully, 1: email already exists.}

                   if (result != null)
                   {
                        try
                        {
                            resultInt = Int32.Parse(result.ToString());
                        }
                        catch
                        {

                        }
                   }                                      
               }
            }



         }
         return resultInt;

      }


      private bool DbAvailableStatus(IConfiguration configuration)
      {
         bool DbAvailable = false;
         //String DbConnectionString = configuration.GetConnectionString("DbConnectionStrDev");
         String DbConnectionString = configuration.GetConnectionString("DbConnectionStrDev");
         using (SqlConnection conn = new SqlConnection(DbConnectionString))
         {
            try
            {
               conn.Open();
               DbAvailable = true;
            }
            catch (Exception ex)
            {
               String message = ex.Message;
            }

         }
         return DbAvailable;
      }
   }
}
