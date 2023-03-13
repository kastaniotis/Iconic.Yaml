using System.IO;

namespace Iconic.Yaml.Tests;

[TestClass]
public class YamlTests
{
    private YamlLoader configuration;
    public YamlTests() 
    {
        configuration = new YamlLoader();
        configuration.Load("app.yaml");
    }

    [TestMethod]
    public void GetValues()
    {
        var dbname = configuration.Get("database.motosales.name");
        Assert.AreEqual("motosales", dbname);
        var dbport = configuration.Get("database.motosales.port");
        Assert.AreEqual("3306", dbport);
    }

    [TestMethod]
    public void TryToLoadNonExistendFile()
    {
        var nonExistent = "app2.yaml";
        try
        {
            configuration.Load(nonExistent);
        }
        catch (Exception e)
        {
            Assert.AreEqual(typeof(YamlException), e.GetType());
            Assert.AreEqual($"The application requested a yaml file that does not exist: [{nonExistent}]", e.Message);
        }
    }

    [TestMethod]
    public void TryToGetNonExistendElement()
    {
        try
        {
            var asd = configuration.Get("database.motosales.asd");
        }
        catch (Exception e)
        {
            Assert.AreEqual(typeof(YamlException), e.GetType());
            Assert.AreEqual($"The application requested a yaml element that does not exist: [database.motosales.asd]", e.Message);
        }
    }

    [TestMethod]
    public void TryToLoadFileWithExistendElement()
    {
        try
        {
            configuration.Load("log.yaml");
        }
        catch (Exception e)
        {
            Assert.AreEqual(typeof(YamlException), e.GetType());
            Assert.AreEqual($"The application requested a yaml file that defines an element that already exists: [log.yaml]", e.Message);
        }
    }
}