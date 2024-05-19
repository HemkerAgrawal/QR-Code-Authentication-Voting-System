using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SQLite;
using System.Data;
//using VoteApi.Data;
/*using VoteApi.Models;
using System.Web.Http.Results;*/


using Microsoft.AspNetCore.Http;
using VoteApi.Models;
using VoteApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace VoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
     // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\inetpub\wwwroot\FingerPrint_Voting_Systen\bin\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");

        SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\ishee\source\repos\FingerPrint_Voting_Systen\bin\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");
        private readonly IConfiguration _configuration;
     //   private MyDbContext db = new MyDbContext();


        public ValueController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            // var connectionString = _configuration.GetConnectionString("SQLiteConnection");
            con.Open();
            //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            //   {
            //    connection.Open();
            //    string query = "SELECT * FROM registration"; // Replace 'YourTable' with the actual table name.
            string query = "select * from registration where id like '" + id + "'";
            using (SQLiteCommand command = new SQLiteCommand(query, con))
                {
                    var results = new List<ClassMail>();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        var model = new ClassMail
                        {

                            name = reader.GetString(reader.GetOrdinal("name")),
                            email = reader.GetString(reader.GetOrdinal("email")),
                            dob = reader.GetString(reader.GetOrdinal("dob")),
                            phone = reader.GetString(reader.GetOrdinal("phone")),
                            fp = reader.GetString(reader.GetOrdinal("fp")),
                            address = reader.GetString(reader.GetOrdinal("address")),
                            qr = reader.GetString(reader.GetOrdinal("qr")),
                            id = reader.GetString(reader.GetOrdinal("id")),
                            vote = reader.GetString(reader.GetOrdinal("vote")),
                            extra1 = reader.GetString(reader.GetOrdinal("extra1"))


                       // id = reader.GetInt32(reader.GetOrdinal("Id")), // Map the "Id" column to the Id property
                         //       Name = reader.GetString(reader.GetOrdinal("Name")), // Map the "Name" column to the Name property
                           //     Description = reader.GetString(reader.GetOrdinal("Description")) // Map the "Description" column to the Description property
                                                                                                 // Map data from reader to MyModel properties
                            };
                            results.Add(model);
                        }
                    }

                    //update started
                    string updateQuery = "UPDATE registration SET vote = 1 WHERE id  like '" + id + "'";
                    using (SQLiteCommand command2 = new SQLiteCommand(updateQuery, con))
                    {
                        /*    command.Parameters.AddWithValue("@Name", model.Name);
                            command.Parameters.AddWithValue("@Description", model.Description);
                            command.Parameters.AddWithValue("@Id", id);*/

                        int rowsAffected = command2.ExecuteNonQuery();
                    }//update end
                    return new JsonResult(results);
                }
            con.Close();
            //}
        }


        [HttpPost]
        //  public IHttpActionResult Create(ClassMail model)
        //  public HttpResponseMessage Create(ClassMail model)
        public String Create(ClassMail model)
        {
            if (!ModelState.IsValid)
            {
                //  return BadRequest(ModelState);
                return "Bad Request";
            }
            con.Open();
         //   using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                //  connection.Open();

                // string insertQuery = "INSERT INTO YourTable (Name, Description) VALUES (@Name, @Description)";
                string insertQuery = "INSERT INTO registratiob(name, email,dob, phone, fp, address, qr, id, vote, extra1 ) VALUES (@name, @email, @dob, @phone, @fp, @address, qr, @id, @vote, @extra1)";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, con))
                {
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@dob", model.dob);
                    command.Parameters.AddWithValue("@phone", model.phone);
                    command.Parameters.AddWithValue("@fp", model.fp);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@qr", model.qr);
                    command.Parameters.AddWithValue("@id", model.id);
                    command.Parameters.AddWithValue("@vote", model.vote);
                    command.Parameters.AddWithValue("@extra1", model.extra1);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        //   return StatusCode(HttpStatusCode.Created);
                        //  return "Created: Data inserted successfully";
                        return "Yes";
                    }
                }
            }

            // return InternalServerError();
            //  return Request.CreateResponse(HttpStatusCode.InternalServerError);
            // return "Internal Server Error: Data insertion failed";
            return "No";
        }

        [HttpPut]
        //   public string Update(int id, ClassMail model)
        public string Update(string id)
        {
            if (!ModelState.IsValid)
            {
                return "Bad Request: Invalid data"; // Custom message for a validation error
            }
            con.Open();
          //  using (SQLiteConnection connection = new SQLiteConnection(connectionString))
           // {
                //connection.Open();

                //    string updateQuery = "UPDATE registration SET vote = 1, WHERE id = @Id";
                 //  string updateQuery = "UPDATE registration SET vote = 1, WHERE id = @id";
                string updateQuery = "UPDATE registration SET vote = 1 WHERE id  like '" + id + "'";
                using (SQLiteCommand command = new SQLiteCommand(updateQuery, con))
                {
                /*    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Description", model.Description);
                    command.Parameters.AddWithValue("@Id", id);*/

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "Updated: Data updated successfully"; // Custom success message
                    }
                }
           // }
            con.Close();
            return "Internal Server Error: Data update failed"; // Custom error message
        }


        [HttpDelete]
        public string Delete(int id)
        {
            con.Open();
          //  using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
//                connection.Open();

                string deleteQuery = "DELETE FROM registration WHERE id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(deleteQuery, con))
                {
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "Deleted: Data deleted successfully"; // Custom success message
                    }
                }
            }
            con.Close();
            return "Not Found: Data with the specified ID not found"; // Custom message for resource not found
        }


    }



    // Other action methods

    /*  [HttpPut]
      public IHttpActionResult Update(int id, UpdateModel model)
      {
          if (!ModelState.IsValid)
          {
              return BadRequest(ModelState);
          }

          var existingData = db.MyModels.Find(id);

          if (existingData == null)
          {
              return NotFound();
          }

          existingData.Name = model.Name;
          existingData.Description = model.Description;

          db.Entry(existingData).State = EntityState.Modified;

          try
          {
              db.SaveChanges();
          }
          catch (DbUpdateConcurrencyException)
          {
              if (!DataExists(id))
              {
                  return NotFound();
              }
              else
              {
                  throw;
              }
          }

          return StatusCode(HttpStatusCode.NoContent);
      }

      private bool DataExists(int id)
      {
          return db.MyModels.Any(e => e.Id == id);
      }  */










    /*    [HttpGet]
        public JsonResult Get(string id)
       // public String Get(string id)
        {
            con.Open();
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter("select * from registration where id like '" + id + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
               // var result = dt;
                string a = dt.Rows[0].Field<string>(8);
                int i = Int32.Parse(a);
                if (i == 0)
                {
                    SQLiteCommand cmd = new SQLiteCommand("UPDATE registration SET vote='" + 1 + "' WHERE id='" + id + "'", con);
                    cmd.ExecuteNonQuery();
                    var result = "YES";
                    //ClassMail c = JsonSerializerSettings(result);
                    return new JsonResult(Ok(result));

                    // return "Yes";
                  //  return JsonConvert.SerializeObject(dt);
                }
                else
                {
                    //return new JsonResult(Ok());
                     return new JsonResult(NotFound());
                    // return "Wrong Password";

                }

            }
            catch
            {
                return new JsonResult(NotFound());
                // return "Wrong Id";
            }
            con.Close();
            //  var result = _context.Bookings.Find(id);
            //if (result == null)
            //    return new JsonResult(NotFound());
            //return new JsonResult(Ok(result));
        }*/
}

