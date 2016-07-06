using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data.SqlClient;
using AP_Sample;

namespace AP_Site.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class AddVehicleController : ApiController
    {
        public string Get(string vin, string make, string model, int cyl, int trans)
        {
            Car commuter = new Car(vin, make, model, cyl, (Car.TransType) trans);

            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AP_DB"].ConnectionString;
            
            string queryStr = "INSERT INTO dbo.Vehicles (VIN, Make, Model, Cylinders, Transmission) " +
                   "VALUES (@VIN, @Make, @Model, @Cylinders, @Transmission) ";

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = 2;
            cmd.Parameters.Add("@VIN", System.Data.SqlDbType.VarChar, 255).Value = vin;
            cmd.Parameters.Add("@Make", System.Data.SqlDbType.VarChar, 25).Value = make;
            cmd.Parameters.Add("@Model", System.Data.SqlDbType.VarChar, 25).Value = model;
            cmd.Parameters.Add("@Cylinders", System.Data.SqlDbType.Int).Value = cyl;
            cmd.Parameters.Add("@Transmission", System.Data.SqlDbType.Int).Value = trans;

            string statStr = "Vehicle added successfully...";

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                statStr = ex.Message;
            }            

            return statStr;
        }
    }
}
