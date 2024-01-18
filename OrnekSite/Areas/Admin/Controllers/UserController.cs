using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrnekSite.Data;
using OrnekSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Diger.Role_Admin)]



    //ASP.NET CORE5 (MVC) ile Alışveriş Site Geliştirme Kursu





    //Kısa bir iş olan ama uzun uğraşlar sonucu tamamlanacak yaklaşık 5 farklı üniversite proje bu derse ara verdim.

    //    Projede controllerlara da not bırakacağım.Bu derse her şey tamamlandı ve kadar sorunsuz çalışıyor.

    //    Bu derste kaldım(Bu ders dahil değil).





























    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context; 
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.ApplicationUsers.ToList();
            var role = _context.Roles.ToList();
            var userRol = _context.UserRoles.ToList();
            foreach(var item in users)
            {
                var roleID = userRol.FirstOrDefault(i => i.UserId == item.Id).RoleId;
                item.Role = role.FirstOrDefault(u => u.Id == roleID).Name;
            }
            return View(users);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
