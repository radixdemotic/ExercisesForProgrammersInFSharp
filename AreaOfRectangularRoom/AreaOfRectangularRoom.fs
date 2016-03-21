(* Create a program that calculates the area of a room. Prompt
the user for the length and width of the room in feet. Then
display the area in both square feet and square meters.
Example Output
What is the length of the room in feet? 15
What is the width of the room in feet? 20
You entered dimensions of 15 feet by 20 feet.
The area is
300 square feet
27.871 square meters
The formula for this conversion is
m2 = f2 × 0.09290304
Constraints
• Keep the calculations separate from the output.
• Use a constant to hold the conversion factor.

Note
Mutually recursive measures can be defined this way
type [<Measure>] km =

 static member toM = 1.0/1000.0<m/km>

and [<Measure>] m =

 static member toKm = 1000.0<km/m>
*)

module ExercisesForProgrammers.AreaOfRectangularRoom

open System

[<Measure>] type M

[<Measure>] type SqM = M * M

[<Measure>] type Ft

[<Measure>] type SqFt = Ft * Ft

let SqMPerSqFt = 0.09290304<SqM/SqFt>

//hacky name because both Ft->M and M->Ft should be static members
let convertAreaSqFtSqM (area : float<SqFt>) = area * SqMPerSqFt

printf "What is the length of the room in feet? "

let roomLength = System.Double.Parse(Console.ReadLine())

printf "What is the width of the room in feet? "

let roomWidth = System.Double.Parse(Console.ReadLine())

//Could try using LanguagePrimitives.FloatWithMeasure<Ft> here
let roomAreaSqFt : float<SqFt> = (roomLength * 1.0<Ft>) * (roomWidth * 1.0<Ft>)

let roomAreaSqM = convertAreaSqFtSqM roomAreaSqFt

printfn "You entered dimensions of %g feet in length by %g feet in width." roomLength roomWidth
printfn "The area is %.3f square feet and %.3f square meters." roomAreaSqFt roomAreaSqM

Console.ReadKey()|> ignore