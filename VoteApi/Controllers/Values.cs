using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;
using VoteApi.Models;

namespace VoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Values : ControllerBase
    {

        //[HttpGet]
        //public ActionResult<IEnumerable<MyModel>> Get()
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(Configuration.GetConnectionString("SQLiteConnection")))
        //    {
        //        connection.Open();
        //        string query = "SELECT * FROM YourTable"; // Replace 'YourTable' with the actual table name.
        //        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //        {
        //            List<MyModel> results = new List<MyModel>();
        //            using (SQLiteDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var model = new MyModel
        //                    {
        //                        // Map data from reader to MyModel properties
        //                    };
        //                    results.Add(model);
        //                }
        //            }
        //            return Ok(results);
        //        }
        //    }
        //}

    }
}
