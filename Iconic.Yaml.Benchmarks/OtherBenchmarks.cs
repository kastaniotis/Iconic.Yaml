using BenchmarkDotNet.Attributes;

namespace Iconic.Yaml.Benchmarks
{
    [MemoryDiagnoser]
    public class OtherBenchmarks
    {
        [Benchmark]
        public void Init()
        {
            var loader = new YamlLoader();
            loader.Load("app.yaml");
        }
    }
}
