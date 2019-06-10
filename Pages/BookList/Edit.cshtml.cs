using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Model;

namespace WebApplication2.Pages.BookList
{
    public class EditModel : PageModel
    {


        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> Onpost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.Auther = Book.Auther;
                BookFromDb.ISBN = Book.ISBN;
                await _db.SaveChangesAsync();
                Message = "Book has been Updated Successfully";
                return RedirectToPage("Index");

            }
            return RedirectToPage();
        }

    }
}