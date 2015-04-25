<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerTransOnly.aspx.cs" Inherits="VloveImport.web.Customer.CustomerTransOnly" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s12 m12 l12 TestBox1">                    
                    <span class="bold FontHeader orange-text">รายการขนส่ง</span>   
                    <br />
                    <br />                    
                    <div class="col s7 m7 l7 TestBox1">                    
                        <div class="row s7 m7 l7 TestBox1">                           
                            <div class="col s2 m2 l2 TestBox1"
                                style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 200px; height: 50px;">
                                <b>หมายเลข Tracking</b>
                            </div>
                            <div class="col s4 m4 l4 TestBox1">
                                <asp:TextBox ID="txtTrackingNo" runat="server" Width="250px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row s7 m7 l7 TestBox1">                           
                            <div class="col s2 m2 l2 TestBox1"
                                style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 200px; height: 50px;">
                                <b>หมายเลข Shop ID</b>
                            </div>
                            <div class="col s4 m4 l4 TestBox1">
                                <asp:TextBox ID="txtShopID" runat="server" Width="250px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row s7 m7 l7 TestBox1" style="height:100px;">                           
                            <div class="col s2 m2 l2 TestBox1"
                                style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 200px; height: 50px;">
                                <b>หมายเหตุ</b>
                            </div>
                            <div class="col s4 m4 l4 TestBox1">
                                <asp:TextBox ID="txtRemark" runat="server" Width="250px" Height="90px" Rows="4" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row s7 m7 l7 TestBox1" style="height:100px;">                           
                            <asp:Button ID="btnAdd" runat="server" Text="เพิ่มรายการ" OnClick="btnAdd_Click" />  
                        </div>
                        <div class="col s12 m12 l12 TestBox1">                                        
                            <asp:GridView ID="gvTrans" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>ลำดับ</HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                    <asp:BoundField DataField="TRACKING_NO" HeaderText="เลข Tracking" />
                                    <asp:BoundField DataField="SHOP_ORDER_ID" HeaderText="เลข Shop" />
                                    <asp:BoundField DataField="OD_REMARK" HeaderText="หมายเหตุ" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/Images/icon/Sign-Close-icon.png"
                                                Width="15px" Height="15px" OnClick="imbDelete_Click" CommandArgument='<%# Container.DataItemIndex %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table>
                                        <tr>
                                            <td>ลำดับ</td>
                                            <td>เลข Tracking</td>
                                            <td>เลข Shop</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                        </asp:GridView>
                        </div>
                        <div class="col s12 m12 l12 TestBox1">                                        
                            <div style="margin-left: 10px;">                
                                <div class="row s6 m6 l6 TestBox1">
                                    <asp:Button ID="btnBack" runat="server" Text="ย้อนกลับ" OnClick="btnBack_Click" />                                    
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnTrans" runat="server" Text="ดำเนินการต่อ" OnClick="btnTrans_Click" />                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>
