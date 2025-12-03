// See https://aka.ms/new-console-template for more information
using helloserve.com.AdventOfCode;

Console.WriteLine("Hello, Advent Of Code!");

#if DEBUG

Day01 day01 = new();
var result = day01.Part1();
Console.WriteLine($"Day 01, Part 1: {result}");

result = day01.Part2();
Console.WriteLine($"Day 01, Part 2: {result}");

Day02 day02 = new();
result = day02.Part1();
Console.WriteLine($"Day 02, Part 1: {result}");

result = day02.Part2();
Console.WriteLine($"Day 02, Part 2: {result}");

Day03 day03 = new();
result = day03.Part1();
Console.WriteLine($"Day 03, Part 1: {result}");

result = day03.Part2();
Console.WriteLine($"Day 03, Part 2: {result}");

#else

BenchmarkRunner.Run<Day01>();
BenchmarkRunner.Run<Day02>();
BenchmarkRunner.Run<Day03>();

#endif
