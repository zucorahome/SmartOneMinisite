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
      public String AddUSignupEmail(IConfiguration configuration, String SignupEmail)
      {
         bool IsDbAvailable = DbAvailableStatus(configuration);
         String returnMessage = "";

         if (IsDbAvailable)
         {
            String DbConnectionString = configuration.GetConnectionString("DbConnectionStrDevLocal");
            using (SqlConnection conn = new SqlConnection(DbConnectionString))
            {
               conn.Open();
               string sql = "AddUpdateSmartOneMinisiteSignupEmail";

               using (SqlCommand cmd = new SqlCommand(sql, conn))
               {
                  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@SignupEmail", SignupEmail);
                  int resultInt = cmd.ExecuteNonQuery();
                  returnMessage = resultInt > 0 ? "Email Address[" + SignupEmail + "] is saved." : "Email Address[" + SignupEmail + "] either already exists or there was an issue saving this email.";
               }
            }



         }
         return returnMessage;

      }


      private bool DbAvailableStatus(IConfiguration configuration)
      {
         bool DbAvailable = false;
         //String DbConnectionString = configuration.GetConnectionString("DbConnectionStrDev");
         String DbConnectionString = configuration.GetConnectionString("DbConnectionStrDevLocal");
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
