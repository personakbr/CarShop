using CarShop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Admin/Users
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") != "1")
            {
                return RedirectToAction("Index", "Auth", new { Area = "", returnUrl = "/Admin/Users" });
            }
            return View(await _context.Users.ToListAsync());
        }
        // GET: Admin/Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") != "1")
            {
                return RedirectToAction("Index", "Auth", new { Area = "", returnUrl = "/Admin/Users" });
            }
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        // GET: Admin/Users/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") != "1")
            {

                return RedirectToAction("Index", "Auth", new { Area = "", returnUrl = "/Admin/Users" });
            }
            return View();
        }
        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Psw,IsAdmin")] IdentityUser user)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") != "1")
            {
                return RedirectToAction("Index", "Auth", new { Area = "", returnUrl = "/Admin/Users" });
            }
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        // GET: Admin/Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") != "1")
            {
                return RedirectToAction("Index", "Auth", new { Area = "", returnUrl = "/Admin/Users" });
            }
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,Name,Psw,IsAdmin")] IdentityUser user)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") != "1")
            {
                return RedirectToAction("Index", "Auth", new { Area = "", returnUrl = "/Admin/Users" });

            }
            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: Admin/Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") != "1")
            {
                return RedirectToAction("Index", "Auth", new { Area = "", returnUrl = "/Admin/Users" });
            }
            if (id == null)
            { return NotFound(); }
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            { return NotFound(); }
            return View(user);
        }
        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") != "1")
            { return RedirectToAction("Index", "Auth", new { Area = "", returnUrl = "/Admin/Users" }); }
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool UserExists(string id)
        { return _context.Users.Any(e => e.Id == id); }
    }
}

           