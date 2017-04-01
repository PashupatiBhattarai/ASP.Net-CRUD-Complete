<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="Asp.NetCrud.Country" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
        </div>
        <table>
            <tr>
                <td>StateId</td>
                <td>
                    <asp:TextBox ID="txtStateid" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>StateName</td>
                <td>
                    <asp:TextBox ID="txtstatename" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtvalidatestatename" ControlToValidate="txtstatename" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtvalidattecity" ControlToValidate="txtcity" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Population</td>
                <td>
                    <asp:TextBox ID="txtpopulation" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtvalidatepopulation" ControlToValidate="txtpopulation" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Modifieddate</td>
                <td>
                    <asp:TextBox ID="txtmodified" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtvalidatemodified" ControlToValidate="txtmodified" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <asp:ValidationSummary ID="txtsummery" ShowSummary="true" HeaderText="Field is required" EnableClientScript="true" ForeColor="Red" runat="server" />



        </table>
        <asp:Button ID="btngetdetails" runat="server" Text="Save" OnClick="btngetdetails_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btndelete" runat="server" Text="Delete" CausesValidation="false" OnClick="btndelete_Click" />
        <asp:Button ID="btnfind" runat="server" Text="Find" CausesValidation="false" OnClick="btnfind_Click" />

        <div>
        </div>
        <asp:Label ID="txtlbl" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
