# Yaml Loader
A library that allows loading of yaml files and getting values based on paths

It is meant as a lightweight and easy to use alternative to YamlDotNet and the Configuration framework.  

If you feel like sometimes the framework is over-engineered, this is the library for you

If you use complex yaml configuration and you require complex validation or mapping to strongly typed objects, 
then you should use YamlDotNet and the Configuration Framework.

## Yaml support

The library does not validate files and does not support the entire Yaml specification (for example arrays).  

__NOTE__ Only simple values are supported

## Validation

The library does not handle validation. This is functionality that should be handled by each service, 
to avoid leaking business logic all over framework glue-code

## Usage

```C#
var configuration = new YamlLoader();
configuration.Load("app.yaml");
configuration.Load("log.yaml");
var dbpass = configuration.Get("database:motosales:name");
var dbport = configuration.Get("database:motosales:port");
var logMode = configuration.Get("log.mode");
```
