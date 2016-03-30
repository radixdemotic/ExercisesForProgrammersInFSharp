(*prompts the user for five numbers and
computes the total of the numbers.
Constraints
• The prompting must use repetition, such as a counted
loop, not three separate prompts.
• Create a flowchart before writing the program.
Challenges
• Modify the program to prompt for how many numbers
to add, instead of hard-coding the value. Be sure you
convert the input to a number before doing the comparison*)

module ExercisesForProgrammers.SimpleAddingNumbers

open System
open System.Collections.Generic

let userNumericInput prompt = 
    printf "%s" prompt
    System.Int32.Parse(Console.ReadLine())

let populateNumericList (numericList : List<int>)(counter : int) =
    let rec populateNumericList counter =
        if counter > 0 then
            let numericInput = userNumericInput "Enter a number: "
            numericList.Add(numericInput)
            populateNumericList(counter - 1)
        else numericList
    populateNumericList counter

let sumNumericList userNumericList = Seq.sum userNumericList

let printSum userNumListSum = printfn "The total is %d" userNumListSum

[<EntryPoint>]
let main _ = 
    let inputCounter = userNumericInput "Number of Inputs: "
    let emptyNumericList = List<int>(inputCounter)
    let numericList = populateNumericList emptyNumericList //partial application so the list is only passed once.
    let userNumericList = numericList inputCounter
    let userNumListSum = sumNumericList userNumericList
    printSum userNumListSum
    Console.ReadKey() |> ignore
    0 //main returns integer
