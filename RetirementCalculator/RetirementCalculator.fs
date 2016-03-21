(* Create a program that determines how many years you have
left until retirement and the year you can retire. It should
prompt for your current age and the age you want to retire
and display the output as shown in the example that follows.

Example Output
What is your current age? 25
At what age would you like to retire? 65
You have 40 years left until you can retire.
It's 2015, so you can retire in 2055.
Constraints
• Again, be sure to convert the input to numerical data
before doing any math.
• Don’t hard-code the current year into your program.
Get it from the system time via your programming language. *)

module ExerciesForProgrammers.RetirementCalculator

open System

let userIntegerInput () = System.Int32.Parse(Console.ReadLine())

let currentYear = System.DateTime.Today.Year

printf "What is your current age? "

let userAge = userIntegerInput ()

printf "At what age would you like to retire? "

let userRetirementAge = userIntegerInput ()

let yearsUntilRetirement = userRetirementAge - userAge

let retirementYear = currentYear + yearsUntilRetirement

printfn "You have %d years left until you can retire. It's %d, so you can retire in %d."
    yearsUntilRetirement currentYear retirementYear

System.Console.ReadKey() |> ignore