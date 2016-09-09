using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.Models
{
    public class VideoGame : IComparable<VideoGame>
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public string ESRBRating { get; set; }

        public int CompareTo(VideoGame other)
        {
            int diff = this.Year - other.Year;

            if (diff == 0)
            {
                diff = Title.CompareTo(other.Title);

                if (diff == 0)
                {
                    diff = ESRBRating.CompareTo(other.ESRBRating);
                }
            }

            return diff;
        }
    }
}
