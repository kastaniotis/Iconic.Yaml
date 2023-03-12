namespace Iconic.Yaml.Tests;

[TestClass]
public class YamlTests
{
    [TestMethod]
    public void Generic()
    {
        var configuration = new YamlLoader();
        configuration.Load("app.yaml");
        configuration.Load("log.yaml");
        //configuration.load("app2.yaml");
        var dbpass = configuration.Get("database:motosales:name");
        var dbport = configuration.Get("database:motosales:port");
        //var asd = configuration.Get("database:motosales:asd");
    }
}