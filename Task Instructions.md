# Keysight Coding Test

We ask candidates to do this test because we find it is a good way for us to get an insight
into the sort of code the person might write if they came to work for us. You should be
aware that the test is not just about writing some code that produces a correct answer. If
you were to write one huge method that produced the right answer we are unlikely to be
hugely impressed. Likewise a solution that has been needlessly over engineered to
demonstrate what a smarty pants you are could also be seen as a negative. Ultimately
however there is no clear right way or wrong way to go about it. Don’t try and over think
it, just approach as you would any job of work that arrives on your desk during a normal
working day.

For this problem, we request that you use **C#** and write **unit tests**. You may not use any
external libraries to solve this problem, but you may use external libraries or tools for
testing purposes.

Also include in the solution a .md file explaining any assumptions you made at the time of writing the code.

## Mastermind

Have you ever played Mastermind? This game where one player, a codemaker, has to choose a secret combination of colored pegs and then make it guess to someone else, a codebreaker.
The codemaker is answering to each guess attempt of the codebreaker by indicating only the number of well placed colors and the number of correct but misplaced colors.

## Problem Description

The idea of this test is to code an algorithm capable of playing this game: answering the number of well placed and misplaced colors.
Therefore, your function should return, for a secret and a guessing combination:

- The number of well placed colors
- The number of correct but misplaced colors
  
A combination can contain any number of positions but you’d better give the same number for the secret and the guessing.
You can use any number of colors.

## Examples

For a secret `[blue, red, green, pink]` and a guess `[yellow, red, blue, purple]` the answer should be : 1 well placed and 1 misplaced.

Some other examples :

```
secret = [blue, red, green, pink]

evaluate([yellow, red, blue, purple]) should return [1, 1]

evaluate([blue, red, green, pink]) should return [4, 0]

evaluate([pink, blue, red, green]) should return [0, 4]

evaluate([blue, red]) should return [2, 0]  

evaluate([green, pink]) should return [0, 2]  

evaluate([red, yellow], [blue, red]) should return [2, 1]
```
