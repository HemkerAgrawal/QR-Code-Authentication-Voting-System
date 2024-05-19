using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Documents;
using System.Data;

namespace FingerPrint_Voting_Systen
{
    public partial class Nomination : System.Web.UI.Page
    {

        SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        string pre_path = ConfigurationManager.AppSettings["proj_path"].ToString();
        static string pass, photo, otp;
        static string s = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filePath = "";
            
            if (TextBox1.Text == "")
            {
                Label1.Text = "Please insert Party Name";
            }

            else if (FileUpload1.HasFile == false)
            { 

                Label1.Text = "Please insert Image!";
            }
            con.Open();

            SQLiteCommand cmd2 = new SQLiteCommand("select * from party where name like '" + TextBox1.Text + "'", con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {

          //  else
            //    {

                    if (FileUpload1.HasFile)
                    {

                        string spath = Path.GetExtension(FileUpload1.PostedFile.FileName);
                        if (spath != ".jpeg" && spath != ".jpg" && spath != ".png" && spath != ".gif")
                        {
                            Label1.Text = "Only jpeg, jpg, png or gif Image is allowed!";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }

                        string fname = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        //  FileUpload1.SaveAs(Server.MapPath("~/UserImage/") + fname);
                        FileUpload1.SaveAs(Server.MapPath("~/App_Data/UserImage/") + fname);
                        Label1.Text = "Image Saved!";
                        Label1.ForeColor = System.Drawing.Color.Green;
                        string gender = string.Empty;
                        Label2.Text = "";
                        const int bmpW = 600;

                        const int bmpH = 450;

                        //const int bmpW = 200;

                        //const int bmpH = 150;

                        if ((FileUpload1.HasFile))
                        {


                            Label2.Text = "";

                            if ((CheckFileType(FileUpload1.FileName)))
                            {

                                Int32 newWidth = bmpW;

                                Int32 newHeight = bmpH;

                                String upName = FileUpload1.FileName.Substring(0, FileUpload1.FileName.IndexOf("."));


                                filePath = ("~/image/") + upName + ".jpg";



                                Bitmap upBmp = (Bitmap)Bitmap.FromStream(FileUpload1.PostedFile.InputStream);

                                Bitmap newBmp = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                                newBmp.SetResolution(72, 72);



                                Double upWidth = upBmp.Width;

                                Double upHeight = upBmp.Height;

                                int newX = 0;

                                int newY = 0;

                                Double reDuce;


                                if (upWidth > upHeight)
                                {


                                    reDuce = newWidth / upWidth;



                                    newHeight = ((Int32)(upHeight * reDuce));



                                    newY = ((Int32)((bmpH - newHeight) / 2));



                                    newX = 0;

                                }

                                else if (upWidth < upHeight)
                                {


                                    reDuce = newHeight / upHeight;



                                    newWidth = ((Int32)(upWidth * reDuce));



                                    newX = ((Int32)((bmpW - newWidth) / 2));



                                    newY = 0;

                                }

                                else if (upWidth == upHeight)
                                {


                                    reDuce = newHeight / upHeight;



                                    newWidth = ((Int32)(upWidth * reDuce));



                                    newX = ((Int32)((bmpW - newWidth) / 2));


                                    newY = ((Int32)((bmpH - newHeight) / 2));


                                }


                                Graphics newGraphic = Graphics.FromImage(newBmp);

                                try
                                {

                                    newGraphic.Clear(Color.White);

                                    newGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                                    newGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                                    newGraphic.DrawImage(upBmp, newX, newY, newWidth, newHeight);

                                    newBmp.Save(MapPath(filePath), System.Drawing.Imaging.ImageFormat.Jpeg);
                                    Label2.Text = "Saved ";
                                }
                                catch (Exception ex)
                                {
                                    string newError = ex.Message;
                                    Label2.Text = newError;
                                }

                                finally
                                {

                                    upBmp.Dispose();

                                    newBmp.Dispose();

                                    newGraphic.Dispose();

                                }


                            try
                            {
                                //con.Open();
                                SQLiteCommand cmdc = new SQLiteCommand("insert into party values(@id,@name,@file,@extra1)", con);
                                cmdc.Parameters.AddWithValue("@id", 0);
                                cmdc.Parameters.AddWithValue("@name", TextBox1.Text);
                                cmdc.Parameters.AddWithValue("@file", filePath);
                                cmdc.Parameters.AddWithValue("@extra1", 1);



                                int k2 = cmdc.ExecuteNonQuery();


                                if (k2 != 0)
                                {
                                    Label1.Text = "Details saved successfully!";
                                    Label1.ForeColor = System.Drawing.Color.Green;
                                    TextBox1.Text = "";

                                }
                                else if (k2 == 0)
                                {
                                    Label1.Text = "There is some problem!";
                                    Label1.ForeColor = System.Drawing.Color.Red;
                                }

                                else
                                {
                                    Label1.Text = "Please insert Image!";
                                    Label1.ForeColor = System.Drawing.Color.Red;

                                }
                                //  }
                            }
                            catch(Exception exce) 
                            {
                                Label1.Text = exce.ToString();
                            }
                            con.Close();


                        }

                            else
                            {

                                Label2.Text = "Please select a picture with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png.";
                            }

                   

                    }
                }
            }
            else
            {
                Label2.Text = "Party Already Exists";

            }
        }
        public bool CheckFileType(string fileName)
        {

            string ext = Path.GetExtension(fileName);

            switch (ext.ToLower())
            {

                case ".gif":

                    return true;

                case ".png":

                    return true;

                case ".jpg":

                    return true;

                case ".jpeg":

                    return true;

                case ".bmp":

                    return true;

                default:

                    return false;

            }

        }
    }
        
}