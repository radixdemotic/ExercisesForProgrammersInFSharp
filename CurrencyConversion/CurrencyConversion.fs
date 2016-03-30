(* Very basic initial pass.

Write a program that converts currency. Specifically, convert
euros to U.S. dollars. Prompt for the amount of money in
euros you have, and prompt for the current exchange rate
of the euro. Print out the new amount in U.S. dollars. The
formula for currency conversion is
amountto = amountfrom × ratefrom / rateto
where:
• Amount to is the amount in U.S. dollars.
• Amount from is the amount in euros.
• rate from is the current exchange rate in euros.
• rate to is the current exchange rate of the U.S. dollar.
Example Output
How many euros are you exchanging? 81
What is the exchange rate? 137.51
81 euros at an exchange rate of 137.51 is
111.38 U.S. dollars.
Constraints
• Ensure that fractions of a cent are rounded up to the
next penny.
• Use a single output statement.*)

module ExercisesForProgrammers.CurrencyConversion

open System

let getDoubleValue prompt = 
    printf "%s" prompt
    System.Double.Parse(Console.ReadLine())

let conversionCalculator amountEUR exchangeRate = 
    let baserate = 100.0
    Math.Round (amountEUR * exchangeRate / baserate, 2)

let printConversionResult amountEUR conversionRate amountUSD = 
    printfn "%.2f Euros at an exchange rate of $%.2f per Euro is $%.2f." amountEUR conversionRate amountUSD

[<EntryPoint>]
let main _ =
    //when prompting for currency, specify the base rate? Assume base rate of 100.0
    let amountEUR = getDoubleValue "How many Euros are you exchanging? "
    let EURtoUSDExchangeRate = getDoubleValue "What is the EUR->USD exchange rate with a base of 100? "
    let amountUSD = conversionCalculator amountEUR EURtoUSDExchangeRate
    printConversionResult amountEUR EURtoUSDExchangeRate amountUSD
    Console.ReadKey() |> ignore
    0