<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerTranspot.aspx.cs" Inherits="VloveImport.web.Customer.CustomerTranspot" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col s10 m10 l10 TestBox1">
        ข้อมูลการขนส่ง
        <br />
        <br />
        1. ขนส่งจากจีนถึงไทย โดยวิธี
        <div class="row s6 m6 l6 TestBox1">
            <asp:RadioButton ID="rdbCarr" GroupName="GROUP11" Text="ทางรถ (10-15 วัน)" />
            <asp:RadioButton ID="rdbBoatt" GroupName="GROUP11" Text="ทางเรือ (20-25 วัน)" />
            <p>
                <input class="rdb" name="group1" type="radio" id="rdbCar" value="ทางรถ (10-15 วัน)-Radio" />
                <label for="rdbCar">ทางรถ (10-15 วัน)</label>
            </p>
            <p>
                <input class="rdb" name="group1" type="radio" id="rdbBoat" value="ทางเรือ (20-25 วัน)-Radio" />
                <label for="rdbBoat">ทางเรือ (20-25 วัน)</label>
            </p>
        </div>
        <br />
        2. ขนส่งภายในประเทศ โดยวิธี
        <div class="row s6 m6 l6 TestBox1">
            <p>
                <input class="rdb" name="group2" type="radio" id="rdbSafe" value="มารับเอง-Radio" />
                <label for="rdbSafe">มารับเอง</label>
            </p>
            <p>
                <input class="rdb" name="group2" type="radio" id="rdbNim" value="นิ่มซีเส็ง-Radio" />
                <label for="rdbNim">นิ่มซีเส็ง</label>
            </p>
        </div>
        <button id="btnOrder" runat="server" type="submit" 
            name="action" class="btn waves-effect orange waves-light">Order                                
        </button>
    </div>

    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
            $('select').material_select();
        });
    </script>
</asp:Content>
