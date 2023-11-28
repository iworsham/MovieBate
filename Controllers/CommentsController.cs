using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieBate.DataAccess;
using MovieBate.Models;

namespace MovieBate.Controllers
{
    public class CommentsController : Controller
    {
        private readonly MovieBateContext _context;

        public CommentsController( MovieBateContext context)
        {
          //  _configuration = configuration;
            _context = context;

        }
        [HttpPost]
        [Route("/movies/{id}/comments/new")]
        public IActionResult Create(Comment comment,int id)
        {
            if (Request.Cookies["AnonUser"] == null)
            {
                string anonId = Guid.NewGuid().ToString();
                var anonUser = new User();
                var movie = _context.Movies.Find(id);
                comment.Movie = movie;
                anonUser.Id = anonId;
                Response.Cookies.Append("AnonUser", anonId);
                comment.AnonId = anonId;
                comment.CreatedAt = DateTime.Now.ToUniversalTime();

                
                

                anonUser.Comments.Add(comment);
            }
            else
            {
                var anonUser = new User();
                var movie = _context.Movies.Find(id);
                comment.Movie = movie;
                anonUser.Id = Request.Cookies["AnonUser"];

                comment.CreatedAt = DateTime.Now.ToUniversalTime();
                comment.AnonId = anonUser.Id;
               

             
                anonUser.Comments.Add(comment);
            }

            var newCommentId = comment.Id;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction($"/movies/{id}", new {id = newCommentId});
        }
        [HttpPost]
        [Route("/movies/{id}/comments/edit")]
        public IActionResult Edit(int commentId)
        {


            return View();
        }

        [HttpPost]
        public IActionResult Update(int commentId, Comment comment)
        {
            comment.Id = commentId;

            _context.Comments.Update(comment);
            _context.SaveChanges();

            return RedirectToAction("Show");
        }


        [HttpPost]
        [Route("/movies/{id}/comments/delete")]
        public IActionResult Delete(int commentId, Comment comment)
        {
            comment.Id = commentId;
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}
