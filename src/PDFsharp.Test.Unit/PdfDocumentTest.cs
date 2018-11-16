using FluentAssertions;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using Xunit;

namespace PdfSharp.Pdf.Test
{
    public class PdfDocumentTest : IClassFixture<PdfDocumentFixture>
    {
        private readonly PdfDocumentFixture fixture;

        public PdfDocumentTest(PdfDocumentFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void TestImportMode()
        {
            var pageCount = 1;
            using (var pdfStream = fixture.CreateInMemoryPdf(pageCount))
            {
                var pdf = PdfReader.Open(pdfStream, PdfDocumentOpenMode.Import);
                pdf.PageCount.Should().Be(pageCount);
                pdf.Pages[0].Should().NotBeNull();

                pdf.CanSave(out string _).Should().BeFalse();
                pdf.Invoking(p => p.AddPage()).Should().Throw<InvalidOperationException>();
                pdf.Invoking(p => p.Save(".\\test.pdf")).Should().Throw<InvalidOperationException>();
            }
        }

        [Fact]
        public void TestModifyMode()
        {
            var pageCount = 1;
            using (var pdfStream = fixture.CreateInMemoryPdf(pageCount))
            {
                var pdf = PdfReader.Open(pdfStream, PdfDocumentOpenMode.Modify);
                pdf.AddPage().Should().NotBeNull();

                pdf.PageCount.Should().BeGreaterThan(pageCount);
                pdf.Pages[1].Should().NotBeNull();
            }
        }
    }
}
