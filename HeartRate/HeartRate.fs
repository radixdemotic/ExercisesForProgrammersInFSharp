(* Create a program that prompts for
your age and your resting heart rate. Use the Karvonen formula
to determine the target heart rate based on a range of
intensities from 55% to 95%. Generate a table with the results
as shown in the example output. 
The formula is
TargetHeartRate = (((220 − age) − restingHR) × intensity) + restingHR

Example Output
Resting Pulse: 65 Age: 22
Intensity | Rate
-------------|--------
55% | 138 bpm
60% | 145 bpm
65% | 151 bpm
: : (extra lines omitted)
85% | 178 bpm
90% | 185 bpm
95% | 191 bpm

Constraints
• Don’t hard-code the percentages. Use a loop to increment
the percentages from 55 to 95.
• Ensure that the heart rate and age are entered as numbers.
Don’t allow the user to continue without entering
valid inputs.
• Display the results in a tabular format. *)
module ExercisesForProgrammers.HeartRate

open System

//obviously this should be partially applied before a for loop with yield to build
//a list, which is then passed to be printed.
let targetHeartRate (age : int) (restingHeartRate:int) (intensity:float) =
    int ((float ((220 - age) - restingHeartRate)) * intensity) + restingHeartRate

[<EntryPoint>]
let main _ = 
    Console.ReadKey() |> ignore
    0 // return an integer exit code
