using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;

namespace Blog.Controllers
{
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {

        SubscribeMailManager sm = new SubscribeMailManager(new EfMailDal());
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {            
            sm.TAdd(p);
            return PartialView();
        }
    }
}