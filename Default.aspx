<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 495px;
        }
        .style4
        {
            width: 495px;
            color: #CC0000;
        }
        .style5
        {
            width: 495px;
            color: #0033CC;
            background-color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td class="style4">
                Fetch Data from between Date:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                From Date :</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" type="date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                To Date :</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" type="date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="btnsubmit" 
                    style="height: 29px" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Download result in following format as per your requirement:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="55px" 
                    ImageUrl="~/image/excel.png" onclick="ImageButton1_Click1" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton2" runat="server" Height="55px" 
                    ImageUrl="~/image/csv.png" onclick="ImageButton2_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton3" runat="server" Height="55px" 
                    ImageUrl="~/image/txt.png" onclick="ImageButton3_Click" />
&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton4" runat="server" Height="55px" 
                    ImageUrl="~/image/pdf.png" onclick="ImageButton4_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
