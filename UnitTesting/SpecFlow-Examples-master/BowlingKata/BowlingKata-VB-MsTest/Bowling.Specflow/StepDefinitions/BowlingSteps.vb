Imports Bowling.Bowling
Imports Bowling.Specflow.Drivers
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TechTalk.SpecFlow

Namespace StepDefinitions
    <Binding>
    Public Class BowlingSteps
        Private ReadOnly _driver As BowlingDriver

        Public Sub New(driver As BowlingDriver)
            _driver = driver
        End Sub

        <Given("a new bowling game")>
        Public Sub GivenANewBowlingGame()
            _driver.NewGame()
        End Sub

        <[When]("all of my balls are landing in the gutter")>
        Public Sub WhenAllOfMyBallsAreLandingInTheGutter()
            _driver.Roll(0, 20)
        End Sub

        <[When]("all of my rolls are strikes")>
        Public Sub WhenAllOfMyRollsAreStrikes()
            _driver.Roll(10, 12)
        End Sub

        <[Then]("my total score should be (\d+)")>
        Public Sub ThenMyTotalScoreShouldBe(score As Integer)
            _driver.CheckScore(score)
        End Sub

        <[When]("I roll (\d+)")>
        Public Sub WhenIRoll(pins As Integer)
            _driver.Roll(pins, 1)
        End Sub

        <[When]("I roll (\d+) and (\d+)")>
        Public Sub WhenIRoll(pins1 As Integer, pins2 As Integer)
            _driver.Roll(pins1, pins2, 1)
        End Sub

        <[When]("I roll (\d+) times (\d+) and (\d+)")>
        Public Sub WhenIRollSeveralTimes2(rollCount As Integer, pins1 As Integer, pins2 As Integer)
            _driver.Roll(pins1, pins2, rollCount)
        End Sub

        <[When]("I roll the following series:(.*)")>
        Public Sub WhenIRollTheFollowingSeries(series As String)
            _driver.RollSeries(series)
        End Sub

        <[When]("I roll")>
        Public Sub WhenIRoll(rolls As Table)
            _driver.RollSeries(rolls)
        End Sub
    End Class
End Namespace


