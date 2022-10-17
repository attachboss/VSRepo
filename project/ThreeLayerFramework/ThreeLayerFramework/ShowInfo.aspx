<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowInfo.aspx.cs" Inherits="ThreeLayerFramework.ShowInfo" %>

<!DOCTYPE html>
<%@ Import Namespace="ThreeLayer.Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/TableSheet.css" rel="stylesheet" />
    <script src="js/jquery-3.6.0.min.js"></script>
    <script>
        window.onload = function () {
            var deleteElements = document.getElementsByClassName("delete");
            for (let i = 0; i < deleteElements.length; i++) {
                deleteElements[i].onclick = function () {
                    if (!confirm("确定要删除吗?")) {
                        return false;
                    }
                }
            }
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="AllCourse">
                <thead>
                    <tr>
                        <th>课程名</th>
                        <th>课程代码</th>
                        <th>任课教师</th>
                        <th>学分</th>
                        <th>成绩</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        foreach (UserInfo userInfo in List)
                        {
                    %>
                    <tr>
                        <td><%=userInfo.CName %></td>
                        <td><%=userInfo.CId %></td>
                        <td><%=userInfo.CTeacher %></td>
                        <td><%=userInfo.CCredit %></td>
                        <td><%=userInfo.CGrade %></td>
                        <td><a href="DeleteInfo.ashx?CId=<%=userInfo.CId %>" class="delete">删除</a></td>
                        <td><a href="EditInfo.aspx?CId=<%=userInfo.CId %>" class="edit">编辑</a></td>
                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
            <div name="changePage">
                <a name="firstPage" href="ShowInfo.aspx?pageIndex=1">首页</a> | <a name="prePage">前页</a> | <a name="nextPage">后页</a> | <a name="endPage" href="ShowInfo.aspx?pageIndex=">尾页</a> | <b>页次：<a name="nowPage"></a>/<a name="totalPage"></a>页</b>
            </div>
            <a href="InsertInfo.aspx">添加信息</a>
        </div>
    </form>
</body>
</html>
