//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Data;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using SSS.BLL.Setups;
//using SSS.Utility;
//using SSS.Property;
//using SSS.Property.Setups;
//using System.Collections;

//namespace SSS.Webapplication.Purchase
//{
//    public partial class ItemsAdd : System.Web.UI.Page
//    {
//        Transaction_Detail_Property objTransactionDetailProperty = new Transaction_Detail_Property();
//        Transaction_Master_Property objTransactionMasterProperty = new Transaction_Master_Property();
//        DataTable myDatatable;
//        private Price_List_Mst_Property objPriceListMStProperty = new Price_List_Mst_Property();
//        private Price_List_Mst_BLL objPriceListMstbll;

//        private Final_Product_Selection_Property objFinalProductSelectionProperty = new Final_Product_Selection_Property();
//        private Final_Product_Selection_BLL objFinalProductSelectionBLL;
//        int? recId = null;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (IsPostBack)
//                return;
//            Session.Remove("myDatatable");

//            this.FillCompanyCode();
//            this.FillCurrentDate();
//            this.bindProduct();
//            this.FillDistributorCode();
//            this.FillSalesRep();
//            FillSalesType();

//            if (Request.QueryString["recId"] == null)
//                BindTempDataTable();

//            btnMasterUpdate.Visible = false;
//            //tblSave.Visible = true;

//            /**/
//            //ddlSalesRep.Enabled = true;
//            //ddlRoute.Enabled = true;
//            //DrpPos.Enabled = true;
//            ///**/

//            if (Request.QueryString["recId"] != null)
//            {
//                /**/
//                //ddlSalesRep.Enabled = false;
//                //ddlRoute.Enabled = false;
//                //DrpPos.Enabled = false;
//                ///**/
//                Session.Remove("myDatatable");
//                btnMasterUpdate.Visible = true;
//                tblSave.Visible = false;
//                Session["Cashmemoupdate"] = "yes";
//                recId = Convert.ToInt32(Request.QueryString["recId"]);
//                ViewState["ID"] = recId;
//                Session["recidx"] = recId;
//                bool res = CheckGIN_Processed(Convert.ToInt32(Request.QueryString["recId"]));
//                if (res)
//                {
//                }
//                else
//                {
//                    Response.Write("<script language=javascript>alert('This Cashmemo is not editable because GIN is already Processed.') </script>");
//                    Response.Write("<script language=javascript>window.location ='CashMemoView.aspx' </script>");
//                }
//                BindCashMemoDetail(Convert.ToInt32(recId));
//            }
//        }

//        private bool CheckGIN_Processed(int id)
//        {
//            bool result = true;

//            Transaction_Master_Property objTMProperty = new Transaction_Master_Property();
//            objTMProperty.ID = id;
//            objTMProperty.Document_Type_ID = Convert.ToInt32(DocumentType.GOODS_ISSUE_NOTE);
//            objTMProperty.Distributor_ID = (Int32)SessionManager.CurrentUser.DistributorID;

//            Transaction_Master_BAL objTMBLL = new Transaction_Master_BAL(objTMProperty);
//            result = objTMBLL.Check_GINorGRNFProcessedForDailyTran();

//            return result;
//        }

//        private void BindCashMemoDetail(int cashMemoMasterId)
//        {
//            Transaction_Master_Property objTransactionMasterProperty = new Transaction_Master_Property();
//            objTransactionMasterProperty.ID = cashMemoMasterId;
//            objTransactionMasterProperty.Distributor_ID = (Int32)SessionManager.CurrentUser.DistributorID;
//            Transaction_Master_BAL objTransactionMasterBAL = new Transaction_Master_BAL(objTransactionMasterProperty);

//            DataSet ds = objTransactionMasterBAL.GetTransactionMasterAndDetailByTransactionIDForDailyTran();

//            if (ds.Tables[0].Rows.Count > 0)
//            {
//                ViewState["Document_No"] = ds.Tables[0].Rows[0]["Document_No"].ToString();

//                //retrnpage = 1;

//                //GeneralizeControl.FillCompanyCode();
//                //GeneralizeControl.CompanySelectedValue(Convert.ToInt32(ds.Tables[0].Rows[0]["Company_ID"].ToString()));

//                //GeneralizeControl.FillDistributorCode();
//                //GeneralizeControl.DistributorSelectedValue(Convert.ToInt32(ds.Tables[0].Rows[0]["Distributor_ID"].ToString()));
//                //GeneralizeControl.SalesTypesID = Convert.ToInt32(ds.Tables[0].Rows[0]["Sales_Rep_Type_ID"].ToString());
//                //GeneralizeControl.FillSalesRep();
//                //GeneralizeControl.SalesRepSelectedValue(Convert.ToInt32(ds.Tables[0].Rows[0]["Personnel_ID"].ToString()));
//                //ddlSalesRep.SelectedValue = ds.Tables[0].Rows[0]["Personnel_ID"].ToString();

//                //FillRoute(int.Parse(ddlSalesRep.SelectedValue.ToString()));
//                //ddlRoute.SelectedValue = ds.Tables[0].Rows[0]["Route_ID"].ToString();
//                ////GeneralizeControl.SalesRepID = Convert.ToInt32(ds.Tables[0].Rows[0]["Personnel_ID"].ToString());
//                //GeneralizeControl.FillRoute();
//                //GeneralizeControl.RouteSelectedValue(Convert.ToInt32(ds.Tables[0].Rows[0]["Route_ID"].ToString()));
//                //GeneralizeControl.RouteID = Convert.ToInt32(ds.Tables[0].Rows[0]["Route_ID"].ToString());
//                //GeneralizeControl.FillPOS();
//                //GeneralizeControl.PosSelectedValue(Convert.ToInt32(ds.Tables[0].Rows[0]["Pos_ID"].ToString()));
//                //  FillPOS(int.Parse(ddlRoute.SelectedValue.ToString()));
//                //DrpPos.SelectedValue = ds.Tables[0].Rows[0]["Pos_ID"].ToString();

//                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["DeliveryDate"].ToString()) != null)
//                {
//                    txt_box_dilvrydate.Text = ds.Tables[0].Rows[0]["DeliveryDate"].ToString();
//                    //                    GeneralizeControl.FillDateDeliverydate(ds.Tables[0].Rows[0]["DeliveryDate"].ToString());
//                }
//            }

//            Session["ProductDataset"] = ds;

//            if (ds.Tables[1].Rows.Count > 0)
//            {

//                // totamntquantity.Visible = true;
//                object totamntquantity1;
//                totamntquantity1 = ds.Tables[1].Compute("Sum(Quantity)", "");
//                lblCount.Text = totamntquantity1.ToString();
//                //Session["myDatatable"] = ds.Tables[1];
//                //totamntquantity.Text = "Total Quantity: " + totamntquantity1.ToString();
//                Session["ProductDataset"] = ds;
//                if (Session["myDatatable"] == null)
//                    BindTempDataTable();

//                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
//                {
//                    if (((DataTable)Session["myDatatable"]).Rows.Count > 0)
//                        objTransactionDetailProperty.SNo = ((DataTable)Session["myDatatable"]).Rows.Count + 1;
//                    else
//                        objTransactionDetailProperty.SNo = 1;
//                    objTransactionDetailProperty.Sales_Type_ID = Convert.ToInt32(ds.Tables[1].Rows[i]["Sales_Type_ID"].ToString());
//                    objTransactionDetailProperty.SaleType = ds.Tables[1].Rows[i]["SalesType"].ToString();
//                    objTransactionDetailProperty.Product_ID = Convert.ToInt32(ds.Tables[1].Rows[i]["Product_ID"].ToString());
//                    objTransactionDetailProperty.ProductName = ds.Tables[1].Rows[i]["Product_Code"].ToString() + " - " + ds.Tables[1].Rows[i]["Product_Name"].ToString();

//                    objTransactionDetailProperty.Quantity = Convert.ToDecimal(ds.Tables[1].Rows[i]["Quantity"].ToString());
//                    objTransactionDetailProperty.Status = RecordStatus.Active.ToString();
//                    AddDataToTemperroryCashMemoDetailTable(objTransactionDetailProperty, (DataTable)Session["myDatatable"], 0);
//                }

//                BindGrid();
//                //GridControl1.Dt = ds.Tables[1];
//                //GridControl1.GrdDataKeyName = new string[] { "ID" };
//                //GridControl1.EditUrl = "CashMemoAddDetail.aspx?transactionId=" + Request.QueryString["recId"].ToString();
//                //objTransactionMasterProperty.Operated_By = Convert.ToInt32(SessionManager.CurrentUser.ID);
//                //objTransactionMasterProperty.TableName = "TRANSACTION_DETAILForDailyTran";
//                //GridControl1.ObjGridCommandBase = objTransactionMasterBAL;

//                //GridControl1.PageSize = 3;
//                //GridControl1.TotalRowsNum = Convert.ToInt32(objTransactionMasterProperty.TotalRowsNum);
//                //GridControl1.GrdDataKeyName = new string[] { "ID" };
//                //DataSet ds1;
//                //objTransactionMasterProperty = new Transaction_Master_Property();

//                //objTransactionMasterProperty.Functionality_Enum = FunctionalityEnum.Stock_Position.ToString();
//                //objTransactionMasterProperty.Distributor_ID = Convert.ToInt16(SessionManager.CurrentUser.DistributorID);
//                //objTransactionMasterProperty.Company_ID = Convert.ToInt16(SessionManager.CurrentUser.CompanyID);

//                //objTransactionMasterBAL = new Transaction_Master_BAL(objTransactionMasterProperty);
//                //ds1 = objTransactionMasterBAL.Configuration_CallParameters(0);

//                //if (ds1.Tables[0].Rows.Count > 0)
//                //{
//                //    if (Convert.ToBoolean(ds1.Tables[0].Rows[0]["IsApplicable"].ToString()) == true)
//                //    {
//                //        GridControl1.GrdColumnsHeading = new string[] {"View", "Edit", "Status", "Delete","Cancel", "S. No.", "SKU","Product Code","Sales Type", "Document Type ID", "Company_ID", "DocNo.", 
//                //  "Date", "Code", "Location ID", "Payment Terms", "Total Discount", "Total GST", "Net_Amount", "Quantity","Narration","Is_Active",
//                //  "Ref Document", "Ref Document1","Delivery Date","Warehouse ID","","","","","","Stock","",""}; //,"Personnel ID"
//                //        GridControl1.GrdColumnsDisableAt = new int[] { 0, 2, 4, 5, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 32, 33 };
//                //    }
//                //    else
//                //    {
//                //        GridControl1.GrdColumnsHeading = new string[] {"View", "Edit", "Status", "Delete","Cancel", "S. No.", "SKU","Product Code","Sales Type", "Document Type ID", "Company_ID", "DocNo.", 
//                //  "Date", "Code", "Location ID", "Payment Terms", "Total Discount", "Total GST", "Net_Amount", "Quantity","Narration","Is_Active",
//                //  "Ref Document", "Ref Document1","Delivery Date","Warehouse ID"}; //,"Personnel ID"
//                //        GridControl1.GrdColumnsDisableAt = new int[] { 0, 2, 4, 5, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33 };
//                //    }
//                //}
//                //else
//                //{
//                //    GridControl1.GrdColumnsHeading = new string[] {"View", "Edit", "Status", "Delete","Cancel", "S. No.", "SKU","Product Code","Sales Type", "Document Type ID", "Company_ID", "DocNo.", 
//                //  "Date", "Code", "Location ID", "Payment Terms", "Total Discount", "Total GST", "Net_Amount", "Quantity","Narration","Is_Active",
//                //  "Ref Document", "Ref Document1","Delivery Date","Warehouse ID"}; //,"Personnel ID"
//                //    GridControl1.GrdColumnsDisableAt = new int[] { 0, 2, 4, 5, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33 };
//                //}

//            }
//        }

//        protected void btnMasterUpdate_Click(object sender, EventArgs e)
//        {
//            lblMessage.Text = "";
//            if (((DataTable)Session["myDatatable"]).Rows.Count <= 0)
//            {
//                lblMessage.Text = "Atleast 1 Item is required to Insert!";
//                return;
//            }
//            bool flag;
//            Transaction_Master_Property objTransactionMasterProperty = new Transaction_Master_Property();
//            objTransactionMasterProperty.ID = Convert.ToInt32(ViewState["ID"].ToString());
//            objTransactionMasterProperty.Company_ID = Convert.ToInt32(ddlCompany.SelectedValue.ToString());
//            objTransactionMasterProperty.Document_No = ViewState["Document_No"].ToString();
//            objTransactionMasterProperty.Document_Type_ID = Convert.ToInt32(DocumentType.GOODS_ISSUE_NOTE);
//            //objTransactionMasterProperty.Pos_ID = Convert.ToInt32(DrpPos.SelectedValue.ToString());
//            //objTransactionMasterProperty.Prp_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//            objTransactionMasterProperty.DeliveryDate = Convert.ToDateTime(txt_box_dilvrydate.Text.Trim());

//            Get_DeliveryMan();
//            if (ViewState["DeliverymanId"] != null)
//            {
//                objTransactionMasterProperty.PersonnelRef_ID = Convert.ToInt32(ViewState["DeliverymanId"].ToString());
//            }

//            DataTable updatedDetails = (DataTable)Session["myDatatable"];
//            for (int i = 0; i < rptCashMemoDetail.Items.Count; i++)
//            {
//                TextBox txt = (TextBox)rptCashMemoDetail.Items[i].FindControl("txtStockReturnQuantity");
//                ((DataTable)Session["myDatatable"]).Rows[i]["productQty"] = txt.Text;
//            }


//            //objTransactionMasterProperty.Route_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//            //objTransactionMasterProperty.Personnel_ID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());
//            objTransactionMasterProperty.Document_Date = SessionManager.CurrentUser.FinancialDate;
//            objTransactionMasterProperty.Operation = Operation.Insert.ToString();
//            objTransactionMasterProperty.Operated_By = Convert.ToInt32(SessionManager.CurrentUser.ID);
//            objTransactionMasterProperty.Operation_Date = DateTime.Now;
//            objTransactionMasterProperty.Is_Active = 1;
//            objTransactionMasterProperty.Processed = false;
//            objTransactionMasterProperty.Status = RecordStatus.Active.ToString();
//            objTransactionMasterProperty.Distributor_ID = Convert.ToInt32(SessionManager.CurrentUser.DistributorID);
//            objTransactionMasterProperty.Location_ID = getLoc();
//            objTransactionMasterProperty.Record_Table_Name = "TRANSACTION_MASTER";

//            //objTransactionMasterProperty.DetailData = (DataTable)Session["myDatatable"];
//            objTransactionMasterProperty.DetailData = updatedDetails;

//            Transaction_Master_BAL objTransactionMasterBAL = new Transaction_Master_BAL(objTransactionMasterProperty);
//            flag = objTransactionMasterBAL.UpdateForDailyTranNew();





//            /************************************************************/
//            //if (recId != null)
//            //{
//            //    //if ((string)Session["Cashmemoupdate"] == "yes")
//            //    //{
//            //        DataSet dsproductable;
//            //        dsproductable = (DataSet)Session["ProductDataset"];
//            //        if (dsproductable != null)
//            //        {
//            //            if (dsproductable.Tables[1].Rows.Count > 0)
//            //            {
//            //                DataTable dts = new DataTable();
//            //                dts = (DataTable)ViewState["Dtproduct"];

//            //                DataRow[] rows1 = dts.Select("Product_Index=" + Convert.ToInt32(cmbProduct.SelectedValue.ToString()));
//            //                productid = rows1[0].ItemArray[0].ToString();

//            //                DataRow[] rows = dsproductable.Tables[1].Select("Product_ID=" + Convert.ToInt32(productid) + "and" + " Sales_Type_ID=" + Convert.ToInt32(SaleType1.GetSelectedValue()));
//            //                if (rows.Length > 0)
//            //                {
//            //                    if (rows.Length == 1)
//            //                    {
//            //                        if ((Convert.ToInt32(rows[0]["Product_ID"].ToString()) == Convert.ToInt32(ViewState["Product_IDcheck"].ToString())) && (Convert.ToInt32(rows[0]["Sales_Type_ID"].ToString()) == Convert.ToInt32(ViewState["SaleTypeIdcheck"].ToString())))
//            //                        {

//            //                        }
//            //                        else
//            //                        {
//            //                            rows = dsproductable.Tables[1].Select("Product_ID=" + Convert.ToInt32(productid) + "and" + " Sales_Type_ID=" + Convert.ToInt32(SaleType1.GetSelectedValue()));
//            //                            if (rows.Length > 0)
//            //                            {
//            //                                Response.Write("<script language=javascript>alert('Cannot update sale type because already exist with same SKU')</script>");
//            //                                return;
//            //                            }
//            //                        }
//            //                    }
//            //                }
//            //            }
//            //        }
//            //        objTransactionDetailProperty.ID = Convert.ToInt32(recId);
//            //        objTransactionDetailProperty.Sales_Type_ID = SaleType1.GetSelectedValue();
//            //        objTransactionDetailProperty.Product_ID = Convert.ToInt32(productid);
//            //        objTransactionDetailProperty.Quantity = Convert.ToDecimal(txt_ProdctQuantity.Text.Trim());
//            //        objTransactionDetailProperty.Document_Type_ID = Convert.ToInt32(DocumentType.GOODS_ISSUE_NOTE);
//            //        objTransactionDetailProperty.Transaction_Id = Convert.ToInt32(ViewState["TranMasterID"]);
//            //        objTransactionDetailProperty.Stock = txtstock.Text;
//            //        objTransactionMasterProperty.Distributor_ID = (Int32)SessionManager.CurrentUser.DistributorID;
//            //        objTransactionDetailProperty.Distributor_ID = (Int32)SessionManager.CurrentUser.DistributorID;

//            //        Transaction_Detail_BLL objTransactionDetailBLL = new Transaction_Detail_BLL(objTransactionDetailProperty);
//            //        bool flag;
//            //        flag = objTransactionDetailBLL.UpdateCashMemo();
//            //        if (flag == true)
//            //        {
//            //            int i = Convert.ToInt32(ViewState["TranMasterID"]);
//            //            Response.Redirect("CashMemoAdd.aspx?recId=" + ViewState["TranMasterID"]);
//            //        }
//            //        else
//            //        {
//            //        }
//            //    //}
//            //}


//            if (flag == true)
//            {
//                Session.Remove("myDatatable");
//                BindGrid();
//                lblMessage.Text = "Successfully Update";
//            }
//            else
//            {
//                lblMessage.Text = "Failed Update";
//            }

//        }

//        public void FillCompanyCode()
//        {
//            DataTable dt = GetCompanies();

//            ddlCompany.Items.Clear();

//            if (dt != null)
//            {
//                if (dt.Rows.Count > 0)
//                {
//                    this.ddlCompany.DataSource = dt;
//                    this.ddlCompany.DataTextField = "Company";
//                    this.ddlCompany.DataValueField = "ID";
//                    this.ddlCompany.DataBind();
//                    if (dt.Rows.Count == 1)
//                    {
//                        ddlCompany.SelectedIndex = 1;
//                        ddlCompany.Enabled = false;
//                    }
//                    else
//                    {
//                        ddlCompany.Enabled = true;
//                    }

//                }
//            }
//            else
//                ddlCompany.Items.Add(new ListItem("Please select", "-1"));
//        }
//        public void FillCurrentDate()
//        {
//            txt_box_createdate.Text = DateTime.Now.ToShortDateString();
//        }

//        private static DataTable GetCompanies()
//        {
//            Company_Property objCompanyProperty = new Company_Property();

//            objCompanyProperty.ID = SessionManager.CurrentUser.CompanyID;

//            Company_BLL objCompanyBLL = new Company_BLL(objCompanyProperty);
//            return objCompanyBLL.GetCompanyById();
//        }

//        public void FillDistributorCode()
//        {
//            DataTable dt = GetDistributors();

//            //drpdist.Items.Clear();
//            //drpdist.Items.Add(new ListItem("Please select", "-1"));
//            if (dt != null)
//            {
//                if (dt.Rows.Count > 0)
//                {
//                    //this.drpdist.DataSource = dt;
//                    //this.drpdist.DataTextField = "DistributorDesc";
//                    //this.drpdist.DataValueField = "ID";
//                    //this.drpdist.DataBind();
//                    if (dt.Rows.Count == 1)
//                    {
//                        //drpdist.SelectedIndex = 1;
//                        //drpdist.Enabled = false;
//                    }
//                    else
//                    {
//                        //drpdist.Enabled = true;
//                    }

//                }
//            }
//            else { }
//            //drpdist.Items.Add(new ListItem("Please select", "-1"));
//        }

//        private static DataTable GetDistributors()
//        {
//            Distributor_Setup_Property objDistributorProperty = new Distributor_Setup_Property();
//            objDistributorProperty.ID = Convert.ToInt32(SessionManager.CurrentUser.DistributorID);

//            Distributor_Setup_BLL DistributorBLL = new Distributor_Setup_BLL(objDistributorProperty);

//            return DistributorBLL.GetById();
//        }

//        public void FillSalesRep()
//        {
//            DataTable dt = GetSalesRep();

//            //ddlSalesRep.Items.Clear();
//            //ddlSalesRep.Items.Add(new ListItem("Please select", "-1"));
//            if (dt != null)
//            {
//                if (dt.Rows.Count > 0)
//                {
//                    //this.ddlSalesRep.DataSource = dt;
//                    //this.ddlSalesRep.DataTextField = "Personnel_Name";
//                    //this.ddlSalesRep.DataValueField = "ID";
//                    //this.ddlSalesRep.DataBind();
//                    return;
//                }
//            }
//            else { }
//            //ddlSalesRep.Items.Add(new ListItem("Please select", "-1"));
//        }

//        private static DataTable GetSalesRep()
//        {
//            DataTable dts = new DataTable();

//            Personnel_Setup_Property objPersonelSetupProperty = new Personnel_Setup_Property();
//            objPersonelSetupProperty.Company_ID = (int)SessionManager.CurrentUser.CompanyID;
//            objPersonelSetupProperty.Distributor_Mst_Setup_ID = Convert.ToInt32(SessionManager.CurrentUser.DistributorID);
//            objPersonelSetupProperty.PageSize = 9999999;
//            objPersonelSetupProperty.PageNum = 1;
//            objPersonelSetupProperty.SortColumn = "ID";
//            objPersonelSetupProperty.Status = "Active";
//            objPersonelSetupProperty.Sales_Rep_Type_ID = 1;
//            Personnel_Setup_BLL objPersonelSetupBLL = new Personnel_Setup_BLL(objPersonelSetupProperty);
//            dts = objPersonelSetupBLL.ViewAll();
//            return dts;
//        }

//        protected void ddlSalesRep_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            //if (ddlSalesRep.SelectedValue != "-1")
//            //{
//            //    FillRoute(int.Parse(ddlSalesRep.SelectedValue.ToString()));
//            //    ddlRoute.Focus();
//            //    bindProduct();
//            //}
//        }

//        public void FillRoute(int salesRepId)
//        {
//            DataTable dt = GetRoute(salesRepId);

//            //ddlRoute.Items.Clear();
//            //ddlRoute.Items.Add(new ListItem("Please select", "-1"));

//            //this.ddlRoute.DataSource = dt;
//            //this.ddlRoute.DataTextField = "Route_Desc";
//            //this.ddlRoute.DataValueField = "ID";
//            //this.ddlRoute.DataBind();
//            return;
//        }

//        private static DataTable GetRoute(int salesRepId)
//        {
//            DataTable dts = new DataTable();

//            Permanent_Route_Plan_Setup_Property objPermanentRoutePlanSetupProperty = new Permanent_Route_Plan_Setup_Property();

//            objPermanentRoutePlanSetupProperty.Personnel_ID = Convert.ToInt32(salesRepId);

//            objPermanentRoutePlanSetupProperty.DIstributor_ID = (int)SessionManager.CurrentUser.DistributorID;
//            objPermanentRoutePlanSetupProperty.Status = Utility.RecordStatus.Active.ToString();
//            objPermanentRoutePlanSetupProperty.PageSize = 9999999;
//            objPermanentRoutePlanSetupProperty.PageNum = 1;
//            objPermanentRoutePlanSetupProperty.SortColumn = "ID";
//            objPermanentRoutePlanSetupProperty.Status = "Active";
//            Permanent_Route_Plan_Setup_BLL objPermanentRoutePlanSetupBLL = new Permanent_Route_Plan_Setup_BLL(objPermanentRoutePlanSetupProperty);
//            dts = objPermanentRoutePlanSetupBLL.ViewAllPermanentRoute();

//            return dts;
//        }

//        protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            //if (ddlRoute.SelectedValue != "-1")
//            //{
//            //    FillPOS(int.Parse(ddlRoute.SelectedValue.ToString()));
//            //    Get_DeliveryMan_Date();
//            //    DrpPos.Focus();
//            //}
//        }
//        public void Get_DeliveryMan_Date()
//        {
//            try
//            {
//                DataSet ds;
//                Transaction_Master_Property objTransactionMasterProperty1 = new Transaction_Master_Property();

//                //objTransactionMasterProperty1.Prp_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//                //objTransactionMasterProperty1.Route_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//                //objTransactionMasterProperty1.Personnel_ID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());

//                if (objTransactionMasterProperty1.Personnel_ID != -1 && objTransactionMasterProperty1.Prp_ID != -1)
//                {
//                    //objTransactionMasterProperty1.Prp_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//                    //objTransactionMasterProperty1.Route_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//                    //objTransactionMasterProperty1.Personnel_ID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());

//                    Transaction_Master_BAL objTransactionMasterBAL1 = new Transaction_Master_BAL(objTransactionMasterProperty1);
//                    ds = objTransactionMasterBAL1.GetDeliveryManwithDay();
//                    txt_box_dilvrydate.Visible = true;
//                    txt_box_dilvrydate.Text = Convert.ToDateTime(ds.Tables[1].Rows[0]["Date"].ToString()).ToShortDateString();
//                }
//            }
//            catch
//            {

//            }

//        }

//        public void FillPOS(int routeId)
//        {

//            DataTable dt = GetPOS(routeId);

//            //DrpPos.Items.Clear();
//            //   DrpPos.Items.Add(new ListItem("Please select", "-1"));

//            if (dt != null)
//            {
//                if (dt.Rows.Count > 0)
//                {
//                    //this.DrpPos.DataSource = dt;
//                    //this.DrpPos.DataTextField = "Short_Description";
//                    //this.DrpPos.DataValueField = "ID";
//                    //this.DrpPos.DataBind();

//                    return;
//                }
//            }
//        }

//        private static DataTable GetPOS(int routeId)
//        {
//            POS_Setup_Property objPOSSetupProperty = new POS_Setup_Property();


//            objPOSSetupProperty.RouteID = routeId;
//            //objPOSSetupProperty.Status = Utility.RecordStatus.Active.ToString();
//            objPOSSetupProperty.DistributorID = (int)SessionManager.CurrentUser.DistributorID;
//            objPOSSetupProperty.PageSize = 9999999;
//            objPOSSetupProperty.PageNum = 1;
//            objPOSSetupProperty.SortColumn = "ID";

//            POS_Setup_BLL objPOSSetupBLL = new POS_Setup_BLL(objPOSSetupProperty);
//            return objPOSSetupBLL.ViewAllPOS_SETUPRoute();

//        }

//        //protected void btnSubmit_Click(object sender, EventArgs e)
//        //{
//        //    lblCountName.Visible = true;
//        //    lblCount.Visible = true;
//        //    lblMessage.Text = "";
//        //    string productid = "";
//        //    if (Convert.ToInt32(txt_ProdctQuantity.Text.Trim()) > 0)
//        //    {
//        //        //Check Product already exist or not in database
//        //        //if ((string)Session["Cashmemoupdate"] == "yes")
//        //        //{
//        //        //    DataSet dsproductable;
//        //        //    dsproductable = (DataSet)Session["ProductDataset"];
//        //        //    if (dsproductable != null)
//        //        //    {
//        //        //        if (dsproductable.Tables[1].Rows.Count > 0)
//        //        //        {
//        //        //            if (dsproductable.Tables[1].Rows.Count > 0)
//        //        //            {
//        //        //                DataTable dts = new DataTable();
//        //        //                dts = (DataTable)ViewState["Dtproduct"];

//        //        //                DataRow[] rows1 = dts.Select("Product_Index=" + Convert.ToInt32(cmbProduct.SelectedValue.ToString()));
//        //        //                productid = rows1[0].ItemArray[0].ToString();

//        //        //                DataRow[] rows = dsproductable.Tables[1].Select("Product_ID=" + Convert.ToInt32(productid) + "and" + " Sales_Type_ID=" +
//        //        //                    Convert.ToInt32(cmbSalesType.SelectedValue.ToString()));
//        //        //                if (rows.Length > 0)
//        //        //                {
//        //        //                    lblMessage.Text = "Cannot update sale type because already exist with same SKU";
//        //        //                    //Response.Write("<script language=javascript>alert('Cannot update sale type because already exist with same SKU')</script>");
//        //        //                    return;
//        //        //                }
//        //        //            }
//        //        //        }
//        //        //    }
//        //        //}
//        //        try
//        //        {
//        //            objTransactionDetailProperty.Sales_Type_ID = Convert.ToInt32(cmbSalesType.SelectedValue.ToString()); // SaleType1.GetSelectedValue();
//        //            if (Enum.IsDefined(typeof(Utility.SaleType), cmbSalesType.SelectedItem.ToString()) == false)
//        //            {
//        //                lblMessage.Text = "Please select valid Sale type.";
//        //                //Response.Write("<script language=javascript>alert('Please select valid Sale type.')</script>");
//        //                return;
//        //            }
//        //        }
//        //        catch
//        //        {
//        //            lblMessage.Text = "Please select valid Sale type.";
//        //            //Response.Write("<script language=javascript>alert('Please select valid Sale type.')</script>");
//        //            return;
//        //        }

//        //        try
//        //        {
//        //            if (Convert.ToInt32(cmbProduct.SelectedValue) == -1)
//        //            {
//        //                lblMessage.Text = "Please select Product.";
//        //                //Response.Write("<script language=javascript>alert('Please select Product.')</script>");
//        //                return;
//        //            }
//        //        }
//        //        catch
//        //        {
//        //            lblMessage.Text = "Please select Product.";
//        //            //Response.Write("<script language=javascript>alert('Please select Product.')</script>");
//        //            return;
//        //        }
//        //        objTransactionDetailProperty.SaleType = cmbSalesType.SelectedItem.ToString(); //SaleType1.GetSelectedText();
//        //        objTransactionDetailProperty.Product_ID = Convert.ToInt32(cmbProduct.SelectedValue); //ProductWithIndex1.GetSelectedCodeValue());
//        //        objTransactionDetailProperty.ProductName = cmbProduct.SelectedItem.ToString();//ProductWithIndex1.GetSelectedFinalProductName();
//        //        if (txt_ProdctQuantity.Text != string.Empty)
//        //        {
//        //            objTransactionDetailProperty.Quantity = Convert.ToDecimal(txt_ProdctQuantity.Text.Trim());
//        //        }
//        //        else if (txt_ProdctQuantity.Text == string.Empty)
//        //        {
//        //            RequiredFieldValidator1.Visible = true;
//        //        }
//        //        if (Session["myDatatable"] == null)
//        //        {
//        //            BindTempDataTable();
//        //        }
//        //        if (((DataTable)Session["myDatatable"]).Rows.Count > 0)
//        //        {
//        //            for (int i = 0; i < ((DataTable)Session["myDatatable"]).Rows.Count; i++)
//        //            {
//        //                bool res = CheckDuplicateData(i, (DataTable)Session["myDatatable"]);
//        //                if (res)
//        //                {
//        //                    txt_ProdctQuantity.Text = "";
//        //                    txtProduct_Index.Text = "";
//        //                    lblMessage.Text = "This Product is already Inserted.";
//        //                    //Response.Write("<script language=javascript>alert('This Product is already Inserted.')</script>");
//        //                    return;
//        //                }
//        //            }
//        //            objTransactionDetailProperty.SNo = ((DataTable)Session["myDatatable"]).Rows.Count + 1;
//        //        }
//        //        else
//        //        {
//        //            objTransactionDetailProperty.SNo = 1;
//        //        }
//        //        objTransactionDetailProperty.Status = RecordStatus.Active.ToString();

//        //        AddDataToTemperroryCashMemoDetailTable(objTransactionDetailProperty, (DataTable)Session["myDatatable"], 1);

//        //        BindGrid();
//        //        //Helper.ResetForm(tblCashMemoDetail);
//        //        rptCashMemoDetail.DataBind();

//        //        txt_ProdctQuantity.Text = "";
//        //        txtProduct_Index.Text = "";
//        //        //txtProduct_Index.Focus();
//        //        //cmbSalesType.SelectedValue = "1";
//        //        //FillSalesType();
//        //    }
//        //    else
//        //    {
//        //        txt_ProdctQuantity.Text = "";
//        //    }
//        //    //cmbSalesType.Focus();
//        //    cmbSalesType.Focus();
//        //}
//        protected void btnSubmit_Click(object sender, EventArgs e)
//        {
//            lblCountName.Visible = true;
//            lblCount.Visible = true;
//            lblMessage.Text = "";
//            string productid = "";
//            if (Convert.ToInt32(txt_ProdctQuantity.Text.Trim()) > 0)
//            {
//                //Check Product already exist or not in database
//                //if ((string)Session["Cashmemoupdate"] == "yes")
//                //{
//                //    DataSet dsproductable;
//                //    dsproductable = (DataSet)Session["ProductDataset"];
//                //    if (dsproductable != null)
//                //    {
//                //        if (dsproductable.Tables[1].Rows.Count > 0)
//                //        {
//                //            if (dsproductable.Tables[1].Rows.Count > 0)
//                //            {
//                //                DataTable dts = new DataTable();
//                //                dts = (DataTable)ViewState["Dtproduct"];

//                //                DataRow[] rows1 = dts.Select("Product_Index=" + Convert.ToInt32(cmbProduct.SelectedValue.ToString()));
//                //                productid = rows1[0].ItemArray[0].ToString();

//                //                DataRow[] rows = dsproductable.Tables[1].Select("Product_ID=" + Convert.ToInt32(productid) + "and" + " Sales_Type_ID=" +
//                //                    Convert.ToInt32(cmbSalesType.SelectedValue.ToString()));
//                //                if (rows.Length > 0)
//                //                {
//                //                    lblMessage.Text = "Cannot update sale type because already exist with same SKU";
//                //                    //Response.Write("<script language=javascript>alert('Cannot update sale type because already exist with same SKU')</script>");
//                //                    return;
//                //                }
//                //            }
//                //        }
//                //    }
//                //}
//                try
//                {
//                    objTransactionDetailProperty.Sales_Type_ID = Convert.ToInt32(cmbSalesType.SelectedValue.ToString()); // SaleType1.GetSelectedValue();
//                    if (Enum.IsDefined(typeof(Utility.SaleType), cmbSalesType.SelectedItem.ToString()) == false)
//                    {
//                        lblMessage.Text = "Please select valid Sale type.";
//                        //Response.Write("<script language=javascript>alert('Please select valid Sale type.')</script>");
//                        return;
//                    }
//                }
//                catch
//                {
//                    lblMessage.Text = "Please select valid Sale type.";
//                    //Response.Write("<script language=javascript>alert('Please select valid Sale type.')</script>");
//                    return;
//                }

//                try
//                {
//                    if (Convert.ToInt32(cmbProduct.SelectedValue) == -1)
//                    {
//                        lblMessage.Text = "Please select Product.";
//                        //Response.Write("<script language=javascript>alert('Please select Product.')</script>");
//                        return;
//                    }
//                }
//                catch
//                {
//                    lblMessage.Text = "Please select Product.";
//                    //Response.Write("<script language=javascript>alert('Please select Product.')</script>");
//                    return;
//                }
//                objTransactionDetailProperty.SaleType = cmbSalesType.SelectedItem.ToString(); //SaleType1.GetSelectedText();
//                objTransactionDetailProperty.Product_ID = Convert.ToInt32(cmbProduct.SelectedValue); //ProductWithIndex1.GetSelectedCodeValue());
//                objTransactionDetailProperty.ProductName = cmbProduct.SelectedItem.ToString();//ProductWithIndex1.GetSelectedFinalProductName();
//                objTransactionDetailProperty.Discription = textbox_description.Text.ToString();//ProductWithIndex1.GetSelectedFinalProductName();
//                objTransactionDetailProperty.Product_quantity = txt_ProdctQuantity.Text.ToString();//ProductWithIndex1.GetSelectedFinalProductName();
//                objTransactionDetailProperty.Textboxrates = TextBoxrate.Text.ToString();//ProductWithIndex1.GetSelectedFinalProductName();




















//                // set the values that are coming from the combo box and than set it through the id and we are maping it in its classes like bata base.l
//                if (txt_ProdctQuantity.Text != string.Empty)
//                {
//                    objTransactionDetailProperty.Quantity = Convert.ToDecimal(txt_ProdctQuantity.Text.Trim());
//                }
//                else if (txt_ProdctQuantity.Text == string.Empty)
//                {
//                    RequiredFieldValidator1.Visible = true;
//                }
//                if (Session["myDatatable"] == null)
//                {
//                    BindTempDataTable();
//                }
//                if (((DataTable)Session["myDatatable"]).Rows.Count > 0)
//                {
//                    for (int i = 0; i < ((DataTable)Session["myDatatable"]).Rows.Count; i++)
//                    {
//                        bool res = CheckDuplicateData(i, (DataTable)Session["myDatatable"]);
//                        if (res)
//                        {
//                            txt_ProdctQuantity.Text = "";
//                            txtProduct_Index.Text = "";
//                            lblMessage.Text = "This Product is already Inserted.";
//                            //Response.Write("<script language=javascript>alert('This Product is already Inserted.')</script>");
//                            return;
//                        }
//                    }
//                    objTransactionDetailProperty.SNo = ((DataTable)Session["myDatatable"]).Rows.Count + 1;
//                }
//                else
//                {
//                    objTransactionDetailProperty.SNo = 1;
//                }
//                objTransactionDetailProperty.Status = RecordStatus.Active.ToString();

//                AddDataToTemperroryCashMemoDetailTable(objTransactionDetailProperty, (DataTable)Session["myDatatable"], 1);

//                BindGrid();
//                //Helper.ResetForm(tblCashMemoDetail);
//                rptCashMemoDetail.DataBind();

//                txt_ProdctQuantity.Text = "";
//                txtProduct_Index.Text = "";
//                //txtProduct_Index.Focus();
//                //cmbSalesType.SelectedValue = "1";
//                //FillSalesType();
//            }
//            else
//            {
//                txt_ProdctQuantity.Text = "";
//            }
//            //cmbSalesType.Focus();
//            //cmbSalesType.Focus();
//            txtProduct_Index.Focus();
//        }


//        public void FillSalesType()
//        {
//            cmbSalesType.Items.Clear();
//            Array saleTypeValues = Enum.GetValues(typeof(Utility.SaleType));
//            cmbSalesType.Items.Add(new ListItem("Select Sales Type", "-1"));
//            foreach (int docType in saleTypeValues)
//            {
//                cmbSalesType.Items.Add(new ListItem(Enum.GetName(typeof(Utility.SaleType), docType).ToString(), Convert.ToString(docType)));
//            }
//            cmbSalesType.SelectedIndex = 1;
//        }

//        private bool CheckDuplicateData(int sno, DataTable dt)
//        {
//            bool result = true;
//            if (cmbProduct.SelectedIndex > 0)
//            {
//                if (dt.Rows[sno]["productName"].ToString() == cmbProduct.SelectedItem.ToString() && dt.Rows[sno]["saleType"].ToString() == cmbSalesType.SelectedItem.ToString())
//                {
//                    result = true;
//                }
//                else
//                {
//                    result = false;
//                }
//            }
//            return result;
//        }

//        //tempnoorcashmemo
//        private void AddDataToTemperroryCashMemoDetailTable(Transaction_Detail_Property objTransactionDetailProperty, DataTable myTable, int flag)
//        {
//            bindProduct();
//            DataRow row;
//            row = myTable.NewRow();

//            row["id"] = Guid.NewGuid().ToString();
//            row["sNo"] = objTransactionDetailProperty.SNo;
//            row["Transaction_Id"] = DBNull.Value;
//            row["saleTypeId"] = objTransactionDetailProperty.Sales_Type_ID;
//            row["saleType"] = objTransactionDetailProperty.SaleType;
//            DataTable dts = new DataTable();
//            dts = (DataTable)ViewState["Dtproduct"];

//            DataRow[] rows = dts.Select("Product_Index=" + objTransactionDetailProperty.Product_ID);
//            if (flag == 1)
//                row["productId"] = rows[0].ItemArray[0];//objTransactionDetailProperty.Product_ID;
//            if (flag == 0)
//                row["productId"] = objTransactionDetailProperty.Product_ID;
//            row["ProductName"] = objTransactionDetailProperty.ProductName;
//            row["productQty"] = objTransactionDetailProperty.Quantity;
//            row["status"] = objTransactionDetailProperty.Status;
//            row["discription"] = objTransactionDetailProperty.Discription;
//            row["Product_quantity"] = objTransactionDetailProperty.Product_quantity;
//            row["Textboxrates"] = objTransactionDetailProperty.Textboxrates;

//            //  row["Stock"] = txtstock.Text;
//            row["Productindex"] = objTransactionDetailProperty.Product_ID;

//            myTable.Rows.Add(row);

//        }
//        public DataTable CreateTemporaryCashMemoDetailDT()
//        {
//            //Set fields in Temporary table

//            myDatatable = new DataTable();
//            DataColumn myDataColumn = new DataColumn();

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "id";
//            myDatatable.Columns.Add(myDataColumn);

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "discribe";
//            myDatatable.Columns.Add(myDataColumn);


//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "sNo";
//            myDatatable.Columns.Add(myDataColumn);


//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "Transaction_Id";
//            myDatatable.Columns.Add(myDataColumn);

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "saleTypeId";
//            myDatatable.Columns.Add(myDataColumn);

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "saleType";
//            myDatatable.Columns.Add(myDataColumn);

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "productId";
//            myDatatable.Columns.Add(myDataColumn);

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "productName";
//            myDatatable.Columns.Add(myDataColumn);


//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "productQty";
//            myDatatable.Columns.Add(myDataColumn);

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "ratee";
//            myDatatable.Columns.Add(myDataColumn);


//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "Status";
//            myDatatable.Columns.Add(myDataColumn);

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "Stock";
//            myDatatable.Columns.Add(myDataColumn);

//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "pkquantity";
//            myDatatable.Columns.Add(myDataColumn);


//            myDataColumn = new DataColumn();
//            myDataColumn.DataType = Type.GetType("System.String");
//            myDataColumn.ColumnName = "Productindex";
//            myDatatable.Columns.Add(myDataColumn);
//            return myDatatable;

//        }

//        private void BindTempDataTable()
//        {
//            //Bind Temporary Table data 
//            if (Session["myDatatable"] != null)
//            {
//                BindGrid();
//            }

//            else
//            {
//                DataTable TransactionDetailDt;
//                TransactionDetailDt = new DataTable();
//                TransactionDetailDt = CreateTemporaryCashMemoDetailDT();
//                Session["myDatatable"] = TransactionDetailDt;
//            }
//        }

//        private void BindGrid()
//        {
//            DataTable dt = null;
//            dt = ((DataTable)Session["myDatatable"]);
//            rptCashMemoDetail.DataSource = ((DataTable)Session["myDatatable"]);
//            rptCashMemoDetail.DataBind();
//            if (dt != null)
//            {
//                if (dt.Rows.Count > 0)
//                {
//                    dt.Columns.Add("QtyNumeric", typeof(int), "Convert(productQty, 'System.Int32')");
//                    object sumqty = dt.Compute("Sum(QtyNumeric)", "");
//                    lblCount.Text = sumqty.ToString();
//                    lblCount.Visible = true;
//                    lblCountName.Visible = true;
//                    dt.Columns.Remove("QtyNumeric");
//                }
//            }
//        }

//        protected void txtstock_TextChanged(object sender, EventArgs e)
//        {
//            txt_ProdctQuantity.Focus();
//        }

//        protected void txt_ProdctQuantity_TextChanged(object sender, EventArgs e)
//        {
//            btnSubmit.Focus();
//            //btnSubmit_Click(sender, e);
//            //cmbSalesType.Focus();
//        }

//        protected void tblSave_Click(object sender, EventArgs e)
//        {
//            lblMessage.Text = "";
//            /*************************************************/
//            Transaction_Master_Property objTransactionMasterProperty = new Transaction_Master_Property();
//            objTransactionMasterProperty.Company_ID = Convert.ToInt32(ddlCompany.SelectedValue.ToString());
//            // objTransactionMasterProperty.Route_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//            Permanent_Route_Plan_Setup_Property objPermanentRoutePlanSetupProperty = new Permanent_Route_Plan_Setup_Property();
//            //  objPermanentRoutePlanSetupProperty.Personnel_ID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());
//            objPermanentRoutePlanSetupProperty.PageSize = 9999999;
//            objPermanentRoutePlanSetupProperty.PageNum = 1;
//            objPermanentRoutePlanSetupProperty.SortColumn = "ID";
//            Permanent_Route_Plan_Setup_BLL objPermanentRoutePlanSetupBLL = new Permanent_Route_Plan_Setup_BLL(objPermanentRoutePlanSetupProperty);
//            DataTable dtPermanentRoutePlanSetupBLL = objPermanentRoutePlanSetupBLL.ViewAll();
//            if (dtPermanentRoutePlanSetupBLL.Rows.Count > 0)
//                objTransactionMasterProperty.Prp_ID = Convert.ToInt32(dtPermanentRoutePlanSetupBLL.Rows[0]["ID"]);
//            objTransactionMasterProperty.Document_Type_ID = Convert.ToInt32(DocumentType.Cash_Memo);
//            //  objTransactionMasterProperty.Personnel_ID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());
//            Get_DeliveryMan();
//            if (ViewState["DeliverymanId"] != null)
//            {
//                objTransactionMasterProperty.PersonnelRef_ID = Convert.ToInt32(ViewState["DeliverymanId"].ToString());
//                objTransactionMasterProperty.DeliveryDate = Convert.ToDateTime(ViewState["DeliveryDate"].ToString());
//            }

//            objTransactionMasterProperty.Document_Date = SessionManager.CurrentUser.FinancialDate;
//            // objTransactionMasterProperty.Pos_ID = Convert.ToInt32(DrpPos.SelectedValue.ToString());

//            objTransactionMasterProperty.Location_ID = getLoc();

//            objTransactionMasterProperty.Record_Table_Name = "TRANSACTION_MASTERForDailyTran";
//            objTransactionMasterProperty.Operation = Operation.Insert.ToString();
//            objTransactionMasterProperty.Operated_By = Convert.ToInt32(SessionManager.CurrentUser.ID);
//            objTransactionMasterProperty.Operation_Date = DateTime.Now;
//            objTransactionMasterProperty.Is_Active = 1;
//            objTransactionMasterProperty.Processed = false;
//            objTransactionMasterProperty.Status = RecordStatus.Active.ToString();
//            objTransactionMasterProperty.Distributor_ID = Convert.ToInt32(SessionManager.CurrentUser.DistributorID);

//            /*************************************************/
//            bool flag = false;

//            if (((DataTable)Session["myDatatable"]).Rows.Count != 0) //Session["masterData"] != null &&
//            {
//                #region CHECK ATLEAST 1 PRODUCT IS NORMAL
//                DataRow[] drs = ((DataTable)Session["myDatatable"]).Select("saleType='Active'");
//                if (drs == null || drs.Length <= 0)
//                {
//                    lblMessage.Text = "Enter atleast ONE Active Product.";
//                    //Response.Write("<script language=javascript>alert('Enter atleast ONE Normal Product.')</script>");
//                    return;
//                }
//                #endregion

//                //objTransactionMasterProperty = (Transaction_Master_Property)Session["masterData"];
//                objTransactionMasterProperty.DetailData = (DataTable)Session["myDatatable"];
//                //objTransactionMasterProperty.ConfigDetailData = (DataTable)Session["ConfigTable"];

//                Transaction_Master_BAL objTransactionMasterBAL = new Transaction_Master_BAL(objTransactionMasterProperty);

//                flag = objTransactionMasterBAL.Add();
//                Session["tranMasterData"] = (Transaction_Master_Property)Session["masterData"];
//                if (flag)
//                {
//                    Session.Remove("myDatatable");
//                    BindGrid();
//                    lblMessage.Text = "Cash Memo added successfully!.";
//                    lblCountName.Visible = false;
//                    lblCount.Visible = false;
//                }

//                //if (flag)
//                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closepopup", "closePopup('add=true')", true);
//                //else
//                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closepopup", "closePopup('add=false')", true);
//                //Session.Remove("masterData");
//            }

//            //if (Request.QueryString["CMId"] != null && ((DataTable)Session["myDatatable"]).Rows.Count != 0)
//            //{
//            //    objTransactionMasterProperty.ID = Convert.ToInt32(Request.QueryString["CMId"]);
//            //    objTransactionMasterProperty.DetailData = (DataTable)Session["myDatatable"];
//            //    objTransactionMasterProperty.ConfigDetailData = (DataTable)Session["ConfigTable"];
//            //    objTransactionMasterProperty.Distributor_ID = (Int32)SessionManager.CurrentUser.DistributorID;
//            //    Transaction_Master_BAL objTransactionMasterBAL = new Transaction_Master_BAL(objTransactionMasterProperty);

//            //    flag = objTransactionMasterBAL.Add();

//            //    if (flag)
//            //    {
//            //        if ((string)Session["Cashmemoupdate"] == "yes")
//            //        {
//            //            int recidx = Convert.ToInt32(Session["recidx"]);
//            //            string recid = "recId=" + recidx.ToString();
//            //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closepopup", "closePopup('" + recid + "')", true);
//            //        }
//            //        else
//            //        {
//            //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closepopup", "closePopup('add=true')", true);
//            //        }
//            //    }
//            //    else
//            //    {
//            //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closepopup", "closePopup('add=false')", true);
//            //    }

//            //    Session.Remove("masterData");
//            //}

//        }

//        private void Get_DeliveryMan()
//        {
//            DataSet ds;
//            Transaction_Master_Property objTransactionMasterProperty1 = new Transaction_Master_Property();

//            //objTransactionMasterProperty1.Prp_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//            //objTransactionMasterProperty1.Route_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//            //objTransactionMasterProperty1.Personnel_ID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());

//            if (objTransactionMasterProperty1.Personnel_ID != -1 && objTransactionMasterProperty1.Prp_ID != -1)
//            {
//                //objTransactionMasterProperty1.Prp_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//                //objTransactionMasterProperty1.Route_ID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());
//                //objTransactionMasterProperty1.Personnel_ID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());

//                Transaction_Master_BAL objTransactionMasterBAL1 = new Transaction_Master_BAL(objTransactionMasterProperty1);
//                ds = objTransactionMasterBAL1.GetDeliveryManwithDay();

//                int DeliverymanId;
//                DateTime DeliveryDate;

//                if (ds.Tables.Count > 0)
//                {
//                    if (ds.Tables[0].Rows.Count > 0)
//                    {
//                        DeliverymanId = Convert.ToInt32(ds.Tables[0].Rows[0]["Delivery_Man_ID"].ToString());
//                        ViewState["DeliverymanId"] = DeliverymanId;
//                    }
//                    if (ds.Tables[1].Rows.Count > 0)
//                    {
//                        DeliveryDate = Convert.ToDateTime(ds.Tables[1].Rows[0]["Date"].ToString());

//                        ViewState["DeliveryDate"] = DeliveryDate;
//                    }

//                    if (ViewState["DeliveryDate"] != null)
//                    {
//                        objTransactionMasterProperty.DeliveryDate = Convert.ToDateTime(ViewState["DeliveryDate"].ToString());
//                    }
//                }
//            }
//        }

//        private int? getLoc()
//        {
//            POS_Setup_Property objPOSSetupProperty = new POS_Setup_Property();

//            //objPOSSetupProperty.ID = Convert.ToInt32(DrpPos.SelectedValue.ToString());
//            //objPOSSetupProperty.RouteID = Convert.ToInt32(ddlRoute.SelectedValue.ToString());

//            objPOSSetupProperty.DistributorID = Convert.ToInt32(SessionManager.CurrentUser.DistributorID);
//            objPOSSetupProperty.PageSize = 9999999;
//            objPOSSetupProperty.PageNum = 1;
//            objPOSSetupProperty.SortColumn = "ID";
//            DataTable dt;
//            POS_Setup_BLL objPOSSetupBLL = new POS_Setup_BLL(objPOSSetupProperty);

//            dt = objPOSSetupBLL.ViewAll();
//            int? locid = 0;
//            if (dt.Rows.Count > 0)
//                locid = Convert.ToInt32(dt.Rows[0]["Location_ID"].ToString());
//            return locid;
//        }

//        protected void rptCashMemoDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
//        {
//            if (e.CommandName == "Delete")
//            {
//                ((DataTable)Session["myDatatable"]).Rows[e.Item.ItemIndex].Delete();
//                BindGrid();
//                txtProduct_Index.Focus();

//            }
//        }

//        private void bindProduct()
//        {
//            objFinalProductSelectionProperty.IsFinalProduct = true;
//            // objFinalProductSelectionProperty.SaleRepID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());
//            objFinalProductSelectionBLL = new Final_Product_Selection_BLL(objFinalProductSelectionProperty);

//            DataTable dt = new DataTable();

//            dt = objFinalProductSelectionBLL.ViewProduct();

//            if (dt.Rows.Count > 0)
//            {
//                ViewState["Dtproduct"] = dt;
//                cmbProduct.Items.Clear();
//                cmbProduct.Items.Add(new ListItem("Select Product", "-1"));
//                cmbProduct.DataSource = dt;
//                cmbProduct.DataTextField = "Product";
//                cmbProduct.DataValueField = "ID";
//                cmbProduct.DataBind();
//            }
//        }

//        protected void btndone_Click(object sender, EventArgs e)
//        {
//            Session.Remove("myDatatable");
//            Response.Redirect("CashMemoView.aspx");
//        }

//        protected void rptCashMemoDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
//        {
//            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
//            {
//                Label rptitemlblstocks = (Label)e.Item.FindControl("rptitemlblstocks");
//                if (txt_ProdctQuantity.Visible == true && rptitemlblstocks != null)
//                {
//                    rptitemlblstocks.Visible = true;
//                }
//                else if (rptitemlblstocks != null)
//                {
//                    rptitemlblstocks.Visible = false;
//                }
//            }
//            else
//            {
//                Label rptlblstocks = (Label)e.Item.FindControl("rptlblstocks");

//                if (txt_ProdctQuantity.Visible == true && rptlblstocks != null)
//                {
//                    rptlblstocks.Visible = true;
//                }
//                else if (rptlblstocks != null)
//                {
//                    rptlblstocks.Visible = false;
//                }
//            }
//        }

//        protected void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            int product_id = Convert.ToInt32(cmbProduct.SelectedValue.ToString());
//            txtProduct_Index.Text = product_id.ToString();
//            objPriceListMStProperty.Product_ID = product_id;
//            // objFinalProductSelectionProperty.SaleRepID = Convert.ToInt32(ddlSalesRep.SelectedValue.ToString());
//            objPriceListMstbll = new Price_List_Mst_BLL(objPriceListMStProperty);
//            DataTable dt = new DataTable();

//            dt = objPriceListMstbll.ViewAllProductsPrice();

//            if (dt.Rows.Count > 0)
//            {
//                foreach (DataRow row in dt.Rows)
//                {
//                    TextBoxrate.Text = row["PrimaryPrice"].ToString();
//                    //TextBox8.Text = row["Product_ID"].ToString();
//                }

//                //cmbProduct.DataBind();
//            }
//        }

//        protected void txt_ProdctQuantity_TextChanged1(object sender, EventArgs e)
//        {

//        }

//        protected void TextBoxrate_TextChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}