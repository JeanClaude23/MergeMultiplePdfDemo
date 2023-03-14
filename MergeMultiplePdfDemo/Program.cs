using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace MergeMultiplePdfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the paths to the PDF files to combine
            string directoryPath = @"D:\Reports\ADSI_Jean\htmlMerged";
            string[] reportFiles = Directory.GetFiles(directoryPath, "*.pdf");

            // Define the paths to the PDF files to combine
            //string[] pdfFiles = new string[] { @"D:\Reports\file1.pdf", @"D:\Reports\file2.pdf", @"D:\Reports\file3.pdf", @"D:\Reports\Result.pdf" };

            Console.WriteLine("Merging started.....");
            // Create a new PDF document
            PdfDocument outputDocument = new PdfDocument();

            // Loop through each PDF file and add its pages to the output document
            foreach (string pdfFile in reportFiles)
            {
                // Open the input PDF document using PDFSharp
                PdfDocument inputDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);

                // Add the pages of the input document to the output document
                foreach (PdfPage page in inputDocument.Pages)
                {
                    outputDocument.AddPage(page);
                }
            }

            // Save the output document to a file
            outputDocument.Save(@"D:\Reports\ADSI_Jean\pdfMerged\combinedPdfFiles.pdf");

            Console.WriteLine("Merging Completed!!!");
            Console.ReadLine();
        }
    }
}
