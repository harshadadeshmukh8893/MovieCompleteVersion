
using MovieApp.ExceptionFolder;
using MovieApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service
{
    public class MovieManager
    {
        static List<Movie> movies = new List<Movie>();//list of movies
        static readonly string filePath = ConfigurationManager.AppSettings["path"];

        public const int length = 4;
        public MovieManager()
        {
            movies = new List<Movie>();
            LoadMovies();
        }
        public static void AddMovies(Movie movie)
        {
            if (movies.Count <= length)
            {
                movies.Add(movie);
                SaveMovies();
            }
            else
                throw new LengthException("Can not add movies! list is full..");

            //    Console.WriteLine("List is Full !! No Movies found ");
        }
        public static void ClearMoviesByName()
        {
            Console.WriteLine("=================================");
            Console.Write("Enter Movie name: ");
            string findMovie = Console.ReadLine();
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Name == findMovie)
                {
                    movies.RemoveAt(i);
                }
            }
            SaveMovies();
            Console.WriteLine("Movie Deleted Succesfully");
        }
        public static List<Movie> GetMovies()
        {
            if (movies.Count > 0)
            {
                LoadMovies();
                return movies;
            }
            else
                throw new MemoryException("List is empty!please add movies");
        }
        public static int GetMovieYear()
        {
            Console.WriteLine("-------------------------------");
            Console.Write("Enter Movie year : ");
            int movieYear = Convert.ToInt32(Console.ReadLine());
            int index = 0;
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Year == movieYear)
                    index = i;
            }
            return index;
        }
        public static void LoadMovies()
        {
            movies = DataSerilizer.BinaryDeserializer(filePath);
        }
        public static void SaveMovies()
        {
            DataSerilizer.BinarySerializer(movies, filePath);
        }
        public static void DeleteAllMovies()
        {
            //LoadMovies();
            movies.Clear();
            File.WriteAllText(filePath, string.Empty);
            SaveMovies();
            Console.WriteLine("All Movie removed from the list !!");
        }

    }

}

