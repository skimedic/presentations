#language:de

Funktionalität: Punkteberechnung (mit alternativen Definitionen)
    Als Spieler
    Will ich, dass das System meine Punktezahl berechnet
    Damit ich weiss wie gut ich bin

Szenario: Ein einziger Spare
    Gegeben sei eine neue Bowling-Partie
    Wenn ich folgende Serie werfe: 3,7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
    Dann soll meine Punktzahl 29 sein

Szenario: Nur Spares
    Gegeben sei eine neue Bowling-Partie
    Wenn ich 10 mal 1 und 9 werfe
    Und ich 1 werfe
    Dann soll meine Punktzahl 110 sein

Szenario: Noch ein weiteres Anfänger-Spiel
    Gegeben sei eine neue Bowling-Partie
    Wenn ich werfe
    | Pins  |
    |	2   |
    |	7   |
    |	1   |
    |	5   |
    |	1   |
    |	1   |
    |	1   |
    |	3   |
    |	1   |
    |	1   |
    |	1   |
    |	4   |
    |	1   |
    |	1   |
    |	1   |
    |	1   |
    |	8   |
    |	1   |
    |	1   |
    |	1   |
    Dann soll meine Punktzahl 43 sein