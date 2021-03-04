<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Supplier_Bill_Amount_Tab.aspx.cs" Inherits="SSS.Webapplication.Purchase.Supplier_Bill_Amount_Tab" %>



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

             
              
         
        
       
           
         
           
              
       
          
          
       
                    <td class="auto-style1">
                        <asp:Label ID="Label12" runat="server" Text=" Charges : *" Visible="true">
</asp:Label>
            </td>
                </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label10" runat="server" Text="  Charges 1: *" Visible="true">
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
                <asp:Label ID="Label3" runat="server" Text="  Charges 2: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox3" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label9" runat="server" Text="  Charges 3: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox4" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label6" runat="server" Text=" Distribution of charges based on : *" Visible="true">
</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="gender" Text="Quality" Width="260px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="gender" Text="Amount" Width="260px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="gender" Text="As Detail" Width="260px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label13" runat="server" Text=" Amounts : *" Visible="true">
</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label15" runat="server" Text="  Gross Amount: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox5" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label18" runat="server" Text="  Discount Amount: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox20" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label16" runat="server" Text=" After Dis.Amount: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox18" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label19" runat="server" Text="  Sales Tax: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox21" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label17" runat="server" Text="  Net Amount.Exc.Penalty: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox19" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label20" runat="server" Text="  Penalty: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox22" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label21" runat="server" Text=" Aging Basis : *" Visible="true">
</asp:Label>
            </td>
        
            <td>

            </td>
              <td class="auto-style1" >
                <asp:Label ID="Label2" runat="server" Text="  Total Charges: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox2" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="gender" Text="Delivery Date" Width="260px" />
            </td>
            <td>
                <asp:RadioButton ID="RadioButton7" runat="server" GroupName="gender" Text="Bill Date(Supplier)" Width="260px" />
            </td>
             <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Text="  Net.Amt: *" Visible="true">
</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButton5" runat="server" GroupName="gender" Text="Bill Recieving Date" Width="260px" />
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox23" runat="server" Enabled="false" Visible="true" Width="160px">
  
    </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="TextBox14" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
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

             
              
         
        
       
           
         
           
              
       
          
          
       
                    <td></td>
                    <td>&nbsp;</td>
                </tr>
            </tr>
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
                
                
          </table> 
         </div>
           <%--</div>--%>
    </ContentTemplate>
           </asp:UpdatePanel> 
     </asp:Content>