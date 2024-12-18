using System;

class Program
{
    static void Main()
    {
       // Activate your license here
            // SautinSoft.PdfMetamorphosis.SetLicense("1234567890");

            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
            p.DocxToPdfConvertFile("test.docx", "test.pdf");
            Console.WriteLine("Converted - [OK]");

    }
}