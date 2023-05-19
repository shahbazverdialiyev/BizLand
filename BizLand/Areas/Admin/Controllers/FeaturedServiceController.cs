using BizLand.DAL;
using BizLand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BizLand.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturedServiceController:Controller
    {
        private readonly BizLandDbContext _bizLandDbContext;
        public FeaturedServiceController(BizLandDbContext bizLandDbContext)
        {
            _bizLandDbContext = bizLandDbContext;
        }
        public IActionResult Index()
        {
            return View(_bizLandDbContext.FeaturedServices.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(FeaturedService service)
        {
            if (service == null)
            {
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (await _bizLandDbContext.FeaturedServices.FirstOrDefaultAsync(s => s.Title == service.Title && s.Description== service.Description) != null)
            {
                ModelState.AddModelError("Title", "bele service var");
            }
            await _bizLandDbContext.FeaturedServices.AddAsync(service);
            await _bizLandDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            FeaturedService? service = await _bizLandDbContext.FeaturedServices.FirstOrDefaultAsync(s => s.Id == id);
            if(service == null)
            {
                return NotFound();
            }
            return View(service);
        }
        public async Task<IActionResult> Delete(int id)
        {
            FeaturedService? service = await _bizLandDbContext.FeaturedServices.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            _bizLandDbContext.FeaturedServices.Remove(service);
            await _bizLandDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            FeaturedService? service = await _bizLandDbContext.FeaturedServices.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id,FeaturedService updatedService)
        {
            FeaturedService? service= await _bizLandDbContext.FeaturedServices.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            if (updatedService == null)
            {
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            updatedService.Id = service.Id;
            _bizLandDbContext.FeaturedServices.Update(updatedService);
             await _bizLandDbContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
