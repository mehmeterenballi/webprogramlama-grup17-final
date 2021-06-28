using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeritabaniProjesi.Data;
using VeritabaniProjesi.Models;
using VeritabaniProjesi.ViewModel;

namespace VeritabaniProjesi.Controllers
{
    public class TitlesController : Controller
    {
        private readonly BasicDataContext _context;
        private readonly UserManager<MyUser> _userManager;


        public TitlesController(BasicDataContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Titles
        public async Task<IActionResult> Index(string searchString)
        {
            var pages = from t in _context.Titles select t;
            if (!string.IsNullOrEmpty(searchString))
                pages = pages.Where(s => s.PostTitle.ToLower().Contains(searchString.ToLower()));


            var dataContents = pages.Include(t => t.Question);

            return View(await dataContents.ToListAsync());
        }

        // GET: Titles/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> Create([Bind("PostTitle, Content")] CreateTitleViewModel ctvm)
        {
            Title title = new Title();

            if (ModelState.IsValid)
            {
                SetTitleValuesToDefault(ref title);
                title.PostTitle = ctvm.PostTitle;
                title.Date = DateTime.Now;

                var user  = _userManager.GetUserAsync(User);

                title.Question = new Post
                {
                    PostTitle = title.PostTitle,
                    Date = title.Date,
                    Sender = user.Result.NickName,
                    Rating = 0,
                    Content = ctvm.Content
                };

                title.QuestionId = title.Question.Id;

                _context.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Posts", new{title = title.PostTitle});
            }

            return View(ctvm);
        }

     

 

        // GET: Titles/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles
                .Include(t => t.Question)
                .FirstOrDefaultAsync(m => m.PostTitle == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var title = await _context.Titles.FindAsync(id);
            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleExists(string id)
        {
            return _context.Titles.Any(e => e.PostTitle == id);
        }

        private void SetTitleValuesToDefault(ref Title title)
        {
            title.Date = DateTime.Now;
            //title.QuestionId = ;
            //title.Question = ;
        }
    }
}
