<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccFuncTopup.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccFuncTopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<table width ="100%">
    <tr>
        <td colspan ="2"><b>เติมเงิน</b></td>
    </tr>
    <tr>
        <td colspan ="2">
            <b>
                <span style ="color:red;">
                    เติมเงิน : เป็นการเติมเงินเข้าระบบเท่านั้น ไม่ได้มีการตัดจ่ายบิลใดๆ หากลูกค้าต้องการชำระบิล กรุณากดเมนู “ชำระเงิน” ที่หน้ารายการสั่งซื้อคะ
                    <br /><br />
                    การชำระเงิน : เป็นการเลือกชำระเงินในบิลนั้นๆ ระบบจะทำการสั่งซื้อให้หลังจากได้รับยืนยันการชำระบิลจากลูกค้า
                </span>
            </b>
        </td>
    </tr>
    <tr>
        <td colspan ="2">
            วันที่: <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td width ="10%"></td>
        <td width ="90%">
            <b>ประวัติการชำระเงิน</b>
            <div style = "border:2px solid #959595; background-color:#F5F5F5; height:50px; vertical-align :middle; width:60%; height:120px;">
                <table>
                    <tr height = "120px">
                        <td width ="50%">ยอดเงินคงเหลือ</td>
                        <td style ="vertical-align:top;text-align:right;" width ="50%">
                            <hr style="width:100%; text-align:left; background-color :black; height:2px; color: black; border :0;"/>
                            0 THB <br />
                            0 THB <br />
                            <hr style="width:100%; text-align:left; background-color :black; height:2px; color: black; border :0;"/>
                            0 THB
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div style = "border:2px solid #959595; background-color:#F5F5F5; height:50px; vertical-align :middle; width:60%; height:70px;">
                <br />
                1.เลือกธนาคารที่ท่านสะดวกในการชำระเงิน<br />
                2.ระบุวิธีการชำระเงิน และจำนวนเงินที่จะชำระ หลังจากนั้น ระบุวิธีการแจ้งการชำระเงิน
            </div>
            <br />
            <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; height:50px; vertical-align :middle; width:30%; height:50px;">
                <br />
                <div style ="margin-left:10px;">
                    <b>เลือก I LOVE IMPORT ธนาคาร</b>
                </div>
            </div>
            <asp:RadioButtonList ID="rbList1_bank_list" DataTextField = "BANK_SHOP_ACCOUNT_NO" DataValueField = "BANK_SHOP_ID" runat="server"></asp:RadioButtonList>
            <br />
            <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; height:50px; vertical-align :middle; width:30%; height:50px;">
                <br />
                <div style ="margin-left:10px;">
                    <b>หลักฐานการชำระเงิน</b>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <b>* จำนวนเงิน</b><br />
            <asp:TextBox ID="txt_tranfer_amount" runat="server" Width ="400px" ></asp:TextBox>
            <%--<hr style="width:100%; text-align:left; background-color :#DDDDDD; height:2px; color: #DDDDDD; border :0;"/>--%>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
                วัน ที่โอนเงิน 
                <span style ="color:red;">*</span><br />
                <asp:TextBox ID="TextBox1" runat="server" Width ="400px" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            เวลา ที่โอน <span style ="color:red;">*</span><br />
            <asp:DropDownList ID="ddlH" DataTextField ="PAYMENT_TIME" DataValueField ="PAYMENT_TIME" runat="server" style =" display:inline;" Width ="100px"></asp:DropDownList>&nbsp;&nbsp;
            <asp:DropDownList ID="ddlM" DataTextField ="PAYMENT_TIME" DataValueField ="PAYMENT_TIME" runat="server" style =" display:inline;" Width ="100px"></asp:DropDownList>&nbsp;&nbsp;
            <asp:DropDownList ID="ddls" DataTextField ="PAYMENT_TIME" DataValueField ="PAYMENT_TIME" runat="server" style =" display:inline;" Width ="100px"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            E-mail<br />
            <asp:TextBox ID="txt_email" runat="server" Width ="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            หมายเหตุ<br />
            <asp:TextBox ID="txt_remark" runat="server" Width ="400px" Height ="80px" TextMode ="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <div style = "border:2px solid #FFD324; background-color:#FFF6BF; height:50px; vertical-align :middle; width:60%; height:120px;">
                <div style ="margin-top:15px;">
                    1. หลังจากท่านโอนเงินแล้ว ท่านสามารถยืนยันการชำระได้ที่นี่ กดตกลงได้เลยค่ะ <br />
                    2. หากท่านตอนนี้ยังไม่ชำระ ท่านสามารถออกจากหน้านี้ได้ เมื่อต้องการชำระ ไปที่บิลที่ต้องการชำระได้เลยค่ะ <br />
                    3. หากเปิดบิลแล้ว ไม่ได้ชำระเงินภายใน 72 ชม. บริษัทจะปิดออเดอร์ค่ะ <br />
                    4. ถ้าลูกค้าต้องการแก้ข้อมูลการโอน สามารถกลับไปที่ รายการสั่งซื้อ แก้ไขได้ค่ะ <br />
                    5. ถ้าเกินความสงสัย ลูกค้าสามารถติดต่อ cs ได้ค่ะ เบอร์โทรติดต่อ 090-120-1200 090-050-1200 
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
                <button id="btnSaveUcWithdraw" type="button" class="btn waves-effect orange waves-light" 
                    name="action" runat="server" onclick ="return funsubmit('S');" >
                    SUBMIT
                </button>
            &nbsp;&nbsp;
                <button id="Button2" type="button" class="btn waves-effect orange waves-light" 
                    name="action" runat="server" onclick ="return funsubmit('C');" >
                    CLEAR     
                </button>
        </td>
    </tr>
</table>

        <asp:HiddenField ID="hd_submit" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Style="display: none;" />

    </ContentTemplate>
</asp:UpdatePanel>