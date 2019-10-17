Imports Bowling.Bowling
Imports TechTalk.SpecFlow

Namespace Drivers
    Public Class BowlingDriver
        Private _game As Game

        Public Sub NewGame()
            _game = New Game()
        End Sub

        Public Sub Roll(pins As Integer, rollCount As Integer)
            For i = 1 To rollCount
                _game.Roll(pins)
            Next
        End Sub

        Public Sub Roll(pins1 As Integer, pins2 As Integer, rollCount As Integer)
            For i = 1 To rollCount
                _game.Roll(pins1)
                _game.Roll(pins2)
            Next
        End Sub

        Public Sub RollSeries(series As String)
            For Each roll As String In series.Trim().Split(",")
                _game.Roll(Integer.Parse(roll))
            Next
        End Sub

        Public Sub RollSeries(rolls As Table)
            For Each row As TableRow In rolls.Rows
                _game.Roll(Integer.Parse(row.Item("Pins")))
            Next
        End Sub

        Public Sub CheckScore(expected As Integer)
            Assert.AreEqual(expected, _game.Score)
        End Sub
    End Class
End Namespace