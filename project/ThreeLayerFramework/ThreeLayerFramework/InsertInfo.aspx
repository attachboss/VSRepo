<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertInfo.aspx.cs" Inherits="ThreeLayerFramework.InsertInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-3.6.0.min.js"></script>
    <script>
        $(function() {
            $("input :text").val("请输入..");
            $("input :text").focus(function () {
                $(this).one($(this).val(""));
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            课程名：<input type="text" id="txtName" name="txtName" /><br />
            课程代码：<input type="text" id="txtId" name="txtId" /><br />
            任课教师：<input type="text" id="txtTeacher" name="txtTeacher" /><br />
            学分：<input type="text" id="txtCredit" name="txtCredit" /><br />
            成绩：<input type="text" id="txtGrade" name="txtGrade" /><br />
            <input type="hidden" name="IsPostBack" value="0" />
            <input type="submit" id="btnSub" value="提交"/><br />
        </div>
    </form>
</body>
</html>
