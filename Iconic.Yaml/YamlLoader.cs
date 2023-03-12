namespace Iconic.Yaml;
public class YamlLoader
{
    private const int Spaces = 2;
    private const string AssignmentDelimiter = ": ";

    private Dictionary<string, string> _elements = new();

    public void Load(string fileName)
    {
        try
        {
            var lines = File.ReadAllLines(fileName);

            var hierarchy = new List<string>();
            foreach (var line in lines)
            {
                int depth = (line.Length - line.TrimStart().Length)/Spaces;
                var parts = line.Split(AssignmentDelimiter);
                var name = parts[0].Trim();
                var value = "";
                if (parts.Length > 1)
                {
                    value = parts[1].Trim();
                }

                while (hierarchy.Count <= depth)
                {
                    hierarchy.Add("");
                }

                hierarchy[depth] = name;

                if (value != "")
                {
                    var alias = "";
                    for (var i = 0; i < depth; i++)
                    {
                        alias += hierarchy[i];
                    }

                    try
                    {
                        _elements.Add(alias + name, value);
                    }
                    catch (ArgumentException )
                    {
                        throw new YamlException($"The application requested a yaml file that defines an element" +
                                                " that already exists: {filename}");
                    }
                    
                }
            }
        }
        catch (FileNotFoundException)
        {
            throw new YamlException($"The application requested a yaml file that does not exist: {fileName}");
        }
    }

    public string Get(string path)
    {
        try
        {
            return _elements[path];
        }
        catch (KeyNotFoundException)
        {
            throw new YamlException($"The application requested a yaml element that does not exist {path}");
        }
    }
}