<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="calculadoraRep.aspx.vb" Inherits="CalculadoraWeb.calculadoraRep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Calculadora Web</title>
    <style>
        .calc-container {
            width: 250px;
            margin: 0 auto;
        }
        .calc-display {
            text-align: right;
            margin-bottom: 10px;
        }
        table {
            width: 100%;
        }
        td {
            padding: 5px;
        }
        .btn {
            width: 100%;
            height: 40px;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="calc-container">
            <h1>Calculadora</h1>

            <asp:TextBox ID="TextBox1" runat="server" CssClass="calc-display" ReadOnly="true" Width="228px"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="calc-display" ReadOnly="true" Width="228px"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="calc-display" ReadOnly="true" Height="16px" Width="229px"></asp:TextBox>

            <table>
                <tr>
                    <td><asp:Button ID="Button7" runat="server" Text="7" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="Button8" runat="server" Text="8" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="Button9" runat="server" Text="9" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="ButtonClear" runat="server" Text="C" CssClass="btn" OnClick="ButtonClear_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="Button4" runat="server" Text="4" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="Button5" runat="server" Text="5" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="Button6" runat="server" Text="6" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="ButtonSqrt" runat="server" Text="√" CssClass="btn" OnClick="ButtonSqrt_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="Button1" runat="server" Text="1" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="Button2" runat="server" Text="2" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="Button3" runat="server" Text="3" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="ButtonPow" runat="server" Text="x²" CssClass="btn" OnClick="ButtonPow_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="Button0" runat="server" Text="0" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="ButtonDot" runat="server" Text="." CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="ButtonEqual" runat="server" Text="=" CssClass="btn" OnClick="ButtonEqual_Click" /></td>
                    <td><asp:Button ID="ButtonDiv" runat="server" Text="/" CssClass="btn" OnClick="composicion" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="ButtonAdd" runat="server" Text="+" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="ButtonSub" runat="server" Text="-" CssClass="btn" OnClick="composicion" /></td>
                    <td><asp:Button ID="ButtonMul" runat="server" Text="*" CssClass="btn" OnClick="composicion" /></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
