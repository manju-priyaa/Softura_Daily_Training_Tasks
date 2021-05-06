using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryAssignmentonMoviesProject
{
    class ManagerMovie
    {
        //use of dictionary
        public Dictionary<int, Movie> movies;
        //constructor
        public ManagerMovie()
        {
            movies = new Dictionary<int, Movie>();
        }

        //generate id for the movie using dictionary
        private int GenerateId()
        {
            if (movies.Count == 0)
            {
                return 1;
            }
            List<int> ids = movies.Keys.ToList();
            ids.Sort();
            int id = ids[ids.Count - 1];
            id++;
            return id;
        }
        //Create a single movie
        //case 1

        public Movie CreateMovie()
        {
            Movie movie = new Movie();
            movie.Id = GenerateId();
            movie.TakeMovieDetails();
            return movie;
        }
        //to check the Id using keys
        public int GetMovieIndexById(int id)
        {
            return movies.Keys.ToList().IndexOf(id);
        }

        // add a list of movies
        // case 2

        void AddMovies()
        {
            int choice = 0;
            do
            {
                Movie movie = CreateMovie();
                movies.Add(movie.Id, movie);
                Console.WriteLine("Do you wish to add another movie?? if yes enter any number other than 0. to exit enter 0");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Not a correct input");
                }
            } while (choice != 0);

        }

        // print the movie by id
        // case 3

        public void PrintMovieById()
        {
            Console.WriteLine("Please enter the movie to be printed");
            int id = Convert.ToInt32(Console.ReadLine());
            int idx = GetMovieIndexById(id);
            try
            {
                if (idx >= 0)
                {
                    PrintMovie(movies[idx]);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("no such movie");
            }

        }



        //print all the movies
        //case 4
        public void PrintAllMovies()
        {
            if (movies.Count == 0)
                Console.WriteLine("no movies present");
            else
            {
                foreach (var item in movies)
                {

                    PrintMovie(item.Value);
                }
            }
        }
        public void PrintMovie(Movie movie)
        {
            Console.WriteLine("---------");
            Console.WriteLine(movie);
            Console.WriteLine("--------");
        }

        //Update Movie by id
        //case 5

        private void UpdateMovie()
        {
            Console.WriteLine("Please enter the movie id for updation");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do you want to update name or the duration or both");
            string choice = Console.ReadLine().ToLower();
            string name;
            double duration;
            switch (choice)
            {
                case "name":
                    Console.WriteLine("Please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    break;
                case "duration":
                    Console.WriteLine("Please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid entryplease try again");
                    }
                    UpdateMovieDuration(id, duration);
                    break;
                case "both":
                    Console.WriteLine("Please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    Console.WriteLine("Please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid entryplease try again");
                    }
                    UpdateMovieDuration(id, duration);
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;
            }
        }
        //update movie by duration
        public Movie UpdateMovieDuration(int id, double duration)
        {
            Movie movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                movies[idx].Duration = duration;
                movie = movies[idx];
            }
            return movie;
        }
        //update movie by name
        public Movie UpdateMovieName(int id, string name)
        {
            Movie movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                movies[idx].Name = name;
                movie = movies[idx];
            }
            return movie;
        }

        //delete movie by id
        //case 6
        private void DeleteMovie()
        {
            Console.WriteLine("Please enter the movie id to be deleted");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                movies.Remove(GetMovieIndexById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPS something went wrong please try again or please enter the id in the list");

            }
        }
        // Sort the movies by Id
        //case 7
        private void SortMovies()
        {

            var myList = movies.ToList();

            if (movies.Count != 0)
            {
                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            }

            else
                Console.WriteLine("no elements to be sorted");
        }

        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a movie");
                Console.WriteLine("2. Add a list of movies");
                Console.WriteLine("3. Print the movie ");
                Console.WriteLine("4.Print  all the movie ");
                Console.WriteLine("5.Update a Movie By Id ");
                Console.WriteLine("6. Delete a Movie by Id");
                Console.WriteLine("7.Sort movies");
                Console.WriteLine("8. Exit the application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateMovie();
                        break;
                    case 2:
                        AddMovies();
                        break;
                    case 3:
                        PrintMovieById();
                        break;
                    case 4:
                        PrintAllMovies();
                        break;
                    case 5:
                        UpdateMovie();
                        break;
                    case 6:
                        DeleteMovie();
                        break;
                    case 7:
                        SortMovies();
                        break;
                    default:
                        Console.WriteLine("Please enter the vald choice");
                        break;

                }

            } while (choice != 8);
        }
        static void Main(string[] a)
        {
            new ManagerMovie().PrintMenu();


        }
    }
}

