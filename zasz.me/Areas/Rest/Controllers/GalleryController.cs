﻿using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Rest.Controllers
{
    public class GalleryController : Controller
    {
        [DefaultAction]
        public ActionResult Look()
        {
            return View();
        }
    }
}