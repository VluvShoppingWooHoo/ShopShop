<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VloveImport.web.Customer.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mView" runat="server">
        <asp:View ID="v0" runat="server">
            <div style="height:650px;">
                <div class="col s2 m2 l2">
                    &nbsp;
                </div>
                <div class="col s8 m8 l8">
                    <div class="row">
                        <span class="orange-text bold">ชื่อ</span>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                    </div>
                    <div class="row">
                        <span class="orange-text bold">อีเมลล์</span>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="row">
                        <span class="orange-text bold">รหัสผ่าน</span>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="row">
                        <span class="orange-text bold">ยืนยันรหัสผ่าน</span>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:CheckBox ID="ckb" runat="server" Text="ยอมรับ" />
                        &nbsp;เงื่อนไขสมาชิกเว็บไซต์
                    </div>
                    <div class="row" style="height:160px;">                
                        <asp:TextBox ID="txtAccept" runat="server" TextMode="MultiLine" Rows="5" Height="150px"
                            Text="โปรดอ่านและทำความเข้าใจข้อตกลงข้างล่างนี้โดยละเอียดก่อนสมัครเป็นสมาชิก เพื่อรักษาสิทธิประโยชน์ในการใช้บริการของท่าน
                            1.	ผู้สมัครสมาชิกต้องกรอกข้อมูลให้ครบถ้วน และตรงตามเป็นจริง เพื่อสิทธิประโยชน์ของท่านเอง หากตรวจสอบพบว่าข้อมูลของท่านที่ให้มาเป็นเท็จ ทางระบบจะยกเลิกการเป็นสมาชิกของท่านทันที โดยไม่ต้องแจ้งให้ทราบล่วงหน้า
                            2.	สมาชิกต้องปฏิบัติตามกฏระเบียบและข้อตกลงของบอร์ดอย่างเคร่งครัดเพื่อความสงบเรียบร้อย ในกรณีที่สมาชิกละเมิดกฏ Admin และผู้ดูแลเว็บบอร์ด มีสิทธิ์ยกเลิกการเป็นสมาชิกได้โดยไม่แจ้งให้ทราบล้วงหน้า
                            3.	เพื่อความเป็นส่วนตัวและความปลอดภัยในข้อมูลของสมาชิกเอง ผู้ดูแลเว็บบอร์ดขอแจ้งให้สมาชิกทราบว่า เป็นหน้าที่ของสมาชิกในการรักษาชื่อ Login และ Password ของสมาชิกให้ดี โดยไม่บอกให้ผู้อื่นทราบ
                            4.	ข้อมูลของสมาชิกจะถูกเก็บเป็นความลับอย่างสูงสุด ผู้ดูแลเว็บบอร์ดจะไม่เปิดเผยข้อมูลของสมาชิกเพื่อประโยชน์ทางการค้า หรือเพื่อประโยชน์ในด้านอื่น ๆ ทั้งสิ้น
                            "></asp:TextBox>
                    </div>
                    <div class="row">     
                        <span class="orange-text bold">โทรศัพท์มือถือ</span>   
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                    </div>
                    <div class="row">   
                        <span class="orange-text bold">รหัสผู้แนะนำ</span>      
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtRefCust" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hddRefCust" runat="server" />
                    </div>
                    <div class="row">
                        <button id="btnRegis" runat="server" type="submit" onserverclick="btnRegis_Click"
                            name="action" class="btn waves-effect orange waves-light">
                            Register                                                            
                        </button>
                        <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="col s2 m2 l2">
                    &nbsp;
                </div>  
            </div>
      
        </asp:View>
        <asp:View ID="V1" runat="server">
            <div class="row" style="borde">
                <div class="row s4 m4 l4">
                    <span class="FontHeader orange-text">สมัครสมาชิกสำเร็จ</span> 
                </div>
                <div class="row s4 m4 l4">
                    กรุณาตรวจสอบที่อีเมลล์ของคุณ และยืนยันการสมัครสมาชิก
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>
