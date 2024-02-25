using EDMS.Data;
using EDMS.Models;
using EDMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EDMS.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookRepository _bookRepository;
        public DocumentsController(AppDbContext context, IWebHostEnvironment webHostEnvironment, IBookRepository bookRepository)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Create(DocumentViewModel entity)
		{
            if (ModelState.IsValid)
            {
                if (entity.FileImage != null)
                {
                    string folder = "/Files";
                    folder += entity.FileImage.FileName + Guid.NewGuid().ToString();
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await entity.FileImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                int id = await _bookRepository.AddNewDocument(entity);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new {docId = id});
                }
            }
            return View();

		}
	}
}
