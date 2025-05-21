using admin.libraryweb.Interfaces.Services;
using admin.libraryweb.Models.ExternalServices.Library;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;

namespace admin.libraryweb.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookExternalService _bookExternalService;

        public BookController(IBookExternalService bookExternalService)
        {
            _bookExternalService = bookExternalService;
        }

        public async Task<ActionResult> Index(int page = 1, int pageSize = 10)
        {
            var list = await _bookExternalService.GetAll(page, pageSize);
            return View(list);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var book = await _bookExternalService.GetById(id);
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookCommand model,
            IFormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                using (var target = new MemoryStream())
                {
                    formCollection.Files["File"].CopyTo(target);
                    model.FileBase64 = Convert.ToBase64String(target.ToArray());
                }
                var result = await _bookExternalService.Crear(model);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var book = await _bookExternalService.GetById(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                await _bookExternalService.Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
