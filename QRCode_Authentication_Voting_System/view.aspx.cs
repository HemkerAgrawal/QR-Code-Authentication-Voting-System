using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;

namespace FingerPrint_Voting_Systen
{
    public partial class view : System.Web.UI.Page
    {
        SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        string pre_path = ConfigurationManager.AppSettings["proj_path"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tr();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //  SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\lenovo\source\repos\wapi1\App_Data\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");
            con.Open();

            SQLiteDataAdapter sda = new SQLiteDataAdapter("select * from party", con);
            //      SQLiteDataAdapter sda = new SQLiteDataAdapter("select ice,extra2,extra5,extra6,extra7 from t2 where item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%'", con);
            //   SQLiteDataAdapter sda = new SQLiteDataAdapter("select ice,extra2,extra5,extra6,extra7 from t2 where item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%'", con);


            DataTable ddt = new DataTable();
            sda.Fill(ddt);
            if (ddt.Rows.Count < 1)
            {
                Label1.Text = "Sorry the requested item is unavailabe.";
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




                SQLiteCommand cmd = new SQLiteCommand("select name,file from party", con);

                DataTable dt2 = new DataTable();
                SQLiteDataAdapter da1 = new SQLiteDataAdapter(cmd);
                da1.Fill(dt2);
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                con.Close();




                // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\lenovo\source\repos\wapi1\App_Data\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");
                con.Open();
                SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select name,file from party", con);
                //   SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select t2.itemcode,t2.item,t2.category,t2.sellprice,t2.photo,t2.extra2,t2.extra5,t2.extra6,t2.extra7,t5.quantity,t5.customerid from t2 inner join t5 on t2.itemcode = t5.itemcodes where (item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%') and t5.customerid = '" + TextBox2.Text + "'", con);
                DataTable ddt2 = new DataTable();
                sda2.Fill(ddt2);
                con.Close();

                ddt2.Merge(dt2);
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
         /*   if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "id";
                e.Row.Cells[1].Text = "name";
                e.Row.Cells[2].Text = "file";
                e.Row.Cells[3].Text = "extra1";
                //e.Row.Cells[4].Text = "Item";
                //e.Row.Cells[5].Text = "Category";
                //e.Row.Cells[6].Text = "Unit";
                //e.Row.Cells[7].Text = "Rate";
                //e.Row.Cells[8].Text = "Quantity";
                //e.Row.Cells[9].Text = "Amount";
                //e.Row.Cells[10].Text = "Status";
                //e.Row.Cells[10].Visible = false;

                // customerid,ordernumber,itemcode,item,category,quantity,amount,status,hsncode,photo,extra1,extra2,extra3,extra4,extra5
            }*/
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
         
        protected void Button2_Click(object sender, EventArgs e)
        {
            tr();
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
              //  Label4.Text = "Sorry the requested item is unavailabe.";
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



               /* SQLiteCommand cmd = new SQLiteCommand("select name,extra1,count from vote", con);

                DataTable dt2 = new DataTable();
                SQLiteDataAdapter da1 = new SQLiteDataAdapter(cmd);
                da1.Fill(dt2);
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                con.Close();  */



                // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\lenovo\source\repos\wapi1\App_Data\dbase.db;Version=3;Mode=ReadWrite;New=False;Compress=True;");
            //    con.Open();
                SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select name,extra1,count from vote", con);
                //   SQLiteDataAdapter sda2 = new SQLiteDataAdapter("select t2.itemcode,t2.item,t2.category,t2.sellprice,t2.photo,t2.extra2,t2.extra5,t2.extra6,t2.extra7,t5.quantity,t5.customerid from t2 inner join t5 on t2.itemcode = t5.itemcodes where (item like '" + TextBox6.Text + "%' or category like '" + TextBox6.Text + "%' or extra4 like '" + TextBox6.Text + "%' or extra8 like '" + TextBox6.Text + "%') and t5.customerid = '" + TextBox2.Text + "'", con);
                DataTable ddt2 = new DataTable();
                sda2.Fill(ddt2);
             //   con.Close();

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
    }
}