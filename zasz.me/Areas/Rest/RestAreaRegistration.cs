﻿using System.Web.Mvc;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Rest
{
    public class RestAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Rest"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Rest_Home",
                "Rest/{controller}/{action}/{id}",
                new {Controller = "Home", action = "Show", id = UrlParameter.Optional}
                );
            Site.Register("zasz.me", Domain.Rest);
        }
    }
}