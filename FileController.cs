using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.RegularExpressions;
using AOT;

namespace Main;

[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static partial class FileController
{
  private static readonly Regex FilenameRegex = ValidateFileRegex();

  public static string ProjectRoot => Directory.GetCurrentDirectory();

  public static void CreateFile(string folderPath, string fileName, string fileData)
  {
    if (!IsValidFilename(fileName))
    {
      Console.WriteLine("Invalid filename: " + fileName);
      return;
    }

    try
    {
      File.WriteAllText(Path.Join(folderPath, fileName), fileData);
    }
    catch (Exception err)
    {
      Console.WriteLine(err);
    }
  }

  public static void CreateProjectFile(string fileName, string fileData) =>
      CreateFile(ProjectRoot, fileName, fileData);

  public static void CreateProjectFile<T>(string fileName, T fileData) =>
      CreateProjectFile(fileName, JsonSerializer.Serialize(fileData, typeof(T), JsonContext.Default));

  public static T? GetProjectFileDeserialized<T>(string fileName) where T : class =>
      GetFileDeserialized<T>(Path.Join(ProjectRoot, fileName));

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

  private static bool IsValidFilename(string fileName)
  {
    return FilenameRegex.IsMatch(fileName) && !fileName.Contains("..");
  }

  [GeneratedRegex(@"^[a-zA-Z0-9_\-]+$", RegexOptions.Compiled)]
  private static partial Regex ValidateFileRegex();
}
