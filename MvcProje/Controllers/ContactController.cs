using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetByID(id);
            return View(contactValues);
        }

        public PartialViewResult PartialContact()
        {
            ViewData["contactMessageCount"] = contactManager.GetList().Count();
            ViewData["messageInboxCount"] = messageManager.GetListInbox().Count();
            ViewData["messageSendboxCount"] = messageManager.GetListSendbox().Count();
            return PartialView();
        }
    }
}