<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmOrder_TEMP.aspx.cs" Inherits="VloveImport.web.admin.pages.frmOrder_TEMP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../UserControls/ucEmail.ascx" TagName="ucEmail" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/ucImage.ascx" TagName="ucImage" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function CheckInputPercent(obj) {
            if (obj.value > 100) {
                obj.value = 0;
                alert("Can not fill more than 100%");
            }
        }

        function Fun_CalShopProduct_Detail() {
            return true;
        }

        function CheckInputDiscount(type) {
            //replace
            if (type == "1") //Serveice Charge
            {
                var txt_Service_Charge = document.getElementById('<%=txt_Service_Charge.ClientID%>').value.replace(",", "");
                var txtDiscountServiceCh = document.getElementById('<%=txtDiscountServiceCh.ClientID%>').value.replace(",", "");

                if (parseFloat(txtDiscountServiceCh) > parseFloat(txt_Service_Charge)) {
                    alert("Can not fill discount  more than the service charge.");
                    document.getElementById('<%=txtDiscountServiceCh.ClientID%>').value = "0";
                }
            }
            else if (type == "2") //Transport Customer Price
            { // 
                var txt_Transport_Cus_Price = document.getElementById('<%=txt_Transport_Cus_Price.ClientID%>').value.replace(",", "");
                var txtDiscountCus_TRANSPORT = document.getElementById('<%=txtDiscountCus_TRANSPORT.ClientID%>').value.replace(",", "");
                if (parseFloat(txtDiscountCus_TRANSPORT) > parseFloat(txt_Transport_Cus_Price)) {
                    alert("Can not fill discount  more than the transport customer price.");
                    document.getElementById('<%=txtDiscountCus_TRANSPORT.ClientID%>').value = "0";
                }
            }
    }

    //function addCommas(nStr) {
    //    nStr += '';
    //    x = nStr.split('.');
    //    x1 = x[0];
    //    x2 = x.length > 1 ? '.' + x[1] : '';
    //    var rgx = /(\d+)(\d{3})/;
    //    while (rgx.test(x1)) {
    //        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    //    }
    //    return x1 + x2;
    //}

    function addCommas(number) {
        var number = parseFloat(number);
        number = number.toFixed(2);
        var x = number.split('.');
        var x1 = x[0];
        var x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        return x1 + x2;
    }

    function CalPrice() {

        //Service_Charge Tab2
            var ServiceCh = parseFloat(document.getElementById('<%=txt_Service_Charge.ClientID%>').value.replace(",", ""));
        var ServiceCh_Dis = parseFloat(document.getElementById('<%=txtDiscountServiceCh.ClientID%>').value.replace(",", ""));
            var ServiceCh_Total = ServiceCh - ServiceCh_Dis;
            document.getElementById('<%=lbl_tb2_Service_Charge.ClientID%>').innerText = addCommas(ServiceCh_Total);
            //Order Discount
        var OrderDiscount = parseFloat(document.getElementById('<%=txt_Discount.ClientID%>').value.replace(",", ""));
            document.getElementById('<%=lbl_tb2_Discount.ClientID%>').innerText = addCommas(OrderDiscount);
            //Transport Price From Ch To Th
        var TranPriceCH_TO_TH_Percent = parseFloat(document.getElementById('<%=txtDiscountC_T_TRANSPORT.ClientID%>').value.replace(",", ""));
        var TranPriceCH_TO_TH = parseFloat(document.getElementById('<%=lbl_tb3_Total_Transport_CH_TO_TH.ClientID%>').innerText.replace(",", "").replace("(THB)", ""));
            var TranPriceCH_TO_TH_Dis = TranPriceCH_TO_TH * (TranPriceCH_TO_TH_Percent / 100);
            var TranPriceCH_TO_TH_Total = TranPriceCH_TO_TH - TranPriceCH_TO_TH_Dis;

            document.getElementById('<%=lbl_tb3_Total_Transport_CH_TO_TH_DISCOUNT.ClientID%>').innerText = addCommas(TranPriceCH_TO_TH_Dis);
            document.getElementById('<%=lbl_tb3_Total_Transport_CH_TO_TH_TOTAL.ClientID%>').innerText = addCommas(TranPriceCH_TO_TH_Total);
            //Transport Price From Shop To Customer
        var TranPriceShopToCus = parseFloat(document.getElementById('<%=txt_Transport_Cus_Price.ClientID%>').value.replace(",", ""));
        var TranPriceShopToCus_Dis = parseFloat(document.getElementById('<%=txtDiscountCus_TRANSPORT.ClientID%>').value.replace(",", ""));
            var TranPriceShopToCus_Total = TranPriceShopToCus - TranPriceShopToCus_Dis;

            document.getElementById('<%=lbl_tb3_Total_Transport_To_Customer_DISCOUNT.ClientID%>').innerText = addCommas(TranPriceShopToCus);
            document.getElementById('<%=lbl_tb3_Total_Transport_To_Customer_DISCOUNT.ClientID%>').innerText = addCommas(TranPriceShopToCus_Dis);
            document.getElementById('<%=lbl_tb3_Total_Transport_To_Customer_TOTAL.ClientID%>').innerText = addCommas(TranPriceShopToCus_Total);
            //Service_Charge Tab4
            document.getElementById('<%=lbl_tb3_Service_Charge.ClientID%>').innerText = addCommas(ServiceCh);
            document.getElementById('<%=lbl_tb3_Service_Charge_DISCOUNT.ClientID%>').innerText = addCommas(ServiceCh_Dis);
            document.getElementById('<%=lbl_tb3_Service_Charge_TOTAL.ClientID%>').innerText = addCommas(ServiceCh_Total);
            //Transport China Price
        var TranPriceCH = parseFloat(document.getElementById('<%=lbl_tb3_Total_Transport_China_Price.ClientID%>').innerText.replace(",", "").replace("(THB)", ""));
            //Total Transport
            var TotalTranSport = TranPriceCH + TranPriceCH_TO_TH + TranPriceShopToCus + ServiceCh;
            var TotalTranSport_Dis = TranPriceCH_TO_TH_Dis + TranPriceShopToCus_Dis + ServiceCh_Dis;
            var TotalTranSport_Total = TranPriceCH + TranPriceCH_TO_TH_Total + TranPriceShopToCus_Total + ServiceCh_Total;

            document.getElementById('<%=lbl_tb3_Total_Transport.ClientID%>').innerText = addCommas(TotalTranSport);
            document.getElementById('<%=lbl_tb3_Total_Transport_DISCOUNT.ClientID%>').innerText = addCommas(TotalTranSport_Dis);
            document.getElementById('<%=lbl_tb3_Total_Transport_TOTAL.ClientID%>').innerText = addCommas(TotalTranSport_Total);
            document.getElementById('<%=lbl_tb2_Total_Transport_Active_Price.ClientID%>').innerText = addCommas(TotalTranSport_Total); 

            //Tab 2 Header Cal
            var ProductPrice = parseFloat(document.getElementById('<%=lbl_tb2_Total_Prodcut_Active_Price.ClientID%>').innerText.replace(",", "").replace("(THB)", ""));
            var TotalInCome = parseFloat(document.getElementById('<%=lbl_tb2_Total_Income.ClientID%>').innerText.replace(",", "").replace("(THB)", ""));

            var Actually_Amount = ProductPrice + TotalTranSport_Total - OrderDiscount;
            
            var OrderBalance = (Actually_Amount) - TotalInCome; //ChargeTranSportPrice

            //alert(Actually_Amount + ":::::" + ChargeTranSportPrice + ":::-::" + TotalInCome);
            document.getElementById('<%=lbl_tb2_Actually_Amounte.ClientID%>').innerText = addCommas(Actually_Amount);

        if (OrderBalance > 0) {
            //alert(OrderBalance);
                document.getElementById('<%=lbl_tb2_Total_Refund.ClientID%>').innerText = "0.00";

                var Order_status = parseInt('<%=ddl_ViewDetail_ORDER_STATUS.SelectedValue%>');
                var TranSport_Percent = parseFloat('<%=lbl_tb1_TranSport_Percent.Text.Replace("%","").Trim()%>');
                var ChargeTranSportPrice = 0;
                if (Order_status < 7) {
                    ChargeTranSportPrice = parseFloat(ProductPrice * (TranSport_Percent / 100.00));
                }

                document.getElementById('<%=lbl_tb2_Additional_Amount.ClientID%>').innerText = addCommas(OrderBalance + ChargeTranSportPrice);
            }
            else if (OrderBalance < 0) {
                //alert(OrderBalance);
                document.getElementById('<%=lbl_tb2_Total_Refund.ClientID%>').innerText = addCommas((OrderBalance * -1));
                document.getElementById('<%=lbl_tb2_Additional_Amount.ClientID%>').innerText = "0.00";
            }
            else {
                document.getElementById('<%=lbl_tb2_Total_Refund.ClientID%>').innerText = "0.00";
                document.getElementById('<%=lbl_tb2_Additional_Amount.ClientID%>').innerText = "0.00";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-top: 10px;">
                <h2 style="color: #318DBF;">Order Managemaent</h2>
                <hr style="width: 100%; text-align: left; margin-top: -15px; background-color: #D1DBE0; height: 5px; color: #D1DBE0; border: 0;" />
            </div>
            
            <h3>ORDER DETAIL :
                <asp:Label ID="lbl_header_detail" Font-Size="Large" runat="server" Text="" ForeColor="RED"></asp:Label></h3>
            <hr style="width: 100%; text-align: left; background-color: #8db0ef; height: 5px; color: #8db0ef; border: 0;" />
            <div style="min-height: 550px;">
                <asp:TabContainer ID="TabORDER" runat="server" Width="100%" ActiveTabIndex="0">
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Order Detail">
                        <ContentTemplate>
                            <fieldset>
                                <table>
                                    <tr>
                                        <td class="width15">Order code : </td>
                                        <td class="width30">
                                            <asp:Label ID="lbl_tb1_order_code" runat="server"></asp:Label>
                                        </td>
                                        <td class="width20">Transport Method China To Thai : </td>
                                        <td class="width35">
                                            <asp:Label ID="lbl_tb1_TranSport_CH_TO_TH" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Order date :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Order_Date" runat="server"></asp:Label>
                                        </td>
                                        <td>Transport Method To Customer :
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_TranSport_TO_Customer" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Order Status :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Order_status" runat="server"></asp:Label>
                                        </td>
                                        <td>Transport Status : </td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_TranSport_Status" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Exchange Rate :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Exchange_Rate" runat="server"></asp:Label>
                                        </td>
                                        <td>Transport Percent :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_TranSport_Percent" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Employee Name :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Emp_Name" runat="server"></asp:Label>
                                        </td>
                                        <td>Employee Update Date :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Emp_Update_Date" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Emploayee Remark :</td>
                                        <td colspan="3">
                                            <asp:Label ID="lbl_tb1_Emp_Remark" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            <fieldset>
                                <table>
                                    <tr>
                                        <td class="width15">Customer Code :</td>
                                        <td class="width30">
                                            <asp:Label ID="lbl_tb1_Customer_Code" runat="server"></asp:Label>
                                        </td>
                                        <td class="width20">Customer Name :</td>
                                        <td class="width35">
                                            <asp:Label ID="lbl_tb1_Customer_Name" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Customer Email :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Customer_Email" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:ImageButton ID="imgbtn_SendEmail" runat="server" ImageUrl="~/img/icon/sendemail.png" ToolTip="Send Email To Customer" Width="25px" Height="25px" OnClick="imgbtn_SendEmail_Click" />
                                        </td>
                                        <td>Customer Telephone :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Customer_Telephone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Customer Balance :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Customer_Balance" runat="server"></asp:Label>
                                        </td>
                                        <td>Customer Point :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_Customer_Point" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>VIP Type :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_VIP_STATUS" runat="server"></asp:Label>
                                        </td>
                                        <td>VIP Date :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb1_VIP_DATE" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Customer Address :</td>
                                        <td colspan="3">
                                            <asp:Label ID="lbl_tb1_Customer_Address" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Customer Remark</td>
                                        <td colspan="3">
                                            <asp:Label ID="lbl_tb1_Customer_Remark" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Payment Detail">
                        <ContentTemplate>
                            <fieldset>
                                <table>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gv_detail_transaction" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="No." DataField="ROW_INDEX">
                                                        <HeaderStyle CssClass="width5" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Transaction Type" DataField="TRAN_TYPE_TEXT">
                                                        <HeaderStyle CssClass="width15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Transaction Date" DataField="TRAN_DATE_TEXT">
                                                        <HeaderStyle CssClass="width15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Transaction  Amount" DataField="TRAN_AMOUNT" DataFormatString="{0:#,##0.00}">
                                                        <HeaderStyle CssClass="width15" />
                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Transaction Detail" DataField="TRAN_DETAIL">
                                                        <HeaderStyle CssClass="width25" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HtmlEncode="False" HeaderText="Transaction<br>Employee Detail" DataField="EMP_REMARK">
                                                        <HeaderStyle CssClass="width25" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="width15">Total Income : </td>
                                        <td class="width30">
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <asp:Label ID="lbl_tb2_Total_Income" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="width50">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="width20">Total Refund : </td>
                                        <td class="width35">
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <asp:Label ID="lbl_tb2_Total_Refund" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="width50 ItemStyle-right"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>Additional Amount : </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <asp:Label ID="lbl_tb2_Additional_Amount" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="width50 ItemStyle-right"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <hr style="width: 100%; text-align: left; background-color: #b6b2b2; height: 2px; color: #8db0ef; border: 0;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Total Product Price :</td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <asp:Label ID="lbl_tb2_Total_Prodcut_Price" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="width50 ItemStyle-right"></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>Total Product Active Price : </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <asp:Label ID="lbl_tb2_Total_Prodcut_Active_Price" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="width50 ItemStyle-right"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>Total Transport Active Price :</td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <asp:Label ID="lbl_tb2_Total_Transport_Active_Price" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="width50 ItemStyle-right"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>Service Charge :</td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <u>
                                                            <asp:Label ID="lbl_tb2_Service_Charge" runat="server"></asp:Label>
                                                        </u>
                                                    </td>
                                                    <td class="width50 ItemStyle-right"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>Discount :</td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <u>
                                                            <asp:Label ID="lbl_tb2_Discount" runat="server"></asp:Label>
                                                        </u>
                                                    </td>
                                                    <td class="width50 ItemStyle-right"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>Actually Amount :</td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td class="width50 ItemStyle-right">
                                                        <span class="doubleUnderline">
                                                            <asp:Label ID="lbl_tb2_Actually_Amounte" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="width50 ItemStyle-right"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>

                            <fieldset>
                                <table>
                                    <tr>
                                        <td width="25%" class="auto-style1">Order Status :</td>
                                        <td width="75%" colspan="3" class="auto-style1">
                                            <asp:DropDownList Width="300px" ID="ddl_ViewDetail_ORDER_STATUS" runat="server" AutoPostBack="True" onChange ="CalPrice();" OnSelectedIndexChanged="ddl_ViewDetail_ORDER_STATUS_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Transport Status :</td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddl_ViewDetail_TRANSPORT_STATUS" runat="server" Width="300px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Remark : </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_Update_STS_EMP_Remark" TextMode="MultiLine" Width="300px" Height="50px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trTranCusPrice1" runat="server" visible="False">
                                        <td runat="server">Transport Detail : </td>
                                        <td colspan="3" runat="server">
                                            <asp:TextBox ID="txt_Transport_Cus_Detail" TextMode="MultiLine" Width="300px" Height="50px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trTranCusPrice4" runat="server">
                                        <td class="width20" id="Td7" runat="server">Total Transport China To Thai :
                                        </td>
                                        <td class="width30" id="Td8" runat="server">
                                            <asp:Label ID="lbl_tb2_Total_Transport_CH_TO_TH" runat="server"></asp:Label>
                                        </td>
                                        <td class="width20" id="Td9" runat="server">Discount :</td>
                                        <td class="width30" id="Td10" runat="server">
                                            <asp:TextBox ID="txtDiscountC_T_TRANSPORT" runat="server" MaxLength="3" Width="200px" onKeyUp="CheckInputPercent(this); CalPrice();"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtDiscountC_T_TRANSPORT_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtDiscountC_T_TRANSPORT" ValidChars="0123456789">
                                            </asp:FilteredTextBoxExtender>
                                            &nbsp;%
                                        </td>
                                    </tr>
                                    <tr id="trTranCusPrice" runat="server">
                                        <td id="Td1" runat="server">Transport Customer Price :</td>
                                        <td id="Td2" runat="server">
                                            <asp:TextBox ID="txt_Transport_Cus_Price" runat="server" Width="200px" onKeyUp="CheckInputDiscount(2); CalPrice();"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_Transport_Cus_Price" ID="txt_Transport_Cus_Price_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td id="Td11" runat="server">Discount :</td>
                                        <td id="Td12" runat="server">
                                            <asp:TextBox ID="txtDiscountCus_TRANSPORT" Width="200px" runat="server" onKeyUp="CheckInputDiscount(2); CalPrice();"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtDiscountCus_TRANSPORT_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtDiscountCus_TRANSPORT" ValidChars="0123456789.">
                                            </asp:FilteredTextBoxExtender>
                                            &nbsp;Bath
                                        </td>
                                    </tr>
                                    <tr id="trTranCusPrice2" runat="server">
                                        <td id="Td3" runat="server">Service Charge :</td>
                                        <td id="Td4" runat="server">
                                            <asp:TextBox ID="txt_Service_Charge" runat="server" Width="200px" onKeyUp="CheckInputDiscount(1); CalPrice();"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_Service_Charge" ID="txt_Service_Charge_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td id="Td13" runat="server">Discount :</td>
                                        <td id="Td14" runat="server">
                                            <asp:TextBox ID="txtDiscountServiceCh" Width="200px" runat="server" onKeyUp="CheckInputDiscount(1); CalPrice();"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtDiscountServiceCh_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtDiscountServiceCh" ValidChars="0123456789.">
                                            </asp:FilteredTextBoxExtender>
                                            &nbsp;Bath
                                        </td>
                                    </tr>
                                    <tr id="trTranCusPrice3" runat="server">
                                        <td id="Td5" runat="server">Discount :</td>
                                        <td id="Td6" runat="server">
                                            <asp:TextBox ID="txt_Discount" runat="server" Width="200px" onKeyUp ="CalPrice();"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_Discount" ID="FilteredTextBoxExtender1" ValidChars="1234567890.,">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td id="Td15" runat="server"></td>
                                        <td id="Td16" runat="server"></td>
                                    </tr>
                                    <tr id="tr_tb2_chk_email" runat="server" visible="False">
                                        <td runat="server"></td>
                                        <td runat="server">
                                            <table>
                                                <tr>
                                                    <td class="width15">
                                                        <asp:CheckBox ID="tb_2_chk_email" runat="server" />
                                                    </td>
                                                    <td class="ItemStyle-left width85">Send Email TO Customer
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btn_detail_update" runat="server" Text="Update Order" CssClass="btnSave" OnClick="btn_detail_update_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>

                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Product Detail">
                        <ContentTemplate>
                            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" Width="100%"
                                DataKeyNames="ORDER_SHOP_ID,SHOP_ORDER_ID,SHOPNAME,TRACKING_NO,WEIGHT,SIZE,WEIGHT_PRICE,SIZE_PRICE,TRANSPORT_CHINA_PRICE,TRANSPORT_THAI_PRICE,OD_ID,OD_AMOUNT,OD_AMOUNT_ACTIVE,OD_PRICE,OD_SIZE,OD_COLOR,OD_REMARK,OD_URL,OD_PICURL,OD_STATUS,ROW_INDEX_SHOP,TOTAL_PROD_PRICE,TOTAL_PROD_PRICE_ACTIVE,ROW_INDEX,ROW_RANK_PROD,PRODUCT_TYPE,OD_PRICE_ACTIVE,CAL_TRANSPORT_SHOP_RATE,SHOP_REMARK" OnRowDataBound="gv_detail_RowDataBound" OnRowCreated="gv_detail_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ROW_INDEX") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowIndex" runat="server" Text='<%# Bind("ROW_INDEX") %>'></asp:Label>&nbsp;&nbsp;
                                <asp:ImageButton ID="imgbtn_popup_shopdetail" runat="server" ImageUrl="~/img/icon/View.png" Width="20px" Height="20px" OnClick="imgbtn_popup_shopdetail_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="width5" />
                                        <ItemStyle CssClass="ItemStyle-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product detail">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("OD_ITEMNAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_gv_prod_detail_Item" runat="server" Text='<%# Bind("OD_ITEMNAME") %>'></asp:Label>
                                            <asp:ImageButton ID="imgbtn_gv_prod_detail_upload_pic" runat="server" Visible="false" OnClick="imgbtn_gv_prod_detail_upload_pic_Click" />
                                            <br />
                                            <br />
                                            <asp:Label ID="lbl_gv_prod_detail_UploadText" runat="server" Font-Bold="true" Text="Upload Receipt File :" Visible="false"></asp:Label>
                                            <asp:ImageButton ID="imgbtn_gv_prod_detail_upload" runat="server" OnClick="imgbtn_gv_prod_detail_upload_Click" Width="16px" Visible="false" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="width25" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Picture">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("OD_REMARK") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtn_gv_prod_pic" runat="server" Width="50px" Height="100px" OnClick="imgbtn_gv_prod_pic_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="width10" Width="60px" />
                                        <ItemStyle CssClass="ItemStyle-center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OD_PRICE" DataFormatString="{0:#,##0.00}" HtmlEncode="False" HeaderText="Price">
                                        <HeaderStyle CssClass="width10" />
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OD_AMOUNT" HeaderText="Order amount">
                                        <HeaderStyle CssClass="width10" />
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOTAL_PROD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Total price">
                                        <HeaderStyle CssClass="width10" />
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Price Active">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:MultiView ID="MultiView_Price_Active" runat="server" ActiveViewIndex="0">
                                                <asp:View ID="View_Price_Active1" runat="server">
                                                    <asp:Label ID="lbl_OD_Price_ACTIVE" runat="server" Text='<%# Bind("OD_PRICE_ACTIVE") %>'></asp:Label>
                                                </asp:View>
                                                <asp:View ID="View_Price_Active2" runat="server">
                                                    <asp:TextBox ID="txt_OD_Price_ACTIVE" runat="server" AutoCompleteType="Disabled" Text='<%# Bind("OD_PRICE_ACTIVE") %>' Width="90%"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_OD_Price_ACTIVE" ID="txt_OD_Price_ACTIVE_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                                                    </asp:FilteredTextBoxExtender>
                                                </asp:View>
                                            </asp:MultiView>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="width10" />
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order active<br>amount">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                                                <asp:View ID="View3" runat="server">
                                                    <asp:Label ID="lbl_OD_AMOUNT_ACTIVE" runat="server" Text='<%# Bind("OD_AMOUNT_ACTIVE") %>'></asp:Label>
                                                </asp:View>
                                                <asp:View ID="View4" runat="server">
                                                    <asp:TextBox ID="txt_OD_AMOUNT_ACTIVE" runat="server" AutoCompleteType="Disabled" Text='<%# Bind("OD_AMOUNT_ACTIVE") %>' Width="90%"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_OD_AMOUNT_ACTIVE" ID="txt_OD_AMOUNT_ACTIVE_FilteredTextBoxExtender1" ValidChars="1234567890,">
                                                    </asp:FilteredTextBoxExtender>
                                                </asp:View>
                                            </asp:MultiView>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="width10" />
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TOTAL_PROD_PRICE_ACTIVE" DataFormatString="{0:#,##0.00}" HtmlEncode="False" HeaderText="Total active<br>price">
                                        <HeaderStyle CssClass="width10" />
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Tools">
                                        <HeaderStyle CssClass="width10" />
                                        <ItemStyle CssClass="ItemStyle-center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                                                <asp:View ID="View5" runat="server">
                                                    <asp:ImageButton ID="imgbtn_Editprod_amount" runat="server" ImageUrl="~/img/icon/b_edit.png" Width="15px" Height="15px" OnClick="imgbtn_Editprod_amount_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="imgbtn_Send_Product" ToolTip="Remark Flag Send Product" AlternateText="Remark Flag Send Product" runat="server" Height="25px" ImageUrl="~/img/icon/icon_transport.png" OnClick="imgbtn_Send_Product_Click" Width="25px" />
                                                </asp:View>
                                                <asp:View ID="View6" runat="server">
                                                    <asp:ImageButton ID="imgbtn_Updateprod_amount" runat="server" ImageUrl="~/img/icon/check-icon.png" Width="15px" Height="15px" OnClick="imgbtn_Updateprod_amount_Click" />
                                                    &nbsp;&nbsp;
                                        <asp:ImageButton ID="imgbtn_Cancelprod_amount" runat="server" ImageUrl="~/img/icon/Close-2-icon.png" Width="15px" Height="15px" OnClick="imgbtn_Cancelprod_amount_Click" />
                                                </asp:View>
                                            </asp:MultiView>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Transport Detail">
                        <ContentTemplate>
                            <fieldset>
                                <table>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gv_detail_shopname" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ORDER_CURRENCY,ORDER_TRANS_RATE,TRANSPORT_DATE,TRANSPORT_DETAIL,TRANSPORT_CUSTOMER_PRICE,ORDER_SHOP_ID,SHOPNAME,SHOP_ORDER_ID,TRACKING_NO,WEIGHT,SIZE,TRANSPORT_CHINA_PRICE,TRANSPORT_THAI_PRICE,PRODUCT_TYPE,CAL_TRANSPORT_SHOP_RATE,EMP_USER,TRAN_DATE_TEXT,TRANSPORT_CHINA_TEXT,TRANSPORT_THAI_TEXT,TRANSPORT_STATUS_TEXT,SUM_TRANSPORT_CHINA_PRICE,SUM_TRANSPORT_THAI_PRICE,SHOP_REMARK" OnRowDataBound="gv_detail_shopname_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField HeaderText="No." DataField="ROW_INDEX">
                                                        <HeaderStyle CssClass="width5" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Shop name" DataField="SHOPNAME">
                                                        <HeaderStyle CssClass="width25" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Shop order id" DataField="SHOP_ORDER_ID">
                                                        <HeaderStyle CssClass="width10" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Size&lt;br&gt;(CM)" HtmlEncode="False" DataField="SIZE">
                                                        <HeaderStyle CssClass="width10" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Weight&lt;br&gt;(KG)" HtmlEncode="False" DataField="WEIGHT" DataFormatString="{0:#,##0.00}">
                                                        <HeaderStyle CssClass="width10" />
                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Transport China&lt;br&gt;Price" HtmlEncode="False" DataField="TRANSPORT_CHINA_PRICE" DataFormatString="{0:#,##0.00}">
                                                        <HeaderStyle CssClass="width10" />
                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Product Type" DataField="PRODUCT_TYPE_TEXT">
                                                        <HeaderStyle CssClass="width15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Transport China To Thai (THB)" DataField="TRANSPORT_THAI_PRICE" DataFormatString="{0:#,##0.00}">
                                                        <HeaderStyle CssClass="width10" />
                                                        <ItemStyle CssClass="ItemStyle-right" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Tools">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtn_tab3_popup_shopdetail" runat="server" ImageUrl="~/img/icon/View.png" Width="20px" Height="20px" OnClick="imgbtn_tab3_popup_shopdetail_Click" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="width5" />
                                                        <ItemStyle CssClass="ItemStyle-center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="width15">Transport Method China To Thai :</td>
                                        <td class="width30">
                                            <asp:Label ID="lbl_tb3_Transport_Method_CH_TO_TH" runat="server"></asp:Label>
                                        </td>
                                        <td class="width20">Transport Method To Customer :</td>
                                        <td class="width35">
                                            <asp:Label ID="lbl_tb3_Transport_Method_To_Customer" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>Transport To Customer Detail : </td>
                                        <td>
                                            <asp:Label ID="lbl_tb3_Transport_To_Customer_Detail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>Transport To Customer Date :</td>
                                        <td>
                                            <asp:Label ID="lbl_tb3_Transport_To_Customer_Date" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            <fieldset>
                                <table>
                                    <tr>
                                        <td class="width20"></td>
                                        <td class="width15 ItemStyle-center">
                                            <b>Full Price</b>
                                        </td>
                                        <td class="width15 ItemStyle-center">
                                            <b>Discount</b>
                                        </td>
                                        <td class="width15 ItemStyle-center">
                                            <b>Total Price</b>
                                        </td>
                                        <td class="width35"></td>
                                    </tr>
                                    <tr>
                                        <td>Total Transport China Price :</td>
                                        <td class="ItemStyle-right">
                                            <asp:Label ID="lbl_tb3_Total_Transport_China_Price" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_tb3_Total_Transport_China_Price_CNY" runat="server"></asp:Label>
                                        </td>
                                        <td class="ItemStyle-right">=&nbsp;<asp:Label ID="lbl_tb3_Total_Transport_China_Price_TOTAL" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Total Transport China To Thai :</td>
                                        <td class="ItemStyle-right">
                                            <asp:Label ID="lbl_tb3_Total_Transport_CH_TO_TH" runat="server"></asp:Label>
                                        </td>
                                        <td class="width15 ItemStyle-right">
                                            <asp:Label ID="lbl_tb3_Total_Transport_CH_TO_TH_DISCOUNT" runat="server"></asp:Label>
                                        </td>
                                        <td class="width15 ItemStyle-right">=&nbsp;<asp:Label ID="lbl_tb3_Total_Transport_CH_TO_TH_TOTAL" runat="server"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Total Transport To Customer :</td>
                                        <td class="ItemStyle-right">
                                            <asp:Label ID="lbl_tb3_Total_Transport_To_Customer" runat="server"></asp:Label>
                                        </td>
                                        <td class="width15 ItemStyle-right">
                                            <asp:Label ID="lbl_tb3_Total_Transport_To_Customer_DISCOUNT" runat="server"></asp:Label>
                                        </td>
                                        <td class="width15 ItemStyle-right">=&nbsp;<asp:Label ID="lbl_tb3_Total_Transport_To_Customer_TOTAL" runat="server"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Service Charge :</td>
                                        <td class="ItemStyle-right">
                                            <u>
                                                <asp:Label ID="lbl_tb3_Service_Charge" runat="server"></asp:Label>
                                            </u>
                                        </td>
                                        <td class="width15 ItemStyle-right">
                                            <u>
                                                <asp:Label ID="lbl_tb3_Service_Charge_DISCOUNT" runat="server"></asp:Label>
                                            </u>
                                        </td>
                                        <td class="width15 ItemStyle-right">=&nbsp;
                                            <u>
                                                <asp:Label ID="lbl_tb3_Service_Charge_TOTAL" runat="server"></asp:Label>
                                            </u>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Total Transport Price :</td>
                                        <td class="ItemStyle-right">
                                            <span class="doubleUnderline">
                                                <asp:Label ID="lbl_tb3_Total_Transport" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td class="width15 ItemStyle-right">
                                            <span class="doubleUnderline">
                                                <asp:Label ID="lbl_tb3_Total_Transport_DISCOUNT" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td class="width15 ItemStyle-right">=&nbsp;
                                            <span class="doubleUnderline">
                                                <asp:Label ID="lbl_tb3_Total_Transport_TOTAL" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </fieldset>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </div>
            <br />
            <table class="width100">
                <tr>
                    <td class="ItemStyle-center">
                        <asp:Button ID="btnPrint" runat="server" Text="Print Invoice" CssClass=" btnSave" OnClick="btnPrint_Click"></asp:Button>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCancleOrder" runat="server" Text="Cancle Order" CssClass=" btnCancel" OnClick="btnCancleOrder_Click"></asp:Button>
                        &nbsp;&nbsp;
            <asp:Button ID="btnback" runat="server" Text="Back To Order List" CssClass="btnCancel" OnClick="btnback_Click"></asp:Button>
                    </td>
                </tr>
            </table>


            <asp:ModalPopupExtender ID="Modal_ShopDetail" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel5" TargetControlID="lbl_modal_ShopDetail">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel5" Height="420px" Width="800px" runat="server" Style="display: none;">
                <%--Style="display: none;"--%>
                <table width="800px" style="border-collapse: separate; border-spacing: 0px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                        <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                            <div style="margin-left: -40px; margin-top: 10px;">
                                <asp:Label ID="lbl_modal_ShopDetail" runat="server" Text="Shop Detail"></asp:Label>
                            </div>
                        </td>
                        <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                            <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td style="text-align: center; padding: 0px 0px;" colspan="3">
                            <center>
                <asp:Panel Width="96%" Height="320px" ID="Panel6" runat="server" BackColor="#FFFFFF">
                        <br />
                        <table>
                            <tr>
                                <td>
                                    Shop name :
                                </td>
                                <td colspan ="3">
                                    <asp:Label ID="lbl_sd_shopname" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tracking no :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_sd_trackingno" runat="server"></asp:TextBox>
                                </td>
                                <td>Shop order id :</td>
                                <td>
                                    <asp:TextBox ID="txt_sd_shoporder_id" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Size : <span style ="color:red">Ex.15*15*15 (CM)</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_sd_size" runat="server" onblur ="Fun_CalShopProduct_Detail();"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_sd_size" ID="txt_sd_size_FilteredTextBoxExtender1" ValidChars="1234567890*.">
                                </asp:FilteredTextBoxExtender>
                                </td>
                                <td>Weight : <span style ="color:red">(KG)</span></td>
                                <td>
                                    <asp:TextBox ID="txt_sd_weight" runat="server" onblur ="Fun_CalShopProduct_Detail();"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_sd_weight" ID="txt_sd_weight_FilteredTextBoxExtender1" ValidChars="1234567890.">
                                </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
<%--                                     <tr>
                                <td>Size price :</td>
                                <td>
                                    <asp:TextBox ID="txt_sd_size_price" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    Weight price :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_sd_weight_rpice" runat="server"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    Transport china price : <span style ="color:red">(CNY)</span>
                                </td>
                                <td>
                                <asp:TextBox ID="txt_sd_tran_china_price" runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_sd_tran_china_price" ID="txt_sd_tran_china_price_FilteredTextBoxExtender" ValidChars="1234567890.,">
                                </asp:FilteredTextBoxExtender>
                                </td>
                                <td></td>
                                <td>
                                             
                                </td>
                            </tr>
                            <tr>
                                <td>Transport Method :</td>
                                <td>
                                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex ="0">
                                        <asp:View ID="View1" runat="server">
                                            <asp:DropDownList ID="ddl_TRANS_METHOD_AirPlane" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_TRANS_METHOD_AirPlane_SelectedIndexChanged">
<%--                                                <asp:ListItem Value="-1">Please Select</asp:ListItem>
                                                <asp:ListItem Value="1">Product General</asp:ListItem>
                                                <asp:ListItem Value="2">Product Soft</asp:ListItem>
                                                <asp:ListItem Value="3">Product Brand</asp:ListItem>
                                                <asp:ListItem Value="4">Other</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </asp:View>
                                        <asp:View ID="View2" runat="server">
                                            <asp:DropDownList ID="ddl_TRANS_METHOD_OTHER" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_TRANS_METHOD_OTHER_SelectedIndexChanged">
<%--                                                <asp:ListItem Value="-1">Please Select</asp:ListItem>
                                                <asp:ListItem Value="1">Product Dress Grneral</asp:ListItem>
                                                <asp:ListItem Value="2">Product Grneral</asp:ListItem>
                                                <asp:ListItem Value="3">Product Cal Cubi</asp:ListItem>
                                                <asp:ListItem Value="4">Product Brand</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                                <td>Transport thai price :</td>
                                <td>
                                    <asp:TextBox ID="txt_sd_tran_thai_price" runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_sd_tran_thai_price" ID="txt_sd_tran_thai_price_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                                </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>Remark :</td>
                                <td colspan ="3">
                                    <asp:TextBox ID="txt_sd_tran_remark" runat="server" TextMode ="MultiLine" Height ="80px" Width ="98%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="4" class ="ItemStyle-center">
                                    <asp:Button ID="btnUpdateShopDetail" runat="server" Text="Update" CssClass="btnSave" OnClick="btnUpdateShopDetail_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>                  
                </asp:Panel>
            </center>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:ModalPopupExtender ID="MadoalPop_Email" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel1" TargetControlID="lbl_modal_email">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" Height="520" Width="800px" runat="server" Style="display: none;">
                <%--Style="display: none;"--%>
                <table width="800px" style="border-collapse: separate; border-spacing: 0px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                        <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                            <div style="margin-left: -40px; margin-top: 10px;">
                                <asp:Label ID="lbl_modal_email" runat="server" Text="Send Email"></asp:Label>
                            </div>
                        </td>
                        <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                            <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td style="text-align: center; padding: 0px 0px;" colspan="3">
                            <center>
                <asp:Panel Width="96%" Height="420px" ID="Panel2" runat="server" BackColor="#FFFFFF">
                        <br />
                        <uc1:ucEmail ID="ucEmail1" runat="server" />                 
                </asp:Panel>
            </center>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:ModalPopupExtender ID="ModalViewPic" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panl_ViewPic" TargetControlID="lbl_modal_ViewPic">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panl_ViewPic" Height="600px" Width="900px" runat="server" Style="display: none;">
                <%--Style="display: none;"--%>
                <table width="800px" style="border-collapse: separate; border-spacing: 0px; height: 600px;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                        <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                            <div style="margin-left: -40px; margin-top: 10px;">
                                <asp:Label ID="lbl_modal_ViewPic" runat="server" Text="Image"></asp:Label>
                            </div>
                        </td>
                        <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                            <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td style="text-align: center; padding: 0px 0px;" colspan="3">
                            <center>
                    <asp:Panel Width="96%" Height="580px" ID="Panel4" runat="server" BackColor="#FFFFFF">
                        <br />
                            <uc2:ucImage ID="ucImage" runat="server" />                            
                    </asp:Panel>
                </center>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:ModalPopupExtender ID="Modal_Upload" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel_Upload" TargetControlID="lbl_modal_Upload">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel_Upload" Height="200px" Width="900px" runat="server" Style="display: none;">
                <%--Style="display: none;"--%>
                <table width="800px" style="border-collapse: separate; border-spacing: 0px; height: 200px;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
                        <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                            <div style="margin-left: -40px; margin-top: 10px;">
                                <asp:Label ID="lbl_modal_Upload" runat="server" Text="UploadFile Image"></asp:Label>
                            </div>
                        </td>
                        <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                            <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                            </div>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td style="text-align: center; padding: 0px 0px;" colspan="3">
                            <center>
                    <asp:Panel Width="96%" Height="180px" ID="Panel7" runat="server" BackColor="#FFFFFF">
                        <br />
                            <fieldset style ="width:95%;">
                                <legend>
                                    Upload Receipt File
                                </legend>
                                <table>
                                    <tr>
                                        <td class ="width15">Choose File :</td>
                                        <td class ="width85">
                                            <asp:FileUpload ID="FL_UPLOAD_RECEIPT" runat="server"></asp:FileUpload>
                                            <br />
                                            <span style ="color:red;">
                                                File type is only png,jpg,gif
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass =" btnSave" OnClick="btnUpload_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>                           
                    </asp:Panel>
                </center>
                        </td>
                    </tr>
                    <tr style="background-color: #CFCDCD;">
                        <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
                    </tr>
                </table>
            </asp:Panel>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>
    </asp:UpdatePanel>




</asp:Content>

