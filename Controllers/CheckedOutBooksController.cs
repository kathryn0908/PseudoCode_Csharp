namespace YardView.Controllers
{
    public class CheckedOutBooksController : Controller
    {
       public async Task<IActionResult> Index()
        {
            return View();
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedoutBook = await _context.CheckedOutBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkedoutBook == null)
            {
                return NotFound();
            }

            return View(checkedoutBook);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedoutBook = await _context.CheckedOutBooks.FindAsync(id);
            if (checkedoutBook == null)
            {
                return NotFound();
            }
            return View(checkedoutBook);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,UserId,Book,User,CheckoutDate")] CheckedOutBooks checkedoutBook)
        {
            if (id != checkedoutBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkedoutBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(checkedoutBook.Id))
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
            return View(checkedoutBook);
        }
            // GET: /Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedoutBook = await _context.CheckedOutBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkedoutBook == null)
            {
                return NotFound();
            }

            return View(checkedoutBook);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkedoutBook = await _context.CheckedOutBook.FindAsync(id);
            _context.CheckedOutBook.Remove(checkedoutBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    private readonly YardViewContext _context;

        public CheckedOutBooksController(YardViewContext context)
        {
            _context = context;
        }
    }
}
