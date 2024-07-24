using ReadyGo.Service.Interfaces;
using MigraDocCore.DocumentObjectModel;
using System.IO;
using MigraDocCore.Rendering;
using System;
using ReadyGo.Domain.Entities.ViewModels;
using System.Linq;
using ReadyGo.Domain.Entities;
using MigraDocCore.DocumentObjectModel.Tables;
using System.Text.RegularExpressions;

namespace ReadyGo.Service.Services
{
    public class InvoiceService : IInvoiceService
    {
        public MemoryStream OrderInvoice(OrderDetailsViewModel order, string terms)
        {
            try
            {
                var total = order.Total - order.ProductsDiscount;
                total = total < 0 ? total + order.InvoiceDiscount : total - order.InvoiceDiscount;
                const int headFont = 8;
                const int normalFont = 6;
                string path = Directory.GetCurrentDirectory();
                DirectoryInfo d = new DirectoryInfo(Path.Combine(path, "wwwroot", "invoices"));
                var document = new Document();
                var section = document.AddSection();
                string[] itemArr = { "Sales", "Return" };
                string[] headerArr = { "Customer Code", "Order Date", "Business Name","Order No.",
                    "Customer Name","Sales Person", "Address","Vehicle","Phone","Driver","Route" };
                //Header
                Paragraph paragraph = section.AddParagraph();
                var head = paragraph.AddFormattedText("Light House Bread", TextFormat.Bold);
                head.Font.Size = headFont;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Ready Go (Pvt) Ltd.", TextFormat.Bold);
                head.Font.Size = headFont;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("NTN: 7363312-7 : STRN: 32-77-8761-429-47.", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Inquiry Number: 042 111 544 484", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Order Invoice", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;


                paragraph = section.AddParagraph();
                //header

                //table initialization
                var headerTable = section.AddTable();
                headerTable.Borders.Width = 0.25;
                headerTable.Borders.Left.Width = 0.75;
                headerTable.Borders.Right.Width = 0.75;
                headerTable.Borders.Top.Width = 0.75;
                headerTable.Borders.Bottom.Width = 0.75;
                headerTable.Rows.LeftIndent = 0;
                headerTable.RightPadding = 0;
                headerTable.TopPadding = 0;
                headerTable.LeftPadding = 0;
                headerTable.BottomPadding = 0;

                Column column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();

                //table initialization
                Row row = new Row();
                FormattedText body = new FormattedText();
                //Order Header
                row = headerTable.AddRow();
                //Customer Code
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[0], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.LeftIndent = 2;

                //Customer Code
                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(order.CustomerCode);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.LeftIndent = 2;
                
                //Date
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[1], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.LeftIndent = 2;
                
                //Date
                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(order.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //BusinessName
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[2], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Regex.Replace(order.BusinessName, ".{40}", "$0 "));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //Order Number
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[3], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(order.OrderCode);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;
                
                //Customer name
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[4], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Regex.Replace(order.CustomerName, ".{40}", "$0 "));
                //body = paragraph.AddFormattedText(order.CustomerName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //SalesPerson
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[5], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(order.SalesPersonName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Customer Address
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[6], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(order.CustomerAddress);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //Vehicle
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[7], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(order.VehicleNo);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Phone
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[8], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(order.CustomerPhone);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //Driver
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[9], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(order.DriverName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Route 
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[10], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(order.RouteName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                paragraph = row.Cells[10].AddParagraph();
                row.Cells[10].MergeRight = 9;

                //Order Header


                paragraph = section.AddParagraph();
                //header

                //table initialization
                var table = section.AddTable();
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.75;
                table.Borders.Right.Width = 0.75;
                table.Borders.Top.Width = 0.75;
                table.Borders.Bottom.Width = 0.75;
                table.Rows.LeftIndent = 0;
                table.RightPadding = 0;
                table.TopPadding = 0;
                table.LeftPadding = 0;
                table.BottomPadding = 0;

                Column salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();
                salesColumn = table.AddColumn();


                //Sales Items 
              
                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Sales", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Sr. No.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                //row = table.AddRow();
                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("Item Name", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].Format.LeftIndent = 1;
                row.Cells[1].MergeRight = 6;

                //row = table.AddRow();
                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText("FOC", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[9].AddParagraph();
                body = paragraph.AddFormattedText("Qty", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText("GST", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("Rate", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].MergeRight = 1;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText("Gross", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 1;

                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText("Disc.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].MergeRight = 1;

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText("Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].MergeRight = 1;
                var totalSalesDisc = 0.0;
                var prodDisc = 0.0;
                int serial = 1;
                foreach (var sales in order.Details.Where(x => x.Waste.Equals(0)).OrderBy(x => x.ProductCode))
                {
                    double foc = 0;
                    double quantity = 0;
                    if (sales.Promos.Equals("---"))
                    {
                        quantity = sales.Quantity;
                    }
                    else
                    {
                        foc = sales.Quantity;
                    }

                    prodDisc = sales.Discount * sales.Quantity;
                    totalSalesDisc += prodDisc;

                    row = table.AddRow();
                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText(serial.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[0].Format.RightIndent = 1;

                    serial += 1;

                    paragraph = row.Cells[1].AddParagraph();
                    body = paragraph.AddFormattedText(sales.ProductName, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    //row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[1].Format.LeftIndent = 1;
                    row.Cells[1].MergeRight = 6;

                    paragraph = row.Cells[8].AddParagraph();
                    body = paragraph.AddFormattedText(foc.ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[8].Format.RightIndent = 1;

                    paragraph = row.Cells[9].AddParagraph();
                    body = paragraph.AddFormattedText(quantity.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[9].Format.RightIndent = 1;

                    paragraph = row.Cells[10].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Tax, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[10].Format.RightIndent = 1;
                    row.Cells[10].MergeRight = 1;

                    paragraph = row.Cells[12].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.UnitPrice, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[12].Format.RightIndent = 1;
                    row.Cells[12].MergeRight = 1;

                    paragraph = row.Cells[14].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Gross, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[14].Format.RightIndent = 1;
                    row.Cells[14].MergeRight = 1;

                    paragraph = row.Cells[16].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(prodDisc, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[16].Format.RightIndent = 1;
                    row.Cells[16].MergeRight = 1;

                    paragraph = row.Cells[18].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round((sales.Gross - prodDisc), 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[18].Format.RightIndent = 1;
                    row.Cells[18].MergeRight = 1;
                }
                //Sales Items
                //Sales Items Total

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("-", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].Format.RightIndent = 1;
                
                
                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("-", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].Format.RightIndent = 1;
                row.Cells[1].MergeRight = 6;

                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText("-", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[8].Format.RightIndent = 1;
                
                paragraph = row.Cells[9].AddParagraph();
                body = paragraph.AddFormattedText(order.Details.Where(x => x.Waste.Equals(0)).Sum(x => x.Quantity).ToString(), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[9].Format.RightIndent = 1;

                var taxSales = order.Details.Where(x => x.Waste.Equals(0)).Sum(x => x.Tax);
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(taxSales, 2).ToString("N2"), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[10].Format.RightIndent = 1;
                row.Cells[10].MergeRight = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("-", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].Format.RightIndent = 1;
                row.Cells[12].MergeRight = 1;
                
                var grossSales = order.Details.Where(x => x.Waste.Equals(0)).Sum(x => x.Gross);
                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(grossSales).ToString("N2"), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[14].Format.RightIndent = 1;
                row.Cells[14].MergeRight = 1;

                var discountSales = order.Details.Where(x => x.Waste.Equals(0)).Sum(x => x.Discount);
                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(totalSalesDisc, 2).ToString("N2"), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[16].Format.RightIndent = 1;
                row.Cells[16].MergeRight = 1;

                var totalSales = Math.Round((grossSales - totalSalesDisc), 2);
                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(totalSales).ToString("N2"), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[18].Format.RightIndent = 1;
                row.Cells[18].MergeRight = 1;

                //Sales Items Total

                //Return Items 
                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Return Items", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Sr. No.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("Item Name", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].Format.LeftIndent = 1;
                row.Cells[1].MergeRight = 6;

                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText("FOC", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[9].AddParagraph();
                body = paragraph.AddFormattedText("Qty", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText("GST", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("Rate", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].MergeRight = 1;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText("Gross", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 1;

                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText("Disc.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].MergeRight = 1;

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText("Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].MergeRight = 1;
                var totalDiscount = 0.0;
                serial = 1;
                foreach (var sales in order.Details.Where(x => x.Waste != 0 && !x.IsWaste).OrderBy(x=>x.ProductCode))
                {
                   
                    row = table.AddRow();
                    
                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText(serial.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[0].Format.RightIndent = 1;
                    serial += 1;

                    paragraph = row.Cells[1].AddParagraph();
                    body = paragraph.AddFormattedText(sales.ProductName, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[1].Format.LeftIndent = 1;
                    row.Cells[1].MergeRight = 6;

                    paragraph = row.Cells[8].AddParagraph();
                    body = paragraph.AddFormattedText("0", TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[8].Format.RightIndent = 1;

                    paragraph = row.Cells[9].AddParagraph();
                    body = paragraph.AddFormattedText(sales.Quantity.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[9].Format.RightIndent = 1;

                    totalDiscount += sales.Quantity * sales.Discount;
                    paragraph = row.Cells[10].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Tax, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[10].Format.RightIndent = 1;
                    row.Cells[10].MergeRight = 1;

                    paragraph = row.Cells[12].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.UnitPrice, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[12].Format.RightIndent = 1;
                    row.Cells[12].MergeRight = 1;
                    
                    paragraph = row.Cells[14].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round((sales.Waste + (sales.Discount * sales.Quantity)), 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[14].Format.RightIndent = 1;
                    row.Cells[14].MergeRight = 1;
                    
                    paragraph = row.Cells[16].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(((sales.Discount * sales.Quantity)), 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[16].Format.RightIndent = 1;
                    row.Cells[16].MergeRight = 1;

                    paragraph = row.Cells[18].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round((sales.Waste), 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[18].Format.RightIndent = 1;
                    row.Cells[18].MergeRight = 1;

                    row = table.AddRow();
                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText("Reason:", TextFormat.Bold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[0].Format.LeftIndent = 2;
                    row.Cells[0].MergeRight = 3;

                    paragraph = row.Cells[4].AddParagraph();
                    body = paragraph.AddFormattedText(sales.Reason, TextFormat.Bold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[4].MergeRight = 5;
                    row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[4].Format.LeftIndent = 2;
                    row.Cells[10].MergeRight = 9;

                }
                //Return Items 

                //Waste Items 
                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Waste Items", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Sr. No.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("Item Name", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].Format.LeftIndent = 1;
                row.Cells[1].MergeRight = 6;

                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText("FOC", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[9].AddParagraph();
                body = paragraph.AddFormattedText("Qty", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText("GST", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("Rate", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].MergeRight = 1;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText("Gross", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 1;

                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText("Disc.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].MergeRight = 1;

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText("Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].MergeRight = 1;
                serial = 1;
                foreach (var sales in order.Details.Where(x => x.Waste != 0 && x.IsWaste).OrderBy(x => x.ProductCode))
                {

                    row = table.AddRow();

                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText(serial.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[0].Format.RightIndent = 1;
                    serial += 1;

                    paragraph = row.Cells[1].AddParagraph();
                    body = paragraph.AddFormattedText(sales.ProductName, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[1].Format.LeftIndent = 1;
                    row.Cells[1].MergeRight = 6;

                    paragraph = row.Cells[8].AddParagraph();
                    body = paragraph.AddFormattedText("0", TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[8].Format.RightIndent = 1;

                    paragraph = row.Cells[9].AddParagraph();
                    body = paragraph.AddFormattedText(sales.Quantity.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[9].Format.RightIndent = 1;

                    totalDiscount += sales.Quantity * sales.Discount;
                    paragraph = row.Cells[10].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Tax, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[10].Format.RightIndent = 1;
                    row.Cells[10].MergeRight = 1;

                    paragraph = row.Cells[12].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.UnitPrice, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[12].Format.RightIndent = 1;
                    row.Cells[12].MergeRight = 1;

                    paragraph = row.Cells[14].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round((sales.Waste + (sales.Discount * sales.Quantity)), 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[14].Format.RightIndent = 1;
                    row.Cells[14].MergeRight = 1;

                    paragraph = row.Cells[16].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(((sales.Discount * sales.Quantity)), 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[16].Format.RightIndent = 1;
                    row.Cells[16].MergeRight = 1;

                    paragraph = row.Cells[18].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round((sales.Waste), 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[18].Format.RightIndent = 1;
                    row.Cells[18].MergeRight = 1;

                    row = table.AddRow();
                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText("Reason:", TextFormat.Bold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[0].Format.LeftIndent = 2;
                    row.Cells[0].MergeRight = 3;

                    paragraph = row.Cells[4].AddParagraph();
                    body = paragraph.AddFormattedText(sales.Reason, TextFormat.Bold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[4].MergeRight = 5;
                    row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[4].Format.LeftIndent = 2;
                    row.Cells[10].MergeRight = 9;

                }
                //Waste Items 

                //Return/Waste Total

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Return/Waste Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("-", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].Format.RightIndent = 1;

                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("-", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].Format.RightIndent = 1;
                paragraph = row.Cells[4].AddParagraph();
                row.Cells[1].MergeRight = 6;

                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText("-", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[8].Format.RightIndent = 1;

                paragraph = row.Cells[9].AddParagraph();
                body = paragraph.AddFormattedText(order.Details.Where(x => x.Waste != 0).Sum(x => x.Quantity).ToString(), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[9].Format.RightIndent = 1;

                var taxReturn = order.Details.Where(x => x.Waste != 0).Sum(x => x.Tax);
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(taxReturn, 2).ToString("N2"), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[10].Format.RightIndent = 1;
                row.Cells[10].MergeRight = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("-", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].Format.RightIndent = 1;
                row.Cells[12].MergeRight = 1;

                var grossReturn = order.Details.Where(x => x.Waste != 0).Sum(x => x.Waste);
                grossReturn += totalDiscount;
                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(grossReturn).ToString("N2"), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[14].Format.RightIndent = 1;
                row.Cells[14].MergeRight = 1;

                var discountReturn = order.Details.Where(x => x.Waste != 0).Sum(x => x.Discount);
                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(totalDiscount, 2).ToString("N2"), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[16].Format.RightIndent = 1;
                row.Cells[16].MergeRight = 1;

                var totalReturn = Math.Round(grossReturn, 2);
                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(totalReturn - (totalDiscount)).ToString("N2"), TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[18].Format.RightIndent = 1;
                row.Cells[18].MergeRight = 1;
                //Return/Waste Total

                //Summary Table
                paragraph = section.AddParagraph();

                //table initialization
                var summaryTable = section.AddTable();
                summaryTable.Borders.Width = 0.25;
                summaryTable.Borders.Left.Width = 0.75;
                summaryTable.Borders.Right.Width = 0.75;
                summaryTable.Borders.Top.Width = 0.75;
                summaryTable.Borders.Bottom.Width = 0.75;
                summaryTable.Rows.LeftIndent = 0;
                summaryTable.RightPadding = 0;
                summaryTable.TopPadding = 0;
                summaryTable.LeftPadding = 0;
                summaryTable.BottomPadding = 0;
                summaryTable.Rows.Alignment = RowAlignment.Right;

                Column summaryColumn = summaryTable.AddColumn();
                column = summaryTable.AddColumn();

                //table initialization
                Row summaryRow = new Row();
                FormattedText summaryBody = new FormattedText();

                //Summary Sales//

                paragraph = section.AddParagraph();

                summaryRow = summaryTable.AddRow();
                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText("Summary", TextFormat.Bold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].MergeRight = 1;

                //Summary
                //Gross Sales
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Gross {itemArr[0]} Inc Tax", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;


                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(grossSales).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

                //Sales Discount
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"{itemArr[0]} Disc.", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(totalSalesDisc).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;


                //Sales Tax
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Tax on Sales", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;


                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(taxSales, 2).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

                //Net Sales
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Net Sales", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(grossSales).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

                summaryRow = summaryTable.AddRow();
                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryRow.Cells[0].MergeRight = 1;
                summaryRow.Format.Shading.Color = Colors.LightGray;

                //Summary Sales//


                //Summary return/Waste

                //Return Total
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Gross {itemArr[1]} Inc Tax", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(grossReturn).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

                //Return Discount
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"{itemArr[1]} Disc.", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(totalDiscount, 2).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

                //Return Tax
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Tax on Return", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(taxReturn, 2).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

                //Net Return
                summaryRow = summaryTable.AddRow();
                
                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Net Return", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(totalReturn).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;


                summaryRow = summaryTable.AddRow();
                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryRow.Cells[0].MergeRight = 1;
                summaryRow.Format.Shading.Color = Colors.LightGray;
                //Summary

                //Footer
                //Invoice Discount
                summaryRow = summaryTable.AddRow();
                
                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Invoice Discount", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(order.InvoiceDiscount, 2).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

                //Net Amount
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Net Amount", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                var netTotalExDisc = totalSales - totalReturn;
                var netAmount = 0.0;
                if (netTotalExDisc >= 0)
                    netAmount = netTotalExDisc - order.InvoiceDiscount;
                else
                    netAmount = netTotalExDisc + order.InvoiceDiscount;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(netAmount).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

               

                var netTotalSalesSummary = totalSales + 0;//0 is for tax
                
                //Payment
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Payment", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;

                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round(order.Payment, 2).ToString("N2"), TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;

                //Balance
                summaryRow = summaryTable.AddRow();

                paragraph = summaryRow.Cells[0].AddParagraph();
                summaryBody = paragraph.AddFormattedText($"Balance", TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                summaryRow.Cells[0].Format.LeftIndent = 2;


                paragraph = summaryRow.Cells[1].AddParagraph();
                summaryBody = paragraph.AddFormattedText(Math.Round((netAmount - (order.Payment))).ToString("N2"), TextFormat.Bold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                summaryRow.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                summaryRow.Cells[1].Format.RightIndent = 2;
                //Footer

                paragraph = section.AddParagraph();

                paragraph = section.AddParagraph();
                summaryBody = paragraph.AddFormattedText(terms, TextFormat.NotBold);
                summaryBody.Font.Size = normalFont;
                summaryBody.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;

                headerTable.Format.Alignment = ParagraphAlignment.Center;
                headerTable.Columns.Width = "0.798cm";
                headerTable.Rows.LeftIndent = "0.025cm";
                headerTable.Rows.Height = "0.5cm";
                headerTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                table.Format.Alignment = ParagraphAlignment.Center;
                table.Columns.Width = "0.798cm";
                table.Rows.LeftIndent = "0.025cm";
                table.Rows.Height = "0.5cm";
                table.Rows.VerticalAlignment = VerticalAlignment.Center;

                summaryTable.Format.Alignment = ParagraphAlignment.Center;
                summaryTable.Columns.Width = "4cm";
                summaryTable.Rows.LeftIndent = "0.025cm";
                summaryTable.Rows.Height = "0.5cm";
                summaryTable.Rows.VerticalAlignment = VerticalAlignment.Center;


                //section = document.LastSection;
                section.PageSetup = document.DefaultPageSetup.Clone();
                //section.PageSetup.PageFormat = PageFormat.Letter; // Has no effect after Clone(), just for documentation purposes.
                //section.PageSetup.PageWidth = Unit.FromInch(3);
                var length = (table.Rows.Count * 0.4);
                var paragraphLine = (terms.Split('\n').Length + 7);
                var paragraphLength = terms.Length / 70;
                //section.PageSetup.PageHeight = Unit.FromCentimeter(length + 4 + ((paragraphLine > paragraphLength ? paragraphLine : paragraphLength) * 0.5));
                ////section.PageSetup.LeftMargin = Unit.FromCentimeter(0.5);
                //section.PageSetup.TopMargin = "0.5cm";
                //section.PageSetup.LeftMargin = "0.2cm";
                //section.PageSetup.RightMargin = "0.2cm";
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false);
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                string filename = "OrderInvoice.pdf";

                MemoryStream ms = new MemoryStream();
                pdfRenderer.PdfDocument.Save(ms, false);
                return ms;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public MemoryStream PaymentInvoice(Payment payment, string terms)
        {
            try
            {
                const int headFont = 8;
                const int normalFont = 6;
                string path = Directory.GetCurrentDirectory();
                DirectoryInfo d = new DirectoryInfo(Path.Combine(path, "wwwroot", "invoices"));
                var document = new Document();
                var section = document.AddSection();
                string[] headerArr = { "Customer Code", "Payment Date", "Business Name","Payment No.",
                    "Customer Name","Sales Person", "Address","Device Name","Phone","Route" };

                //Header
                Paragraph paragraph = section.AddParagraph();
                var head = paragraph.AddFormattedText("Light House Bread", TextFormat.Bold);
                head.Font.Size = headFont;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Ready Go (Pvt) Ltd.", TextFormat.Bold);
                head.Font.Size = headFont;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("NTN: 7363312-7 : STRN: 32-77-8761-429-47.", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Inquiry Number: 042 111 544 484", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Payment Invoice", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                //header
                var headerTable = section.AddTable();
                headerTable.Borders.Width = 0.25;
                headerTable.Borders.Left.Width = 0.75;
                headerTable.Borders.Right.Width = 0.75;
                headerTable.Borders.Top.Width = 0.75;
                headerTable.Borders.Bottom.Width = 0.75;
                headerTable.Rows.LeftIndent = 0;
                headerTable.RightPadding = 0;
                headerTable.TopPadding = 0;
                headerTable.LeftPadding = 0;
                headerTable.BottomPadding = 0;

                Column column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();

                //table initialization
                Row row = new Row();
                FormattedText body = new FormattedText();
                //Order Header
                row = headerTable.AddRow();
                //Customer Code
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[0], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.LeftIndent = 2;

                //Customer Code
                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(string.IsNullOrEmpty(payment.Customer.AxCode)?"-": payment.Customer.AxCode);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.LeftIndent = 2;

                //Date
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[1], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.LeftIndent = 2;

                //Date
                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(payment.ReceivedAt.ToString("dd/MM/yyyy HH:mm:ss"));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //BusinessName
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[2], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Regex.Replace(payment.Customer.BusinessName, ".{40}", "$0 "));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //Order Number
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[3], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(payment.PaymentCode??"-");
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Customer name
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[4], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Regex.Replace(payment.Customer.FirstName + " " + payment.Customer.LastName, ".{40}", "$0 "));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //SalesPerson
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[5], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(payment.SalesPerson.FirstName+" "+payment.SalesPerson.LastName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Customer Address
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[6], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(payment.Customer.Address1);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //Vehicle
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[7], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(payment.DeviceName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Phone
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[8], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(string.IsNullOrEmpty(payment.Customer.PhoneNumber)?"-": payment.Customer.PhoneNumber);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //Driver
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[9], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(payment.Customer.Route.Name);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                paragraph = section.AddParagraph();
                //Payment Header
                var table = section.AddTable();
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.75;
                table.Borders.Right.Width = 0.75;
                table.Borders.Top.Width = 0.75;
                table.Borders.Bottom.Width = 0.75;
                table.Rows.LeftIndent = 0;
                table.RightPadding = 0;
                table.TopPadding = 0;
                table.LeftPadding = 0;
                table.BottomPadding = 0;
                table.Rows.Alignment = RowAlignment.Right;

                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();

                //Summary
                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Summary", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 9;
                //Summary
                //Footer

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Openning Balance", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 1;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(payment.CurrentBalance,2).ToString("N2"));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 1;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Amount Received", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 1;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(payment.PaymentReceived, 2).ToString("N2"));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5; 
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 1;

                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("New Balance", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 1;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(payment.NewBalance, 2).ToString("N2"));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 1;


                //Terms
                paragraph = section.AddParagraph();

                paragraph = section.AddParagraph();
                body = paragraph.AddFormattedText(terms, TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                //Terms
                //Footer

                headerTable.Format.Alignment = ParagraphAlignment.Center;
                headerTable.Columns.Width = "0.798cm";
                headerTable.Rows.LeftIndent = "0.025cm";
                headerTable.Rows.Height = "0.5cm";
                headerTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                table.Format.Alignment = ParagraphAlignment.Center;
                table.Columns.Width = "0.798cm";
                table.Rows.LeftIndent = "1.1cm";
                table.Rows.Height = "0.5cm";
                table.Rows.VerticalAlignment = VerticalAlignment.Center;
                section = document.LastSection;
                section.PageSetup = document.DefaultPageSetup.Clone();
                //section.PageSetup.PageFormat = PageFormat.Letter; // Has no effect after Clone(), just for documentation purposes.
                //section.PageSetup.PageWidth = Unit.FromInch(3);
                //var length = table.Rows.Count * 0.4;
                //section.PageSetup.PageHeight = Unit.FromInch(10);
                //section.PageSetup.LeftMargin = Unit.FromCentimeter(0.5);
                //section.PageSetup.TopMargin = "0.5cm";
                //section.PageSetup.LeftMargin = "0.2cm";
                //section.PageSetup.RightMargin = "0.2cm";
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false);
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                string filename = "PaymentInvoice.pdf";
                MemoryStream ms = new MemoryStream();
                pdfRenderer.PdfDocument.Save(ms, false);
                return ms;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public MemoryStream DeliveryReportyInvoice(DeliveryReportViewModel model, string terms)
        {
            try
            {
                //var total = model.Total - model.ProductsDiscount;
                //total = total < 0 ? total + model.InvoiceDiscount : total - model.InvoiceDiscount;
                const int headFont = 8;
                const int normalFont = 6;
                string path = Directory.GetCurrentDirectory();
                DirectoryInfo d = new DirectoryInfo(Path.Combine(path, "wwwroot", "invoices"));
                var document = new Document();
                var section = document.AddSection();
                section.PageSetup = document.DefaultPageSetup.Clone();
                string[] itemArr = { "Sales", "Return" };
                string[] headerArr = { "Report Date" , "Salesperson","Route", "Vehicle Number",  "Driver Name", "Status" };
                //Header
                Paragraph paragraph = section.AddParagraph();
                var head = paragraph.AddFormattedText("Light House Bread", TextFormat.Bold);
                head.Font.Size = headFont;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Ready Go (Pvt) Ltd.", TextFormat.Bold);
                head.Font.Size = headFont;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("NTN: 7363312-7 : STRN: 32-77-8761-429-47.", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Inquiry Number: 042 111 544 484", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;

                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Settlement Sheet Report", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                //header

                //table initialization
                var headerTable = section.AddTable();
                headerTable.Borders.Width = 0.25;
                headerTable.Borders.Left.Width = 0.75;
                headerTable.Borders.Right.Width = 0.75;
                headerTable.Borders.Top.Width = 0.75;
                headerTable.Borders.Bottom.Width = 0.75;
                headerTable.Rows.LeftIndent = 0;
                headerTable.RightPadding = 0;
                headerTable.TopPadding = 0;
                headerTable.LeftPadding = 0;
                headerTable.BottomPadding = 0;
                headerTable.Rows.Alignment = RowAlignment.Center;

                Column column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();

                //table initialization
                Row row = new Row();
                FormattedText body = new FormattedText();
                //Order Header
                row = headerTable.AddRow();
                //Customer Code
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[0], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.LeftIndent = 2;

                //Customer Code
                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(model.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.LeftIndent = 2;

                //Date
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[1], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.LeftIndent = 2;

                //Date
                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(model.SalesPersonName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //BusinessName
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[2], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(model.RouteName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //Order Number
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[3], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(model.VehicleNumber);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Customer name
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[4], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(model.DriverName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //SalesPerson
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[5], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                var status = model.IsMarked ? "Approved" : "Disapproved";

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(status);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Order Header

                //Sales Items 
                paragraph = section.AddParagraph();
                //Payment Header
                var table = section.AddTable();
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.75;
                table.Borders.Right.Width = 0.75;
                table.Borders.Top.Width = 0.75;
                table.Borders.Bottom.Width = 0.75;
                table.Rows.LeftIndent = 0;
                table.RightPadding = 0;
                table.TopPadding = 0;
                table.LeftPadding = 0;
                table.BottomPadding = 0;
                table.Rows.Alignment = RowAlignment.Center;

                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();


                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Stock Details", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();

                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Sr. No.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("Item Name", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].MergeRight = 4;
                row.Cells[1].Format.LeftIndent = 2;


                paragraph = row.Cells[6].AddParagraph();
                body = paragraph.AddFormattedText("Code", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[6].MergeRight = 1;

                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText("Unit Price", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[8].MergeRight = 1;

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText("Ass. Stock", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("Sales", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].MergeRight = 1;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText("Return", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 1;

                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText("Waste", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].MergeRight = 1;


                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText("Stock Balance", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].MergeRight = 1;

                int serial = 1;
                foreach (var sales in model.OrderProducts.OrderBy(x=>x.ProductCode))
                {
                    row = table.AddRow();
                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText(serial.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[0].Format.RightIndent = 1;

                    serial += 1;

                    paragraph = row.Cells[1].AddParagraph();
                    body = paragraph.AddFormattedText(sales.ProductName, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[1].MergeRight = 4;
                    row.Cells[1].Format.LeftIndent = 2;

                    paragraph = row.Cells[6].AddParagraph();
                    body = paragraph.AddFormattedText(sales.ProductCode, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[6].Format.RightIndent = 1;
                    row.Cells[6].MergeRight = 1;

                    paragraph = row.Cells[8].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Price, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[8].Format.RightIndent = 1;
                    row.Cells[8].MergeRight = 1;

                    paragraph = row.Cells[10].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Assigned).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[10].Format.RightIndent = 1;
                    row.Cells[10].MergeRight = 1;

                    paragraph = row.Cells[12].AddParagraph();
                    body = paragraph.AddFormattedText(sales.Quantity.ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[12].Format.RightIndent = 1;
                    row.Cells[12].MergeRight = 1;

                    paragraph = row.Cells[14].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.ReturnQuantity, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[14].Format.RightIndent = 1;
                    row.Cells[14].MergeRight = 1;

                    paragraph = row.Cells[16].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.WasteQuantity, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[16].Format.RightIndent = 1;
                    row.Cells[16].MergeRight = 1;

                    paragraph = row.Cells[18].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Assigned + sales.ReturnQuantity - (sales.WasteQuantity + sales.Quantity)).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[18].MergeRight = 1;
                    row.Cells[18].Format.RightIndent = 1;

                }
                //Sales Items
                //Sales Total
                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 9;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].Format.RightIndent = 1;

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x=>x.Assigned)).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[10].Format.RightIndent = 1;
                row.Cells[10].MergeRight = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.Quantity), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[12].Format.RightIndent = 1;
                row.Cells[12].MergeRight = 1;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.ReturnQuantity), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[14].Format.RightIndent = 1;
                row.Cells[14].MergeRight = 1;

                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.WasteQuantity), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[16].Format.RightIndent = 1;
                row.Cells[16].MergeRight = 1;

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(sales => sales.Assigned + sales.ReturnQuantity - (sales.WasteQuantity + sales.Quantity))).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[18].MergeRight = 1;
                row.Cells[18].Format.RightIndent = 1;

                //Sales Total


                //Order Table 
                paragraph = section.AddParagraph();
                var orderTable = section.AddTable();
                orderTable.Borders.Width = 0.25;
                orderTable.Borders.Left.Width = 0.75;
                orderTable.Borders.Right.Width = 0.75;
                orderTable.Borders.Top.Width = 0.75;
                orderTable.Borders.Bottom.Width = 0.75;
                orderTable.Rows.LeftIndent = 0;
                orderTable.RightPadding = 0;
                orderTable.TopPadding = 0;
                orderTable.LeftPadding = 0;
                orderTable.BottomPadding = 0;
                orderTable.Rows.Alignment = RowAlignment.Center;

                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();
                column = orderTable.AddColumn();



                //Order Details
             
                row = orderTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Order Details", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = orderTable.AddRow();

                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Sr. No.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("Business Name", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].MergeRight = 5;
                row.Cells[1].Format.LeftIndent = 2;

                paragraph = row.Cells[7].AddParagraph();
                body = paragraph.AddFormattedText("Cust. Code", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[7].MergeRight = 1;

                paragraph = row.Cells[9].AddParagraph();
                body = paragraph.AddFormattedText("Code", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[9].MergeRight = 2;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("Gross", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].MergeRight = 1;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText("Disc.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 1;

                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText("Ret/Was", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].MergeRight = 1;

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText("Net", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].MergeRight = 1;

                serial = 1;
                foreach (var sales in model.Orders.OrderBy(x=>x.Code))
                {
                    row = orderTable.AddRow();

                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText(serial.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[0].Format.RightIndent = 1;
                    serial += 1;

                    paragraph = row.Cells[1].AddParagraph();
                    body = paragraph.AddFormattedText(Regex.Replace(sales.BusinessName, ".{40}", "$0 "), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[1].MergeRight = 5;
                    row.Cells[1].Format.LeftIndent = 2;

                    paragraph = row.Cells[7].AddParagraph();
                    body = paragraph.AddFormattedText(sales.CustomerCode, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[7].Format.RightIndent = 1;
                    row.Cells[7].MergeRight = 1;

                    paragraph = row.Cells[9].AddParagraph();
                    body = paragraph.AddFormattedText(sales.Code, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[9].Format.RightIndent = 1;
                    row.Cells[9].MergeRight = 2;

                    paragraph = row.Cells[12].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Gross, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[12].Format.RightIndent = 1;
                    row.Cells[12].MergeRight = 1;

                    paragraph = row.Cells[14].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Discount, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[14].Format.RightIndent = 1;
                    row.Cells[14].MergeRight = 1;

                    paragraph = row.Cells[16].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Return, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[16].Format.RightIndent = 1;
                    row.Cells[16].MergeRight = 1;

                    paragraph = row.Cells[18].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Total, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[18].Format.RightIndent = 1;
                    row.Cells[18].MergeRight = 1;
                }
                //Order Details 

                //Order Total

                row = orderTable.AddRow();

                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].Format.RightIndent = 1;
                row.Cells[0].MergeRight = 11;
              
                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Orders.Sum(x=>x.Gross), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[12].Format.RightIndent = 1;
                row.Cells[12].MergeRight = 1;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Orders.Sum(x => x.Discount), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[14].Format.RightIndent = 1;
                row.Cells[14].MergeRight = 1;

                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Orders.Sum(x => x.Return), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[16].Format.RightIndent = 1;
                row.Cells[16].MergeRight = 1;

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Orders.Sum(x => x.Total), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[18].Format.RightIndent = 1;
                row.Cells[18].MergeRight = 1;

                //Order Total



                //Payment Table 
                paragraph = section.AddParagraph();
                var paymentTable = section.AddTable();
                paymentTable.Borders.Width = 0.25;
                paymentTable.Borders.Left.Width = 0.75;
                paymentTable.Borders.Right.Width = 0.75;
                paymentTable.Borders.Top.Width = 0.75;
                paymentTable.Borders.Bottom.Width = 0.75;
                paymentTable.Rows.LeftIndent = 0;
                paymentTable.RightPadding = 0;
                paymentTable.TopPadding = 0;
                paymentTable.LeftPadding = 0;
                paymentTable.BottomPadding = 0;
                paymentTable.Rows.Alignment = RowAlignment.Center;

                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();
                column = paymentTable.AddColumn();


                //Payment Details

                row = paymentTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Payment Details", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = paymentTable.AddRow();

                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Sr. No.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("Business Name", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].MergeRight = 5;
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].Format.LeftIndent = 2;

                paragraph = row.Cells[7].AddParagraph();
                body = paragraph.AddFormattedText("Cust. Code", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[7].MergeRight = 2;

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText("Code", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText("Payment Received", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;

                serial = 1;
                foreach (var payment in model.Payments.OrderBy(x => x.PaymentCode))
                {
                    row = paymentTable.AddRow();
                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText(serial.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[0].Format.RightIndent = 1;
                    serial += 1;

                    paragraph = row.Cells[1].AddParagraph();
                    body = paragraph.AddFormattedText(Regex.Replace(payment.BusinessName, ".{40}", "$0 "), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[1].MergeRight = 5;
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[1].Format.LeftIndent = 2;

                    paragraph = row.Cells[7].AddParagraph();
                    body = paragraph.AddFormattedText(payment.CustomerCode, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[7].Format.RightIndent = 1;
                    row.Cells[7].MergeRight = 2;

                    paragraph = row.Cells[10].AddParagraph();
                    body = paragraph.AddFormattedText(payment.PaymentCode, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[10].Format.RightIndent = 1;
                    row.Cells[10].MergeRight = 3;

                    paragraph = row.Cells[14].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(payment.Payment, 2).ToString("N2"), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[14].Format.RightIndent = 1;
                    row.Cells[14].MergeRight = 5;
                }
                //Payment Details 

                //Payment Totals
                row = paymentTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].Format.RightIndent = 1;
                row.Cells[0].MergeRight = 13;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Payments.Sum(x=>x.Payment), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[14].Format.RightIndent = 1;
                row.Cells[14].MergeRight = 5;

                //Payment Totals



                paragraph = section.AddParagraph();


                //Summary Sales//
                //table initialization
                var summaryTable = section.AddTable();
                summaryTable.Borders.Width = 0.25;
                summaryTable.Borders.Left.Width = 0.75;
                summaryTable.Borders.Right.Width = 0.75;
                summaryTable.Borders.Top.Width = 0.75;
                summaryTable.Borders.Bottom.Width = 0.75;
                summaryTable.Rows.LeftIndent = 0;
                summaryTable.RightPadding = 0;
                summaryTable.TopPadding = 0;
                summaryTable.LeftPadding = 0;
                summaryTable.BottomPadding = 0;
                summaryTable.Rows.Alignment = RowAlignment.Right;

                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();


                //Return/Waste Total
                //Return/Waste Total


                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Summary", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 9;

                //Summary
                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText($"Dispatch", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Dispatch, 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Unsold/Return", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => (x.ReturnQuantity + (x.Assigned - x.Quantity)) * x.Price), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Waste", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.WasteQuantity * x.Price), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Gross Sale", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Dispatch - model.OrderProducts.Sum(x => (x.ReturnQuantity + (x.Assigned - x.Quantity)) * x.Price) - model.OrderProducts.Sum(x => x.WasteQuantity * x.Price)).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                //var netTotalSales = totalSales;//0 is for tax
                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Discount", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.TotalDiscount, 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Discount %", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.TotalGross == 0 ? 0 : (model.TotalDiscount / model.TotalGross) * 100, 2).ToString("N2") + "%", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Net Sales", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Dispatch - model.OrderProducts.Sum(x => (x.ReturnQuantity + (x.Assigned - x.Quantity)) * x.Price) - model.OrderProducts.Sum(x => x.WasteQuantity * x.Price) - model.TotalDiscount).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Cash Short", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.CashShort).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;
                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Market Credit", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Total - model.TotalCash).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                row.Cells[0].MergeRight = 9;
                row.Format.Shading.Color = Colors.LightGray;

                //Summary Sales//


                //Footer

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText($"Net Cash Recievable", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Dispatch - model.OrderProducts.Sum(x => (x.ReturnQuantity + (x.Assigned - x.Quantity)) * x.Price) - model.OrderProducts.Sum(x => x.WasteQuantity * x.Price) - model.TotalDiscount - model.CashShort - (model.Total - model.TotalCash)).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                //row = table.AddRow();
                //paragraph = row.Cells[0].AddParagraph();
                //body = paragraph.AddFormattedText($"Customer Balance", TextFormat.NotBold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[0].MergeRight = 1;
                //row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[0].Format.LeftIndent = 2;


                //paragraph = row.Cells[2].AddParagraph();
                //body = paragraph.AddFormattedText(Math.Round(model.TotalBalance, 2).ToString("N2"), TextFormat.NotBold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[2].MergeRight = 2;
                //row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[2].Format.RightIndent = 2;


                //Footer

                paragraph = section.AddParagraph();

                paragraph = section.AddParagraph();
                body = paragraph.AddFormattedText(terms, TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                
                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();

                paragraph = section.AddParagraph();
                body = paragraph.AddFormattedText("                                             ____________________                                 _____________________                                      _____________________", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Left;

                paragraph = section.AddParagraph();
                body = paragraph.AddFormattedText("                                                       Salesman                                                                 TSO                                                           Area Sales Manager", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Left;

                //Summary Sales//
                //table initialization
                //var signTable = section.AddTable();
                //signTable.Borders.Width = 0.25;
                //signTable.Borders.Left.Width = 0.75;
                //signTable.Borders.Right.Width = 0.75;
                //signTable.Borders.Top.Width = 0.75;
                //signTable.Borders.Bottom.Width = 0.75;
                //signTable.Rows.LeftIndent = 0;
                //signTable.RightPadding = 0;
                //signTable.TopPadding = 0;
                //signTable.LeftPadding = 0;
                //signTable.BottomPadding = 0;
                //signTable.Rows.Alignment = RowAlignment.Right;

                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();

                //row = signTable.AddRow();
                //paragraph = row.Cells[0].AddParagraph();
                //body = paragraph.AddFormattedText($"Salesman", TextFormat.Bold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[0].Format.LeftIndent = 2;
                //row.Cells[0].MergeRight = 2;

                //row.Cells[3].MergeRight = 2;

                //paragraph = row.Cells[6].AddParagraph();
                //body = paragraph.AddFormattedText($"TSO", TextFormat.Bold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[6].Format.LeftIndent = 2;
                //row.Cells[6].MergeRight = 2;

                //row.Cells[9].MergeRight = 2;

                //paragraph = row.Cells[12].AddParagraph();
                //body = paragraph.AddFormattedText($"Area Sales Manager", TextFormat.Bold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[12].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[12].Format.LeftIndent = 2;
                //row.Cells[12].MergeRight = 2;

                //row.Cells[15].MergeRight = 2;

                headerTable.Format.Alignment = ParagraphAlignment.Center;
                headerTable.Columns.Width = "1cm";
                headerTable.Rows.LeftIndent = "0.025cm";
                headerTable.Rows.Height = "0.5cm";
                headerTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                table.Format.Alignment = ParagraphAlignment.Center;
                table.Columns.Width = "1cm";
                table.Rows.LeftIndent = "1.1cm";
                table.Rows.Height = "0.5cm";
                table.Rows.VerticalAlignment = VerticalAlignment.Center;

                orderTable.Format.Alignment = ParagraphAlignment.Center;
                orderTable.Columns.Width = "1cm";
                orderTable.Rows.LeftIndent = "1.1cm";
                orderTable.Rows.Height = "0.5cm";
                orderTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                paymentTable.Format.Alignment = ParagraphAlignment.Center;
                paymentTable.Columns.Width = "1cm";
                paymentTable.Rows.LeftIndent = "1.1cm";
                paymentTable.Rows.Height = "0.5cm";
                paymentTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                summaryTable.Format.Alignment = ParagraphAlignment.Center;
                summaryTable.Columns.Width = "0.798cm";
                summaryTable.Rows.LeftIndent = "1.1cm";
                summaryTable.Rows.Height = "0.5cm";
                summaryTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                //signTable.Format.Alignment = ParagraphAlignment.Center;
                //signTable.Columns.Width = "0.88cm";
                //signTable.Rows.LeftIndent = "1.1cm";
                //signTable.Rows.Height = "0.5cm";
                //signTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                section = document.LastSection;
                section.PageSetup = document.DefaultPageSetup.Clone();
                section.PageSetup.PageFormat = PageFormat.Letter; // Has no effect after Clone(), just for documentation purposes.
                //section.PageSetup.PageWidth = Unit.FromInch(3);
                //var length = (table.Rows.Count * 0.4);
                //var paragraphLine = (terms.Split('\n').Length + 7);
                //var paragraphLength = terms.Length / 70;
                //section.PageSetup.PageHeight = Unit.FromCentimeter(length + 4 + ((paragraphLine > paragraphLength ? paragraphLine : paragraphLength) * 0.5));
                //section.PageSetup.LeftMargin = Unit.FromCentimeter(0.5);
                //section.PageSetup.TopMargin = "0.5cm";
                //section.PageSetup.LeftMargin = "0.2cm";
                //section.PageSetup.RightMargin = "0.2cm";
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false);
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                MemoryStream ms = new MemoryStream();
                pdfRenderer.PdfDocument.Save(ms, false);
                return ms;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public MemoryStream SettlementSheetInvoice(DeliveryReportViewModel model, string terms)
        {
            try
            {
                const int headFont = 8;
                const int normalFont = 6;
                string path = Directory.GetCurrentDirectory();
                DirectoryInfo d = new DirectoryInfo(Path.Combine(path, "wwwroot", "invoices"));
                var document = new Document();
                var section = document.AddSection();
                section.PageSetup = document.DefaultPageSetup.Clone();
                string[] itemArr = { "Sales", "Return" };
                string[] headerArr = { "Report Date", "Salesperson", "Route", "Vehicle Number", "Driver Name", "Status" };
                //Header
                Paragraph paragraph = section.AddParagraph();
                var head = paragraph.AddFormattedText("Light House Bread", TextFormat.Bold);
                head.Font.Size = headFont;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Ready Go (Pvt) Ltd.", TextFormat.Bold);
                head.Font.Size = headFont;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("NTN: 7363312-7 : STRN: 32-77-8761-429-47.", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Inquiry Number: 042 111 544 484", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;

                paragraph = section.AddParagraph();
                head = paragraph.AddFormattedText("Settlement Sheet Report", TextFormat.Bold);
                head.Font.Size = 7;
                head.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph = section.AddParagraph();
                //header

                //table initialization
                var headerTable = section.AddTable();
                headerTable.Borders.Width = 0.25;
                headerTable.Borders.Left.Width = 0.75;
                headerTable.Borders.Right.Width = 0.75;
                headerTable.Borders.Top.Width = 0.75;
                headerTable.Borders.Bottom.Width = 0.75;
                headerTable.Rows.LeftIndent = 0;
                headerTable.RightPadding = 0;
                headerTable.TopPadding = 0;
                headerTable.LeftPadding = 0;
                headerTable.BottomPadding = 0;
                headerTable.Rows.Alignment = RowAlignment.Center;

                Column column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();
                column = headerTable.AddColumn();

                //table initialization
                Row row = new Row();
                FormattedText body = new FormattedText();
                //Order Header
                row = headerTable.AddRow();
                //Customer Code
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[0], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.LeftIndent = 2;

                //Customer Code
                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(model.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"));
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.LeftIndent = 2;

                //Date
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[1], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.LeftIndent = 2;

                //Date
                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(model.SalesPersonName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //BusinessName
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[2], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(model.RouteName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //Order Number
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[3], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(model.VehicleNumber);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Customer name
                row = headerTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[4], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(model.DriverName);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.LeftIndent = 2;

                //SalesPerson
                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(headerArr[5], TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 3;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.LeftIndent = 2;

                var status = model.IsMarked ? "Approved" : "Disapproved";

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText(status);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 5;
                row.Cells[14].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[14].Format.LeftIndent = 2;

                //Order Header

                //Sales Items 
                paragraph = section.AddParagraph();
                //Payment Header
                var table = section.AddTable();
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.75;
                table.Borders.Right.Width = 0.75;
                table.Borders.Top.Width = 0.75;
                table.Borders.Bottom.Width = 0.75;
                table.Rows.LeftIndent = 0;
                table.RightPadding = 0;
                table.TopPadding = 0;
                table.LeftPadding = 0;
                table.BottomPadding = 0;
                table.Rows.Alignment = RowAlignment.Center;

                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();
                column = table.AddColumn();


                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Settlement Sheet", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 19;

                row = table.AddRow();

                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Sr. No.", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[1].AddParagraph();
                body = paragraph.AddFormattedText("Item Name", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].MergeRight = 3;
                row.Cells[1].Format.LeftIndent = 2;


                paragraph = row.Cells[5].AddParagraph();
                body = paragraph.AddFormattedText("Code", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[5].MergeRight = 1;    

                paragraph = row.Cells[7].AddParagraph();
                body = paragraph.AddFormattedText("Unit Price", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText("Ass. Stock", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[8].MergeRight = 1;

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText("Unsold/Return", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].MergeRight = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("Waste", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].MergeRight = 1;

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText("Sampling to (Mkt)", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[14].MergeRight = 1;


                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText("Sampling to (HO)", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[16].MergeRight = 1;

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText("Sold Stock", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].MergeRight = 1;

                row = table.AddRow();

                row.Cells[0].MergeRight = 7;

                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText("Unit", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[9].AddParagraph();
                body = paragraph.AddFormattedText("Value", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText("Unit", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[11].AddParagraph();
                body = paragraph.AddFormattedText("Value", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText("Unit", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[13].AddParagraph();
                body = paragraph.AddFormattedText("Value", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[14].AddParagraph();
                body = paragraph.AddFormattedText("Unit", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[15].AddParagraph();
                body = paragraph.AddFormattedText("Value", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[16].AddParagraph();
                body = paragraph.AddFormattedText("Unit", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";


                paragraph = row.Cells[17].AddParagraph();
                body = paragraph.AddFormattedText("Value", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText("Unit", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";


                paragraph = row.Cells[19].AddParagraph();
                body = paragraph.AddFormattedText("Value", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";

                int serial = 1;
                foreach (var sales in model.OrderProducts.OrderBy(x => x.ProductCode))
                {
                    row = table.AddRow();
                    paragraph = row.Cells[0].AddParagraph();
                    body = paragraph.AddFormattedText(serial.ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[0].Format.RightIndent = 1;

                    serial += 1;

                    paragraph = row.Cells[1].AddParagraph();
                    body = paragraph.AddFormattedText(sales.ProductName, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[1].MergeRight = 3;
                    row.Cells[1].Format.LeftIndent = 2;

                    paragraph = row.Cells[5].AddParagraph();
                    body = paragraph.AddFormattedText(sales.ProductCode, TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[5].Format.RightIndent = 1;
                    row.Cells[5].MergeRight = 1;

                    paragraph = row.Cells[7].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Price).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[7].Format.RightIndent = 1;

                    paragraph = row.Cells[8].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Assigned).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[8].Format.RightIndent = 1;

                    paragraph = row.Cells[9].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Assigned * sales.Price).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[9].Format.RightIndent = 1;

                    paragraph = row.Cells[10].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(Math.Abs(sales.ReturnQuantity) + (sales.Assigned - sales.Quantity)).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[10].Format.RightIndent = 1;

                    paragraph = row.Cells[11].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(Math.Abs(sales.ReturnQuantity) + (sales.Assigned - sales.Quantity) * sales.Price).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[11].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[11].Format.RightIndent = 1;

                    paragraph = row.Cells[12].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.WasteQuantity).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[12].Format.RightIndent = 1;

                    paragraph = row.Cells[13].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.WasteQuantity * sales.Price).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[13].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[13].Format.RightIndent = 1;

                    paragraph = row.Cells[18].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Quantity).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[18].Format.RightIndent = 1;

                    paragraph = row.Cells[19].AddParagraph();
                    body = paragraph.AddFormattedText(Math.Round(sales.Quantity * sales.Price).ToString(), TextFormat.NotBold);
                    body.Font.Size = normalFont;
                    body.Font.Name = "Arial";
                    row.Cells[19].Format.Alignment = ParagraphAlignment.Right;
                    row.Cells[19].Format.RightIndent = 1;

                }
                //Sales Items
                //Sales Total
                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Total", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 7;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].Format.RightIndent = 1;

                paragraph = row.Cells[8].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.Assigned)).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[8].Format.RightIndent = 1;

                paragraph = row.Cells[9].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.Assigned * x.Price)).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[9].Format.RightIndent = 1;

                paragraph = row.Cells[10].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => Math.Abs(x.ReturnQuantity) + (x.Assigned - x.Quantity))).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[10].Format.RightIndent = 1;

                paragraph = row.Cells[11].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => Math.Abs(x.ReturnQuantity) + (x.Assigned - x.Quantity) * x.Price)).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[11].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[11].Format.RightIndent = 1;

                paragraph = row.Cells[12].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.WasteQuantity)).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[12].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[12].Format.RightIndent = 1;

                paragraph = row.Cells[13].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.WasteQuantity * x.Price)).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[13].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[13].Format.RightIndent = 1;

                paragraph = row.Cells[18].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(sales => sales.Quantity)).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[18].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[18].Format.RightIndent = 1;

                paragraph = row.Cells[19].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(sales => sales.Quantity * sales.Price)).ToString(), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[19].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[19].Format.RightIndent = 1;

                //Sales Total

                paragraph = section.AddParagraph();


                //Summary Sales//
                //table initialization
                var summaryTable = section.AddTable();
                summaryTable.Borders.Width = 0.25;
                summaryTable.Borders.Left.Width = 0.75;
                summaryTable.Borders.Right.Width = 0.75;
                summaryTable.Borders.Top.Width = 0.75;
                summaryTable.Borders.Bottom.Width = 0.75;
                summaryTable.Rows.LeftIndent = 0;
                summaryTable.RightPadding = 0;
                summaryTable.TopPadding = 0;
                summaryTable.LeftPadding = 0;
                summaryTable.BottomPadding = 0;
                summaryTable.Rows.Alignment = RowAlignment.Right;

                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();
                column = summaryTable.AddColumn();


                //Return/Waste Total
                //Return/Waste Total

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Summary", TextFormat.Bold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 9;

                //Summary
                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText($"Dispatch", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Dispatch, 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Unsold/Return", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => (x.ReturnQuantity + (x.Assigned - x.Quantity)) * x.Price), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Waste", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.OrderProducts.Sum(x => x.WasteQuantity * x.Price), 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Gross Sale", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Dispatch - model.OrderProducts.Sum(x => (x.ReturnQuantity + (x.Assigned - x.Quantity)) * x.Price) - model.OrderProducts.Sum(x => x.WasteQuantity * x.Price)).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                //var netTotalSales = totalSales;//0 is for tax
                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Discount", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.TotalDiscount, 2).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Discount %", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.TotalGross == 0 ? 0 : (model.TotalDiscount / model.TotalGross) * 100, 2).ToString("N2")+ "%", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Net Sales", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Dispatch - model.OrderProducts.Sum(x => (x.ReturnQuantity + (x.Assigned - x.Quantity)) * x.Price) - model.OrderProducts.Sum(x => x.WasteQuantity * x.Price) - model.TotalDiscount).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Cash Short", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.CashShort).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;
                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText("Market Credit", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Total - model.TotalCash).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                row.Cells[0].MergeRight = 9;
                row.Format.Shading.Color = Colors.LightGray;

                //Summary Sales//


                //Footer

                row = summaryTable.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                body = paragraph.AddFormattedText($"Net Cash Recievable", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[0].MergeRight = 3;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.LeftIndent = 2;

                paragraph = row.Cells[4].AddParagraph();
                body = paragraph.AddFormattedText(Math.Round(model.Dispatch - model.OrderProducts.Sum(x => (x.ReturnQuantity + (x.Assigned - x.Quantity)) * x.Price) - model.OrderProducts.Sum(x => x.WasteQuantity * x.Price) - model.TotalDiscount - model.CashShort - (model.Total - model.TotalCash)).ToString("N2"), TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                row.Cells[4].MergeRight = 5;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].Format.RightIndent = 2;

                //row = table.AddRow();
                //paragraph = row.Cells[0].AddParagraph();
                //body = paragraph.AddFormattedText($"Customer Balance", TextFormat.NotBold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[0].MergeRight = 1;
                //row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[0].Format.LeftIndent = 2;


                //paragraph = row.Cells[2].AddParagraph();
                //body = paragraph.AddFormattedText(Math.Round(model.TotalBalance, 2).ToString("N2"), TextFormat.NotBold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[2].MergeRight = 2;
                //row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[2].Format.RightIndent = 2;


                //Footer

                paragraph = section.AddParagraph();

                paragraph = section.AddParagraph();
                body = paragraph.AddFormattedText(terms, TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Center;

                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();

                paragraph = section.AddParagraph();
                body = paragraph.AddFormattedText("                                             ____________________                                 _____________________                                      _____________________", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Left;

                paragraph = section.AddParagraph();
                body = paragraph.AddFormattedText("                                                       Salesman                                                                 TSO                                                           Area Sales Manager", TextFormat.NotBold);
                body.Font.Size = normalFont;
                body.Font.Name = "Arial";
                paragraph.Format.Alignment = ParagraphAlignment.Left;

                //Summary Sales//
                ////table initialization
                //var signTable = section.AddTable();
                //signTable.Borders.Width = 0.25;
                //signTable.Borders.Left.Width = 0.75;
                //signTable.Borders.Right.Width = 0.75;
                //signTable.Borders.Top.Width = 0.75;
                //signTable.Borders.Bottom.Width = 0.75;
                //signTable.Rows.LeftIndent = 0;
                //signTable.RightPadding = 0;
                //signTable.TopPadding = 0;
                //signTable.LeftPadding = 0;
                //signTable.BottomPadding = 0;
                //signTable.Rows.Alignment = RowAlignment.Right;

                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();
                //column = signTable.AddColumn();

                //row = signTable.AddRow();
                //paragraph = row.Cells[0].AddParagraph();
                //body = paragraph.AddFormattedText($"Salesman", TextFormat.Bold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[0].Format.LeftIndent = 2;
                //row.Cells[0].MergeRight = 2;

                //row.Cells[3].MergeRight = 2;

                //paragraph = row.Cells[6].AddParagraph();
                //body = paragraph.AddFormattedText($"TSO", TextFormat.Bold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[6].Format.LeftIndent = 2;
                //row.Cells[6].MergeRight = 2;

                //row.Cells[9].MergeRight = 2;

                //paragraph = row.Cells[12].AddParagraph();
                //body = paragraph.AddFormattedText($"Area Sales Manager", TextFormat.Bold);
                //body.Font.Size = normalFont;
                //body.Font.Name = "Arial";
                //row.Cells[12].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[12].Format.LeftIndent = 2;
                //row.Cells[12].MergeRight = 2;

                //row.Cells[15].MergeRight = 2;

                headerTable.Format.Alignment = ParagraphAlignment.Center;
                headerTable.Columns.Width = "1cm";
                headerTable.Rows.LeftIndent = "0.025cm";
                headerTable.Rows.Height = "0.5cm";
                headerTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                table.Format.Alignment = ParagraphAlignment.Center;
                table.Columns.Width = "1cm";
                table.Rows.LeftIndent = "1.1cm";
                table.Rows.Height = "0.5cm";
                table.Rows.VerticalAlignment = VerticalAlignment.Center;

                summaryTable.Format.Alignment = ParagraphAlignment.Center;
                summaryTable.Columns.Width = "0.798cm";
                summaryTable.Rows.LeftIndent = "1.1cm";
                summaryTable.Rows.Height = "0.5cm";
                summaryTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                //signTable.Format.Alignment = ParagraphAlignment.Center;
                //signTable.Columns.Width = "0.88cm";
                //signTable.Rows.LeftIndent = "1.1cm";
                //signTable.Rows.Height = "0.5cm";
                //signTable.Rows.VerticalAlignment = VerticalAlignment.Center;

                section = document.LastSection;
                section.PageSetup = document.DefaultPageSetup.Clone();
                section.PageSetup.PageFormat = PageFormat.Letter; // Has no effect after Clone(), just for documentation purposes.
                //section.PageSetup.PageWidth = Unit.FromInch(3);
                //var length = (table.Rows.Count * 0.4);
                //var paragraphLine = (terms.Split('\n').Length + 7);
                //var paragraphLength = terms.Length / 70;
                //section.PageSetup.PageHeight = Unit.FromCentimeter(length + 4 + ((paragraphLine > paragraphLength ? paragraphLine : paragraphLength) * 0.5));
                //section.PageSetup.LeftMargin = Unit.FromCentimeter(0.5);
                //section.PageSetup.TopMargin = "0.5cm";
                //section.PageSetup.LeftMargin = "0.2cm";
                //section.PageSetup.RightMargin = "0.2cm";
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false);
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                string filename = "SettlementSheetWHInvoice.pdf";
                MemoryStream ms = new MemoryStream();
                pdfRenderer.PdfDocument.Save(ms, false);
                return ms;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
