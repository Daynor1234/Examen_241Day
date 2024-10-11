Public Class calculadoraRep
    Inherits System.Web.UI.Page

    ' Variable para mantener el estado de la expresión
    Private Property Expression As String
        Get
            If ViewState("Expression") IsNot Nothing Then
                Return ViewState("Expression").ToString()
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            ViewState("Expression") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Expression = ""
        End If
    End Sub

    ' Manejar la composición de la expresión
    Protected Sub composicion(ByVal sender As Object, ByVal e As EventArgs)
        Expression += DirectCast(sender, Button).Text
        TextBox1.Text = Expression
    End Sub

    ' Limpiar la calculadora
    Protected Sub ButtonClear_Click(ByVal sender As Object, ByVal e As EventArgs)
        Expression = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    ' Convertir la expresión infija a postfija y evaluarla
    Protected Sub ButtonEqual_Click(ByVal sender As Object, ByVal e As EventArgs)
        TextBox2.Text = Expression
        Dim postfijo As String = ConvertirInfijoAPostfijo(Expression)
        TextBox3.Text = postfijo
        Dim resultado As Double = EvaluarPostfijo(postfijo)
        MostrarResultado(resultado)
    End Sub

    ' Función para calcular la raíz cuadrada
    Protected Sub ButtonSqrt_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim n As Double = Convert.ToDouble(TextBox1.Text)
        If n >= 0 Then
            n = Math.Sqrt(n)
            MostrarResultado(n)
        End If
    End Sub

    ' Función para calcular el cuadrado
    Protected Sub ButtonPow_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim n As Double = Convert.ToDouble(TextBox1.Text)
        n = Math.Pow(n, 2)
        MostrarResultado(n)
    End Sub

    ' Método para mostrar el resultado redondeado si es necesario
    Private Sub MostrarResultado(resultado As Double)
        If resultado Mod 1 = 0 Then
            TextBox1.Text = Math.Round(resultado).ToString()
        Else
            TextBox1.Text = resultado.ToString("F5").TrimEnd("0"c).TrimEnd("."c)
        End If
    End Sub

    ' Métodos para la conversión de infijo a postfijo y su evaluación (igual que en la lógica de Windows Forms)
    Public Shared Function Precedencia(ch As Char) As Integer
        Select Case ch
            Case "+"c, "-"c
                Return 1
            Case "*"c, "/"c
                Return 2
            Case "^"c
                Return 3
            Case Else
                Return -1
        End Select
    End Function

    Public Shared Function ConvertirInfijoAPostfijo(exp As String) As String
        Dim resultado As String = ""
        Dim pila As New Stack(Of Char)()

        For i As Integer = 0 To exp.Length - 1
            Dim c As Char = exp(i)

            If Char.IsDigit(c) OrElse c = "."c Then
                While i < exp.Length AndAlso (Char.IsDigit(exp(i)) OrElse exp(i) = "."c)
                    resultado &= exp(i)
                    i += 1
                End While
                resultado &= " "
                i -= 1
            ElseIf c = "("c Then
                pila.Push(c)
            ElseIf c = ")"c Then
                While pila.Count > 0 AndAlso pila.Peek() <> "("c
                    resultado &= pila.Pop() & " "
                End While
                pila.Pop()
            Else
                While pila.Count > 0 AndAlso Precedencia(c) <= Precedencia(pila.Peek())
                    resultado &= pila.Pop() & " "
                End While
                pila.Push(c)
            End If
        Next

        While pila.Count > 0
            resultado &= pila.Pop() & " "
        End While

        Return resultado.Trim()
    End Function

    Public Shared Function EvaluarPostfijo(exp As String) As Double
        Dim pila As New Stack(Of Double)()
        Dim tokens As String() = exp.Split(" "c)

        For Each token As String In tokens
            If Double.TryParse(token, result:=Nothing) Then
                pila.Push(Convert.ToDouble(token))
            Else
                Dim val1 As Double = pila.Pop()
                Dim val2 As Double = pila.Pop()
                Select Case token
                    Case "+"
                        pila.Push(val2 + val1)
                    Case "-"
                        pila.Push(val2 - val1)
                    Case "*"
                        pila.Push(val2 * val1)
                    Case "/"
                        pila.Push(val2 / val1)
                End Select
            End If
        Next

        Return pila.Pop()
    End Function
End Class
