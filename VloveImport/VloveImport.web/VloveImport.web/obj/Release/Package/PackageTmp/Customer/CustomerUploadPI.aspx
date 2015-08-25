<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerUploadPI.aspx.cs" Inherits="VloveImport.web.Customer.CustomerUploadPI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col s12 m12 l12 TestBox1">                    
                    <span class="bold FontHeader orange-text">สินค้าฝากจ่าย</span>   
                    <br />
                    <br />                    
                    <div class="col s9 m9 l9 TestBox1">                                                  
                        <div class="row s7 m7 l7 TestBox1" id="Code" runat="server" visible="false" style="padding-bottom:2px;">                           
                            <div class="col s2 m2 l2 TestBox1"
                                style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 200px; height: 50px;">
                                <b>รหัสสินค้าฝากจ่าย</b>
                            </div>
                            <div class="col s4 m4 l4 TestBox1">
                                <asp:Label ID="lbOrderCode" runat="server"></asp:Label>
                            </div>
                        </div>     
                        <div class="row s7 m7 l7 TestBox1">                           
                            <div class="col s2 m2 l2 TestBox1"
                                style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 200px; height: 50px;">
                                <b>หมายเลขใบ PI</b>
                            </div>
                            <div class="col s4 m4 l4 TestBox1">
                                <asp:TextBox ID="txtPINo" runat="server" Width="250px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row s7 m7 l7 TestBox1" id="Tracking" runat="server" visible="false">                           
                            <div class="col s2 m2 l2 TestBox1"
                                style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 200px; height: 50px;">
                                <b>หมายเลข Tracking</b>
                            </div>
                            <div class="col s4 m4 l4 TestBox1">
                                <asp:TextBox ID="txtTracking" runat="server" Width="250px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row s7 m7 l7 TestBox1">                           
                            <div class="col s2 m2 l2 TestBox1"
                                style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 200px; height: 50px;">
                                <b>จำนวนเงิน</b>
                            </div>
                            <div class="col s4 m4 l4 TestBox1">
                                <asp:TextBox ID="txtAmount" runat="server" Width="250px"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txtAmount" 
                                    ID="txt_Transport_Cus_Price_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                                </asp:FilteredTextBoxExtender>
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
                        <div class="row s9 m9 l9 TestBox1" id="Uploadpi" runat="server">                           
                            <div class="col s2 m2 l2 TestBox1"
                                style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 200px; height: 50px;">
                                <b>อัพโหลดใบ PI</b>
                            </div>
                            <div class="col s7 m7 l7">
                                <div class="file-field input-field">
                                    <input class="file-path validate" id="filetext" type="text" style="width: 250px; margin-left: 0px; margin-right: 20px;" />
                                    <div class="btn">
                                        <span>File</span>
                                            <asp:FileUpload ID="Ifile" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>                        
                        <div class="col s12 m12 l12 TestBox1">                                        
                            <div style="margin-left: 10px;">                
                                <div class="row s6 m6 l6 TestBox1">
                                    <button id="btnBack" runat="server" type="submit" onserverclick="btnBack_ServerClick"
                                        name="action" class="btn waves-effect orange waves-light">
                                        ย้อนกลับ                                
                                    </button>&nbsp;&nbsp;
                                    <button id="btnUploadPI" runat="server" type="submit" onserverclick="btnUploadPI_ServerClick"
                                        name="action" class="btn waves-effect orange waves-light">
                                        ฝากจ่าย                                
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col s5 m5 l5 TestBox1">                    
                        <asp:Image ID="imgPI" runat="server" ImageUrl="~/Images/icon/close-icon.png" Visible="false"    
                            Width="350px" Height="380px" BorderWidth="2px" BorderColor="Gray"/>
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
