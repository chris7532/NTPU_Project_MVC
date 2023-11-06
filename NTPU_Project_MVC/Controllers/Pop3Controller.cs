using Microsoft.AspNetCore.Mvc;
using NTPU_Project_MVC.DataAccess.Repository;
using NTPU_Project_MVC.DataAccess.Repository.IRepository;

namespace NTPU_Project_MVC.Web.Controllers
{
    public class Pop3Controller : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public Pop3Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var query = _unitOfWork.Pop3.GetByRange(5,"Date").ToList();
            return View(query);
        }


        #region API Calls
        [HttpPost]
        public IActionResult GetHashDataTop20(string startDate, string endDate)
        {
            var query = _unitOfWork.Pop3.GetByGroup(startDate, endDate).Take(20);
            return Json(new { data = query });
        }
        [HttpGet]
        public IActionResult GetHashDataTest()
        {
            var query = _unitOfWork.Pop3.GetByGroupTest();
            return Json(new { data = query });
        }

        [HttpPost]
        public IActionResult GetHashData(string startDate, string endDate)
        {

            var query = _unitOfWork.Pop3.GetByGroup(startDate, endDate);

            return Json(new { data = query });
        }

        [HttpPost]
        public IActionResult HashToIpGroup(string hash)
        {

            var query = _unitOfWork.Pop3.HashToIpGroup(hash);

            return Json(new { data = query });
        }
        #endregion
    }
}
