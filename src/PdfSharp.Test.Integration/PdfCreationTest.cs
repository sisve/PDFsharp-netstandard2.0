using FluentAssertions;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace PdfSharp.Test.Integration
{
    public class PdfCreationTest
    {
        public PdfCreationTest()
        {
            if (Directory.Exists("temp"))
                Directory.Delete("temp", true);
            Directory.CreateDirectory("temp");
        }

        [Fact]
        public void TestAES128Encryption()
        {
            var doc = new PdfDocument();
            /* WARNING
             * annotations won't work without setting a value for GlobalFontSettings.FontResolver, which isn't distributed with 
             * PDFSharpCore; a naive implementation is at the bottom of this file...
             */
            var font = new XFont(GlobalFontSettings.DefaultFontName, 12, XFontStyle.Regular);
            for (int i = 1; i <= 3; i++)
            {
                var page = doc.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                gfx.DrawString($"Page {i}", font, XBrushes.Black, 25, 25);
            }
            doc.SecuritySettings.DocumentSecurityLevel = Pdf.Security.PdfDocumentSecurityLevel.Encrypted128BitAes;
            doc.SecuritySettings.UserPassword = "pass";
            var path = Path.Combine("temp", "test.pdf");
            doc.Save(path);
            File.Exists(path).Should().BeTrue();
        }
    }
}
