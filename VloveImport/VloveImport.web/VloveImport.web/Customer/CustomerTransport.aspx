<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerTransport.aspx.cs" Inherits="VloveImport.web.Customer.CustomerTransport" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s12 m12 l12 TestBox1">
                    ข้อมูลการขนส่ง
                <br />
                    <br />

                    <div class="row s6 m6 l6 TestBox1">
                        1. ขนส่งจากจีนถึงไทย โดยวิธี 
                        <br />
                        <asp:RadioButtonList ID="rdbChina" runat="server" DataTextField="TRANS_NAME" DataValueField="TRANS_ID">
                        </asp:RadioButtonList>
                
                        <br />
                        2. ขนส่งภายในประเทศ โดยวิธี
                        <br />
                        <asp:RadioButtonList ID="rdbThai" CssClass="rdbThai" runat="server" DataTextField="TRANS_NAME" DataValueField="TRANS_ID">
                        </asp:RadioButtonList>
                
                        <br />
                        <div id="divAddress" class="divAddress" runat="server">
                            3. เลือกที่อยู่ในการจัดส่ง
                            <br />
                            <asp:RadioButtonList ID="rdbAddress" runat="server" DataTextField="ADDRESS_FULL" DataValueField="CUS_ADD_ID">
                            </asp:RadioButtonList>
                        </div>

                        <br />
                        <button id="btnBack" runat="server" type="submit" onserverclick="btnBack_ServerClick"
                            name="action" class="btn waves-effect orange waves-light">
                            Back                                
                        </button>
                        <button id="btnOrder" runat="server" type="submit" onserverclick="btnOrder_ServerClick"
                            name="action" class="btn waves-effect orange waves-light">
                            Order                                
                        </button>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <script type="text/javascript">
        $(function () {
            $('.divAddress').hide();
            SetFadeout();
            $('.rdbThai label').click(function (e) {
                //alert(e.currentTarget.control.id);
                //$("#" + e.currentTarget.control.id).attr('checked', 'checked');
                if (e.currentTarget.innnerHtml == "มารับเอง" || e.currentTarget.control.value == 3) {
                    $('.divAddress').hide();
                }
                else {
                    $('.divAddress').show();
                }
            });
            //$('select').material_select();
        });
    </script>
</asp:Content>
