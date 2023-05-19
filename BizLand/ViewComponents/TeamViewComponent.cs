using BizLand.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.ViewComponents
{
    public class TeamViewComponent:ViewComponent
    {
        private readonly BizLandDbContext _bizLandDbContext;

        public TeamViewComponent(BizLandDbContext bizLandDbContext)
        {
            _bizLandDbContext = bizLandDbContext;
        }

        public IViewComponentResult Invoke()
        {
            return View(_bizLandDbContext.Members.ToList());
        }
    }
}
