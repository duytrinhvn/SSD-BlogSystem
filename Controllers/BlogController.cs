using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogSystem.Data;
using BlogSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BlogController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: BlogController
        [Route("blog")]
        public ActionResult Index()
        {
            var posts =
                _db.Posts
                    .OrderByDescending(x => x.Posted)
                    .ToArray();

            return View(posts);
        }

        [Route("blog/{key}")]
        public IActionResult Post(string key)
        {
            var post = _db.Posts.FirstOrDefault(x => x.Key == key);
            return View(post);
        }

        // GET: BlogController/Create
        [Authorize]
        [HttpGet, Route("blog/create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [Authorize]
        [HttpPost, Route("blog/create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            _db.Posts.Add(post);
            _db.SaveChanges();


            return RedirectToAction("Post", "Blog", new
            {
                year = post.Posted.Year,
                month = post.Posted.Month,
                key = post.Key
            });
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
