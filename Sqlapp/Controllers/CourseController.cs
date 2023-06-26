using Microsoft.AspNetCore.Mvc;
using Sqlapp.Models;
using Sqlapp.Services;
using System.Collections.Generic;

namespace Sqlapp.Controllers
{
    public class ComicBookController : Controller
    {
        private readonly ComicBookService _comicBookService;

        public ComicBookController(ComicBookService comicBookService)
        {
            _comicBookService = comicBookService;
        }

        // The Index method is used to get a list of comic books and return it to the view
        public IActionResult Index()
        {
            IEnumerable<ComicBook> comicBooks = _comicBookService.GetComicBooks();
            return View(comicBooks);
        }
    }
}
