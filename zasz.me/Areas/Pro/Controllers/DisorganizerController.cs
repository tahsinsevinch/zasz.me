﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Mvc;
using zasz.me.Areas.Pro.Models;
using zasz.me.Services;
using System.Linq;
using zasz.me.Areas.Shared.Controllers.Utils;

namespace zasz.me.Areas.Pro.Controllers
{
    public class DisorganizerController : Controller
    {
        public ActionResult Tinker()
        {
            var Service = new FontsService();
            Service.LoadFonts(Request.MapPath("~/Content/Shared/Fonts"));
            TinkerModel TinkerModel = new TinkerModel();
            TinkerModel.Fonts.AddRange(Service.AvailableFonts.Keys.ToArray());
            TinkerModel.Strategies.AddRange(Enum.GetNames(typeof(TagDisplayStrategy)));
            TinkerModel.Themes.AddRange(Enum.GetNames(typeof(Theme)));
            TinkerModel.Styles.AddRange(Enum.GetNames(typeof(Style)));
            Service.Dispose();
            return View(TinkerModel);
        }
        
        [HttpPost]
        public ActionResult Tinker(TinkerModel Model)
        {
            var Service = new FontsService();
            Service.LoadFonts(Request.MapPath("~/Content/Shared/Fonts"));
            Model.Fonts.AddRange(Service.AvailableFonts.Keys.ToArray());
            Model.Strategies.AddRange(Enum.GetNames(typeof(TagDisplayStrategy)));
            Model.Themes.AddRange(Enum.GetNames(typeof(Theme)));
            Model.Styles.AddRange(Enum.GetNames(typeof(Style)));
            Service.Dispose();

            Dictionary<string, int> Tags = Model.Lines.Select(
                Line => Line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(Splits => Splits.Length == 2)
                .ToDictionary(Splits => Splits[0], Splits => int.Parse(Splits[1]));

            var TagCloudService = new TagCloudService(Tags, int.Parse(Model.Width), int.Parse(Model.Height))
            {
                MaximumFontSize = float.Parse(Model.MaxFontSize),
                MinimumFontSize = float.Parse(Model.MinFontSize),
            };

            if (!String.IsNullOrEmpty(Model.Angle)) TagCloudService.Angle = int.Parse(Model.Angle);
            if (!String.IsNullOrEmpty(Model.Margin)) TagCloudService.Margin = int.Parse(Model.Margin);
            if (!String.IsNullOrEmpty(Model.SelectedFont))
                TagCloudService.SelectedFont = Service.AvailableFonts[Model.SelectedFont];
            if (!String.IsNullOrEmpty(Model.SelectedStrategy))
                TagCloudService.DisplayChoice = DisplayStrategy.Get(Model.SelectedStrategy.Enumize<TagDisplayStrategy>());

            Theme BgfgScheme = !String.IsNullOrEmpty(Model.SelectedTheme)
                                   ? Model.SelectedTheme.Enumize<Theme>() : Theme.LightBgDarkFg;
            Style FgScheme = !String.IsNullOrEmpty(Model.SelectedStyle)
                                   ? Model.SelectedStyle.Enumize<Style>() : Style.Varied;

            TagCloudService.ColorChoice = ColorStrategy.Get(BgfgScheme, FgScheme, Color.FromArgb(0, Color.White), Color.Red);

            TagCloudService.VerticalTextRight = Model.VerticalTextRight;
            TagCloudService.ShowWordBoundaries = Model.ShowBoundaries;
            TagCloudService.Crop = Model.Crop;

            Dictionary<string, RectangleF> Borders;
            Bitmap Bitmap = TagCloudService.Construct(out Borders);
            Model.Borders = Borders;
            
            Model.Skipped = string.Join("; ", TagCloudService.WordsSkipped.Select(It => It.Key));

            /* This is soo worst design - Concurrant users will interfere with each other*/
            Bitmap.Save(Request.MapPath("~/Content/Pro/Images/TinkeringCloud.png"), ImageFormat.Png);
            return View(Model);
        }
    }
}
