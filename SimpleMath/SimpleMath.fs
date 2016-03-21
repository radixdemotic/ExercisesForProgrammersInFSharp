(* 
Write a program that prompts for two numbers. Print the
sum, difference, product, and quotient of those numbers.

Constraints
• Values coming from users will be strings. Ensure that
you convert these values to numbers before doing the
math.
• Keep the inputs and outputs separate from the numerical
conversions and other processing.
• Generate a single output statement with line breaks in
the appropriate spots. *)

module ExercisesForProgrammers.SimpleMath

open System
open Printf

let IntFromStringInput () = System.Int32.Parse (Console.ReadLine())

printf "What is the first number? "

let firstnumber = IntFromStringInput ()

printf "What is the second number? "

let secondnumber = IntFromStringInput ()

let simpleArithmeticOperators = [(+); (-); (*); (/)]

let simpleArithmeticStrings = ["+"; "-"; "*"; "/"]
//this is hard coded. the operators have to match with the way the operators are ordered.

let simpleArithmetic (firstnumber: int) (secondnumber: int) (operation: (int -> int -> int)) = (operation) firstnumber secondnumber

let arithmeticResults = simpleArithmeticOperators |> List.map (fun operation -> simpleArithmetic firstnumber secondnumber operation)

let printPairs = List.zip simpleArithmeticStrings arithmeticResults

let printableResults = printPairs |> List.map (fun (operation, result) -> sprintf "%d %s %d = %d" firstnumber operation secondnumber result)

printableResults |> List.iter (fun result -> printfn "%s" result)

System.Console.ReadKey() |> ignore