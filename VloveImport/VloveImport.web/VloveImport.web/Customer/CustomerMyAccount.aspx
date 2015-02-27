<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerMyAccount.aspx.cs" Inherits="VloveImport.web.Customer.CustomerMyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h5 id="lblWelcome" runat="server"></h5>
        <p id="P1">บัญชีของคุณ</p>
        <p id="lblBalance" runat="server"></p>
        <p id="lblPoint" runat="server"></p>
        <button id="btnTopup" runat="server" type="submit" onserverclick="btnTopup_Click" 
            name="action" class="btn waves-effect orange waves-light">Login                                
        </button>
        <button id="btnWithdraw" runat="server" type="submit" onserverclick="btnWithdraw_Click" 
            name="action" class="btn waves-effect orange waves-light">Login                                
        </button>
        <button id="btnTransLog" runat="server" type="submit" onserverclick="btnTransLog_Click" 
            name="action" class="btn waves-effect orange waves-light">Login                                
        </button>
        <button id="btnVocher" runat="server" type="submit" onserverclick="btnVocher_Click" 
            name="action" class="btn waves-effect orange waves-light">Login                                
        </button>
        <button id="btnMyPoint" runat="server" type="submit" onserverclick="btnMyPoint_Click" 
            name="action" class="btn waves-effect orange waves-light">Login                                
        </button>
    </div>
    <div>
        <p id="P2">ประวัติการซื้อสินค้า</p>
        <p id="P3" runat="server"></p>
        <p id="P4" runat="server"></p>
    </div>
    <div>
        <p id="P5">สินค้าล่าสุด</p>
        <p id="P6" runat="server"></p>
        <p id="P7" runat="server"></p>
    </div>
</asp:Content>
