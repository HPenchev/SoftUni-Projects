using System;
using Novacode;
using System.Diagnostics;
using System.Drawing;


class Program
{
    static void Main()
    {

        string fileName = @"../../SoftUni OOP Game Contest.docx";

        string headlineText = "SoftUni OOP Game Contest";

        var headLineFormat = new Formatting();
        headLineFormat.Size = 18D;
        headLineFormat.Bold = true;
       

        var doc = DocX.Create(fileName);

        Paragraph title = doc.InsertParagraph(headlineText, false, headLineFormat);
        title.Alignment = Alignment.center;
        doc.InsertParagraph("", false);
              
        Picture picture = doc.AddImage(@"rpg-game.png").CreatePicture();
        var drawingImg = System.Drawing.Image.FromFile(@"rpg-game.png");
        int ratio = drawingImg.Width / drawingImg.Height;
        int newWidth = (int)doc.PageWidth - (int)(doc.MarginLeft + doc.MarginRight);
        picture.Width = newWidth;
        picture.Height = newWidth / ratio;
        Paragraph p = doc.InsertParagraph("", false);
        p.InsertPicture(picture);
        p.Alignment = Alignment.center;
        doc.InsertParagraph("", false);
        Paragraph text = doc.InsertParagraph("", false);
        text.Append("SoftUni is organizing a contest for the best");
        text.Append(" role playing game").Bold();
        text.Append(" from the OOP teamwork projects. The winning teams will receive a");
        text.Append(" grand prize").Bold().UnderlineColor(Color.Black);
        text.Append("!");
        text.AppendLine("The game should be:");
        var list = doc.AddList("", 0, ListItemType.Bulleted);
        doc.AddListItem(list, "Properly structured and follow all good OOP practices");
        doc.AddListItem(list, "Awesome");
        doc.AddListItem(list, "..Very Awesome");
        doc.InsertList(list);
        doc.InsertParagraph("", false);
        int width = 3;
        int height = 4;
        var table = doc.AddTable(height, width);
        table.Alignment = Alignment.center;
        for (int row = 0; row < table.RowCount; row++)
        {
            for (int col = 0; col < table.ColumnCount; col++)
            {
                table.Rows[row].Cells[col].Paragraphs[0].Alignment = Alignment.center;
                if (row == 0)
                {
                    table.Rows[row].Cells[col].FillColor = System.Drawing.Color.MediumBlue;
                    switch (col)
                    {
                        case 0:
                            table.Rows[row].Cells[col].Paragraphs[0].Append("Team");
                            break;
                        case 1:
                            table.Rows[row].Cells[col].Paragraphs[0].Append("Game");
                            break;
                        case 2:
                            table.Rows[row].Cells[col].Paragraphs[0].Append("Points");
                            break;
                    }
                }
                else
                {
                    table.Rows[row].Cells[col].Paragraphs[0].Append("-");
                }
            }
        };

        doc.InsertTable(table);
        doc.InsertParagraph("", false);
        var footerFormat = new Formatting();
        footerFormat.FontFamily = new FontFamily("Tahoma");

        footerFormat.Size = 10D;
        var footer = doc.InsertParagraph("The top 3 teams will receive a ", false, footerFormat);
        footer.Alignment = Alignment.center;

        footerFormat.Bold = true;
        footer.InsertText("SPECTACULAR ", false, footerFormat);

        footerFormat.Bold = false;
        footer.InsertText("prize:\n");

        
        footerFormat.UnderlineStyle = UnderlineStyle.singleLine;
        footerFormat.FontColor = System.Drawing.Color.MediumBlue;
        footerFormat.Size = 14D;
        footer.InsertText("A HANDSHAKE FROM NAKOV", false, footerFormat);
        doc.Save();
    }
}

