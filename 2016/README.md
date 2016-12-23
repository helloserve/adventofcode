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

### Day 8

A very cool challenge managing the memory buffer of a small screen. Biggest problems here was good range checking and circular indexing. Added a screen dump for debugging which came in handy in part 2 of the challenge.

### Day 9

This is getting somewhat tricky now. The first part wasn't easy per sè, but I got it done pretty solidly through a TDD approuch. However, with the twist in part 2, and the resulting recursion running into the memory exception, I ended up copying the part 1 code and altering it completely to work with `long` variables exclusively. That got it done, and of course it executes significantly faster too.

### Day 10

Due to the language-heavy input I decided to build a more compiler-esque parser into a base class. This made it straight forward to read the commands. However, the challenge itself was deviously worded (although evident from the example) in that the commands don't follow one another in a top to bottom way (read paragrapgh 2). The result was a refactoring of parse results and requeueing the input. Part 2 was also devious in that it required that the input be run to the end instead of to where the comparison test was successfull in part 1, but it required me to simply pass out of range values for that part.

### Day 11

I must admit, this one stumped me completely. After **many** false starts I started on an algorithm to do forward looking at target floors to determine the next move, but it was only after talking to a fellow adventist that I was directed to a state tree implementation.

Some simple exclusion scenarios:

1. We can only ever take one item on the lift, except
2. When it's two of the same assembly types
3. If they **fit** (e.g. HG and HM)

My decision hierarchy or prioritization are as follows:

1. In order to speed up initial moves, first check the floor above to move asssemblies up. The assumption is that it will only be later on that matching M and G items will be on the same floor.
2. Consider items on the same floor. We first want to try and consider moving whatever we can up.
3. Then we look if we are matching anything below, so we can consider moving the assembly down where it will fit, meaning the following move can mvoe them up together.
4. If we don't fit anything outright, we try and move as many (two) at a time as we can. These has to be of the same assembly type, or by themselves. We consider moving up or down, but not down if there are no items below me because we would simply have to bring it up again.

Problems I faced in trying to solve part 1 was mainly around incorrect constraint logic (was something fried?), stack overflows and also mismatched array indexes. Particularly for the latter, in my `Floor` class I keep the level of the floor in a property. This is a non-zero based value, e.g. Floor 1, 2 etc. In my `ScenarioNode` class however, the `FloorIndex` property is zero based because it is used as the direct index (read position) of the evelator in that state. In checking the lower floors for content, I had these two misaligned, and not all the floors were considered. Regarding the stack overflows, initially I had a self-traversing recursive method in the `ScenarioNode` class, but this very quickly became a problem, forcing me to switch to an outside state-managed node traverse loop.
The problem I faced in trying to solve part 2 was again a constraint one. I just had to add code to check the previous floor the elevator was at at every state to make sure that we did not create a **fried** scenario when we moved stuff away. In fact, I'm quiite surprized that part 1 passed without this piece of code.

### Day 12

The instructions doesn't mention what the `jnz` command does when `x` is zero. I assumed it simply moves to the next instruction, which would be the equivalent of `jnz 1 1`. This fits in with my design where I absolutely rely on the result of the command to leave my at the correct instruction regardless of the input. Part 2 was simply passing an initial state.

### Day 13

So, A\*. I've never implemented it before, not even for Stingray. And it wasn't easy. The theory of the algorithm isn't too hard, the implementation is another thing though. My biggest problems were with the heuristics, and setting `g(n)` correctly for nodes in the open set. But there was period there were I fell into the _iterate on changes until successful_ pit of frustration. Also, the visualization of it helped a lot, but was also troublesome to do. I do feel however that I now have a solid grasp on the implementation of A\*, and that really is the reason why I do things like the Advent of Code.

### Day 14

More MD5, more threading. Was pretty straight forward.

### Day 15

An automaton. Simple loop of time, and inspect the situation at each step. Replaced a loop with modulus.

### Day 16

What I learnt from this puzzle was that .NET's strings are **really** slow. After my code based on strings did not finish in a reasonable time, I actually wrote code to produce `long` values from the input and proceeded to bit shift `>>` and invert `~` my way to a result. This worked for all my unit tests and the example of disk size 20, but not for part 1 with size 272. The `long` values simply started wrapping, even switching to `ulong` wasn't enough space either. So I revisted my original `string` code and rewrote it using `char[]` and `Array.Copy`. This completed almost instantly, even for part 2. The particular part of the original `string` code that was slow is the $ notation, for example `result = $"{result}{c}"` where `c` is the next character determined for the checksum. So even I could use the bit shifting code to generate enough data, the checksum code would _still_ have taken too long at these lengths.

### Day 17

I did not attempt a recursive implementation this time round (although I suspect it would have been ok on a 4x4 grid). For part 2 I just removed the length check for early exit and extended the room position check instead.

### Day 18

Ezpz day.