# Advent Of Code
Solutions to the challanges on http://adventofcode.com for 2016

## Unit Tests
All solutions are executed through unit tests. Input for unit tests are read from fixed resource files in the test project, or manually hardcoded in the test itself.

## Implementations

### Day 1

After the initial few unit tests, I decided to update my solution to work with proper vector algebra. Each direction is a vector `[(1,0), (-1,0), (0, 1), (0, -1)]`, and multiplying with a scalar (steps) and adding to the current position keeps easy track of where you're going. This allowed me to only have one switch statement for direction, and I have another clamp pattern for determining the new direction (NESW) based on a circular string compass variable. For part 2, I simply added an additional for-loop over the steps, and recorded each step individually.

I must note that initially my `Vector2` class methods manipulated the instance itself, and this messed up the content of my position list. I had to change the implementation to return new instances in order to keep the fluent code structure.