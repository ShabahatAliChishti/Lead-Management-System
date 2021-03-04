<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PuchaseRequisition.aspx.cs" Inherits="SSS.Webapplication.Purchase.ItemsAdd" EnableEventValidation="false"  MaintainScrollPositionOnPostback="true"  %>

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
           .auto-style3 {
               width: 207px;
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
   
    </style>
        
    <script src="../../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script type="text/javascript">
       <%-- $(document).ready(function () {
            $('#<%=ddlSalesRep.ClientID %>').focus();
        });

        $('input[id*=<%= txtProduct_Index.ClientID %>]').blur(function () {

            var vals = 0;

            $('input[id*=<%= txtProduct_Index.ClientID %>]').each(function () {

                var value = $(this).val();
                if (isNaN(parseInt(value)) == false) {
                    vals = parseInt(value);
                    $('#<%= cmbProduct.ClientID %>').val(vals);
                    aField = document.getElementById('<%= txt_ProdctQuantity.ClientID %>');
                    setTimeout("aField.focus()", 50);
                }
            }, null);
        });--%>

        function GetProductID() {
            $(document).ready(function () {
                document.getElementById('<%= txtProduct_Index.ClientID %>').value = $("#<%= cmbProduct.ClientID %>").val();
                aField = document.getElementById('<%= txt_ProdctQuantity.ClientID %>');
                setTimeout("aField.focus()", 50);
            });
        }

        function changeText(txtB) {
            //alert(txtB);
            var textBox = document.getElementById(txtB);
            var txt = textBox.value;
            debugger;
            $('#<%= cmbProduct.ClientID %>').val(txt); //MainContent_cmbProduct
            $(document).ready(function () {
                aField = document.getElementById('<%= txt_ProdctQuantity.ClientID %>');//'txt_ProdctQuantity');
                setTimeout("aField.focus()", 50);
            });
        }
       function getRate(txtB) {
            //alert(txtB);
            var textBox = document.getElementById(txtB);
            var txt = textBox.value;
            debugger;
            console.log(txt);
        }

        function Callme(e, textarea) {
            debugger;
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 13) { //Enter keycode
                //alert("fdfd");
                if (textarea == "<%= txtProduct_Index.ClientID %>") {
                    changeText(textarea);
                    $('#<%= txt_ProdctQuantity.ClientID %>').focus();
                }

                if (textarea == "<%= txt_ProdctQuantity.ClientID %>") {
                    $('#<%= btnSubmit.ClientID %>').click();
                }

                <%--if (textarea == "<%= btnSubmit.ClientID %>") {
                    $('#<%= txtProduct_Index.ClientID %>').click();
                }--%>

                if (textarea == "<%= cmbSalesType.ClientID %>") {
                    $('#<%= txtProduct_Index.ClientID %>').focus();
                }

                //e.preventDefault();
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <table  width="100%" cellspacing="4">
        <tr >
            <td colspan="2" >
                <h1> 
                  Purchase Requisition</h1></td>
        </tr>
       
        <tr>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" onclick="btnSubmit_Click" Text="General" ValidationGroup="Select" />
                <%--  onkeypress="javascript:Callme(event, this.id);"--%>
            </td>
            <td class="auto-style4" >
                <asp:Button style="margin-left:145px;" ID="Button2" runat="server" onclick="btnSubmit_Click" Text="Purchase Requisition on min stock" ValidationGroup="Select" />
                <%--  onkeypress="javascript:Callme(event, this.id);"--%>
            </td>
            
            <tr>
                <td class="auto-style1">Type: * </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlCompany" runat="server" AppendDataBoundItems="true" onchange="PopulateCompany();" Width="160px">
                        <asp:ListItem Value="-1">Please select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="ddlCompany" CssClass="error" ErrorMessage="&lt;br&gt;Please select Company" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
                 <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="  Date: *"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txt_box_createdate" runat="server" Enabled="false" Width="160px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_box_createdate" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
              
              <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label6" runat="server" Text="  Reference: *" Visible="true">
</asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtbox_reference" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbox_reference" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
              <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="  Delivery Date: *" Visible="true">
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
                <td>
                    <asp:Label ID="Label3" runat="server" Text="  Location: *" Visible="true">
</asp:Label>
                </td>
                <td>
                    
                    <asp:DropDownList ID="DropDownListLocation" runat="server" AppendDataBoundItems="true" onchange="PopulateCompany();" Width="160px">
                        <asp:ListItem Value="-1">Please select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListLocation" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr >
                <td class="auto-style1">
                    <asp:Label ID="Label9" runat="server" Text="  Naration: *" Visible="true">
</asp:Label>
                </td>
               
                <td class="auto-style1">

                    <asp:TextBox ID="txtbox_narration" runat="server" Enabled="true" Visible="true" Width="160px">
  
    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtbox_narration" CssClass="error" ErrorMessage="*" InitialValue="-1" ValidationGroup="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
          
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="Button3" runat="server" onclick="btnSubmit_Click" style="margin-left:10px; " Text="Select Requisition material user recquired" ValidationGroup="Select" />
                    <%--  onkeypress="javascript:Callme(event, this.id);"--%></td>
                <td class="auto-style4">
                    <asp:Button ID="Button4" runat="server" onclick="btnSubmit_Click" Text="Memo Detail" ValidationGroup="Select" />
                    <%--  onkeypress="javascript:Callme(event, this.id);"--%></td>
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
              
                     <tr class="detail-div">
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Department:*"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Product Code: *"></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="Label11" runat="server" Text="Products: *"></asp:Label>
                        </td>
                         <td >
                            <asp:Label ID="Label10" runat="server" Text="Description: *"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblstock"  runat="server" Text="No of packs:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Rate:*"></asp:Label>
                        </td>
                      
                    </tr>
                     
                    <tr class="detail-div">
                        <td valign="top" style="padding=0;">
                            <%--<asp:DropDownList Width="160px" ID="cmbSalesType" runat="server" AppendDataBoundItems="True" onkeypress="javascript:Callme(event, this.id);">
                    <asp:ListItem Text = "Please select" Value = "0"></asp:ListItem>
                </asp:DropDownList>--%>
                            <asp:ComboBox ID="cmbSalesType" runat="server" BorderColor="#8ec1ff" 
                                BorderStyle="Solid" BorderWidth="1px" CssClass="SaleType" onkeypress="javascript:Callme(event, this.id);"></asp:ComboBox>
                            <asp:RequiredFieldValidator ID="rfvSaleType" runat="server" 
    ControlToValidate = "cmbSalesType" InitialValue = "Select Sales Type"
    ErrorMessage="&lt;br&gt;Select Sale Type" CssClass="error"></asp:RequiredFieldValidator>
                        </td>

                           <td  valign="top" style="padding:0px;"> <%----%>
                           <asp:TextBox ID="txtProduct_Index" runat="server" CssClass="dll2" onblur="javascript:changeText(this.id)" onkeypress="javascript:Callme(event, this.id);"
          Width="50px" style="border:1px solid #8ec1ff; float:left" TabIndex="1"></asp:TextBox>
         </td>
<td style="display:block; margin-top: 12px; "  id="tdtxtstock" runat="server">
                            <asp:DropDownList ID="cmbProduct" runat="server" AppendDataBoundItems="true"  Width="160px" OnSelectedIndexChanged="cmbProduct_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="-1">Please select</asp:ListItem>
                    </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="cmbProduct" Display="Static" ErrorMessage="Select Product" 
                                ValidationGroup="Select" style="float:left; color:Red;" 
                   InitialValue="Select Product" Height="18px"></asp:RequiredFieldValidator>

                          
                        </td>
         <td valign="top" class="auto-style3">
              <asp:TextBox ID="TextBox8" CssClass="dll2" runat="server" AutoPostBack="True" Visible="true" 
                                MaxLength="12" style="border:1px solid #8ec1ff; float:left" 
                                Width="150px" ontextchanged="txtstock_TextChanged"
                                 ></asp:TextBox>
         </td>
                        
                         <td valign="top">
                            <asp:TextBox ID="txt_ProdctQuantity" CssClass="dll2" runat="server" 
                                MaxLength="12" style="border:1px solid #8ec1ff; float:left" 
                                 ValidationGroup="Select" Width="150px" 
                                onkeydown="return numbersOnly(event);"  
                                 ></asp:TextBox> <%--onkeypress="javascript:Callme(event, this.id);" ontextchanged="txt_ProdctQuantity_TextChanged"--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txt_ProdctQuantity" Display="Static" style="float:left; color:Red;    margin: 15px 0px 0 10px;"  ErrorMessage="Enter Product Quantity" 
                                ValidationGroup="Select"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server"
                                  ControlToValidate="txt_ProdctQuantity" Display="Static" style="border:1px solid #8ec1ff; float:left" ErrorMessage="Must be greter than zero."
                                  Operator="GreaterThan" Type="Integer"
                                  ValueToCompare="0"/>
                          
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="TextBoxrate" CssClass="dll2" runat="server" 
                                MaxLength="12" style="border:1px solid #8ec1ff; float:left" 
                                 ValidationGroup="Select" Width="150px" 
                                onkeydown="return numbersOnly(event);"  
                                 ></asp:TextBox> 

                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TextBoxrate" Display="Static" ErrorMessage="Enter Rate" 
                                ValidationGroup="Select" style="float:left; color:Red;" 
                   InitialValue="Enter Product" Height="18px"></asp:RequiredFieldValidator>

                        </td>
                        
                        
                    </tr>
                    
                    <tr>
                        <td colspan="5" valign="top">
                            <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click"  Text="Done" ValidationGroup="Select"/><%--  onkeypress="javascript:Callme(event, this.id);"--%>
                            <asp:Button ID="tblSave" runat="server" onclick="tblSave_Click" Text="Save Cash Memo"  />
                            <asp:Button ID="btnMasterUpdate" runat="server" OnClick="btnMasterUpdate_Click" Text="Edit" Visible="False"  />
                            <asp:Button ID="btndone" runat="server" OnClick="btndone_Click" Text="Delete"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="5" valign="top">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" valign="top">
                            <asp:Label ID="lblCountName" runat="server" Visible="False" Text = "Total Qty:" 
                   Font-Bold="True" Font-Size="Small"></asp:Label>
                            <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Small" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" valign="top">
                            <asp:Repeater ID="rptCashMemoDetail" runat="server" onitemcommand="rptCashMemoDetail_ItemCommand" OnItemDataBound="rptCashMemoDetail_ItemDataBound">
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="padding:0px 0 0 0;" width="700">
                                        <tr class="HeaderStyle">
                                             <th style="width:10%" >S.no</th
                                            <th style="width:10%" >Item</th>
                                            <th style="width:10%" >Discription</th>
                                            <%--<th>S.No</th>--%>
                                            <th style="width:20%">Department</th>
                                            <th style="width:50%">No of packs</th>
                                            <th style="width:20%">Pack</th>
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
                                        <td style="width:50%"><%# Eval("ProductName")%></td>
                                        <td style="width:20%"><asp:TextBox ID="txtStockReturnQuantity" runat="server" Text='<%# Eval("productQty")%>' CssClass="txtForm"
                                                onkeydown="return numbersOnly(event);"></asp:TextBox></td>
                                          <td style="width:50%"><%# Eval("Discription")%></td>
                                        <td style="width:50%"><%# Eval("Product_quantity")%></td>                                     
                                        <td style="width:50%"><%# Eval("Textboxrates")%></td>
                                        
                                        
                                        <td style="display:none">
                                            <asp:Label ID="rptitemlblstocks" runat="server" Text='<%# Eval("stock")%>' Visible="false"></asp:Label>
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
