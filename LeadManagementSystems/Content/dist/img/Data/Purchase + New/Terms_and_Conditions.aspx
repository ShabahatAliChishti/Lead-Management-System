<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Terms_and_Conditions.aspx.cs" Inherits="SSS.Webapplication.Purchase.Terms_and_Conditions" %>

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
        .style1 {
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
           #RequiredFieldValidator1 {
               clear: right;
               float: right;
           }

           .new {
               margin: 0;
               height: 202px;
               width: 99%;
           }

           .detail-div {
               background: #ECECEC;
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

           .new td {
               padding: 0;
               height: 25px;
           }

           .new th {
               padding: 0;
               height: 25px;
           }

           .topMargin {
               margin: 3px 4px 0 0;
               float: left;
           }

           .dll {
               margin: 5px 0 0 0;
               float: left;
           }

           .dll2 {
               margin: 12px 0 0 0;
               float: left;
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
                Terms and Conditions</h1>

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
                <table ID="tblCashMemoDetail" runat="server" align="center" class="new " cellpadding="0" cellspacing="0">
              
                  
                  
                    
                  
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
                             
                                
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="padding:0px 0 0 0;" width="700">
                                        <tr class="HeaderStyle">
                                             <th style="width:13%;" >S.no</th
                                             <th style="width:12%" >Code</th>
                                            <th style="width:15.5%" >Code</th>
                                            <th style="width:73%" >Terms and Condiitons</th>                                           
                                            
                                          
                                            
                                            <th style="display:none">
                                                <asp:Label ID="rptlblstocks" runat="server" Text="Stock" Visible="false"></asp:Label>
                                            </th>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" style="padding:0px 0 0 0;" width="700" >
                                </HeaderTemplate>
                               <ItemTemplate>
                                    <tr class="RowStyle">
                                                           
                                         <td class="auto-style1" style="margin-right:-50px;width:13%;">
                    <asp:TextBox ID="TextBox3" runat="server" Enabled="true" Visible="true" Width="80px" >
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_box_dilvrydate" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
                                      <%--   <td class="auto-style1" style="width:13%;">
                    <asp:TextBox ID="TextBox15" runat="server" Enabled="true" Visible="true"  Width="80px">
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txt_box_dilvrydate" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>--%>
                                          <td class="auto-style1" style="margin-right:-50px;">
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="true" Visible="true" Width="80px" >
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_box_dilvrydate" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
                                            <td class="auto-style1" style="margin-right:-50px;">
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="true" Visible="true" Width="450px" >
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_box_dilvrydate" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
                                        
                                      
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                    <%--</table>--%>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                       
                    </tr>
               
          </table> 
         </div>
           <%--</div>--%>
    </ContentTemplate>
           </asp:UpdatePanel> 
    </asp:Content>