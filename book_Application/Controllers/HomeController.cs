using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using book_Application.Models;
using Newtonsoft.Json;

namespace book_Application.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() //Takes in view for index
        { 

            ViewData["Message"] = "Senast lästa böcker"; //Text moving with viewdata

            return View();
        }


        [HttpGet]
        public IActionResult Booklist() //Takes in view for booklist
        {
            var booklist = new List<Booklist>(); //Create list

            string s2 = HttpContext.Session.GetString("cookie1"); //Get session
            if ((s2 != null) || (s2 == ""))
            {
                booklist = JsonConvert.DeserializeObject<List<Booklist>>(s2);
            };

            return View(booklist);

        }

        [HttpPost]
        public IActionResult Booklist(IFormCollection fc) 
        {
            var booklist = new List<Booklist>(); //Create list

            string s2 = HttpContext.Session.GetString("cookie1"); //Get session
            if ((s2 != null) || (s2 == ""))
            {
                booklist = JsonConvert.DeserializeObject<List<Booklist>>(s2);
            };

            ViewData["Text"] = "Lista över senast lästa böcker";
            Booklist bookItem = new Booklist(fc["book"], fc["author"]); //Create book
            booklist.Add(bookItem);

            string s1 = JsonConvert.SerializeObject(booklist);
            HttpContext.Session.SetString("cookie1", s1); // Set session

            ViewData["books_in_list"] = booklist;

            return View(booklist);

        }

        public IActionResult Read() //Takes in view for Read
        {

            var weeklyBook = new  List<System.Collections.IList>();
            weeklyBook.Add(new List<string>() {"The Brain That Changes Itself ", "Tibetan Buddhism ", "Sagan om ringen ", "Stefans stora feta röda ", "Stefans lilla gröna"});
            ViewBag.weeklyBook = weeklyBook;

            return View();
             }

         }
     }
 