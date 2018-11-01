using FluentAssertions;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using Xunit;

namespace PdfSharp.Pdf.Test
{
    public class PdfDocumentTest
    {
        private static PdfDocument CreatePdf(Stream stream)
        {
            var pdf = new PdfDocument();
            pdf.AddPage();
            pdf.Save(stream);
            return pdf;
        }

        private static Stream CreateInMemoryPdf()
        {
            var pdfStream = new MemoryStream();
            CreatePdf(pdfStream);
            pdfStream.Position = 0;
            return pdfStream;
        }

        [Fact]
        public void TestImportMode()
        {
            using (var pdfStream = CreateInMemoryPdf())
            {
                var pdf = PdfReader.Open(pdfStream, PdfDocumentOpenMode.Import);
                pdf.PageCount.Should().Be(1);
                pdf.Pages[0].Should().NotBeNull();

                pdf.CanSave(out string _).Should().BeFalse();
                pdf.Invoking(p => p.AddPage()).Should().Throw<InvalidOperationException>();
                pdf.Invoking(p => p.Save(".\\test.pdf")).Should().Throw<InvalidOperationException>();
            }
        }

        [Fact]
        public void TestModifyMode()
        {
            using (var pdfStream = CreateInMemoryPdf())
            {
                var pdf = PdfReader.Open(pdfStream, PdfDocumentOpenMode.Modify);
                pdf.AddPage().Should().NotBeNull();

                pdf.PageCount.Should().Be(2);
                pdf.Pages[1].Should().NotBeNull();
            }
        }
    }
}
