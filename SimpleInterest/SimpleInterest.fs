(*Create a program that computes simple interest. Prompt for
the principal amount, the rate as a percentage, and the time,
and display the amount accrued (principal + interest).
The formula for simple interest is A = P(1 + rt), where P is
the principal amount, r is the annual rate of interest, t is the
number of years the amount is invested, and A is the amount
at the end of the investment.
*)

module ExercisesForProgrammers.SimpleInterest

open System

let getDoubleValue prompt = 
    printf "%s" prompt
    System.Double.Parse(Console.ReadLine())

let calculateInterest principal interestRate duration = 
    let nextPenny = 2
    Math.Round (principal * (1.0 + ((interestRate / 100.0) * duration)), nextPenny)

let annualInterest principal interestRate duration = 
    [for year in 1.0..duration do
        yield (year, calculateInterest principal interestRate year)]

let investmentReceipt duration interestRate investment = 
    printfn "After %d years at %g%% interest, the investment will be worth $%.2f." (int duration) interestRate investment

let printYearlyPrincipal yearlyPrincipal = 
    yearlyPrincipal |> List.iter (fun yearReturn -> printfn "Year %d: $%.2f" (int (fst yearReturn)) (snd yearReturn))

[<EntryPoint>]
let main _ = 
    let principal = getDoubleValue "Enter the principal: "
    let interestRate = getDoubleValue "Enter the interest rate as percentage: "
    let duration = getDoubleValue "Enter the duration of the investment: "
    //much easier to keep everything as a float then convert to int at printing
    let investment = calculateInterest principal interestRate duration
    investmentReceipt duration interestRate investment
    let yearlyPrincipal = annualInterest principal interestRate duration
    printYearlyPrincipal yearlyPrincipal
    Console.ReadKey() |> ignore
    0
