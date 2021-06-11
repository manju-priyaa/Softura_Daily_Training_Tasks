using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreDb
{
    class Program
    {
        //using stored procedure to insert values
        public string BookSP(string title,int aid,double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            SqlCommand cmd = new SqlCommand("sp_INSBooks", con);


            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            //cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            //cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value =price;

            //or

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@Title";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Value = title;
            cmd.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@AuthorID";
            p2.SqlDbType = SqlDbType.Int;
            p2.Value = aid;
            cmd.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@Price";
            p3.SqlDbType = SqlDbType.Money;
            p3.Value = price;
            cmd.Parameters.Add(p3);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            res = "Success";
            return res;

        }
        public void InsertBooks()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            //SqlCommand cmd = new SqlCommand("insert into tbl_Books values('Harry Potter' , 3, 950)", con);


            //or

            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "insert into tbl_Books values('Two States',1,650)";
            //cmd.Connection = con;

            //or

            string qry = "insert into tbl_Books values(@Title,@AuthorID,@Price)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Title", "Davinci Code");
            cmd.Parameters.AddWithValue("@AuthorID", 7);
            cmd.Parameters.AddWithValue("@Price", 400);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateBooks()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            Console.WriteLine("Enter the Book Id to be Updated");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Book Title to be Updated");
            string title = Console.ReadLine();
            string strCmd = "Update tbl_Books set Title=@title where BookID=@id";
            SqlCommand cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@title", title);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Book Updated");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }


        }

        //static void Main(string[] args)
        //{
        //    Program obj = new Program();
        //    //obj.InsertBooks();
        //    //obj.UpdateBooks();
        //    //obj.BookSP("Mind Master", 8, 400);
        //    obj.BookSP("Sivagami Sabhadam",2 , 250 );

        //    //SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
        //    //SqlCommand cmd = new SqlCommand("select * from tbl_Books", con);

        //    ////Connected Architechure
        //    //con.Open();
        //    ////Execute Reader goes to the db reads and returns back the data
        //    //SqlDataReader rdr = cmd.ExecuteReader();
        //    //while(rdr.Read())
        //    //    Console.WriteLine(rdr["BookID"]+ " " + rdr["Title"] + " " + rdr["Price"].ToString());
        //    //con.Close();

        //    Console.ReadLine();
        //}
    }
}
