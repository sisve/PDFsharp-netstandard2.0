using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System;
using System.IO;
using System.Text;

namespace HelloMigraDoc
{
    class Program
    {
        static Program()
        {
            // https://gunnarpeipman.com/net/no-data-is-available-for-encoding/
            // https://stackoverflow.com/questions/49215791/vs-code-c-sharp-system-notsupportedexception-no-data-is-available-for-encodin?noredirect=1&lq=1
            // nuget: System.Text.Encoding.CodePages
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        static void Main(string[] args)
        {
            Directory.CreateDirectory("out");

            // Create a MigraDoc document
            Document document = Documents.CreateDocument();

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "out/MigraDoc.mdddl");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
            {
                Document = document
            };

            renderer.RenderDocument();

            // Save the document...
            string filename = "out/HelloMigraDoc.pdf";
            renderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            //Process.Start(filename);
        }
    }
}
