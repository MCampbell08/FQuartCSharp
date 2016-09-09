using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScratchConsole2.Enums;

namespace ScratchConsole2
{
    public class Movie
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public float StarRating { get; set; }
        public MPAARating Rating { get; set; }
        public Movie(int year = 1880, string title = "[unknown]", float starRating = 0, MPAARating rating = MPAARating.R)
        {
            Year = year;
            Title = title;
            StarRating = starRating;
            Rating = rating;
        }

        public override string ToString()
        {
            return Title + " (" + Year + ") - " + Rating + ": " +StarRating + "/5 stars";
        }

    }
}
