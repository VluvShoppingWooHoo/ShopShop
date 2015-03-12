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

            $("#btnSave").click(function () {

                var rdb = "";
                if ($("input[type='radio'][class~='rdb']:checked").length > 0) {
                    rdb = $("input[type='radio'][class~='rdb']:checked").val();
                }
                var cb = "";
                for (var i = 0; i < $("input[type='checkbox'][class~='cb']:checked").length ; i++) {
                    cb += $("input[type='checkbox'][class~='cb']:checked")[i].value + "||";
                }
                var dtMat = $('#dtMaterial').val();
                var dtHTML = $('#dtHTML').val();
                var ddl = $('#ddl1').val();
                var param = { "cb": cb, "rdb": rdb, "dtMat": dtMat, "dtHTML": dtHTML, "ddl": ddl };

                $.ajax({
                    type: 'POST',
                    //url: form.attr('action'),
                    url: "../TestPage.aspx/SampleMethod",
                    data: JSON.stringify(param),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        //bindModal(data);
                        //$('#loadingCircle').hide();
                        //$('#loadingLine').hide();
                        //$('#showData').show();
                        //$('#footer').show();
                    },
                    error: function (err) {
                        //alert('gs');
                    }
                });

                //var form = $('#form1');

                //$.ajax({
                //    type: 'POST',
                //    url: form.attr('action'),
                //    data: form.serialize(),
                //    dataType: 'json',
                //    success: function (data) {
                //        //bindModal(data);
                //        //$('#loadingCircle').hide();
                //        //$('#loadingLine').hide();
                //        //$('#showData').show();
                //        //$('#footer').show();
                //    },
                //    error: function (err) {
                //        //alert('gs');
                //    }
                //});
            });
        });
    </script>
</asp:Content>
