# Yaml
---
A library that allows loading yaml files and getting values based on the element's path

This is meant as a lightweight and super-efficient alternative to YamlDotNet. It also serves 
very nicely as a lightweight alternative to the Configuration framework.  

If you feel like sometimes the framework is overengineered, this is the library for you

## Usage

```C#
var configuration = new YamlLoader();
configuration.Load("app.yaml");
configuration.Load("log.yaml");
var dbpass = configuration.Get("database:motosales:name");
var dbport = configuration.Get("database:motosales:port");
var logMode = configuration.Get("log.mode");
```
