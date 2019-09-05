<%@ Page Language="C#" Inherits="PhoneGen.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">

            <table align="center">
                <tr>
                    <td>
                        Enter a phone number (7 or 10 digits only)  <input id="txtPhNum" type="text" maxlength="10" runat="server"/>
                        </td>
                    <td>
                        <asp:Button id="btnSubmit" runat="server" Text="Submit!" OnClick="btnSubmitClicked" />
                    </td>
                    </tr>
                <tr>
                    <td colspan="2">
                        <asp:RegularExpressionValidator id="phNumValidation" runat="server" ControlToValidate="txtPhNum" ValidationExpression="^([0-9]{7})$|^([0-9]{10})$"
                                            ErrorMessage="Enter a Valid 7 or 10 digit phone number." Display="Static" EnableClientScript="false"
                                            ></asp:RegularExpressionValidator>
        
                        </td>
                    </tr>
                <tr>
                    <td colspan="2">
                            <asp:Literal id="ltNumberOutput" runat="server"/>
                        </td>
                    </tr>
            </table>
                        
            <asp:GridView id="grdPhGrid" runat="server" AutoGenerateColumns="true" EmptyDataText="No Data generated" AllowPaging="true" HorizontalAlign="Center"
                      OnPageIndexChanging="grdPhGrid_PageIndexChanging"   >
                          
                <PagerStyle height="40px"></PagerStyle>
                <PagerSettings mode="Numeric" position="Bottom" pagebuttoncount="10"></PagerSettings>
            </asp:GridView>
	</form>
</body>
</html>
