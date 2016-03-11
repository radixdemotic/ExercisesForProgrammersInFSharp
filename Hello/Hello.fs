module ExercisesForProgrammers.Hello

open System

printf "What is your name? "
printf "Hello, %s, nice to meet you!" (System.Console.ReadLine())
System.Console.ReadKey() |> ignore
