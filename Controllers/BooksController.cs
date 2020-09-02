namespace YardView.Controllers
{
    public class BooksController : Controller
    {
       public async Task<IActionResult> Index(string BookGenre, string BookPublishDate, string searchString)
        {
   
            IQueryable<string> genreQuery = from m in _context.Book
                                            orderby m.Genre
                                            select m.Genre;

            IQueryable<string> publishdateQuery = from m in _context.Book
                                            orderby m.PublishDate
                                            select m.PublishDate;

            var books = from m in _context.Books
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

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Genre")] Books book)
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
                    if (!BooksExists(book.Id))
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
        
    private readonly YardViewContext _context;

        public BooksController(YardViewContext context)
        {
            _context = context;
        }
    }
}
