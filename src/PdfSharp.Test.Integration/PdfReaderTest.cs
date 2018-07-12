using PdfSharp.Pdf.IO;
using System;
using Xunit;

namespace PdfSharp.Test.Integration
{
    public class PdfReaderTest
    {
        [Fact]
        public void TestPasswordProtectedDocument()
        {
            Assert.Throws<PdfReaderException>(() =>
            {
                var doc = PdfReader.Open("data/pdf test - password.pdf");
            });
        }
    }
}
