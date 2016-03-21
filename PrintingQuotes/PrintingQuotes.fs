(* Prompt for a Quote and an Author.
Display the Quote and Author in a single Output
Use String Concatenation (could use pluses to concat and print in next line, but unnecessary.)

- could manually create the dict by casting on a array of pairs.
- could also have an array<string> since single key/attribution has multiple values/quotes.
  a nested for line could be used to iterate through the array.

Alternative: Instead of prompting for Quotes, 
hold quotes and attributions in a structure
map each key,value pair to the printingformat *)

module ExercisesForProgrammers.PrintingQuotes

open System.Collections.Generic

printf "What is the quote? "

let quote = System.Console.ReadLine()

printf "Who said it? "

let attribution = System.Console.ReadLine()

let printQuote attribution quote = printfn "%s said, \"%s\"" attribution quote

printQuote attribution quote

let quotes = new Dictionary<string,string>()

quotes.Add("Ada Lovelace", "Understand well as I may, my comprehension can only be an infinitesimal fraction of all I want to understand.")
quotes.Add("John von Neumann", "There's no sense in being precise when you don't even know what you're talking about.")
quotes.Add("Steve Wozniak", "Wherever smart people work, doors are unlocked.")
quotes.Add("Grace Hopper", "A human must turn information into intelligence or knowledge. We've tended to forget that no computer will ever ask a new question.")
quotes.Add("Edsger W. Dijkstra", "Perfecting oneself is as much unlearning as it is learning.")

for KeyValue(attribution, quote) in quotes do
    printQuote attribution quote

System.Console.ReadKey() |> ignore