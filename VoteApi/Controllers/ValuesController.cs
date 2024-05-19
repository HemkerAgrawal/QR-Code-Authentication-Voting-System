using System.Data.SQLite;
using System.Data;
using Newtonsoft.Json;
using System.Web.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;
//using Microsoft.AspNetCore.Mvc;

namespace VoteApi.Controllers
{
    // [RoutePrefix("api/Mail/{id}")]

  //  [ApiController]
    [Route("[controller]")]
    public class ValuesController
    {


        // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\lenovo\source\repos\wapi1\App_Data\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");
        SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\ishee\source\repos\FingerPrint_Voting_Systen\bin\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");
        //  C:\Users\ishee\source\repos\FingerPrint_Voting_Systen\bin
        
        
        [Route("api/values/{id}")]

        public string Get(string id)//, string p, string no)
        {

            con.Open();

            //    string c = "select exists(select abc from t1 where id like '" + id + "')";
            //    string ab = "abc";
            //if (string.Equals(c, ab))
            //{
            try
            {
                //  SQLiteDataAdapter sda = new SQLiteDataAdapter("select * from t1 where id like '" + id + "'", con);
                SQLiteDataAdapter sda = new SQLiteDataAdapter("select * from registration where id like '" + id + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string a = dt.Rows[0].Field<string>(8);
//                string a1 = dt.Rows[0].Field<string>(1);
                int i = Int32.Parse(a);
            //    int j = i + 1;
             //   int d = Int32.Parse(no);
                //  string a = dt.Rows[0].Field<string>(2);
                //if (a == c1.name2)
                //{
                //        SQLiteCommand cmd = new SQLiteCommand("insert into t2(name,name2) values('" + c1.name + "','" + c1.name2 + "')", con);
                //        cmd.ExecuteNonQuery();
                //    //    // con.Close();
                //    return "true";

                //}
                //else
                //{
                //    // con.Open();
                //    SQLiteCommand cmd = new SQLiteCommand("insert into t3(name,name2) values('" + c1.name + "','" + c1.name2 + "')", con);
                //    cmd.ExecuteNonQuery();
                //    return "false";
                //}

                if (i == 0)
                {

                    // SQLiteCommand cmd = new SQLiteCommand("UPDATE t1 SET no='" + j.ToString() + "' WHERE id='" + id + "'", con);
                    SQLiteCommand cmd = new SQLiteCommand("UPDATE registration SET vote='" + 1 + "' WHERE id='" + id + "'", con);


                    //  con.Open();
                    cmd.ExecuteNonQuery();
                    // con.Close();
                    string url;
                    //   url = "https://localhost:44381/customerpage.aspx?id =" + id;
                    url = "https://google.com";
                //    Redirect(url);
                 //   return "T";
                     return JsonConvert.SerializeObject(dt);

                    //  return "data found";
                }
                else
                {
                    return "Wrong Password";

                }
                //}
                //else
                //{
                //    return "wrong";
                //}
            }
            catch
            {
                return "Wrong Id";
            }
            // cmd.ExecuteNonQuery();
            con.Close();
            //    //SQLiteCommand cmd = new SQLiteCommand("insert into t2(name,name2) values('" + c1.name + "','" + c1.name2 + "')", con);
            //    //cmd.ExecuteNonQuery();
            //    return false;
            //}


            //   SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select * from t1 where id like '" + id + "'", con);
          /*     SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select * from registration where id like '" + id + "'", con);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt2);  */
            //   // return "data found";
            //}
            //else
            //{
            //    return "no data found";
            //}
            //con.Close();
            //return "value";
        }
    }
}
