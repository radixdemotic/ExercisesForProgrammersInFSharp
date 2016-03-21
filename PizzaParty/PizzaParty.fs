(* Write a program to evenly divide pizzas. Prompt for the
number of people, the number of pizzas, and the number of
slices per pizza. Ensure that the number of pieces comes out
even. Display the number of pieces of pizza each person
should get. If there are leftovers, show the number of leftover
pieces.

from: 
http://stackoverflow.com/questions/30460487/f-exception-handling-how-to-parse-number-in-readline
let rec queryGuess () =
    printf "please input your guess " 
    let input = Console.ReadLine()
    match System.Int32.TryParse input with
    | (true, number) when number >= 1 && number <= 100
                     -> number
    | _              -> printfn "sorry - please enter a number between 1 and 100"
                        queryGuess ()

Should assign a pluralization or a no slices leftover using a match case.*)

module ExercisesForProgrammers.PizzaParty

open System

//should really recursively gather and check for a positive integer input
let GetIntegerInput () = System.Int32.Parse(Console.ReadLine())

let Party =
    printf "How many people in your party? "
    GetIntegerInput ()

let Pizzas = 
    printf "How many pizzas do you have? "
    GetIntegerInput ()

let Slices = 
    printf "How many slices in each pizza? "
    GetIntegerInput ()

let TotalSlices = Pizzas * Slices

let Serving, Leftovers = TotalSlices / Party, TotalSlices % Party

let PizzaParty () =
    printfn "%d people with %d pizzas" Party Pizzas
    printfn "Each person gets %d slices of pizza." Serving
    printfn "There are %d leftover slices." Leftovers

[<EntryPoint>]
let main _ =
    PizzaParty ()
    System.Console.ReadKey() |> ignore
    0