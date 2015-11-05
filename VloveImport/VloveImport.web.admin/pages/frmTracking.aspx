<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmTracking.aspx.cs" Inherits="VloveImport.web.admin.pages.frmTracking" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style ="margin-top:10px;">
                <h2 style ="color:#318DBF;">Tracking</h2>
                <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
            </div>
            <fieldset style="width: 98.5%;">
                <legend>
                    <asp:Label ID="lbl_header" runat="server" Text="Add Tracking"></asp:Label>
                </legend>
                <table>
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Transport Name :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:DropDownList ID="ddl_TransportName" runat="server" Width="300px"></asp:DropDownList>
                            <span style ="color:red;">*</span>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Tracking Number :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtTrackingNumber" runat="server" Width="300px"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Transport Date :"></asp:Label></td>
                        <td>
                            <uc1:ucCalendar ID="ucCalendar1" runat="server" />                            
                            <span style ="color:red;">*</span>
                        </td>
                        <td><asp:Label ID="Label5" runat="server" Text="Pack No :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPackNo" Width ="300px" runat="server"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Weight :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtWeight" Width ="300px" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtWeight" ValidChars="0123456789."></asp:FilteredTextBoxExtender>
                        </td>
                        <td><asp:Label ID="Label6" runat="server" Text="Size(Cubic) :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtCubic" Width ="300px" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" TargetControlID="txtCubic" ValidChars="0123456789."></asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>                        
                        <td colspan="2">
                            <asp:Label ID="Label7" runat="server" Text="Width :"></asp:Label> &nbsp;&nbsp;
                            <asp:TextBox ID="txtWidth" Width ="80px" runat="server" ></asp:TextBox>  &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars" TargetControlID="txtWidth" ValidChars="0123456789."></asp:FilteredTextBoxExtender>
                            <asp:Label ID="Label8" runat="server" Text="Height :"></asp:Label>   &nbsp;&nbsp;
                            <asp:TextBox ID="txtHeight" Width ="80px" runat="server" ></asp:TextBox>  &nbsp;&nbsp;&nbsp;&nbsp;   
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars" TargetControlID="txtHeight" ValidChars="0123456789."></asp:FilteredTextBoxExtender>              
                            <asp:Label ID="Label9" runat="server" Text="High :"></asp:Label>   &nbsp;&nbsp;
                            <asp:TextBox ID="txtHigh" Width ="80px" runat="server" ></asp:TextBox>                       
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterMode="ValidChars" TargetControlID="txtHigh" ValidChars="0123456789."></asp:FilteredTextBoxExtender>
                        </td>
                        <td rowspan="2"><asp:Label ID="Label11" runat="server" Text="Remark :"></asp:Label></td>
                        <td rowspan="2">
                            <asp:TextBox ID="txtRemark" Width ="300px" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>  
                        <td><asp:Label ID="Label10" runat="server" Text="Type :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtType" Width ="300px" runat="server"></asp:TextBox>
                        </td> 
                    </tr>
                    <tr>
                    <td class ="ItemStyle-center" colspan="4">
                        <asp:Button ID="btnAdd" runat="server" Text=" Add to Grid " CssClass="btnSave" OnClick="btnAdd_Click" />
                    </td>
                </tr>
                </table>
                <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%">                
                    <Columns>
                        <asp:TemplateField HeaderText="Transport Date">
                            <ItemTemplate>
                                <%# (Container.DisplayIndex + 1).ToString() %>
                            </ItemTemplate>
                            <HeaderStyle CssClass="width15" />
                            <ItemStyle CssClass="ItemStyle-center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="T_TRANSPORT_NAME" HeaderText="Transport Name">
                            <HeaderStyle CssClass="width15" />
                        </asp:BoundField>              
                        <asp:BoundField DataField="T_TRACKING_NO" HeaderText="Tracking Number" >
                            <HeaderStyle CssClass="width15" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Transport Date">
                            <ItemTemplate>
                                <asp:Label ID="lbDate" runat="server" Text='<%# DateStringtoString(DataBinder.Eval(Container.DataItem, "T_DATE").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="width15" />
                            <ItemStyle CssClass="ItemStyle-center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="T_WEIGHT" HeaderText="Weight">
                            <HeaderStyle CssClass="width10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="T_CUBIC" HeaderText="Cubic">
                            <HeaderStyle CssClass="width10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="T_WIDTH" HeaderText="Width">
                            <HeaderStyle CssClass="width10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="T_HEIGHT" HeaderText="Height">
                            <HeaderStyle CssClass="width10" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="T_HIGH" HeaderText="High">
                            <HeaderStyle CssClass="width10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="T_PACK_NO" HeaderText="Pack No">
                            <HeaderStyle CssClass="width10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="T_TYPE" HeaderText="Type">
                            <HeaderStyle CssClass="width10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="T_REMARK" HeaderText="Remark">
                            <HeaderStyle CssClass="width15" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdT_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "T_ID") %>'/>
                                <asp:ImageButton ID="imgBtn_edit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="imgBtn_edit_Click" />&nbsp;&nbsp;  
                                <asp:ImageButton ID="imgBtn_Delete" runat="server" ImageUrl="~/img/icon/Close-2-icon.png" OnClick="imgBtn_Delete_Click" Height="15px" Width="15px" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="width10" />
                            <ItemStyle CssClass="ItemStyle-center" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table style="border: 1px solid black;">
                            <tr>
                                <td class="width5">No. </td>
                                <td class="width15">Transport Name</td>
                                <td class="width15">Transport Number</td>
                                <td class="width15">Transport Date</td>
                                <td class="width10">Weight</td>
                                <td class="width10">Size(Cubic)</td>
                                <td class="width10">Width</td>
                                <td class="width10">Height</td>                                
                                <td class="width10">High</td>
                                <td class="width10">Pack No.</td>
                                <td class="width10">Type</td>
                                <td class="width15">Remark</td>
                            </tr>
                            <tr style="border: 1px solid black;">
                                <td colspan="12"><br />Data empty.</td>
                            </tr>
                        </table>
                        
                    </EmptyDataTemplate>
                </asp:GridView>
                <br />
                <table class = "width100">
                <tr>
                    <td class ="ItemStyle-center">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnSave" OnClick="btnSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            </fieldset>           
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
