using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Model
{
    [Serializable]
    public class Movie
    {
        public static readonly string Count;

        public string Name { get; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }



        public Movie() { }
        public Movie(string name, string genre, string director, int year)
        {
            Name = name;
            Genre = genre;
            Director = director;
            Year = year;

        }
        public override string ToString()
        {
            return $"Movie Name : {Name}\n" + $"Movie Director : {Director}\n"
                     + $"Movie Genre :{Genre}\n" +
                      $"Year Of Realse :{Year}";
        }
    }
}