(*Write a simple program to compute the tax on an order
amount. The program should prompt for the order amount
and the state. If the state is “WI,” then the order must be
charged 5.5% tax. The program should display the subtotal,
tax, and total for Wisconsin residents but display just the
total for non-residents.

Implement this program using only a simple if statement—
don’t use an else clause.
• Ensure that all money is rounded up to the nearest cent.

Allow the user to enter a state abbreviation in upper,
lower, or mixed case.
• Also allow the user to enter the state’s full name in
upper, lower, or mixed case. (if input.toUpper = WI or input.toUpper = Wisconsin then ...)

*)

module ExercisesForProgrammers.SalesTaxCalculator

open System

//sensible to pass in a parser as an optional argument along with the prompt
//type parseInput with members for different parsers?
let getDoubleInput prompt =
    printf "%s" prompt
    System.Double.Parse(Console.ReadLine())

let getStringInput prompt = 
    printf "%s" prompt
    Console.ReadLine()

//as an if statement: if orderState.ToUpper() = "WI" || orderState.ToUpper() = "WISCONSIN" then 0.055 else 0.
// else has to be used unless the function is a unit type, which wouldn't be helpful here.

let getStateTax (orderState : string) = 
    match orderState.ToUpper() with
    | ("WI" | "WISCONSIN") -> 0.055
    | _ -> 0.

//possible to map sales tax on a list of orderAmounts for a zippable list of taxes. e.g. let getWITax = getTaxAmount 0.055
// listOfAmounts |> List.map getWITax and List.zip amounts (amounts |> List.map getWITax)
let getTaxAmount (stateTax:float) (orderAmount:float) = 
    Math.Round (orderAmount * stateTax, 2)

let calculateTotal (orderAmount:float) (salesTax : float) = 
    Math.Round (orderAmount + salesTax, 2)

let printReceipt orderAmount salesTax grandTotal = 
    if salesTax <> 0.0 then printfn "The subtotal is: $%.2f." orderAmount; printfn "The tax is $%.2f." salesTax
    printfn "The total is $%.2f." grandTotal

[<EntryPoint>]
let main _ = 
    let orderAmount = getDoubleInput "Enter the Order Amount: "
    let orderState = getStringInput "Enter the state of Order: "
    let stateTax = getStateTax orderState
    let salesTax = getTaxAmount stateTax orderAmount
    let grandTotal = calculateTotal orderAmount salesTax
    printReceipt orderAmount salesTax grandTotal
    Console.ReadKey() |> ignore
    0
