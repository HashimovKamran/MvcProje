using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class MessageController : Controller
    {

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        DraftController draftController = new DraftController();

        public ActionResult Inbox()
        {
            var messageListInbox = messageManager.GetListInbox();
            return View(messageListInbox);
        }

        public ActionResult Sendbox()
        {
            int isRead = 0, isNotRead = 0;
            var messageListSendbox = messageManager.GetListSendbox();
            foreach (var item in messageListSendbox)
            {
                if (item.MessageRead == true)
                {
                    isRead++;
                }
                else
                {
                    isNotRead++;
                }
            }
            ViewData["isRead"] = isRead;
            ViewData["isNotRead"] = isNotRead;
            return View(messageListSendbox);
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            messageValue.MessageRead = true;
            messageManager.Add(messageValue);
            return View(messageValue);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            return View(messageValue);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message, string button)
        {
            ValidationResult results = messageValidator.Validate(message);
            if (button == "draft")
            {
                if (results.IsValid)
                {
                    Draft draft = new Draft();
                    draft.ReceiverMail = message.ReceiverMail;
                    draft.Subject = message.Subject;
                    draft.DraftContent = message.MessageContent;
                    draft.DraftDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    draftController.AddDraft(draft);
                    return RedirectToAction("Draft","Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            else if (button == "save")
            {
                if (results.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = "admin@gmail.com";
                    message.MessageRead = false;
                    messageManager.Add(message);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }
    }
}