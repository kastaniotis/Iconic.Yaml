using System.Text;

namespace Iconic.Yaml;
public class YamlLoader
{
    private const int Spaces = 2;
    private const string AssignmentDelimiter = ":";

    private readonly Dictionary<string, string> _elements = new();

    public void Clear()
    {
        _elements.Clear();
    }

    public void Load(string fileName)
    {
        var lines = ReadFile(fileName);
        Parse(lines, fileName);
    }

    public string[] ReadFile(string fileName)
    {
        try
        {
            return File.ReadAllLines(fileName);
        }
        catch (FileNotFoundException)
        {
            throw new YamlException($"The application requested a yaml file that does not exist: [{fileName}]");
        }
    }

    public void Parse(string[] lines, string fileName)
    {        
        var hierarchy = new List<string>();
        foreach (var line in lines)
        {
            var delimiterPosition = line.IndexOf(AssignmentDelimiter, StringComparison.Ordinal);
            if (delimiterPosition <= -1) continue; //All valid lines have the delimiter in yaml
            
            var span = line.AsSpan();
            var depth = GetElementDepth(span);
                
            var name = span[..delimiterPosition].Trim();
            var value = span[(delimiterPosition+1)..].Trim();

            hierarchy.Insert(depth, name.ToString());

            if (value.IsEmpty) continue; //If there's no value, we won't assign an element

            var alias = new StringBuilder();
            for (var i = 0; i < depth; i++)
            {
                alias.Append(hierarchy[i]).Append(':');
            }

            try
            {
                alias.Append(name);
                _elements.Add(alias.ToString(), value.ToString());
            }
            catch (ArgumentException)
            {
                throw new YamlException($"The application requested a yaml file that defines an element that already exists: [{fileName}]");
            }
        }            
    }

    private static int GetElementDepth(ReadOnlySpan<char> line)
    {
        return (line.Length - line.TrimStart().Length)/Spaces;
    }

    public string Get(string path)
    {
        try
        {
            return _elements[path];
        }
        catch (KeyNotFoundException)
        {
            throw new YamlException($"The application requested a yaml element that does not exist: [{path}]");
        }
    }
}