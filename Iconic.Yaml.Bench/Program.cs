
using Iconic.Yaml;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

var configuration = new YamlLoader();

for (int i = 0; i < 5; i++)
{
    configuration.Load("app.yaml");
    configuration.Clear();
}

