using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreDb
{
    class BookShop
    {
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to Book Shop");
                Console.WriteLine("******* ** **** ****");
                Console.WriteLine("1. Display The Books Available ");
                Console.WriteLine("2. Insert a new Book ");
                Console.WriteLine("3. Update the Book Price ");
                Console.WriteLine("4. Delete the Book");
                Console.WriteLine("5. Display the Authors Available ");
                Console.WriteLine("6. Insert a new Author ");
                Console.WriteLine("7. Update the Author Name ");
                Console.WriteLine("8. Delete the Author");
                Console.WriteLine("9. Exit");
                Console.WriteLine("------------------------------------------");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SelectBook();
                        break;
                    case 2:
                        InsertBook();
                        break;
                    case 3:
                        UpdateBook();
                        break;
                    case 4:
                        DeleteBook();
                        break;
                    case 5:
                        SelectAuthor();
                        break;
                    case 6:
                        InsertAuthor();
                        break;
                    case 7:
                        UpdateAuthor();
                        break;
                    case 8:
                        DeleteAuthor();
                        break;
                    case 9:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
                Console.WriteLine("------------------------------------------");

            } while (choice != 9);

        }

       //case 1
         void SelectBook()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            SqlCommand cmd = new SqlCommand("select * from tbl_Books", con);

            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    Console.WriteLine(" Book ID :  " + rdr["BookID"] + " Title : " +rdr["Title"] + " Price : " + rdr["Price"] + " Author ID :  " + rdr["AuthorID"] .ToString());
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


        //case 2
         void InsertBook()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            Console.WriteLine("Enter the Book Title to be inserted :");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the corresponding Author Id : ");
            int auid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Price of the Book : ");
            double price = Convert.ToDouble(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("sp_INSBooks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = auid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value =price;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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


        //case 3
         void UpdateBook()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            Console.WriteLine("Enter the Book Id to be Updated");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Book Price to be Updated");
            double price = Convert.ToDouble(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("sp_UpdateBooks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", SqlDbType.NVarChar).Value = id;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.NVarChar).Value = price;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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


        //case 4

         void DeleteBook()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            Console.WriteLine("Enter the Book Id to be Deleted");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("sp_DeleteBooks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", SqlDbType.NVarChar).Value = id;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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

        //case 5
         void SelectAuthor()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            SqlCommand cmd = new SqlCommand("select * from tbl_Author", con);

            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    Console.WriteLine(" Author ID :  " + rdr["AuthorID"] + " Name : " + rdr["AuthorName"].ToString());
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

        //case 6
         void InsertAuthor()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            Console.WriteLine("Enter the Author Name to be inserted :");
            string name = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("sp_INSAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = name;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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


        //case 7
         void UpdateAuthor()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            Console.WriteLine("Enter the Author Id to be Updated");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Author Name to be Updated");
            string name = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("sp_UpdateAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.NVarChar).Value = id;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = name;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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


        //case 8
        void DeleteAuthor()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-L4O7HT2; database = BooksDb;Integrated security= true");
            Console.WriteLine("Enter the Author Id to be Deleted");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("sp_DeleteAuthor" +
                "", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.NVarChar).Value = id;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            };
        }




        static void Main(string[] args)
        {
            BookShop obj = new BookShop();
            obj.PrintMenu();
            Console.ReadLine();
        }
    }
}
