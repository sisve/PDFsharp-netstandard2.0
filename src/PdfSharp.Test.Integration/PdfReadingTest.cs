using FluentAssertions;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using Xunit;

namespace PdfSharp.Test.Integration
{
    public class PdfReadingTest
    {
        [Theory]
        [InlineData("RC4-128 open password.pdf", "pass")] //Adobe 6.0
        [InlineData("AES-256 open password.pdf", "pass")] //Adobe 7.0
        [InlineData("AES-128 open password.pdf", "pass")] //Adobe X
        [InlineData("test.pdf", "pass")] //Created by PdfSharp
        public void TestPasswordProtectedDocument(string fileName, string openPassword)
        {
            var path = Path.Combine("data", fileName);
            Assert.Throws<PdfReaderException>(() =>
            {
                PdfReader.Open(path);
            });
            var doc = PdfReader.Open(path, openPassword);
            doc.PageCount.Should().Be(3);
        }

        [Theory]
        [InlineData("3 pages.pdf")]
        public void TestRegularDocument(string fileName)
        {
            var path = Path.Combine("data", fileName);
            var doc = PdfReader.Open(path);
            doc.PageCount.Should().Be(3);
        }
    }
}
