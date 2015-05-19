<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncWithdraw.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncWithdraw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

        <br />
        <b>ถอนเงิน</b> : <b>ยอดเงินคงเหลือ THB <asp:Label ID="lbMymoney" runat="server"></asp:Label></b>
        <br /><br />
        <b>
            <span style ="color:red;">
                ถอนเงิน : ในกรณีกดถอนเงิน เมื่อเจ้าหน้าที่ตรวจสอบผ่านแล้ว ระบบจะตัดเงินคงเหลือทันที
                <%--หากลูกค้าต้องการชำระบิล กรุณากดเมนู “ชำระเงิน” ที่หน้ารายการสั่งซื้อคะ--%>
                <br /><br />
                เงินจะเข้าบัญชีลูกค้าในช่วงระยะเวลาดำเนินการ 7-10 วัน
                <%--การชำระเงิน : เป็นการเลือกชำระเงินในบิลนั้นๆ ระบบจะทำการสั่งซื้อให้หลังจากได้รับยืนยันการชำระบิลจากลูกค้า--%>
            </span>
        </b>
        <br />
        <br />        
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:25%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>* เลขที่บัญชีโอนเงินกลับ</b>                                        
            </div>
        </div>
        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
            <div style ="margin-left:10px;">                                
                <asp:DropDownList ID="ddl_account_name" runat="server" 
                CssClass="dpBlock" Width="300px"></asp:DropDownList>
            </div>
        </div>
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:25%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>* จำนวนเงิน</b>                                        
            </div>
        </div>
        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
            <div style ="margin-left:10px;">
                <asp:TextBox ID="txt_amount" runat="server" Width="300px" CssClass="txt_amount"></asp:TextBox>
                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_amount" ID="txt_amount_FilteredTextBoxExtender" ValidChars="1234567890">
                </asp:FilteredTextBoxExtender>
            </div>
        </div>
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:25%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>* หมายเหตุ</b>                                        
            </div>
        </div>
        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
            <div style ="margin-left:10px;">
                <asp:TextBox ID="txt_remark" runat="server" TextMode="MultiLine" Width="300px" Height="50px" Rows="5" CssClass="txt_remark"></asp:TextBox>
            </div>
        </div>
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:25%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <span style="color:red; font-weight:600;">* รหัสผ่านสำหรับการถอนเงิน</span>
            </div>
        </div>
        <div style = "vertical-align :middle; width:50%; height:50px; margin-left: 32%; margin-top: -40px;">            
            <div style ="margin-left:10px;">
                <asp:TextBox ID="txt_Withraw_Password" runat="server" Width="300px" TextMode="Password" CssClass="txt_Withraw_Password"></asp:TextBox>
                 <br />&nbsp;&nbsp;<b>**รหัสผ่านเป็นอันเดียวกันกับ รหัสผ่านการชำระเงิน</b>
            </div>
        </div>
        <br /><br />
         <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 20%;">            
            <div style ="margin-left:10px;">
                <button type="button" class="btn waves-effect orange waves-light" name="action">
                <asp:Button ID="btnWithdraw" runat="server" Text="SUBMIT" OnClick="btnWithdraw_Click" />
                </button>
                &nbsp;&nbsp;
                <button type="button" class="btn waves-effect orange waves-light" name="action">
                <asp:Button ID="btnClear" runat="server" Text="CLEAR" OnClick="btnClear_Click" />
                </button>
                <%--<button id="btnSaveUcWithdraw" type="button" class="btn waves-effect orange waves-light"
                    name="action">
                    SUBMIT               
                </button>
                &nbsp;&nbsp;
                <button id="Button2" type="button" class="btn waves-effect orange waves-light"
                    name="action" runat="server" onclick="return funsubmit('C');">
                    CLEAR                    
                </button>--%>
            </div>
        </div>      

