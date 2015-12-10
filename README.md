# adventofcode
Solutions to the challanges on AdventOfCode.com

## Unit Tests
All the solutions are executed through unit tests.

## Verses
Named for the verses of the song "The Twelve Days of Christmas", the ```Verses``` class contains the implementations, with necessary models under the Models folder structured per day.

##Implementations

###Day 1
The input is parsed one character at a time, essentially increasing or decreasing a variable based on a switch statement. The first part always reads the last entry in the result, the second part scans through it until it finds level -1.

###Day 2
Simple process to parse all the dimensions in a loop. The loop instantiates a ```Present``` object for each interation, which knows how to calculate it's own wrapping and lint areas.

###Day 3
A bit more graph-theory here for doing house keeping. For part 1, a single ```House``` instance is referenced, but the instance keeps track of it's neighbours which are all indexed in a global list (passed as '''ref'''). Each instruction changes the referenced instance the newly discovered neighbour. Once the instruction set has been exhausted, the currently referenced instance recursively determines the number of houses that received at least one present by calling on all its neighbours. For part 2, two instances are referenced, executed and moved on in turn. Both instanced operate on the same global index thus avoiding duplicates, and the recursive method still works from either referenced instance.

###Day 4
An MD5 implementation? I might still do that myself. Currently this just uses the .NET implementation and brute forces from a lower range of 100 000 up to a upper bound based on the length of the input.

###Day 5
Pretty straight forward string parsing. The implementation is based on keeping count of what it finds. ```NiceString``` is used in part 1, which defines some basic implementation, and then ```NicerString``` extends it and changes the criteria loop.

###Day 6
This is a simple and pretty easy X,Y coordinate problem. Part 1 was initially based on an array of ```bool```, but part 2 changed that to ```int``` to account for the different brightness values. So, the ```LightGrid``` class defines the basics and knows to switch on, off or toggle, and the ```BrightGrid``` class extends that so that it knows to adjust the brightness.

###Day 7
Now this was a tremendous puzzle. The instructions are rather complicated to parse, and the various permutations are not covered in the least by the problem description. Regardless, the solution sort-of emulates the circuit, but in a recursive way so as to only build what it needs to. The ```Circuit``` class indexes and processes the instructions recursively. The ```Wire```, ```Signal```` and all the extensions of ```Gate``` all extend a basic ```Input``` class which reads and stores the output. The various implementations are instantiated via regular expression conditions and setup in a graph structure. Part 2 merely ensures that an instruction for a wire can be overrided by a new instruction.
