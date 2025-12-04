# Advent Of Code
Solutions to the challenges on http://adventofcode.com

## 2025

C# only. Benchmarks are for entire puzzle input, run to completion.
CPU: AMD Ryzen 9 4900HS

### Day 1

| Method | Job       | Runtime   | Mean     | Error   | StdDev   | Gen0     | Gen1    | Allocated |
|------- |---------- |---------- |---------:|--------:|---------:|---------:|--------:|----------:|
| Part1  | .NET 10.0 | .NET 10.0 | 338.1 us | 4.10 us |  3.83 us | 183.1055 | 53.2227 | 503.74 KB |
| Part2  | .NET 10.0 | .NET 10.0 | 346.3 us | 6.05 us |  5.05 us | 183.1055 | 54.1992 | 503.74 KB |
| Part1  | .NET 8.0  | .NET 8.0  | 363.0 us | 4.04 us |  3.38 us | 195.3125 | 43.4570 | 503.74 KB |
| Part2  | .NET 8.0  | .NET 8.0  | 386.4 us | 7.73 us | 14.32 us | 194.3359 | 45.4102 | 503.74 KB |

### Day 2

| Method | Job       | Runtime   | Mean      | Error    | StdDev   | Gen0        | Allocated |
|------- |---------- |---------- |----------:|---------:|---------:|------------:|----------:|
| Part1  | .NET 10.0 | .NET 10.0 |  39.62 ms | 0.776 ms | 1.533 ms |  74307.6923 | 148.33 MB |
| Part2  | .NET 10.0 | .NET 10.0 | 112.37 ms | 1.593 ms | 1.490 ms | 188200.0000 | 375.62 MB |
| Part1  | .NET 8.0  | .NET 8.0  |  34.74 ms | 0.660 ms | 0.617 ms |  74357.1429 | 148.33 MB |
| Part2  | .NET 8.0  | .NET 8.0  | 104.07 ms | 1.955 ms | 1.829 ms | 188200.0000 | 375.62 MB |

### Day 3

| Method | Job       | Runtime   | Mean     | Error    | StdDev   | Gen0     | Allocated |
|------- |---------- |---------- |---------:|---------:|---------:|---------:|----------:|
| Part1  | .NET 10.0 | .NET 10.0 | 517.0 us |  6.30 us |  5.59 us | 324.2188 | 662.99 KB |
| Part2  | .NET 10.0 | .NET 10.0 | 565.2 us | 10.96 us | 10.77 us | 328.6133 | 672.38 KB |
| Part1  | .NET 8.0  | .NET 8.0  | 444.3 us |  8.47 us |  9.07 us | 327.1484 | 669.23 KB |
| Part2  | .NET 8.0  | .NET 8.0  | 502.7 us |  9.18 us |  8.58 us | 333.0078 | 691.13 KB |

### Day 4

| Method | Job       | Runtime   | Mean       | Error    | StdDev   | Gen0     | Gen1   | Allocated  |
|------- |---------- |---------- |-----------:|---------:|---------:|---------:|-------:|-----------:|
| Part1  | .NET 10.0 | .NET 10.0 |   480.9 us |  9.50 us | 12.36 us | 497.0703 | 0.9766 | 1016.78 KB |
| Part2  | .NET 10.0 | .NET 10.0 | 3,089.0 us | 25.85 us | 24.18 us | 496.0938 | 3.9063 | 1016.78 KB |
| Part1  | .NET 8.0  | .NET 8.0  |   526.6 us | 10.50 us | 17.54 us | 484.3750 |      - | 1016.77 KB |
| Part2  | .NET 8.0  | .NET 8.0  | 3,641.6 us | 15.85 us | 14.05 us | 484.3750 |      - | 1016.77 KB |


## 2016
Solution was done in .NET Core 1.1.0 and .NET Standard 1.6

## 2015
Solution was done in .NET Framework 4.5
