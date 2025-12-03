```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7171/24H2/2024Update/HudsonValley)
AMD Ryzen 9 4900HS with Radeon Graphics 3.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.307
  [Host]   : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET 8.0 : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3

Job=.NET 8.0  Runtime=.NET 8.0  

```
| Method | Mean      | Error    | StdDev   | Gen0        | Allocated |
|------- |----------:|---------:|---------:|------------:|----------:|
| Part1  |  35.11 ms | 0.549 ms | 0.429 ms |  74333.3333 | 148.33 MB |
| Part2  | 113.40 ms | 2.266 ms | 2.946 ms | 188200.0000 | 375.62 MB |
