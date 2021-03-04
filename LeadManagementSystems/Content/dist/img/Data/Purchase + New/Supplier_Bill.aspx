<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Supplier_Bill.aspx.cs" Inherits="SSS.Webapplication.Purchase.Supplier_Bill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../UserControls/GeneralizeControl.ascx" tagname="GeneralizeControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script src="/Scripts/IntegerNumberValidation.js" type="text/javascript"></script>
    <script src="../../Scripts/CustomScript/DetailValidation.js" type="text/javascript"></script>
    <script src="/Scripts/CustomScript/addrecord-script.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.dialog.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            InitializeValidation();
        });
    </script>
   <script src="../../Scripts/CustomScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/CustomScript/jquery-ui-1.8.17.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 434px;
        }
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            height: 18px;
        }
    </style>
       <style type="text/css">
    #RequiredFieldValidator1    
    {
        clear:right; float:right}
    
    .new    
    {
        margin:0;
    
    }
           .detail-div {    background: #ECECEC;
    margin: 0;
    width: 80%;
    border-top: 2px solid #2B334B;
    
    border-bottom: 2px solid #2B334B;
           }
           .detail-div td {
    padding: 10px 0 0 10px !important;
    height: 0 !important;
}
           td.ajax__combobox_textboxcontainer {
    margin: 10px 0 0 0px;
    padding: 5px 0 0 0px !important;
}
           button#MainContent_cmbSalesType_Button {
    padding: 0 !important;
    margin: -4px 0 0 -20px !important;
}
        
    .new td    
    {
        padding:0; height:25px; 
    }
    .new th    
    {
        padding:0; height:25px;
    }      
    .topMargin  
        {margin:3px 4px 0 0; float:left;
        
          }
 
 .dll   
 {
     margin:5px 0 0 0; float:left 
 }
 
 .dll2   
 {
     margin:12px 0 0 0; float:left 
 }

           .centerTbl {
               margin: 0 auto;
               width: 700px;
               text-align: center;
               display: block;
           
   
    }
           .main table tr td h1 {
    background: #4B6C9E;
    color: #fff;
    padding: 3px 0px 3px 5px;
    border-bottom: 2px solid #2B334B;
}
           .RowStyle td {
               background-color: #DFEFFC !important;
           }   
   
           .auto-style4 {
               height: 31px;
           }
   
           .auto-style5 {
               height: 29px;
           }
   
           .auto-style6 {
               height: 23px;
           }
   
    </style>
        
    <script src="../../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <table  width="100%" cellspacing="4">
        <tr >
            <td colspan="2" >
                <h1> 
                 Supplier Bill</h1>

            </td>
        </tr>
       
        <tr>
          
            
            <td class="auto-style5">Type: * </td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlCompany" runat="server" AppendDataBoundItems="true" onchange="PopulateCompany();" Width="160px">
                    <asp:ListItem Value="-1">Please select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="ddlCompany" CssClass="error" ErrorMessage="&lt;br&gt;Please select Bill type" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label10" runat="server" Text="  Bill NO: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox14" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label7" runat="server" Text="  Date: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txt_box_dilvrydate" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txt_box_dilvrydate">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_box_dilvrydate" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="  Year: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox13" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox13" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </tdTextBox13 </tr="">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label11" runat="server" Text="  Period : *" Visible="true">
</asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox15" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TextBox15" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label14" runat="server" Text="  Suppplier : *" Visible="true">
</asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox6" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox6" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox7" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox7" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server" Text=" Text upto 45 chars : *" Visible="true">
</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox9" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox9" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox10" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox10" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox11" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox11" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox12" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBox12" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox16" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox11" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox17" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox12" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--   <tr >
                
                  <td class="auto-style1">
                    <asp:Label ID="radiobtn" runat="server" Text=" : *"></asp:Label>
                </td>
                 <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="  Purchase Requisition: *"></asp:Label>
                </td>
            </tr>--%>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label6" runat="server" Text=" Parent Document : *" Visible="true">
</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="gender" Text="Purchase Requisition" Width="260px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="gender" Text="GRN" Width="260px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="gender" Text="Independent" Width="260px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="gender" Text="Independent Non inventory" Width="260px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="Button5" runat="server" style="margin-left:60px;" Text="Select" ValidationGroup="Select" Width="80px" />
                        <%--  onkeypress="javascript:Callme(event, this.id);"--%></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="  Doc No : *" Visible="true">
</asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox8" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox15" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text=" Doc Date: *" Visible="true">
</asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox1" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txt_box_dilvrydate">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_box_dilvrydate" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label8" runat="server" Text="  Naration: *" Visible="true">
</asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox2" runat="server" Enabled="true" Height="30px" Visible="true" Width="320px">
  
    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="Button3" runat="server" style="margin-left:10px; " Text="Item details" ValidationGroup="Select" />
                        <%--  onkeypress="javascript:Callme(event, this.id);"--%></td>
                    <tr>
                        <td></td>
                        <td>&nbsp;</td>
                    </tr>
                </tr>
            </td>
        </tr>
    </table>
                <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
              <ProgressTemplate>
                   <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                      <span style="border-width: 0px;  position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 20px; left: 40%; top: 40%;" ><asp:Label ID="lblWait" runat="server" 
	Text=" Please wait... " />
	<asp:Image ID="imgWait" runat="server" 
	ImageAlign="Middle" ImageUrl="../../Images/loader.gif" /></span>
                </div>
</ProgressTemplate>
          </asp:UpdateProgress>--%>
                </ContentTemplate>
         </asp:UpdatePanel>
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <%--<div class="centerTbl" >--%>
            
    <div id="cashMemoDiv">
                <table ID="tblCashMemoDetail" runat="server" align="center" class="new " width="100%" cellpadding="0" cellspacing="0">
              
                  
                  
                    
                  
                   <%-- <tr>
                        <td class="auto-style2" colspan="5" valign="top">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" valign="top" class="auto-style6">
                            <asp:Label ID="lblCountName" runat="server" Visible="False" Text = "Total Qty:" 
                   Font-Bold="True" Font-Size="Small"></asp:Label>
                            <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Small" Visible="False"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="5" valign="top">
                            <asp:Repeater ID="rptCashMemoDetail" runat="server" >
                                 <%--OnItemDataBound="rptCashMemoDetail_ItemDataBound"--%>
                                 <%--OnItemDataBound="rptCashMemoDetail_ItemDataBound"--%>
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="padding:0px 0 0 0;" width="700">
                                        <tr class="HeaderStyle">
                                             <th style="width:11%" >S.no</th
                                            <th style="width:20%" >Item</th>
                                            <th style="width:21%" >Item</th>                                           
                                            <th style="width:21%" >Discription</th>
                                          <th style="width:20%">Department</th>
                                            <th style="width:11%">Packs rate</th>
                                             <th style="width:11%">No of packs</th>
                                             <th style="width:11%">packing Unit</th>
                                          
                                            
                                            <th style="display:none">
                                                <asp:Label ID="rptlblstocks" runat="server" Text="Stock" Visible="false"></asp:Label>
                                            </th>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" style="padding:0px 0 0 0;" width="700" >
                                </HeaderTemplate>
                               <ItemTemplate>
                                    <tr class="RowStyle">
                                        <td style="width:10%">
                                            <asp:ImageButton ID="imgBtnDelete" runat="server" AlternateText="Click to Delete Record!" CommandArgument='<%# Eval("sNo") %>' CommandName="Delete" ImageUrl="~/Images/icon_delete.gif" OnClientClick="return confirm(&quot;Are you sure you want to delete this record?&quot;);" ToolTip="Click to Delete Record!" ValidationGroup="Test" />
                                        </td>
                                        <%--<td><%# Eval("sNo")%></td>--%>
                                        <td style="width:20%"><%# Eval("saleType") %></td>
                                        <td style="width:20%"><%# Eval("ProductName")%></td>
                                      <%--  <td style="width:20%"><asp:TextBox ID="txtStockReturnQuantity" runat="server" Text='<%# Eval("productQty")%>' CssClass="txtForm"
                                                onkeydown="return numbersOnly(event);"></asp:TextBox></td>--%>
                                          <td style="width:20%"><%# Eval("Discription")%></td>
                                        <td style="width:10%"><%# Eval("Product_quantity")%></td>  
                                         <td style="width:10%"><%# Eval("Product_quantity")%></td>   
                                         <td style="width:10%"><%# Eval("Product_quantity")%></td>                                     

                                        
                                        
                                      
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                    <%--</table>--%>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                       
                    </tr>
                   <tr>
                        <td colspan="5" valign="top" >
                            <asp:Button style="margin-left:350px;" ID="btnSubmit" runat="server"   Text="New" ValidationGroup="Select"/><%--  onkeypress="javascript:Callme(event, this.id);"--%>                           
                            <asp:Button style="margin-left:5px;" ID="btnMasterUpdate" runat="server" Text="Edit" Visible="False"  />
                            <asp:Button style="margin-left:5px;" ID="btndone" runat="server" Text="Delete"  />
                               <asp:Button style="margin-left:5px;" ID="Button4" runat="server" Text="View Voucher"  />
                        </td>
                    </tr>
          </table> 
         </div>
           <%--</div>--%>
    </ContentTemplate>
           </asp:UpdatePanel> 
    </asp:Content>
