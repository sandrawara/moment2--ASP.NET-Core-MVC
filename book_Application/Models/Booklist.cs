using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_Application.Models
{
    public class Booklist
    {
        public Booklist() { } //Empty constructor


        //Constructor objects
        public Booklist(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }

        //Public properties
        public string Title { get; set; }
        public string Author { get; set; }
        }

        public class ViewModeln
        {
            public IEnumerable<Booklist> BooklistDetail { get; set; }
        }

}