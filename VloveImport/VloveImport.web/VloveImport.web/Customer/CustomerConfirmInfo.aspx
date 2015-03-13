<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerConfirmInfo.aspx.cs" Inherits="VloveImport.web.Customer.CustomerConfirmInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col s10 m10 l10 TestBox1">
        ข้อมูลสินค้า
        <div class="row s6 m6 l6 TestBox1">
            <asp:GridView ID="gvBasket" runat="server" AutoGenerateColumns="false">
            <Columns>                                
                <asp:TemplateField>
                    <ItemTemplate>
                        <%--<asp:Image ID="imgItem" runat="server"/>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdBK_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ID") %>'/>
                        <asp:Label ID="lbItemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_ITEMNAME") %>'>></asp:Label><br />
                        <asp:Label ID="lbColor" runat="server" Text='<%# "สี " + DataBinder.Eval(Container.DataItem, "CUS_BK_COLOR") %>'>></asp:Label><br />
                        <asp:Label ID="lbSize" runat="server" Text='<%# "ขนาด " + DataBinder.Eval(Container.DataItem, "CUS_BK_SIZE") %>'>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ราคา">
                    <ItemTemplate>
                        <asp:Label ID="lbPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE") %>'>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="จำนวน">
                    <ItemTemplate>
                        <asp:Label ID="lbAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT") %>'>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="รวมทั้งหมด">
                    <ItemTemplate>
                        <asp:Label ID="lbTotal" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "CUS_BK_PRICE")) * Convert.ToDouble(DataBinder.Eval(Container.DataItem, "CUS_BK_AMOUNT")) %>'>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="imgItem" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="Orange" />
        </asp:GridView>  
        </div>
        ข้อมูลการขนส่ง
        <br />
        <br />
        
        <div class="row s6 m6 l6 TestBox1">
            1. ขนส่งจากจีนถึงไทย โดยวิธี 
            <br />
            <asp:RadioButton ID="rdbCar" runat="server" GroupName="GROUP1" Text="ทางรถ (10-15 วัน)" />    
            <br />         
            <asp:RadioButton ID="rdbBoat" runat="server" GroupName="GROUP1" Text="ทางเรือ (20-25 วัน)" />         
        <%--</div>
        
        <div class="row s6 m6 l6 TestBox1">--%>
            <br />
            2. ขนส่งภายในประเทศ โดยวิธี
            <br />
            <asp:RadioButton ID="rdbSafe" runat="server" GroupName="GROUP2" Text="มารับเอง" />    
            <br />         
            <asp:RadioButton ID="rdbNim" runat="server" GroupName="GROUP2" Text="นิ่มซีเส็ง" />                     
            <br />
            <asp:Button ID="btnUrder" runat="server" CssClass="btn waves-effect orange waves-light" OnClick="btnUrder_Click"/>
        </div>


    </div>

    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
            $('select').material_select();


        });
    </script>
</asp:Content>
