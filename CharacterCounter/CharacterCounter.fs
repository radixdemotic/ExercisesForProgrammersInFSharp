//Prompt for input string
//displays output that shows 
//input string and 
//number of characters the string contains.
//Challenge: If the user enters nothing, state that the user must enter something into the program.
// InputString adapted from http://codereview.stackexchange.com/questions/39558/reading-input-from-the-console-in-f

module ExercisesForProgrammers.CharacterCounter

let rec InputString input =
    match System.Console.ReadLine() with
    | "" | null -> printfn "Must enter an input string"; InputString input
    | input -> input

printfn "Enter a string of characters, have the characters counted: "

let userString = InputString()

printfn "%s has %d characters." userString (String.length userString)

System.Console.ReadKey() |> ignore