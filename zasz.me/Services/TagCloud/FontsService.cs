﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace zasz.me.Services.TagCloud
{
    public class FontsService : IDisposable
    {

        // ReSharper disable InconsistentNaming
        private readonly Action<string> Die = Message => { throw new Exception(Message); };
        // ReSharper restore InconsistentNaming

        private PrivateFontCollection _Fonts;


        /// <summary>
        /// A list of private fonts used by this service. It is loaded from the
        /// path given while construction. It expects .ttf files (TrueType Font)
        /// </summary>
        public Dictionary<string, FontFamily> AvailableFonts { get; private set; }


        public void LoadFonts(string FontsFolderPath)
        {
            if (string.IsNullOrEmpty(FontsFolderPath)) Die("Null Fonts Path");
            string[] Files = Directory.GetFiles(FontsFolderPath);
            List<string> FontFiles = (from AFile in Files
                                      where AFile.EndsWith(".ttf")
                                      select AFile).ToList();
            if (FontFiles.Count() == 0) Die("No Fonts Found");
            _Fonts = new PrivateFontCollection();
            FontFiles.ForEach(F => _Fonts.AddFontFile(F));
            AvailableFonts = _Fonts.Families.ToDictionary(It => It.Name);
        }

        public void Dispose()
        {
            _Fonts.Dispose();
        }
    }
}