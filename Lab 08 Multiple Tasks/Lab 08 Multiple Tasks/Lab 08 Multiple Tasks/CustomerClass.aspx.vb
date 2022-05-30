Public Class CustomerClass
    Inherits System.Web.UI.Page

    Dim customer1 As New Customer("Usama", "Abbasi")
    Dim customer2 As New Customer("Abdullah", "Abbasi")
    Dim customer3 As New Customer("Danish", "Abbasi")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ViewState("Customer1") = customer1
        ViewState("Customer2") = customer2
        ViewState("Customer3") = customer3
        TextBox1.Text = ""

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        Dim cust1 As Customer = CType(ViewState("Customer1"), Customer)
        TextBox1.Text = cust1.FirstName & cust1.LastName & "  "

        Dim cust2 As Customer = CType(ViewState("Customer2"), Customer)
        TextBox1.Text &= cust2.FirstName & cust2.LastName & "  "

        Dim cust3 As Customer = CType(ViewState("Customer3"), Customer)
        TextBox1.Text &= cust3.FirstName & cust3.LastName & "  "

    End Sub

    <Serializable()>
    Public Class Customer
        Private _firstName As String
        Public Property FirstName() As String
            Get
                Return _firstName
            End Get

            Set(ByVal Value As String)
                _firstName = Value
            End Set
        End Property

        Private _lastName As String
        Public Property LastName() As String
            Get
                Return _lastName
            End Get

            Set(ByVal Value As String)
                _lastName = Value
            End Set
        End Property

        Public Sub New(ByVal firstName As String, ByVal lastName As String)
            Me.FirstName = firstName
            Me.LastName = lastName
        End Sub

    End Class
End Class