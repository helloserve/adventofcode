```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7171/24H2/2024Update/HudsonValley)
AMD Ryzen 9 4900HS with Radeon Graphics 3.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.307
  [Host]   : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET 8.0 : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3

Job=.NET 8.0  Runtime=.NET 8.0  

```
| Method | Mean     | Error   | StdDev  | Gen0     | Gen1    | Allocated |
|------- |---------:|--------:|--------:|---------:|--------:|----------:|
| Part1  | 365.6 μs | 2.75 μs | 2.30 μs | 195.3125 | 43.4570 | 503.77 KB |
| Part2  | 379.0 μs | 3.98 μs | 3.33 μs | 195.3125 | 43.4570 | 503.77 KB |
