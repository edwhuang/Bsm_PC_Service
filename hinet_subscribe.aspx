<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hinet_subscribe.aspx.cs" Inherits="hinet_payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
 <p>包月方案測試</p>
  <%= this.result_code %>
  <!--form  method=POST action="http://localhost:1679/BSM_PC_SERVICE/hinet_auth.aspx"--!>
      <form  method=POST action="https://aaav2.hinet.net/HinetMember/Subscribe">
      <input type=text name=Alias value=<%=this.aa_Alias %>>
      <input type=text name=ProductID value=<%=this.aa_ProductID %>>
      <input type=text name=MixCode value=<%=this.aa_MixCode %>>
      <input type=text name=ActionDate value=<%=this.aa_ActionDate %>>
      <input type=text name=TotalMonth value=<%=this.aa_TotalMonth %>>
      <input type=text name=SettingCharge value=<%=this.aa_SettingCharge %>>
      <input type=text name=InstallCharge value=<%=this.aa_InstallCharge %>>
      <input type=text name=FirstCharge value=<%=this.aa_FirstCharge %>>
      <input type=text name=Amount value=<%=this.aa_Amount %>>
      <input type=text name=Rent value=<%=this.aa_Rent %>>
      <input type=text name=CheckSum value=<%=this.aa_CheckSum %>>
      <input type=text name=ApID value=<%=this.aa_ApID %>>
      <input type=text name=DiffMsg value=<%=this.aa_DiffMsg %>>
      <input type=text name=Reserved value=<%=this.aa_Reserved %>>
       <input type=submit name=submit value="連接至中華電信" >
    </form>
</body>
</html>
