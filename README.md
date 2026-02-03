[TaxiFind.tests.benchmarks.TaxiBenchmarks-report-github.md](https://github.com/user-attachments/files/25055239/TaxiFind.tests.benchmarks.TaxiBenchmarks-report-github.md)
```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 7 7840HS w/ Radeon 780M Graphics 3.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.310
  [Host]     : .NET 9.0.12 (9.0.12, 9.0.1225.60609), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 9.0.12 (9.0.12, 9.0.1225.60609), X64 RyuJIT x86-64-v4


```
| Method          | Mean       | Error     | StdDev    | Gen0   | Allocated |
|---------------- |-----------:|----------:|----------:|-------:|----------:|
| Radar           |   1.650 μs | 0.0177 μs | 0.0166 μs | 0.0210 |     176 B |
| BruteForce      | 204.938 μs | 4.0692 μs | 7.6430 μs | 0.9766 |    8568 B |
| ExpandingSquare |   5.081 μs | 0.1011 μs | 0.1771 μs | 0.1144 |     960 B |
