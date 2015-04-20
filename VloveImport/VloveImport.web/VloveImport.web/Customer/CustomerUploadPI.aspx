<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerUploadPI.aspx.cs" Inherits="VloveImport.web.Customer.CustomerUploadPI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s12 m12 l12 TestBox1">                    
                    <span class="bold FontHeader orange-text">สินค้าฝากจ่าย</span>          
                    <div class="row s6 m6 l6 TestBox1">
                        หมายเลขใบ PI
                        <br />
                        <asp:TextBox ID="txtPINo" runat="server"></asp:TextBox>
                    </div>
                    <div class="row s6 m6 l6 TestBox1">
                        จำนวนเงิน
                        <br />
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                        <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txtAmount" 
                            ID="txt_Transport_Cus_Price_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                        </asp:FilteredTextBoxExtender>
                    </div>
                    <div class="row s6 m6 l6 TestBox1">
                        <button id="btnUploadPI" runat="server" type="submit" onserverclick="btnUploadPI_ServerClick"
                            name="action" class="btn waves-effect orange waves-light">
                            ฝากจ่าย                                
                        </button>
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
