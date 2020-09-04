namespace YardView.Controllers
{
    public class BookController : Controller
    {
       public async Task<IActionResult> Index(string BookGenre, string BookPublishDate, string searchString)
        {
   
            IQueryable<string> genreQuery = from m in _context.Book
                                            orderby m.Genre
                                            select m.Genre;

            IQueryable<string> publishdateQuery = from m in _context.Book
                                            orderby m.PublishDate
                                            select m.PublishDate;

            var books = from m in _context.Book
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                {
                    books = books.Where(x => x.Genre == bookGenre);
                }

                var bookGenreVM = new BookGenreViewModel
                {
                    Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                    Books = await books.ToListAsync()
                };

                return View(bookGenreVM);

            }
            //Added additional curly braces for return, not sure if correct syntax examples only showed 1 filter
           

            if (!string.IsNullOrEmpty(bookPublishDate))
            {
                {
                    books = books.Where(x => x.PublishDate == bookPublishDate);
                }

                var bookPublishDateVM = new BookPublishDateViewModel
                {
                    PublishDates = new SelectList(await genreQuery.Distinct().ToListAsync()),
                    Books = await books.ToListAsync()
                };

                return View(bookPublishDateVM);
            }
           
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Author,Genre,PublishDate")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Book.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Author,Genre,PublishDate")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(book);
        }
      public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    private readonly YardViewContext _context;

        public BooksController(YardViewContext context)
        {
            _context = context;
        }
    }
}
