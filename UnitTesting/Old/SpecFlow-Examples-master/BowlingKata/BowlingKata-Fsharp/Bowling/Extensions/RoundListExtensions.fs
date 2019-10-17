namespace Bowling.Extensions

open System.Runtime.CompilerServices
open Bowling.Game
open JetBrains.Annotations

[<Extension>]
type public RoundListExtensions () =
    [<Pure>]
    static let rec GetScoreRec rounds currentScore =
        match rounds with
        | [] -> currentScore
        | h::t -> 
            match h with
            | Strike(Roll e1, Roll e2) -> GetScoreRec t (currentScore + 10 + e1 + e2)
            | Spare(Roll _, Roll _, Roll e) -> GetScoreRec t (currentScore + 10 + e)
            | Open(Roll r1, Roll r2) -> GetScoreRec t (currentScore + r1 + r2)

    [<Extension>]
    [<Pure>]
    static member public GetScore(self : Round list) = GetScoreRec self 0
