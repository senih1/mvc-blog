using blog_mvc_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace blog_mvc_1.Controllers

{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using StreamReader reader = new StreamReader("Appdata/post.txt");
            string txt = reader.ReadToEnd();
            var postLines = txt.Split('\n');

            var posts = new List<Post>();
            foreach (var line in postLines)
            {
                var splittedLine = line.Split("|");
                var postToAdd = new Post();
                postToAdd.Title = splittedLine[0];
                postToAdd.Detail = splittedLine[1];
                postToAdd.Slug = splittedLine[2];
                posts.Add(postToAdd);
            }
            
            return View(posts);
        }
        public IActionResult Post(string slug)
        {
            using StreamReader reader = new StreamReader($"AppData/Posts/{slug}.txt");
            ViewData["content"] = reader.ReadToEnd();
            return View();
        }

        public IActionResult Hakkimda()
        {
            return View();
        }
        public IActionResult Iletisim()
        {
            return View();
        }
    }
}
