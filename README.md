![Nuget](https://img.shields.io/nuget/v/sautinsoft.pdfmetamorphosis) ![Nuget](https://img.shields.io/nuget/dt/sautinsoft.pdfmetamorphosis) 
# .NET SDK to convert HTML, DOCX, TXT to PDF

![meta](https://github.com/SautinSoft/SautinSoft.PdfMetamorphosis.Examples/assets/79837963/ab428377-1b77-431f-bfce-9e0af2d551dc)

[SautinSoft.PdfMetamorphosis](https://sautinsoft.com/products/pdf-metamorphosis/) is .NET assembly (SDK) which gives API  to convert Text, HTML, RTF, DOC and DOCX documents to PDF format.

## Quick links

+ [Developer Guide](https://sautinsoft.com/products/pdf-metamorphosis/help/net/)
+ [API Reference](https://sautinsoft.com/products/pdf-metamorphosis/help/net/api-reference/html/N_SautinSoft.htm)

## Top Features

+ [Convert DOCX file to PDF file.](https://sautinsoft.com/products/pdf-metamorphosis/help/net/developer-guide/convert-docx-to-pdf-csharp-vb-net.php)
+ [Convert RTF file to PDF file.](https://sautinsoft.com/products/pdf-metamorphosis/help/net/developer-guide/convert-rtf-file-to-pdf-file-csharp-vb-net.php)
+ [Convert HTML file to PDF file.](https://sautinsoft.com/products/pdf-metamorphosis/help/net/developer-guide/convert-html-file-to-pdf-file-csharp-vb-net.php)
+ [Convert Text file to PDF file.](https://sautinsoft.com/products/pdf-metamorphosis/help/net/developer-guide/convert-text-file-to-pdf-file-csharp-vb-net.php)
+ [Split and Merge PDF files.](https://sautinsoft.com/products/pdf-metamorphosis/help/net/developer-guide/split-and-merge-pdf-documents-csharp-vb-net.php)


## System Requirement

* .NET Framework 4.6.1 - 4.8.1
* .NET Core 2.0 - 3.1, .NET 5, 6, 7, 8
* .NET Standard 2.0
* Windows, Linux, macOS, Android, iOS.

## Getting Started with PDF Metamorphosis .Net

Are you ready to give PDF Metamorphosis .NET a try? Simply execute `Install-Package sautinsoft.pdfmetamorphosis` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have PDF Metamorphosis .NET and want to upgrade the version, please execute `Update-Package sautinsoft.pdfmetamorphosis` to get the latest version.

## Convert Word to PDF

```csharp
string docxPath = @"..\..\example.docx";
string pdfPath = Path.ChangeExtension(docxPath, ".pdf");

SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
            
p.DocxToPdfConvertFile(docxPath, pdfPath);
```
## Convert HTML to PDF

```csharp
string inputFile = @"..\..\example.htm";
string outputFile = @"..\..\test.pdf";

SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();
            
p.HtmlToPdfConvertFile(inputFile, outputFile);
```

## Merge PDF files

```csharp
string[] pdfFiles = { @"..\..\test-00001.pdf", @"..\..\test-00002.pdf" };

SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

p.MergePDFFileArrayToPDFFile(pdfFiles, @"..\..\test_Split_and_Merge_1and2page.pdf");

```

## Resources

+ **Website:** [www.sautinsoft.com](https://www.sautinsoft.com)
+ **Product Home:** [PDF Metamorphosis .Net](https://sautinsoft.com/products/pdf-metamorphosis/)
+ [Download SautinSoft.PDFMetamorphosis](https://sautinsoft.com/products/pdf-metamorphosis/download.php)
+ [Developer Guide](https://sautinsoft.com/products/pdf-metamorphosis/help/net/)
+ [API Reference](https://sautinsoft.com/products/pdf-metamorphosis/help/net/api-reference/html/N_SautinSoft.htm)
+ [Support Team](https://sautinsoft.com/support.php)
+ [License](https://sautinsoft.com/products/pdf-focus/help/net/getting-started/agreement.php)
