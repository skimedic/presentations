module Bowling.Game

open JetBrains.Annotations

[<Pure>]
let IsValidRoll x = x >= 0 && x <= 10

[<Pure>]
let IsStrike = (=) 10

type public Roll = Roll of int
type public Round = | Strike of Roll * Roll | Spare of Roll * Roll * Roll | Open of Roll * Roll
type public Game =
    | NotStarted
    | InGameRoll1 of Rounds:Round list
    | InGameRoll2 of Rounds:Round list * Last:Roll
    | InGameSpareExtraRoll of Rounds:Round list * Spare1:Roll * Spare2:Roll
    | InGameStrikeExtraRoll1 of Rounds:Round list
    | InGameStrikeExtraRoll2 of Rounds:Round list * Extra1:Roll
    | FinishedGame of Rounds:Round list

[<Pure>]
let IsSpare (l:Roll list) =
    match l with
    | [Roll x; Roll y] -> x + y = 10
    | _ -> false

[<Pure>]
let TryCreateRoll score = if IsValidRoll score then Some(Roll score) else None

[<Pure>]
let FromInGameSpareExtraRoll state roll =
    match state with
    | InGameSpareExtraRoll(rounds, spare1, spare2) ->
        let newRounds = List.append rounds [Spare(spare1, spare2, roll)]
        if newRounds.Length < 10 then Some(InGameRoll1 newRounds, [roll])
        else Some(FinishedGame newRounds, [])
    | _ -> None

[<Pure>]
let FromInGameStrikeExtraRoll1 state extra1 =
    match state with
    | InGameStrikeExtraRoll1(rounds) -> Some <| InGameStrikeExtraRoll2(rounds, extra1)
    | _ -> None

[<Pure>]
let FromInGameStrikeExtraRoll2 state extra2 =
    match state with
    | InGameStrikeExtraRoll2(rounds, extra1) ->
        let newRounds = List.append rounds [Strike(extra1, extra2)]
        if newRounds.Length < 10 then
            let pendingRolls = [extra1; extra2]
            let nextState = InGameRoll1(newRounds)
            Some (nextState, pendingRolls)
        else Some <| (FinishedGame(newRounds), [])
    | _ -> None

[<Pure>]
let FromInGameRoll1 state roll =
    match state with
    | InGameRoll1 rounds ->
        match roll with
        | Roll 10 -> Some <| InGameStrikeExtraRoll1 rounds
        | Roll _ -> Some <| InGameRoll2(rounds, roll)
    | _ -> None

[<Pure>]
let FromInGameRoll2 state roll =
    match state with
    | InGameRoll2(rounds, last) ->
        match (last, roll) with
        | (Roll x, Roll y) when x + y = 10 -> Some <| InGameSpareExtraRoll(rounds, last, roll)
        | (Roll _, Roll _) -> Some <| InGameRoll1([Open(last, roll)] |> List.append rounds)
    | _ -> None

[<Pure>]
let FromNotStarted state =
    match state with
    | NotStarted -> Some <| InGameRoll1([])
    | _ -> None
