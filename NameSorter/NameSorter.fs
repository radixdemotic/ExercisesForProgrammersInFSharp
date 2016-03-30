(*Read this program and sort the list alphabetically. Then print
the sorted list to a file that looks like the following example
output.
(There is no input. The location of the file is hardcoded.)
Example Output
Total of 7 names
-----------------
Ling, Mai
Johnson, Jim
Jones, Aaron
Jones, Chris
Swift, Geoffrey
Xiong, Fong
Zarnecki, Sabrina
Constraint
• Don’t hard-code the number of names.

From Expert F#
open System.IO
File.WriteAllLines("employees.txt", Array.create 10000 line)
let readEmployees (fileName : string) =
fileName |> File.ReadLines |> Seq.map parseEmployee
let firstThree = readEmployees "employees.txt" |> Seq.truncate 3 |> Seq.toList
*)

module ExercisesForProgrammers.NameSorter

open System
open System.IO

[<Literal>]
let path = "A:\Programming\FSharp\ExercisesForProgrammers\NameSorter\Names.txt"

let readNames = path |> File.ReadLines |> Seq.cast<string>

let total namesSeq = 
    Seq.length namesSeq

let sortNamesByAlpha namesSeq =
    Seq.sort namesSeq

let printTotal namesTotal = 
    printfn "Total of %d names" namesTotal
    printfn "------------------"

let printSortedNames namesAlphaSorted = 
    Seq.iter (fun name -> printfn "%s" name) namesAlphaSorted

[<EntryPoint>]
let main _ = 
    let namesSeq = readNames
    let namesTotal = total namesSeq
    printTotal namesTotal
    let namesAlphaSorted = sortNamesByAlpha namesSeq
    printSortedNames namesAlphaSorted
    Console.ReadKey() |> ignore
    0 // return an integer exit code
