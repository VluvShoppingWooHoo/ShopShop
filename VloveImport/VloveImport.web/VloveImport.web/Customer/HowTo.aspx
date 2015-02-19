<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="HowTo.aspx.cs" Inherits="VloveImport.web.Customer.HowTo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mView" runat="server">
        <asp:View ID="vRateImport" runat="server">
            <table>
                <tr>
                    <td>
                        การคิดราคาค่านำเข้าแบ่งตามประเภท
                    </td>
                </tr>
                <tr>
                    <td>                       
1. สินค้าทั่วไปคิดราคาตามน้ำหนัก<br />
2. สินค้าทั่วไปคิดราคาตามขนาด (คิว) คือสินค้าที่มีน้ำหนักเบา แต่มีขนาดใหญ่ ใช้พื้นที่มาก เช่น  ตุ๊กตา กระเป๋า กระเป๋าเดินทาง และสินค้าอื่นๆที่มีหนักเบาแต่ขนาดใหญ่<br />
3. สินค้าลิขสิทธิ์คิดราคาตามน้ำหนัก<br />
สินค้าทุกอย่างที่เป็นแบรน ติดแบรน  copy brand  ทุกอย่างที่มีลิขสิทธิ์ ไม่ว่าจะ copy มือสอง หรือสินค้าของปลอม 

4. สินค้าลิขสิทธิ์คิดราคาตามขนาด (คิว)
สินค้าทุกอย่างที่เป็นแบรน ติดแบรน  copy brand  ทุกอย่างที่มีลิขสิทธิ์ ไม่ว่าจะ copy มือสอง หรือสินค้าของปลอม  ที่มีหนักเบาแต่ขนาดใหญ่<br />
5 สินค้า มอก. 
สินค้า มอก คือสินค้าประเภทเครื่องใช้ไฟฟ้าและสินค้าที่ต้องขอใบอนุญาตนำเข้า <br />
6. สินค้า มอก  คิดราคาตามขนาด (คิว)
สินค้า มอก คือสินค้าประเภทเครื่องใช้ไฟฟ้าและสินค้าที่ต้องขอใบอนุญาตนำเข้า ที่มีหนักเบาแต่ขนาดใหญ่<br />
7. สินค้าเหมาคิวหรือเหมาตู้
สินค้าที่เหมามาเป็นตู้คอนเทนเนอร์
                    </td>
                </tr>
            </table>
        </asp:View>

    </asp:MultiView>
</asp:Content>
