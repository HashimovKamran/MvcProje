using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        // GET: Statistics
        public ActionResult Index()
        {
            ViewData["totalCategories"] = TotalCategories();
            ViewData["headingCount"] = HeadingCount();
            ViewData["writerWithLetterA"] = WriterWithLetterA();
            ViewData["headingCategoryName"] = HeadingCategoryName();
            ViewData["statusCount"] = StatusCount();
            return View();
        }

        private int TotalCategories()
        {
            var totalCount = categoryManager.GetList().Count();
            return totalCount;
        }

        private int HeadingCount()
        {
            var headingCount = headingManager.GetList().Where(h => h.CategoryID == 10).Count();
            return headingCount;
        }

        private int WriterWithLetterA()
        {
            var writerWithLetterA = writerManager.GetList().Where(w => w.WriterName.Contains("A")).Count();
            return writerWithLetterA;
        }

        private string HeadingCategoryName()
        {
            var list = headingManager.GetList().OrderBy(x => x.CategoryID).GroupBy(y => y.CategoryID).Select(z => new { CategoryID = z.Key, Toplam = z.Count() }).ToList();
            int buyuk = 0, categoryId = 0;
            foreach (var item in list)
            {
                if (buyuk < item.Toplam)
                {
                    buyuk = item.Toplam;
                    categoryId = item.CategoryID;
                }
            }

            var headingCategoryName = categoryManager.GetByID(categoryId).CategoryName;
            return headingCategoryName;
        }

        private int StatusCount()
        {
            var statusCountTrue = categoryManager.GetList().Where(c => c.CategoryStatus == true).Count();
            var statusCountFalse = categoryManager.GetList().Where(c => c.CategoryStatus == false).Count();
            int count = statusCountTrue - statusCountFalse;
            return count;
        }
    }
}