<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hinet_payment_r.aspx.cs" Inherits="hinet_payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
 <p>包月方案測試</p>
 <p> <%  =this.checksum%></p>
 <p> <%  =this.checksum_curr%></p>
  
    <form  method=POST action="https://aaav2.hinet.net/A1/AuthScreen.jsp">
    <input type=hidden name=aa-version value=<%=this.version %>>
    <input type =number name=aa-productid value=<%=this.productid %>>
    <input type=hidden name=aa-curl value=<%=this.curl %>>
    <input type=text name=aa-device value=phone>
    <input type=hidden name=aa-eurl value=<%=this.eurl %>>
    <input type=hidden name=aa-fee value=<%=this.fee %>>
    <input type=hidden name=aa-other value=<%=this.other %>>
    <input type=hidden name=aa-sum value=<%=this.checksum %>>
    <input type=submit name=submit value="連接至中華電信" >
    </form>
</body>
</html>
