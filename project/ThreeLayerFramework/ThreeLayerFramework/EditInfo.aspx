<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditInfo.aspx.cs" Inherits="ThreeLayerFramework.EditInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            课程名：<input type="text" id="txtName" name="txtName" value="<%=userInfo.CName %>"/><br />
            任课教师：<input type="text" id="txtTeacher" name="txtTeacher" value="<%=userInfo.CTeacher %>"/><br />
            学分：<input type="text" id="txtCredit" name="txtCredit" value="<%=userInfo.CCredit %>"/><br />
            成绩：<input type="text" id="txtGrade" name="txtGrade" value="<%=userInfo.CGrade %>"/><br />
            <input type="hidden" name="txtId" value="<%=userInfo.CId %>" /><br />
            <input type="submit" id="btnSave" value="保存" />
        </div>
    </form>
</body>
</html>
