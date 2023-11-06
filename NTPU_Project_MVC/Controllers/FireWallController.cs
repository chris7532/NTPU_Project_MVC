using Microsoft.AspNetCore.Mvc;
using NTPU_Project_MVC.DataAccess.Data;
using NTPU_Project_MVC.DataAccess.Repository.IRepository;
using NTPU_Project_MVC.Models;

namespace NTPU_Project_MVC.Web.Controllers
{
    public class FireWallController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FireWallController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var query = _unitOfWork.FireWall.GetByRange(5).ToList();
            return View(query);
        }


        #region API Calls
        [HttpGet]
        public IActionResult GetMsgData()
        {
            var query = _unitOfWork.FireWall.GetByRange(10000)
                            .GroupBy(entity => entity.Msg)
                            .Select(group => new
                            {
                                GroupName = group.Key,
                                GroupCount = group.Count()
                            }).ToList();
            return Json(new { data = query });
        }

        [HttpPost]
        public IActionResult GetMsgData(string startDate, string endDate)
        {
            
            var query = _unitOfWork.FireWall.GetByGroup(startDate, endDate);

            return Json(new { data = query });
        }
        #endregion
    }
}
