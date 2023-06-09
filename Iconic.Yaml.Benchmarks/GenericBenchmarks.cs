﻿using BenchmarkDotNet.Attributes;

namespace Iconic.Yaml.Benchmarks;

[MemoryDiagnoser]
public class GenericBenchmarks
{
    private YamlLoader _configuration;
    public GenericBenchmarks()
    {
        _configuration = new YamlLoader();
        _configuration.Load("app.yaml");
    }

    [Benchmark]
    public void Init()
    {
        var configuration = new YamlLoader();
        configuration.Load("app.yaml");
    }

    [Benchmark]
    public void Get()
    {
        var test = _configuration.Get("database:motosales:name");
    }

    [Benchmark]
    public void GetSmall()
    {
        var test = _configuration.Get("d:m:p");
    }

    [Benchmark]
    public void GetLarge()
    {
        var test = _configuration.Get("dobo:mobo:nomo:master:paster:puppets:metallica");
    }

}