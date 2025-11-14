classDiagram
    class "ICar" {
        <<interface>>
        +int Drive
        +int Attack
        +int Defend
    }
    class "ArmoredCar" {
        -ICar _decoratedCar
        +ArmoredCar(ICar decoratedCar)
        +int Drive
        +int Attack
        +int Defend
    }
    "ArmoredCar" ..|> "ICar"
    "ArmoredCar" --> "ICar"