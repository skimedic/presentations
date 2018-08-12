module Bowling.SpecFlow.StepDefinitions

open Bowling.SpecFlow.Drivers
open TechTalk.SpecFlow

[<Binding>]
type public BowlingSteps(driver : BowlingDriver) =
    let _driver : BowlingDriver = driver
    let [<Given>]``a new bowling game``() =
       _driver.NewGame()

    let [<When>]``all of my balls are landing in the gutter``() =
        _driver.Throw 20 0

    let [<When>]``all of my rolls are strikes``() =
        _driver.Throw 12 10
     
    let [<Then>]``my total score should be (\d+)`` score =
        _driver.CheckScore score

    let [<When>]``I roll (\d+)`` pins =
         _driver.Throw 1 pins
     
    let [<When>]``I roll (\d+) and (\d+)`` pins1 pins2 =
        _driver.DoubleThrow 1 pins1 pins2
     
    let [<When>]``I roll (\d+) times (\d+) and (\d+)`` count pins1 pins2 =
        _driver.DoubleThrow count pins1 pins2
     
    let [<When>]``I roll the following series:(.*)`` (series:string) =
        _driver.ThrowSeriesFromString series
     
    let [<When>]``I roll`` (rolls:Table) =
        _driver.ThrowSeriesFromTable rolls