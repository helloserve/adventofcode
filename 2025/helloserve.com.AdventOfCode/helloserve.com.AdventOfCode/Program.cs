// See https://aka.ms/new-console-template for more information
using helloserve.com.AdventOfCode;

Console.WriteLine("Hello, Advent Of Code!");

Day01 day01 = new();
var result = day01.Part1("Day01.txt");
Console.WriteLine($"Day 01, Part 1: {result}");

result = day01.Part2("Day01.txt");
Console.WriteLine($"Day 01, Part 2: {result}");