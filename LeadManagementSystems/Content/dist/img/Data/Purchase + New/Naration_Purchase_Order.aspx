<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Naration_Purchase_Order.aspx.cs" Inherits="SSS.Webapplication.Purchase.Naration_Purchase_Order" %>


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
               Purchase Order</h1>
                          <h4 style="font-size:15px; color:black; font-family:'Times New Roman'"> 
              Naration charges</h4>
            </td>
        </tr>
    <tr>
         <td class="auto-style4" >
                <asp:Button style="margin-left:600px;" ID="Button2" runat="server"  Text="Populate item based on Min.stock" ValidationGroup="Select" />
                <%--  onkeypress="javascript:Callme(event, this.id);"--%>
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
           <h4 style="font-size:15px; color:black; font-family:'Times New Roman'">Narrations</h4>
                  <tr >
                 
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="  Narration 2: *" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox13" runat="server" Enabled="true" Visible="true" Width="800px">
  
    </asp:TextBox>
                    
                </td>
            </tr>  
                    <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="  Narration 3: *" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                      <asp:TextBox ID="TextBox1" runat="server" Enabled="true" Visible="true" Width="800px">
  
    </asp:TextBox>
                    
                </td>
            </tr>  
                    <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="  Narration 4: *" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                     <asp:TextBox ID="TextBox3" runat="server" Enabled="true" Visible="true" Width="800px">
  
    </asp:TextBox>
                    
                </td>
            </tr>  
                    <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="  Narration 5: *" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                     <asp:TextBox ID="TextBox4" runat="server" Enabled="true" Visible="true" Width="800px">
  
    </asp:TextBox> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                           <h4 style="font-size:15px; color:black; font-family:'Times New Roman'">Revesions</h4>  
        <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label11" runat="server" Text="  Number :" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox15" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TextBox15" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                 <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text=" Date: " Visible="true">
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
                  <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label6" runat="server" Text="  Last Rev Date: "></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="false" Width="160px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                  <tr>
                                       <h4 style="font-size:15px; color:black; font-family:'Times New Roman'">Personnel(Buying Stuff)</h4>
                <td class="auto-style5">Code:</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="ddlCompany" runat="server" AppendDataBoundItems="true" onchange="PopulateCompany();" Width="160px">
                        <asp:ListItem Value="-1">Please select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="ddlCompany" CssClass="error" ErrorMessage="&lt;br&gt;" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                  <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="  Commission :" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox5" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                           <h4 style="font-size:15px; color:black; font-family:'Times New Roman'">Purchase Charges</h4>
                     <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label8" runat="server" Text="  Charges 1 :" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox6" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                     <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label9" runat="server" Text=" Charges 2 :" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox7" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                     <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label10" runat="server" Text="  Charges 3 :" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox9" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox9" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                 <h4 style="font-size:15px; color:black; font-family:'Times New Roman'">Distribute charges to item based on</h4>
                <tr>
              <td>
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Quantity" GroupName="gender" />  
           
                  </td> 
       
              </tr>  
                <tr>
              <td>
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Amount" GroupName="gender" />  
           
                  </td> 
       
              </tr>  
                <tr>
              <td>
            <asp:RadioButton ID="RadioButton3" runat="server" Text="As Detail" GroupName="gender" />  
           
                  </td> 
       
              </tr>  
                  <h4 style="font-size:15px; color:black; font-family:'Times New Roman'">Aging Basis</h4>
                <tr>
              <td>
            <asp:RadioButton ID="RadioButton4" runat="server" Text="Delivery Date" GroupName="gender" />  
           
                  </td> 
       
              </tr>  
                <tr>
              <td>
            <asp:RadioButton ID="RadioButton5" runat="server" Text="Bill Recieving Date" GroupName="gender" />  
           
                  </td> 
       
              </tr>  
                <tr>
              <td>
            <asp:RadioButton ID="RadioButton6" runat="server" Text="Bill Date Suplier" GroupName="gender" />  
           
                  </td> 
       
              </tr>  
           <%--</div>--%>
    </ContentTemplate>
           </asp:UpdatePanel> 
    </asp:Content>