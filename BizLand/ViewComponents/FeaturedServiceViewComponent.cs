using BizLand.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.ViewComponents
{
    public class FeaturedServiceViewComponent:ViewComponent
    {
        private readonly BizLandDbContext _bizLandDbContext;

        public FeaturedServiceViewComponent(BizLandDbContext bizLandDbContext)
        {
            _bizLandDbContext = bizLandDbContext;
        }
        public IViewComponentResult Invoke()
        {
            return View(_bizLandDbContext.FeaturedServices.ToList());
        }
    }
}
