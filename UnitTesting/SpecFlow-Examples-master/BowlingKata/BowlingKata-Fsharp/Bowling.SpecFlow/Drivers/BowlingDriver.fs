namespace Bowling.SpecFlow.Drivers

open System
open Bowling.Game
open Bowling.Extensions
open FluentAssertions;
open TechTalk.SpecFlow

type public BowlingDriver() =
    let mutable _currentGame : Game = NotStarted;
    let rec DoRound state =
        match state with
        | InGameRoll1 _ -> FromInGameRoll1 state
        | InGameRoll2(_, _) -> FromInGameRoll2 state
        | InGameStrikeExtraRoll1(_) -> FromInGameStrikeExtraRoll1 state
        | InGameStrikeExtraRoll2(_, _) ->
            fun r ->
                match FromInGameStrikeExtraRoll2 state r with
                | None -> None
                | Some(nextState, pendingRolls) ->
                    pendingRolls
                    |> List.fold (fun s p -> match s with | Some x -> DoRound x p | None -> s) (Some nextState)
        | InGameSpareExtraRoll(_, _, _) ->
            fun r ->
                match FromInGameSpareExtraRoll state r with
                | None -> None
                | Some(nextState, pendingRolls) ->
                    pendingRolls
                    |> List.fold (fun s p -> match s with | Some x -> DoRound x p | None -> s) (Some nextState)
        | _ -> fun _ -> None

    member public __.NewGame() =
        _currentGame <- match FromNotStarted _currentGame with
                        | Some x -> x
                        | None -> _currentGame

    member public this.Throw rollCount pins : unit =
        if rollCount < 1 then ()
        else
            match TryCreateRoll pins with
            | Some(Roll x) ->
                _currentGame <- match DoRound _currentGame << Roll <| x with
                                | Some newState -> newState
                                | None -> FinishedGame []

                this.Throw (rollCount - 1) pins
            | None -> ()


    member public this.DoubleThrow rollCount pins1 pins2 : unit =
        if rollCount < 1 then ()
        else
            this.Throw 1 pins1
            this.Throw 1 pins2
            this.DoubleThrow (rollCount - 1) pins1 pins2
        
    
    member public this.ThrowSeriesFromString (series:string) : unit =
        series.Trim().Split(',')
        |> Seq.map Int32.Parse
        |> Seq.iter (this.Throw 1)
    
    member public this.ThrowSeriesFromTable (series:Table) : unit =
        series.Rows
        |> Seq.map (fun r -> r.Item("Pins"))
        |> Seq.map Int32.Parse
        |> Seq.iter (this.Throw 1)

    member public __.CheckScore expected : unit =
        let actualScore =
            match _currentGame with
            | InGameRoll1(rolls)
            | InGameRoll2(rolls, _)
            | InGameStrikeExtraRoll1(rolls)
            | InGameStrikeExtraRoll2(rolls, _)
            | InGameSpareExtraRoll(rolls, _, _)
            | FinishedGame(rolls) -> rolls.GetScore()
            | _ -> 0

        ignore <| actualScore.Should<int>().Be(expected, String.Empty)
