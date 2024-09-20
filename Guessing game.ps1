$randomNumber = Get-Random -Minimum 10 -Maximum 1001

$Guess = 0

$attempt = 0

$wrong = ("Was that your guess, or did your brain just malfunction?",
"Did you pick that number, or did you just randomly hit the keyboard?",
"I didn't know guessing the wrong number was your special talent.",
"That guess was so off, even a broken clock is more accurate.",
"Is that your final answer, or are you trying to confuse us all?",
"If guessing wrong was an Olympic sport, you'd take gold.",
"Maybe next time, try using your brain instead of a dartboard.",
"I've seen better guesses from a magic 8-ball.",
"Is that the number you wanted, or the one you deserve?",
"Your guess was so far off, I thought you were playing a different game.",
"Did you guess that, or did you just close your eyes and hope for the best?",
"That guess was so off, even Google can't help you.",
"Next time, try guessing with your brain instead of your gut.",
"I think a coin flip would have given you a better result.",
"Were you even trying, or was that just a random number?",
"I didn’t realize we were playing a game of how wrong can you be.",
"You’re so far off, you might as well be on another planet.",
"Is that the best you’ve got? Maybe stick to something easier.",
"Did you guess that, or did your cat walk across the keyboard?",
"I’ve seen better guesses from a fortune cookie.",
"That was so wrong, even your calculator is confused.",
"Are you guessing, or just making numbers up?",
"You missed so badly, the target called to ask if you're okay.",
"If guessing wrong was an art, you’d be a Picasso.",
"You’re about as accurate as a weather forecast.",
"That guess was more disappointing than Monday mornings.",
"Did you guess, or just pick the first number that came to mind?",
"I’ve seen blindfolded darts players with better aim.",
"If that guess were a GPS, you'd be lost.",
"You're so far off, it's like you're playing a different game entirely."

)

$correct = ("Wow, you're a natural at this!",
"That was a perfect guess—impressive!",
"Spot on! You’ve got a great instinct.",
"You nailed it! Well done!",
"Looks like you’ve got a knack for this!",
"Right on the money! You're on fire!",
"Your intuition is spot-on—amazing!",
"You guessed it like a pro!",
"Bulls-eye! Your guessing game is strong.",
"That was flawless! Keep it up!")

#text to speak variabler!!

$right = "Correct, you guessed it"

$start = "I'm about a number in between 10 and 1000, can you guess it"


Add-Type -AssemblyName System.speech
$speak = New-Object System.Speech.Synthesis.SpeechSynthesizer





Write-Host "Jeg tænker på et tal mellem 10 og 1000."
$speak.Speak($start)


While ($randomNumber -ne $Guess) {

Write-Host -NoNewline "Hvad er tallet? "
$Guess = [int] (Read-Host)

If ($Guess -gt $randomNumber) {
        $wrongSpeak = $wrong | Get-Random;

        Write-Host "$Guess er For højt!.", $speak.Speak($wrongSpeak)
        $attempt++;

      } elseif ($Guess -lt $randomNumber) {
            $wrongSpeak = $wrong | Get-Random;

            Write-Host "$Guess er For lavt!.", $speak.Speak($wrongSpeak)
            $attempt++

         }   else {
            $correctSpeak =  $correct | Get-Random;

            Write-Host "Rigtigt! $randomNumber er det tal jeg tænkte på! Du brugte $attempt forsøg"
            $speak.Speak($correctSpeak)

         }


}
