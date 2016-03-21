(*Create a simple self-checkout system. Prompt for the prices
and quantities of three items. Calculate the subtotal of the
items. Then calculate the tax using a tax rate of 5.5%. Print
out the line items with the quantity and total, and then print
out the subtotal, tax amount, and total.
Example Output
Enter the price of item 1: 25
Enter the quantity of item 1: 2
Enter the price of item 2: 10
Enter the quantity of item 2: 1
Enter the price of item 3: 4
Enter the quantity of item 3: 1
Subtotal: $64.00
Tax: $3.52
Total: $67.52

Two lists, one integer for stuff and one float
recursively cons to the list until quantity = 0
-play along with constraints and create a list of strings from subtotal, tax, and total
Pass that list to a printer function

I'm just going to do this the dumb way to start, since the proper way satisfies both
challenges. I'll practice using ::

*)

module ExercisesForProgrammers.SelfCheckout

open System
//open System.Collections.Generic to add one at a time to a list through console input

[<Literal>]
let salesTax = 0.055

let promptQuantity itemNumber = sprintf "Enter the quantity of item %d: " itemNumber

let promptPrice itemNumber = sprintf "Enter the price of item %d: " itemNumber

let getItem itemNumber:int = 
    printf "%s" (promptQuantity itemNumber)
    Int32.Parse(Console.ReadLine())

let getPrice itemNumber =
    printf "%s" (promptPrice itemNumber)
    Double.Parse(Console.ReadLine())

let calculateSubtotal items prices = 
    List.map2 (fun item price -> item * price) (List.map float items) prices
    |> List.sum
    |> fun subTotal -> Math.Round (subTotal, 2)

let calculateSalesTax subTotal = Math.Round (subTotal * salesTax, 2)

let calculateGrandTotal (subTotal: float) (salesTax: float) = Math.Round (subTotal + salesTax, 2)

let printReceipt subTotal subTax grandTotal =
    printfn "Subtotal: $%.2f" subTotal
    printfn "Tax: $%.2f" subTax
    printfn "Total: $%.2f" grandTotal

[<EntryPoint>]
let main _ =
    let item1, price1 = getItem 1, getPrice 1
    let item2, price2 = getItem 2, getPrice 2
    let item3, price3 = getItem 3, getPrice 3
    let items = [item1; item2; item3]
    let prices = [price1; price2; price3]
    let subTotal = calculateSubtotal items prices
    let subTax = calculateSalesTax subTotal
    let grandTotal = calculateGrandTotal subTotal subTax
    printReceipt subTotal subTax grandTotal
    Console.ReadKey() |> ignore
    0