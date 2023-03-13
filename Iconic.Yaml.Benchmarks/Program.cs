
using BenchmarkDotNet.Running;
using Iconic.Yaml.Benchmarks;

var summary = BenchmarkRunner.Run<GenericBenchmarks>();

    // | Method |          Mean |        Error |       StdDev |   Gen0 | Allocated |
    // |------- |--------------:|-------------:|-------------:|-------:|----------:|
    // |   Init | 200,855.02 ns | 1,794.440 ns | 1,678.520 ns | 2.4414 |   10768 B |
    // |    Get |      27.49 ns |     0.044 ns |     0.035 ns |      - |         - |
