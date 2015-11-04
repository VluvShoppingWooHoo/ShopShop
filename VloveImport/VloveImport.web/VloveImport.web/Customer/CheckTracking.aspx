<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CheckTracking.aspx.cs" Inherits="VloveImport.web.Customer.CheckTracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s2 m2 l2">
            &nbsp;
        </div>
        <div class="col s8 m8 l8">
            <%--<div class="row">
                <img src="../Images/pic/Logo/LOGO-01.jpg" style="width:658px; height:200px;"/>                
            </div>--%>
            <br />
            <div class="row">
                <div class="col s1 m1 l1">&nbsp;</div>
                <div class="col s4 m4 l4">
                    <span class="orange-text bold">Tracking Number</span>
                </div>
                <div class="col s6 m6 l6">
                    <asp:TextBox ID="txtTracking" runat="server" Width="250px" ></asp:TextBox>
                </div>
                <div class="col s1 m1 l1">&nbsp;</div>
            </div>
            <br />
            <div class="row center">
                <button id="btnSearch" runat="server" type="submit" onserverclick="btnSearch_Click" 
                    name="action" class="btn waves-effect orange waves-light">Search                                
                </button>   
            </div>
            <%--<br />
            <div class="row">
                <div class="col s1 m1 l1">&nbsp;</div>
                <div class="col s4 m4 l4">
                    <span class="orange-text bold">Tracking No.</span>
                </div>
                <div class="col s6 m6 l6">
                    <asp:Label ID="lbTrack" runat="server" ></asp:Label>
                </div>
                <div class="col s1 m1 l1">&nbsp;</div>
            </div>--%>
            <br />
            <div class="row">
                <div class="col s1 m1 l1">&nbsp;</div>
                <div class="col s10 m10 l10">
                    <asp:GridView ID="gv_detail" runat="server" CssClass="GridStyle" AutoGenerateColumns="False" Width ="90%" >
                        <Columns>
                            <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="35%">
                                <ItemTemplate>
                                    <%--<asp:HiddenField ID="hdOrderID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ORDER_ID") %>' />   --%>
                                    <asp:HiddenField ID="hdID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TD_ID") %>' />   
                                    <asp:Label ID="lbDate" runat="server" Text='<%# DateStringtoString(DataBinder.Eval(Container.DataItem, "TD_DATE").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail" ItemStyle-Width="65%">
                                <ItemTemplate>  
                                    <asp:Label ID="lbDetail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_DESCRIPTION").ToString() %>'></asp:Label><br />
                                    <asp:Label ID="lbDetail2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_REMARK").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail" ItemStyle-Width="65%">
                                <ItemTemplate>  
                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TD_REMARK").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" align="left" width="100%" height="275" bgcolor="#fbfbfb">
                                <tr>
                                    <td width="100%" align="center">
                                        <b>Data not found.</b>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div class="col s1 m1 l1">&nbsp;</div>
            </div>            
        </div>
        <div class="col s2 m2 l2">
            &nbsp;
        </div>
    </div>    
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

<%--<div>
    <img src="../Images/pic/Under-construction.png" /><br/>ปิดทำการปรับปรุงชั่วคราว ขอบคุณค่ะ 
</div>--%>