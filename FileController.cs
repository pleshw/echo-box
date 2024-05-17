using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.RegularExpressions;
using AOT;

namespace Main;

[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static partial class FileController
{
  public static string ApplicationBase => AppContext.BaseDirectory;

  public static string ProjectRoot => Path.GetFullPath(Path.Join(ApplicationBase, "..", "..", "..", "/data/"));

  public static void CreateFile(string folderPath, string fileName, string fileData)
  {
    string filePath = Path.Join(folderPath, fileName);

    try
    {
      File.WriteAllText(filePath, fileData);
    }
    catch (Exception err)
    {
      Console.WriteLine(err);
    }
  }

  public static void CreateProjectFile(string fileName, string fileData) => CreateFile(ProjectRoot, fileName, fileData);

  public static void CreateProjectFile<T>(string fileName, T fileData) => CreateProjectFile(fileName, JsonSerializer.Serialize(fileData, typeof(T), JsonContext.Default));

  public static T? GetProjectFileDeserialized<T>(string fileName) where T : class => GetFileDeserialized<T>(Path.Join(ProjectRoot, fileName));

  public static T? GetFileDeserialized<T>(string filePath) where T : class
  {
    if (!File.Exists(filePath))
    {
      Console.WriteLine($"File not found: {filePath}");
      return default;
    }

    try
    {
      var fileContent = File.ReadAllText(filePath);
      return JsonSerializer.Deserialize<T>(fileContent);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error reading file: {ex.Message}");
      return default;
    }
  }
}
