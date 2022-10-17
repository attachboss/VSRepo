<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessFile.aspx.cs" Inherits="ThreeLayerFramework.FileResource.ProcessFile" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>
    <form method="post" action="ProcessFile.aspx" enctype="multipart/form-data">
        <input type="file" name="fileUp"/><br />
        <input type="submit" value="上传"/>
    </form>
</body>
</html>