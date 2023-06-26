using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlapp.Models
{
    // This class represents the structure of our data
    public class ComicBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }

        public string Cover { get; set; }
    }
}
