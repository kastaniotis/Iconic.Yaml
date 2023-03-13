# <img src="https://github.com/kastaniotis/Iconic.Yaml/raw/master/Iconic.Yaml/icon.png" style="width:35px;vertical-align:bottom;"> Yaml Loader

[![.NET](https://github.com/kastaniotis/Iconic.Yaml/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kastaniotis/Iconic.Yaml/actions/workflows/dotnet.yml) 
[![GitHub tag (latest SemVer)](https://img.shields.io/github/v/tag/kastaniotis/Iconic.Yaml?color=%2331c854&label=Version%20&sort=semver)](https://github.com/kastaniotis/Iconic.Yaml/releases) 
[![Nuget](https://img.shields.io/nuget/v/Iconic.Yaml)](https://www.nuget.org/packages/Iconic.Yaml/)

A library that allows loading of yaml files and getting values based on paths

It is meant as a lightweight and easy to use alternative to YamlDotNet and the Configuration framework.  

If you feel like sometimes the framework is over-engineered, this is the library for you

If you use complex yaml configuration and you require complex validation or mapping to strongly typed objects, 
then you should use YamlDotNet and the Configuration Framework.

## Yaml support

The library does not validate files and does not support the entire Yaml specification (for example arrays).  

**Only simple values are supported**

## Validation

The library does not handle validation. This is functionality that should be handled by each service, 
to avoid leaking business logic all over framework glue-code

## Usage

```C#
var configuration = new YamlLoader();
configuration.Load("app.yaml");
configuration.Load("log.yaml");
var dbpass = configuration.Get("database.motosales.name");
var dbport = configuration.Get("database.motosales.port");
var logMode = configuration.Get("log.mode");
```

## Performance

Smaller keys are retrieved faster

The library is not yet optimized for performance, however it was designed to front-load expensive operations
to the time of initialization, and make retrieving operations more performant.

## TODO

Work on improving performance and decrease the cpu/memory footprint

## Acknowledgements

Icons are courtesy of the [Noun Project](https://thenounproject.com/)
