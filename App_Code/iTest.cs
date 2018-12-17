using System;

namespace Hinet
{
    public interface iTest
    {
        string Accounting(string aa_ServerName, string aa_OTPW, string aa_Fee, string aa_ApID, string aa_STime, string aa_SRemark, string aa_ProductID, string aa_Authority);

        string AddDiffItem(string ItemName);

        string APAuthenticate(string aa_ServerName, string aa_OTPW, string aa_Fee, string aa_ApID, string aa_ProductID, string aa_Authority);

        string Authorize(string aa_ServerName, string aa_OTPW, string aa_Fee, string aa_ApID, string aa_ProductID, string aa_Authority);

        string GetCurTime();

        string GetMonthSubscribeNo();

        string GetMonthSubscribeNoEx(string Item);

        string GetMonthSubscribePolicyEx(string Item, string attrib);

        string GetOTPW();

        string GetPolicy(string attrib);

        string HinetMemberQuerySubscribe(string aa_ServerName, string aa_ProductID, string aa_OTPW, string aa_TotalMonth, string aa_Reserved);

        string HinetMemberQuerySubscribeEx(string aa_ServerName, string aa_ProductID, string aa_OTPW, string aa_TotalMonth, string aa_SettingCharge, string aa_InstallCharge, string aa_FirstCharge, string aa_Reserved);

        string HinetMemberUnSubscribe(string aa_ServerName, string aa_ProductID, string aa_OTPW, string aa_ActionDate, string aa_Reserved);

        string Make1AChecksum(string aa_Version, string aa_ProductID, string aa_curl, string aa_eurl, string aa_Fee, string aa_others);

        string MMAXGetResult(string Name);

        string MMAXMbrQuery(string aa_ServerName, string aa_ProductID, string aa_MbrOTPW, string aa_Alias);

        string MMAXQuery(string aa_ServerName, string aa_ProductID, string aa_UserID, string aa_Alias);

        string MonthQuery(string aa_ServerName, string aa_Alias, string aa_SubscribeNO, string aa_ProductID, string aa_ApID, string aa_Reserved);

        string MonthSubscribe(string aa_ServerName, string aa_Alias, string aa_ProductID, string aa_ApID, string aa_OTPW, string aa_Authority, string aa_ActionDate, string aa_TotalMonth, string aa_Reserved);

        string MonthSubscribeEx(string aa_ServerName, string aa_Alias, string aa_ProductID, string aa_ApID, string aa_OTPW, string aa_Authority, string aa_ActionDate, string aa_TotalMonth, string aa_SettingCharge, string aa_InstallCharge, string aa_FirstCharge, string aa_Reserved);

        string MonthSubscribePhysicalEx(string aa_ServerName, string aa_Alias, string aa_ProductID, string aa_ApID, string aa_OTPW, string aa_Authority, string aa_ActionDate, string aa_TotalMonth, string aa_SettingCharge, string aa_InstallCharge, string aa_FirstCharge, string aa_Rent, string aa_Amount, string aa_DiffMsg, string aa_Reserved);

        string MonthUnSubscribe(string aa_ServerName, string aa_Alias, string aa_SubscribeNO, string aa_ProductID, string aa_ApID, string aa_ActionDate, string aa_Reserved);

        string MonthUnSubscribePhysicalEx(string aa_ServerName, string aa_Alias, string aa_SubscribeNO, string aa_ProductID, string aa_ApID, string aa_ActionDate, string aa_Amount, string aa_Reserved);

        string Version();
    }
}