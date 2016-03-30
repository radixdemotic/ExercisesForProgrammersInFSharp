(*Create a passwordValidator function that takes in the
password as its argument and returns a value you can
evaluate to determine the password strength. Do not
have the function return a string—you may need to
support multiple languages in the future.
• Use a single output statement.
*)

module ExercisesForProgrammers.PasswordStrengthIndicator

open System

type passwordStrength = VeryWeak | Weak | Strong | VeryStrong

type Password (password: string, strength:passwordStrength) = 
    member this.password = password
    member this.strengthDescriptor = 
        match strength with
        |VeryWeak -> "Very Weak"
        |Weak-> "Weak"
        |Strong-> "Strong"
        |VeryStrong-> "Very Strong"

//Since this isn't really the correct way to generate a password anyway, I'll leave this as-is.
//this probably should be written with regular expressions in the first place.
let isWeakLength (userString : string) = 
    let weakLength = 8
    userString.Length < weakLength

let isAllDigits (userString : string) = 
    String.forall (fun c -> Char.IsDigit(c)) userString

let isAllLetters (userString : string) = 
    String.forall (fun c -> Char.IsLetter(c)) userString

let isAllSpecialCharacters (userString:string) =
    not (String.exists (fun c -> Char.IsLetterOrDigit(c)) userString)

let isAtLeastOneSpecialChar (userString :string) = 
     String.exists (fun c -> Char.IsPunctuation(c)) userString 
     || String.exists (fun c -> Char.IsSeparator(c)) userString
     || String.exists (fun c -> Char.IsSymbol(c)) userString

let isAlphaNumeric (userString : string) = 
    String.exists (fun c -> Char.IsLetter(c)) userString &&
    String.exists (fun c -> Char.IsDigit(c)) userString &&
    not (isAtLeastOneSpecialChar userString)

let isAlphaSpecial (userString : string) = 
    String.exists (fun c -> Char.IsLetter(c)) userString &&
    isAtLeastOneSpecialChar userString &&
    not (String.exists (fun c -> Char.IsDigit(c)) userString)

let (|VeryWeak|Weak|Strong|VeryStrong|) (userInput : string) =
    match userInput with
        |userInput when isWeakLength userInput -> VeryWeak
        |userInput when isAllDigits userInput -> VeryWeak
        |userInput when isAllLetters userInput -> Weak
        |userInput when isAllSpecialCharacters userInput -> Weak
        |userInput when isAlphaSpecial userInput -> Strong
        |userInput when isAlphaNumeric userInput -> Strong
        |userInput -> VeryStrong

let validatePassword userString = 
    match userString with
        | VeryWeak -> new Password(userString, VeryWeak)
        | Weak -> new Password(userString, Weak)
        | Strong -> new Password(userString, Strong)
        | VeryStrong -> new Password(userString, VeryStrong)

let consoleInput prompt = 
    printf "%s" prompt
    Console.ReadLine()

let printPasswordStrength (userString : string)(userPassword : Password) = 
    printf "The password '%s' is a %s password." userString userPassword.strengthDescriptor

[<EntryPoint>]
let main _ = 
    let userString = consoleInput "Enter a password: "
    let userPassword = validatePassword userString
    printPasswordStrength userString userPassword
    Console.ReadKey() |> ignore
    0 // return an integer exit code
