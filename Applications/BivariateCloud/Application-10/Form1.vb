Public Class Form1
    Public rnd As New Random 'Return values between 0 and 1
    Public mFactor = 5 'normalizing factor
    Public numOfPoints = 80 'number of cloud points

    'Random variables
    Public X As New List(Of Double)
    Public Y As New List(Of Double)



    Private Sub FillRandomVariables()
        For i = 0 To numOfPoints - 1
            X.Add(rnd.NextDouble * mFactor)
            Y.Add(rnd.NextDouble * mFactor)
        Next
    End Sub



    'Covariance formula
    'Cov(X,Y) = Sum( (xi - xm) * (yi - ym) ) / (n - 1)

    'Returns the covariance between 2 random variables
    Private Function Covariance(ByVal x As List(Of Double), ByVal y As List(Of Double)) As Double
        Dim c As Double = 0
        Dim meanX = Mean(x)
        Dim meanY = Mean(y)


        For i = 0 To numOfPoints - 1
            c += (x.Item(i) - meanX) * (y.Item(i) - meanY)
        Next
        c = c / (numOfPoints - 1)

        'Console.WriteLine(meanX)
        'Console.WriteLine(meanY)
        'Console.WriteLine(c)
        Return c
    End Function


    'Var(X) = Cov(X,X)

    'Returns the covariance between 2 random variables
    Private Function Variance(ByVal x As List(Of Double)) As Double
        Return Covariance(x, x)
    End Function



    Private Function Mean(ByVal x As List(Of Double)) As Double
        Dim m As Double = 0

        For Each i In x
            m += (i - m)
        Next

        Return m

    End Function



    Private Sub DrawChart()
        'Clear chart
        Me.Chart1.Series(0).Points.Clear()
        Me.Chart1.Series(1).Points.Clear()

        'Draw points
        For i = 0 To numOfPoints - 1
            Me.Chart1.Series(0).Points.AddXY(Me.X.Item(i), Me.Y(i))
        Next



        'Draw regression line
        'Equation formula
        ' y = ALPHA*x + BETA
        ' Alpha = (cov(X,Y)/var(X)) 
        ' Beta  = -((cov(X,Y)/var(x))*meanX) + meanY

        Dim SAME = Covariance(Me.X, Me.Y) / Covariance(X, X)
        Dim Alpha As Double = SAME
        Dim Beta As Double = -(SAME * Mean(X)) + Mean(Y)

        Dim minX As Double = Me.X.Min 'min X value
        Dim maxX As Double = Me.X.Max 'max X value

        Dim minY As Double = (Alpha * minX) + Beta
        Dim maxY As Double = (Alpha * maxX) + Beta

        Me.Chart1.Series(1).Points.AddXY(minX, minY)
        Me.Chart1.Series(1).Points.AddXY(maxX, maxY)

    End Sub





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.FillRandomVariables()
        Me.Covariance(Me.X, Me.Y)
        Me.DrawChart()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
