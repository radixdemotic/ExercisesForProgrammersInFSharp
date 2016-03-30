(*Write a program to compute the value of an investment
compounded over time. The program should ask for the
starting amount, the number of years to invest, the interest
rate, and the number of periods per year to compound.

Ensure that all of the inputs are numeric and that the
program will not let the user proceed without valid
inputs.
*)

module ExercisesForProgrammers.CommpoundInterest

open System

let getDoubleValue prompt = 
    printf "%s" prompt
    System.Double.Parse(Console.ReadLine())

//could this be split into two local functions, finding either principal or investment depending on which is supplied?
let calculateCompoundInterest principal interestRate duration compoundingRate = 
    let nextPenny = 2
    Math.Round (principal * Math.Pow ((1.0 + ((interestRate / 100.0) / compoundingRate)), duration * compoundingRate), nextPenny)
    //thought about rewriting this as several partially applied functions, but the individual functions wouldn't return
    //useful results, so this single line is at least a reasonable fascimile of the compounnd interest formula.

let investmentReceipt principal interestRate duration compoundingRate compoundedPrincipal = 
    printfn "$%.2f invested at %.2f%% for %d years compounded %d times per year is %.2f"
        principal interestRate (int duration) (int compoundingRate) compoundedPrincipal

[<EntryPoint>]
let main _ = 
    let principal = getDoubleValue "Enter the principal amount: "
    let interestRate = getDoubleValue "Enter the interest rate as percentage: "
    let duration = getDoubleValue "Enter the duration of the investment: "
    let compoundingRate = getDoubleValue "Enter the number of times the interest is compounded per year: "
    let compoundedPrincipal = calculateCompoundInterest principal interestRate duration compoundingRate
    investmentReceipt principal interestRate duration compoundingRate compoundedPrincipal
    Console.ReadKey() |> ignore
    0