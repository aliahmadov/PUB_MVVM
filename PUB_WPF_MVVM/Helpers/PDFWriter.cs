using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PUB_WPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PUB_WPF_MVVM.Helpers
{
    public class PDFWriter
    {
        public static int Number { get; set; } = 1;
        public static void GenerateBeerPDF(Beer beer,double total_price,int count)
        {
            Guid file_guid = Guid.NewGuid();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            PdfDocument document = new PdfDocument();

            document.Info.Title = $"Purchase Details Pdf Version";

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font1 = new XFont("Times New Roman", 16, XFontStyle.Bold);
            XFont font3 = new XFont("Times New Roman", 26, XFontStyle.Bold);

            string beerName = $"Name : {beer.Name}";
            string beerPrice = $"Price : {beer.Price}";
            string orderCount = $"Order Count : {count.ToString()}";
            string total_Price = $"Total Price : {total_price.ToString()}$";

            gfx.DrawString(file_guid.ToString(), font3, XBrushes.DarkOrange, new XPoint(100, 50));
            gfx.DrawString(beerName, font1, XBrushes.Black, new XPoint(100, 90));
            gfx.DrawString(beerPrice, font1, XBrushes.Black, new XPoint(100, 120));
            gfx.DrawString(orderCount, font1, XBrushes.Black, new XPoint(100, 150));
            gfx.DrawString(total_Price, font1, XBrushes.Black, new XPoint(100, 180));

            XImage image = XImage.FromFile($@"C:\Users\eliah\source\repos\PUB_WPF_MVVM\PUB_WPF_MVVM{beer.ImagePath}");
            gfx.DrawImage(image,new XPoint(40,220));

            string filePath = $@"C:\Users\eliah\Desktop\{beer.Name.ToUpper()}_Buy_Details{Number++.ToString()}.pdf";
            document.Save(filePath);
           Process.Start(filePath);
        }
    }
}
