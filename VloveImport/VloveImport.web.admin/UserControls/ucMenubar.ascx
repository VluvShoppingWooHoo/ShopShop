﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenubar.ascx.cs" Inherits="VloveImport.web.admin.UserControls.ucMenubar" %>

<table border="0" cellspacing="0" cellpadding="1" align="center" height="15" width="1200px">
    <tr>
        <td bgcolor="#EEEEEE">
            <asp:Menu ID="Menu1"  StaticEnableDefaultPopOutImage="false" DynamicEnableDefaultPopOutImage="false" runat="server" BackColor="Transparent" Orientation="Horizontal"
                DynamicHorizontalOffset="2" Font-Names="tahoma, Arial, mS Sans Serif, sans-serif" Font-Size="8pt" Font-Bold="false"
                ForeColor="Black" StaticSubMenuIndent="10px" Height="20px" Style="margin-top: 1px; margin-left: 0px; padding-bottom: 2px; padding-top: 0px; z-index: 9999;"
                StaticDisplayLevels="1" MaximumDynamicDisplayLevels="1">
                <DynamicHoverStyle BackColor="White" ForeColor="black" Height="20px" />
                <DynamicMenuItemStyle ItemSpacing="0" ForeColor="black" HorizontalPadding="3px" VerticalPadding="4px" Height="20px" CssClass="displayblock" />
                <DynamicMenuStyle BackColor="#EEEEEE" ForeColor="black" HorizontalPadding="8px" VerticalPadding="4px" />
                <Items>
                    <asp:MenuItem Text="New Item" Value="New Item">
                        <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                        <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                    <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                    <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                    <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="White" ForeColor="black" Height="20px" />
                <StaticMenuItemStyle BackColor="Transparent" ItemSpacing="0" HorizontalPadding="8px" VerticalPadding="0px" Height="20px" />
            </asp:Menu>
        </td>
    </tr>
</table>