
using BenchmarkDotNet.Running;
using Iconic.Yaml.Benchmarks;

var summary = BenchmarkRunner.Run<GenericBenchmarks>();

//|   Method |          Mean |        Error |       StdDev |   Gen0 | Allocated |
//|--------- |--------------:|-------------:|-------------:|-------:|----------:|
//|     Init | 231,026.36 ns | 1,659.741 ns | 1,385.959 ns | 2.9297 |   12600 B |
//|      Get |      30.73 ns |     0.077 ns |     0.068 ns |      - |         - |
//| GetSmall |      22.95 ns |     0.063 ns |     0.049 ns |      - |         - |
//| GetLarge |      38.48 ns |     0.278 ns |     0.217 ns |      - |         - |

//|   Method |          Mean |        Error |       StdDev |   Gen0 | Allocated |
//|--------- |--------------:|-------------:|-------------:|-------:|----------:|
//|     Init | 203,078.17 ns | 2,659.603 ns | 2,357.668 ns | 2.9297 |   13032 B |
//|      Get |      30.36 ns |     0.116 ns |     0.109 ns |      - |         - |
//| GetSmall |      22.58 ns |     0.125 ns |     0.117 ns |      - |         - |
//| GetLarge |      37.33 ns |     0.092 ns |     0.081 ns |      - |         - |


//var summary = BenchmarkRunner.Run<OtherBenchmarks>();