(*Calculate gallons of paint needed to paint the ceiling of a
room. Prompt for the length and width, and assume one
gallon covers 350 square feet. Display the number of gallons
needed to paint the ceiling as a whole number.
Example Output
You will need to purchase 2 gallons of
paint to cover 360 square feet.
Remember, you can’t buy a partial gallon of paint. You must
round up to the next whole gallon.
Constraints
• Use a constant to hold the conversion rate.
• Ensure that you round up to the next whole number.

Can't round on a unit of measure. Try to use this:
http://stackoverflow.com/questions/31439855/using-math-round-with-a-unit-of-measure?rq=1
or do a type conversion with <1/measure> inside unit brackets

Use Math.Ceiling Not Round, appropriate for painting the ceiling.
Could extend this to cover walls (lateral surfaces), different paints for different walls.
*)

module ExercisesForProgrammers.PaintCalculator

open System

[<Measure>] type Ft

[<Measure>] type SqFt = Ft * Ft

[<Measure>] type Gallon = static member perSqFt = 1.0<Gallon>/350.0<SqFt>

let GetDoubleInput () = 
    Double.Parse(Console.ReadLine())

//Converting to feet inside this function is a realistic shortcut absent
//entering own unit of measure along with number.
let GetRectRoomArea roomLength roomWidth = 
    (roomLength * 1.0<Ft>) * (roomWidth * 1.0<Ft>)

//elegant or hackey? Should this use Language Primitives instead of multiplying by 1.0 measures?
let GetPaint (rectRoomArea : float<SqFt>) = 
    Math.Ceiling ((rectRoomArea * Gallon.perSqFt) * 1.0<1/Gallon>) * 1.0<Gallon>

[<EntryPoint>]
let main _ =
    printf "Enter a length for the room: "
    let roomLength = GetDoubleInput ()
    printf "Enter a width for the room: "
    let roomWidth = GetDoubleInput ()
    let rectRoomArea = GetRectRoomArea roomLength roomWidth
    let paint = GetPaint rectRoomArea
    printfn "You will need to purchase %g gallons of paint to cover %g square feet." paint rectRoomArea
    Console.ReadKey() |> ignore
    0