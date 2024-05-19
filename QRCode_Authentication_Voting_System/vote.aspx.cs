using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace FingerPrint_Voting_Systen
{
    public partial class vote : System.Web.UI.Page
    {
        // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\ishee\source\repos\FingerPrint_Voting_Systen\bin\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");
        SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                string url;
                url = "Registration.aspx";
                Response.Redirect(url);
            }
            else
            {
                //Label2.Text = Session["id"].ToString();
                //s = Session["id"].ToString();
            }
            if (!IsPostBack)
            {
                tr();
            }
            //con.Open();
           // tr();
        }

        private void tr()
        {

            con.Open();
            SQLiteDataAdapter sda = new SQLiteDataAdapter("select * from vote", con);
            //      SQLiteDataAdapter sda = new SQLiteDataAdapter("select ice,extra2,extra5,extra6,extra7 from t2 where item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%'", con);
            //   SQLiteDataAdapter sda = new SQLiteDataAdapter("select ice,extra2,extra5,extra6,extra7 from t2 where item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%'", con);


            DataTable ddt = new DataTable();
            sda.Fill(ddt);
            if (ddt.Rows.Count < 1)
            {
                Label4.Text = "Sorry the requested item is unavailabe.";
                ddt.Clear();
                //   TextBox6.Text = "";
            }


            else
            {
                DataList1.Visible = true;
                //   SQLiteCommand cmd = new SQLiteCommand("select itemcode,item,category,sellprice,photo,extra2,extra5,extra6,extra7 from t2 where item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%'", con);
                /*Main Query*/ //      SQLiteCommand cmd = new SQLiteCommand("select t2.itemcode,t2.item,t2.category,t2.sellprice,t2.photo,t2.extra2,t2.extra5,t2.extra6,t2.extra7,t5.quantity,t5.customerid from t2 left join t5 on t2.itemcode=t5.itemcodes where item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%' and t5.customerid like '"+TextBox2.Text+"'", con);
                               //  SQLiteCommand cmd = new SQLiteCommand("select t2.itemcode,t2.item,t2.category,t2.sellprice,t2.photo,t2.extra2,t2.extra5,t2.extra6,t2.extra7 from t2 where (item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%') and itemcode NOT IN (select itemcodes from t5 where customerid ='" + TextBox2.Text + "')", con);
                               //DataSet ds = new DataSet();
                               //SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                               //da.Fill(ds);
                               //DataList1.DataSource = ds;
                               //DataList1.DataBind();
                               //con.Close();

                // con.Open();
        /*        SQLiteCommand cmd = new SQLiteCommand("select name,extra1 from vote", con);

                DataTable dt2 = new DataTable();
                SQLiteDataAdapter da1 = new SQLiteDataAdapter(cmd);
                da1.Fill(dt2);
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                con.Close();*/

                // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\lenovo\source\repos\wapi1\App_Data\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");
           //     con.Open();
                SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select name,extra1 from vote", con);
                //   SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select t2.itemcode,t2.item,t2.category,t2.sellprice,t2.photo,t2.extra2,t2.extra5,t2.extra6,t2.extra7,t5.quantity,t5.customerid from t2 inner join t5 on t2.itemcode = t5.itemcodes where (item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%') and t5.customerid = '" + TextBox2.Text + "'", con);
                DataTable ddt2 = new DataTable();
                sda2.Fill(ddt2);
            //    con.Close();

             //   ddt2.Merge(dt2);
                ddt2.AcceptChanges();
                DataList1.DataSource = ddt2;
                DataList1.DataBind();


                /*   con.Open();
                   // SQLiteDataAdapter cmd = new SQLiteDataAdapter("select * from party ", con);
                   SQLiteCommand cmd = new SQLiteCommand("select * from party", con);

                   DataTable dt = new DataTable();
                   SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                   da.Fill(dt);
                 //  using (dt = new DataTable())
                //   {
                       GridView1.DataSource = dt;
                       GridView1.DataBind();
                       con.Close();
                       da.Fill(dt);
                       GridView1.HeaderRow.Cells[0].Text = "id";
                       GridView1.HeaderRow.Cells[1].Text = "name";
                       GridView1.HeaderRow.Cells[2].Text = "file";
                       GridView1.HeaderRow.Cells[3].Text = "extra1";

                  // }*/
            }

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try {
                if (e.CommandName == "add")
                {
                    //string itemname = ((Label)e.Item.FindControl("Label17")).Text;
                    //string sellprice = ((Label)e.Item.FindControl("Label18")).Text;
                    //string category = ((Label)e.Item.FindControl("Label19")).Text;
                    //string itemcode = ((Label)e.Item.FindControl("Label20")).Text;
                    string val = ((Label)e.Item.FindControl("Label3")).Text;
                    Label4.Text = ((Label)e.Item.FindControl("Label3")).Text;

                    con.Open();
                    SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select count from vote where name like '"+ val +"'", con);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    string x = dt2.Rows[0][0].ToString();
                    int y = Int32.Parse(x) + 1;
                    string s = y.ToString();
                    //  int y = 2;
                    // MessageBox.Show(y.ToString());

                    // if (val == "")
                    /*  {
                          val = Label7.Text;
                      }*/
                    // int val2 = 0;

                    //    int val2 = Int32.Parse(val) + 1;
                    //   ((Label)e.Item.FindControl("Label16")).Text = val2.ToString();

                    //      SQLiteCommand cmdc = new SQLiteCommand("insert into t5 values(@date,@customerid,@itemcodes,@quantity,@slno,@rate,@amount)", con);
                    //   con.Open();

                    SQLiteCommand cmd2 = new SQLiteCommand("update vote set count = '" + s + "' where name like '"+val+"'", con);


                    // SQLiteCommand cmd2 = new SQLiteCommand("update vote set count = '"+ s +"'" ,con);// where name like '" +val+ "'", con);
                    //cmd2.Parameters.AddWithValue("name",)
                    //SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd2);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    Button3_Click(Button3, EventArgs.Empty);
//                    Button3_Click();
                   // ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "closeWindow();", true);

                  //  MessageBox.Show("Voted Successfully");

                    /*
                                    cmdc.Parameters.AddWithValue("@date", TextBox1.Text);
                                    cmdc.Parameters.AddWithValue("@customerid", TextBox2.Text);
                                    cmdc.Parameters.AddWithValue("@itemcodes", itemcode);
                                    cmdc.Parameters.AddWithValue("@rate", sellprice);
                                    cmdc.Parameters.AddWithValue("@amount", sellprice);
                                    cmdc.Parameters.AddWithValue("@quantity", val2);
                                    cmdc.Parameters.AddWithValue("@slno", TextBox8.Text);
                                    cmdc.ExecuteNonQuery();
                    */
                }
            }
            catch(Exception ex)
            {
                Label4.Text = ex.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tr();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Console.Beep(700,800);
            // ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('DONE', 'Voting Done Successfully',)", true);

            //  MessageBox.Show("VOTED SUCCESSULLY");
              Environment.Exit(0); 
        }
    }
}