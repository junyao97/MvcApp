using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class PersonController : Controller
    {
        [Route("person")]
        public ActionResult DisplayPerson()
        {
            List<PersonDatabase> PersonData = new List<PersonDatabase>();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand("SELECT * FROM Person", con);
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);

                        var NewPerson = new PersonDatabase() { ID = id, Name = name, Age = age };
                        PersonData.Add(NewPerson);
                    }
                }
            }
            return View("~/Views/PersonDatabase.cshtml", PersonData);
        }        
    }
}