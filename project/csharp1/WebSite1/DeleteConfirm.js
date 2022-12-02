if (confirm("确认要删除吗?")) {
    var xmlHttpReq = new XMLHttpRequest();
    xmlHttpReq.open("DeleteCourse.ashx?课程代码={1}'");
}