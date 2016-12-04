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