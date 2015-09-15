﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerVIP.aspx.cs" Inherits="VloveImport.web.Customer.CustomerVIP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="col s12 m12 l12">
        <span class="FontHeader black-text">สมัครบริการเสริม VIP</span>
        <div class="row divRowBlock">
            <div class="col s12 m12 l12 paddingTop25">
                <b>ยอดเงินคงเหลือ THB
                <asp:Label ID="lbMymoney" runat="server"></asp:Label></b>
                <br />
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s3 m3 l3 paddingTop25">
                <br />
                ประวัติการสมัครบริการ VIP
            </div>
            <div class="col s1 m1 l1"></div>
            <div class="col s8 m8 l8 paddingTop25">
                <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px" HeaderText="No.">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "NOO") %>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px" HeaderText="VIP">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "VIP_NAME") %>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px" HeaderText="มูลค่า">
                            <ItemTemplate>
                                <%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "VIP_PRICE")).ToString("###,##0.00") %>   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px" HeaderText="วันที่เริ่มต้น">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "STARTDATE")).ToString("dd/MM/yyyy") %>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px" HeaderText="วันที่สิ้นสุด">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ENDDATE")).ToString("dd/MM/yyyy") %>       
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="70px" ItemStyle-Height="70px" HeaderText="วันที่ทำรายการ">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "TRANSDATE")).ToString("dd/MM/yyyy") %>              
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <span class="FontHeader black-text"> ยังไม่เคยสมัครบริการ VIP</span>
                    </EmptyDataTemplate>
                    <HeaderStyle CssClass="orange" />
                </asp:GridView>
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s3 m3 l3 paddingTop25">
                ปรเภทของ VIP
            </div>
            <div class="col s1 m1 l1"></div>
            <div class="col s8 m8 l8 paddingTop25">
                <asp:RadioButton ID="rdbVIP6" runat="server" GroupName="VIP" CssClass="Init"/>&nbsp;&nbsp;<span class="FontHeader black-text"> VIP 6 เดือน ลดค่าขนส่ง 15% ราคา 2,500 บาท</span>
                <br />
                <asp:RadioButton ID="rdbVIP12" runat="server" GroupName="VIP" CssClass="Init" />&nbsp;&nbsp;<span class="FontHeader black-text"> VIP 12 เดือน ลดค่าขนส่ง 20% ราคา 4,500 บาท</span>
                <br />
                <asp:RadioButton ID="rdbSuperVIP6" runat="server" GroupName="VIP" CssClass="Init" />&nbsp;&nbsp;<span class="FontHeader black-text"> Super VIP 6 เดือน ลดค่าขนส่ง 25% ราคา 5,000 บาท</span>
                <br />
                <asp:RadioButton ID="rdbSuperVIP12" runat="server" GroupName="VIP" CssClass="Init" />&nbsp;&nbsp;<span class="FontHeader black-text"> Super VIP 12 เดือน ลดค่าขนส่ง 30% ราคา 6,000 บาท</span>
                <br />&nbsp;
            </div>
        </div>        
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                &nbsp;
            </div>
            <div class="col s8 m8 l8 paddingTop25">
                <button id="btnSelect" runat="server" type="submit" onserverclick="btnSelect_ServerClick"
                    name="action" class="btn waves-effect orange waves-light">
                    สมัคร VIP                                
                </button>
                <%--<asp:Button ID="btnSelect" runat="server" Text="สมัครบริการ VIP" OnClick="btnSelect_Click" OnClientClick="return confirm('คุณกำลังสมัครบริการ VIP?')" />--%>
            </div>
            <div class="col s2 m2 l2 paddingTop25">
                &nbsp;
            </div>
        </div>
    </div>
    
    

    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

