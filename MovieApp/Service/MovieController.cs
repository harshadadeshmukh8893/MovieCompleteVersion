using MovieApp.ExceptionFolder;
using MovieApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service
{
    internal class MovieController
    {
        public MovieController()
        {
            Start();
        }
        public static void Start()
        {
            DisplayMenu();
        }
        private static void DisplayMenu()
        {
            while (true)
            {
                List<Movie> movies;
                MovieManager.LoadMovies();
                movies = MovieManager.GetMovies();
               
                Console.WriteLine("------WELCOME TO MOVIE STORE------- ");
                Console.WriteLine("Current movie count in list is :" + movies.Count + "/5");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine("What do you wish to do?");
                Console.WriteLine("1 = Add Movies  \n" +
                    "2 = Display all movies\n" +
                    "3 = Display Movies by year\n" +
                    "4 = Clear movie by name\n" +
                    "5 = Clear all\n" +
                    "6 = Exit");
                Console.Write("Enter your choice :");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("----------****************---------");
                if (choice == 1)
                    try
                    {
                        AddMovies();
                    }
                    catch (LengthException le) { Console.WriteLine(le.Message); }

                else if (choice == 2)
                {
                    try
                    {
                        DisplayAllMovies(MovieManager.GetMovies());
                    }
                    catch (MemoryException me)
                    {
                        Console.WriteLine(me.Message);
                    }
                }
                else if (choice == 3)
                {
                    DisplayMovieByYear(MovieManager.GetMovieYear());
                }
                else if (choice == 4)
                    MovieManager.ClearMoviesByName();
                else if (choice == 5)
                {
                    MovieManager.DeleteAllMovies();
                }
                else if (choice == 6)
                    Environment.Exit(0);
                else
                    Console.WriteLine("Invalid input !!");
            }
        }

        private static Movie AddMovies()
        {
            string Name;
            string genre;
            string director;
            int year;
            Console.Write("Enter Movie Name :");
            Name = Console.ReadLine();
            Console.Write("Enter Movie Genre :");
            genre = Console.ReadLine();
            Console.Write("Enter Movie Director Name :");
            director = Console.ReadLine();
            Console.Write("Enter Movie year of Release :");
            year = Convert.ToInt32(Console.ReadLine());
            

            Movie movieObject = new Movie(Name, genre, director, year);
            MovieManager.AddMovies(movieObject);
            Console.WriteLine("Movie Added in the list");
           
            return movieObject;
        }
        public static void DisplayAllMovies(List<Movie> movies)
        {
            if (movies.Count > 0)
            {
                foreach (Movie movieObject in movies)
                {
                    Console.WriteLine("Welcome to movie store");
                    Console.WriteLine("-------------------------------");
                    // Console.WriteLine(movieObject);
                    Console.WriteLine($"Movie Name : {movieObject.Name}\n" + $"Movie Director : {movieObject.Director}\n"
                       + $"Movie Genre :{movieObject.Genre}\n" +
                      $"Year Of Realse :{movieObject.Year}");
                }
            }
            // else
            //   throw new MemoryException("List is empty!please add movies");



        }
        public static void DisplayMovieByYear(int index)
        {
            List<Movie> movieObject = MovieManager.GetMovies();
            Console.WriteLine(movieObject[index]);


        }

    }
}