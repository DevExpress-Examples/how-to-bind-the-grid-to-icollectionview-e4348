Public NotInheritable Class MainPage
    Inherits Page
    Private grid_data As New DataModel()
    Public Sub New()
        Me.DataContext = grid_data
        Me.InitializeComponent()

    End Sub

    Public Class DataModel
        Private privateData As ICollectionView
        Public Property Data() As ICollectionView
            Get
                Return privateData
            End Get
            Set(ByVal value As ICollectionView)
                privateData = value
            End Set
        End Property
        Public Sub New()
            Data = New CollectionViewSource() With {.Source = CreateList()}.View
        End Sub
    End Class

    Public Shared Function CreateList() As IList
        Dim list As New List(Of TestData)()
        For i As Integer = 0 To 99
            list.Add(New TestData() With {.Number1 = i, .Number2 = i * 10, .Text1 = "row " & i, .Text2 = "ROW " & i})
        Next i
        Return list
    End Function
    Public Class TestData
        Private privateNumber1 As Integer
        Public Property Number1() As Integer
            Get
                Return privateNumber1
            End Get
            Set(ByVal value As Integer)
                privateNumber1 = value
            End Set
        End Property
        Private privateNumber2 As Integer
        Public Property Number2() As Integer
            Get
                Return privateNumber2
            End Get
            Set(ByVal value As Integer)
                privateNumber2 = value
            End Set
        End Property
        Private privateText1 As String
        Public Property Text1() As String
            Get
                Return privateText1
            End Get
            Set(ByVal value As String)
                privateText1 = value
            End Set
        End Property
        Private privateText2 As String
        Public Property Text2() As String
            Get
                Return privateText2
            End Get
            Set(ByVal value As String)
                privateText2 = value
            End Set
        End Property
    End Class

    Private Sub Button_Left(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If grid_data.Data.CurrentPosition = 0 Then
            grid_data.Data.MoveCurrentToLast()
        Else
            grid_data.Data.MoveCurrentToPrevious()
        End If
    End Sub

    Private Sub Button_Right(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If grid_data.Data.CurrentItem Is grid_data.Data.Last() Then
            grid_data.Data.MoveCurrentToFirst()
        Else
            grid_data.Data.MoveCurrentToNext()
        End If
    End Sub
End Class
