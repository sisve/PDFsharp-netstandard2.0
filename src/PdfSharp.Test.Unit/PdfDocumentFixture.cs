using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PdfSharp.Pdf.Test
{
    public class PdfDocumentFixture
    {
        public PdfDocument CreatePdf(Stream stream, int pageCount = 1)
        {
            var pdf = new PdfDocument();
            for (int i = 0; i < pageCount; i++)
                pdf.AddPage();
            pdf.Save(stream);
            return pdf;
        }

        public Stream CreateInMemoryPdf(int pageCount = 1)
        {
            var pdfStream = new MemoryStream();
            CreatePdf(pdfStream, pageCount);
            pdfStream.Position = 0;
            return pdfStream;
        }
    }
}
