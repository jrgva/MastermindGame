MastermindGame

The instructions told that I should write some Unit Test, so I thought that the best idea was to use TDD as methodology for writing this code. I read the instructions with
the examples and I didn't realize about the last example.

I had the core of the game developed just using the same structure for guesses and secrets and in the last example, it's stated that the guesses could be something like a
list of guesses and not just one list, like a secret. So, although everything I'd devoloped so far was useful, I had to make some changes to admit this type of input.
I thought the best way was to code everything for a simple input and then, improve the code for the new input. I assumed that you can send as many guesses in one try as you like,
although it wasn't explicity said in the instructions

Another thing that I thought would be useful was that user can introduce the secret or guess with whitespaces between the comma and word, or not. The user could also use capital
letters and I assumed that it was better if the code was robust enough to accept these inputs and still work. I also thought to limit the words that user can introduce, because,
right now, if user introduces food instead of colours, everything works, but it's never said that this code should only work with colours.

Because of how the guesses could be introduced, I had to create a format that user must use and the code can validate. It was not a choice that I liked, but I didn't find a way to
force user to introduce the guess in a correct format without making the validation or the conversion from input to data more complex than it was.

It was not stated in the instructions, but I thought that only with the class and unit tests was not enough. It was necessary to create an user interface, nothing really fancy, to 
allow the user to interact with the game, to play. It was really boring playing against myself so I made a Vs Machine game mode that generates a random secret. It was not in the
instructions but I thought it was a good addition and it was not difficult to add.