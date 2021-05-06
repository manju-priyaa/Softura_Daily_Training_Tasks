using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOExampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            //connect to the sql server and security enable and use pubs to use queries
            conString = @"server=DESKTOP-L4O7HT2;Integrated security= true; Initial catalog=pubs";
            //sqlconnection is done here..
            con = new SqlConnection(conString);
        }

        // add a movie tpo the database
        // case 1
        void AddMovie()
        {
            Console.WriteLine("Please enter the movie name");
            string mName = Console.ReadLine();
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            //@ is the userdefined variable
            string strCmd = "insert into tblMovie(name,duration) values(@mname,@mdur)";
            //getting the parameter
            cmd = new SqlCommand(strCmd, con);
            //add with value contains two parameters as below
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                //becasue insert query returns a integer 0 if not inserted or 1 if inserted
                //
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Movie inserted");
                }
                else
                {
                    Console.WriteLine("Movie not inserted");
                }
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

        //To print all the movies from Database
        //case 2
        void FetchMoviesFromDatabase()
        {
            //write query
            string strcmd = "Select * from tblMovie";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                //open the connection
                con.Open();
                // this will return the sqldatareader
                //Data Reader is user to read the data from the Sql connected architecture
                SqlDataReader drMovie = cmd.ExecuteReader();
                //this loop will continue until there are elements in the authors table here tbl movie
                while (drMovie.Read())
                {
                    // get the value by accessing the index
                    Console.WriteLine("Movie Id : "+ drMovie[0].ToString());
                    Console.WriteLine("Movie  Name: " + drMovie[1]);
                    Console.WriteLine("Movie Duration : " + drMovie[2].ToString());
                    Console.WriteLine("---------------------------------");
                }
            }
            catch(SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                //this block will be executed whther or not the try catch is executed
                con.Close();
                //close the connection
            }
        }

        // to print one movie from datbase with id
        //case 3
        void FetchOneMoviesFromDatabase()
        {
            //write query
            string strcmd = "Select * from tblMovie where id=@mid";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                //open the connection
                con.Open();
                Console.WriteLine("Please enter the Id");
                int id = Convert.ToInt32(Console.Read());
                //spdbtype indicate sthe type of the input 
                //we can use PARAMETER .ADDWITHVALUE OR THIS ASLO   
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                // this will return the sqldatareader
                //Data Reader is user to read the data from the Sql
                SqlDataReader drMovie = cmd.ExecuteReader();
                //this loop will continue until there are elements in the authors table here tbl movie
                while (drMovie.Read())
                {
                    // get the value by accessing the index
                    Console.WriteLine("Movie Id : " + drMovie[0].ToString());
                    Console.WriteLine("Movie Name: " + drMovie[1]);
                    Console.WriteLine("Movie Duration : " + drMovie[2].ToString());
                    Console.WriteLine("---------------------------------");
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                //this block will be executed whther or not the try catch is executed
                con.Close();
                //close the connection
            }
        }

        //update a movie by duration
        //case 4
        void UpdateMovieDuration()
        {
            Console.WriteLine("Please enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "Update tblMovie set duration = @mduration where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            cmd.Parameters.AddWithValue("@mduration", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Movie Duration Updated");
                }
                else
                {
                    Console.WriteLine("Movie Duration not updated");
                }
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
        //delete movie

        //case 5

        void DeleteMovie()
        {
            Console.WriteLine("Please enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());
            string strCmd = "delete from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid",id);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Movie Deleted");
                }
                else
                {
                    Console.WriteLine("Movie not Deleted");
                }
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
        
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add a Movie ");
                Console.WriteLine("2. Print All the movies ");
                Console.WriteLine("3. Print movie using Id ");
                Console.WriteLine("4. Update the Movie duration");
                Console.WriteLine("5. Delete The Movie ");
                Console.WriteLine("6. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        FetchMoviesFromDatabase();
                        break;
                    case 3:
                        FetchOneMoviesFromDatabase();
                        break;
                    case 4:
                        UpdateMovieDuration();
                        break;
                    case 5:
                        DeleteMovie();
                        break;
                    case 6:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }

            } while (choice != 6);

        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Program program = new Program();
            program.PrintMenu();

        }
    }
}
