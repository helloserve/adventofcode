# Advent Of Code
Solutions to the challanges on http://adventofcode.com for 2016

## Unit Tests
All solutions are executed through unit tests. Input for unit tests are read from fixed resource files in the test project, or manually hardcoded in the test itself.

## Implementations

### Day 1

After the initial few unit tests, I decided to update my solution to work with proper vector algebra. Each direction is a vector `[(1,0), (-1,0), (0, 1), (0, -1)]`, and multiplying with a scalar (steps) and adding to the current position keeps easy track of where you're going. This allowed me to only have one switch statement for direction, and I have another clamp pattern for determining the new direction (NESW) based on a circular string compass variable. For part 2, I simply added an additional for-loop over the steps, and recorded each step individually.

I must note that initially my `Vector2` class methods manipulated the instance itself, and this messed up the content of my position list. I had to change the implementation to return new instances in order to keep the fluent code structure.

### Day 2

A much easier challenge than day 1 I think. It was easy to configure and work your way through a double array representation of the keypad. Part 2 simply required a broadening of the edge code to check for null values in the keypad configuration.

### Day 3

This challenge was really just a triangle class with the logical property. The part 2 twist regarding the input transformation was unexpected though - a good candicate for a map().fold() functional implementation.

### Day 4

The first regular expression for this season, and another circular index clamping bit for part 2 for shifting the letters. Oh, and dumping the output to inspect the names.

### Day 5

And here's the first MD5 problem of the season. The .NET MD5 implementation is pretty damn slow. I decided to optimize it by running [processor count] separate increasing integer ranges for calculating hashes. Since the thread method does not return a result anymore but instead updates a list under a mutex, I had to remove all my TDD test progress. The problem also clearly illustrates the difference between `Encoding.GetBytes()` and `BitConverter.ToString()`, that is, the reverse of the first one is not equivalent to the second (a point that eluded me for a while).

For part 2, I had to change the threading to run until the code was complete, as opposed to running for a specific number of iterations and only using the first 8. To do this I passed in an action for the thread to execute under the mutex and set the abort variable if the code was complete.

### Day 6

Another simple text transformation, but this time I relied heavily on using LINQ composition to determine the most significant (or least for part 2) characters in each column set. I'm seeing more and more how to implement functional solutions in .NET.

### Day 7

A pretty gnarley day, chiefly because the given examples doesn't even come close to covering the possible variations in the input. I initially started out with Regexes, but soon abandoned it completely. After I got part 1 sorted though, part 2 came pretty quickly.