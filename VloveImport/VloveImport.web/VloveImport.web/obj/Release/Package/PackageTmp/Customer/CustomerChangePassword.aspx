<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerChangePassword.aspx.cs" Inherits="VloveImport.web.Customer.CustomerChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <span class="FontHeader black-text bold">รหัสผ่าน</span>
                <br />
                <br />
                <div class="col s12 m12 l12">
                    <span class="FontHeader2 orange-text bold">รหัสผ่านสำหรับการเข้าสู่ระบบ</span>
                    <br />
                    <div id="login" class="col s7 m7 l7">                
                        <br />
                        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                            <br />
                            <div style ="margin-left:10px;">
                                <b>รหัสผ่านเก่า</b>                                        
                            </div>
                        </div>
                        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                            <div style ="margin-left:10px;">
                                <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                            <br />
                            <div style ="margin-left:10px;">
                                <b>รหัสผ่านใหม่</b>                                        
                            </div>
                        </div>
                        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                            <div style ="margin-left:10px;">
                                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                            <br />
                            <div style ="margin-left:10px;">
                                <b>ยืนยันรหัสผ่าน</b>                                        
                            </div>
                        </div>
                        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                            <div style ="margin-left:10px;">
                                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 20%;">            
                            <div style ="margin-left:10px;">
                                <%--<button id="btnConfirm" type="button" class="btn waves-effect orange waves-light" 
                                    name="action">
                                    ยืนยัน
                                </button>--%>
                                <asp:ImageButton ID="imbConfirm" runat="server" ImageUrl="~/Images/btn/confirm.gif"
                                    OnClick="imbConfirm_Click" />
                            </div>
                        </div>
                    </div>                      
                </div>
                <div class="col s12 m12 l12">
                    <br />
                </div>
                <div class="col s12 m12 l12">
                    <span class="FontHeader2 orange-text bold">รหัสผ่านสำหรับถอนเงิน</span> <br />
                    <asp:Label ID="lbWarn" runat="server" Text="กรณีที่ไม่เคยตั้งค่ารหัสผ่านสำหรับถอนเงิน/ชำระเงิน ระบบตั้งให้เป็นรหัสเดียวกับรหัสผ่านสำหรับการเข้าสู่ระบบโดนอัตโนมัติ " ></asp:Label>
                    <%--<asp:LinkButton ID="lbReset" runat="server" Text="รีเซตรหัสผ่านสำหรับการชำระเงิน"
                        CssClass="blue-grey-text textUnderline" OnClick="lbReset_Click"></asp:LinkButton>
                    <br />--%>
                    <div id="withdraw" class="col s7 m7 l7">
                        <br />
                        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                            <br />
                            <div style ="margin-left:10px;">
                                <b>รหัสผ่านเก่า</b>                                        
                            </div>
                        </div>
                        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                            <div style ="margin-left:10px;">
                                <asp:TextBox ID="txtW_OldPass" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="lb1" runat="server" Text="ยังไม่เคยบันทึกรหัสผ่าน" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                            <br />
                            <div style ="margin-left:10px;">
                                <b>รหัสผ่านใหม่</b>                                        
                            </div>
                        </div>
                        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                            <div style ="margin-left:10px;">
                                <asp:TextBox ID="txtW_NewPass" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                            <br />
                            <div style ="margin-left:10px;">
                                <b>ยืนยันรหัสผ่าน</b>                                        
                            </div>
                        </div>
                        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                            <div style ="margin-left:10px;">
                                <asp:TextBox ID="txtW_Confirm" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 20%;">            
                            <div class="col" style ="margin-left:10px;">
                                <%--<button id="btnW_Confirm" type="button" class="btn waves-effect orange waves-light" 
                                    name="action">
                                    ยืนยัน
                                </button>--%>
                                <asp:ImageButton ID="imbW_Confirm" runat="server" ImageUrl="~/Images/btn/confirm.gif"
                                    OnClick="imbW_Confirm_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel1" TargetControlID="lblheader">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" Height="700px" Width="600px" runat="server" Style="display: none;">
                <div class="row s5 m5 l5">
                    <asp:Label ID="lblheader" runat="server" Text="gfsgdfg"></asp:Label>
                    <span class="FontHeader orange-text">รหัสผ่านการเข้าระบบ</span>
                    <br />
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnConf" runat="server" Text="ทำต่อ" OnClick="btnConf_Click"></asp:Button>
                    <asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" OnClick="btnCancel_Click"></asp:Button>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


    <script type="text/javascript"> 
        $(function () {
            SetFadeout();                       
        });       
    </script>
</asp:Content>
