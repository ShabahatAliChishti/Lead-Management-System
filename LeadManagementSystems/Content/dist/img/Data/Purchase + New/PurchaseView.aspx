<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseView.aspx.cs" Inherits="SSS.Webapplication.Purchase.PurchaseView" %>
<%@ Register TagPrefix="my_GV" TagName="GridControl" Src="~/UserControls/GridControl.ascx" %>
<%@ PreviousPageType VirtualPath="~/Setups/POSAdd.aspx" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Purchase Requisition</h2>

<table id="tblFilter" width="100%">
<tr>
<td>
<asp:Label ID="lblSearchArea" runat="server" Text="Search POS:"></asp:Label> 
</td>
<td>
    <asp:TextBox ID="txtSearchArea" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" />
</td>
</tr>
</table>

<div class="myData">
    <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="btnAddNew" runat="server" Text="Add New" 
        onclick="btnAddNew_Click" />
    <br />
    <my_GV:GridControl ID="GridControl1" runat="server" />
    
</div>

</asp:Content>
