using System;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;

//using Microsoft.CodeAnalysis.MSBuild;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;



public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit(object sender, EventArgs e)
    {

        string constr = ConfigurationManager.ConnectionStrings["CombineDB"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "sp_showdate";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = TextBox1.Text.Trim();
        cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = TextBox2.Text.Trim();
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        sda.Fill(dt);
        SqlDataReader sdr = cmd.ExecuteReader();

        if (sdr.Read())
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            Label1.Text = "No Record Found ..!";
        }
        con.Close();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }



    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        //Excel
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "StatusReport" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        GridView1.GridLines = GridLines.Both;
        GridView1.HeaderStyle.Font.Bold = true;
        GridView1.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        //Build the Text file data.
        string txt = string.Empty;

        foreach (TableCell cell in GridView1.HeaderRow.Cells)
        {
            //Add the Header row for Text file.
            txt += cell.Text + "|";
        }

        //Add new line.
        txt += "\r\n";

        foreach (GridViewRow row in GridView1.Rows)
        {
            foreach (TableCell cell in row.Cells)
            {
                //Add the Data rows.
                txt += cell.Text + "\t|";
            }

            //Add new line.
            txt += "\r\n";
        }

        //Download the Text file.
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=StatusReport.txt");
        Response.Charset = "";
        Response.ContentType = "application/text";
        Response.Output.Write(txt);
        Response.Flush();
        Response.End();
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        //pdf
        int columnsCount = GridView1.HeaderRow.Cells.Count;
        // Create the PDF Table specifying the number of columns
        PdfPTable pdfTable = new PdfPTable(columnsCount);

        // Loop thru each cell in GrdiView header row
        foreach (TableCell gridViewHeaderCell in GridView1.HeaderRow.Cells)
        {
            // Create the Font Object for PDF document
            Font font = new Font();
            // Set the font color to GridView header row font color
            font.Color = new BaseColor(GridView1.HeaderStyle.ForeColor);



            // Create the PDF cell, specifying the text and font
            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

            // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
            pdfCell.BackgroundColor = new BaseColor(GridView1.HeaderStyle.BackColor);

            // Add the cell to PDF table
            pdfTable.AddCell(pdfCell);
        }

        // Loop thru each datarow in GrdiView
        foreach (GridViewRow gridViewRow in GridView1.Rows)
        {
            if (gridViewRow.RowType == DataControlRowType.DataRow)
            {
                // Loop thru each cell in GrdiView data row
                foreach (TableCell gridViewCell in gridViewRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(GridView1.RowStyle.ForeColor);

                    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                    pdfCell.BackgroundColor = new BaseColor(GridView1.RowStyle.BackColor);

                    pdfTable.AddCell(pdfCell);
                }
            }
        }

        // Create the PDF document specifying page size and margins
        Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

        PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

        pdfDocument.Open();
        pdfDocument.Add(pdfTable);
        pdfDocument.Close();

        Response.ContentType = "application/pdf";
        Response.AppendHeader("content-disposition",
            "attachment;filename=StatusReport.pdf");
        Response.Write(pdfDocument);
        Response.Flush();
        Response.End();
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
            //Build the Text file data.
        string csv = string.Empty;

        foreach (TableCell cell in GridView1.HeaderRow.Cells)
        {
            //Add the Header row for Text file.
            csv += cell.Text + ",";
        }

        //Add new line.
        csv += "\r\n";

        foreach (GridViewRow row in GridView1.Rows)
        {
            foreach (TableCell cell in row.Cells)
            {
                //Add the Data rows.
                csv += cell.Text + ",";
            }

            //Add new line.
            csv += "\r\n";
        }

        //Download the Text file.
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=StatusReport.csv");
        Response.Charset = "";
        Response.ContentType = "application/text";
        Response.Output.Write(csv);
        Response.Flush();
        Response.End();
    }
        
}
