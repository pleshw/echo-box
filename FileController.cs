using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using AOT;

namespace Main;

public record class ProjectFileInfo<T>
{
  public required string FolderPath;
  public required string FileName;
  public required T FileData;
}

[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static partial class FileController
{
  public static string ApplicationBase => AppContext.BaseDirectory;

  public static string ProjectRoot => Path.GetFullPath(Path.Join(ApplicationBase, "..", "..", ".."));

  public static string ProjectDataFolder => Path.Join(ProjectRoot, "/data/");

  public static void CreateFile(string folderPath, string fileName, string fileData)
  {
    if (!folderPath.Contains(ProjectDataFolder))
    {
      folderPath = Path.Join(ProjectDataFolder, folderPath);
    }

    string filePath = Path.Join(folderPath, fileName);

    try
    {
      Directory.CreateDirectory(folderPath);

      File.WriteAllText(filePath, fileData);
    }
    catch (Exception err)
    {
      Console.WriteLine(err);
    }
  }

  public static void CreateProjectFile<T>(ProjectFileInfo<T> fileData) => CreateFile(fileData.FolderPath, fileData.FileName, JsonSerializer.Serialize(fileData.FileData, typeof(T), JsonContext.Default));

  public static void CreateProjectFile<T>(List<ProjectFileInfo<T>> fileDataList) => fileDataList.ForEach(f => CreateFile(f.FolderPath, f.FileName, JsonSerializer.Serialize(f.FileData, typeof(T), JsonContext.Default)));

  public static void CreateProjectFile(string fileName, string fileData) => CreateFile(ProjectDataFolder, fileName, fileData);

  public static void CreateProjectFile<T>(string fileName, T fileData) => CreateProjectFile(fileName, JsonSerializer.Serialize(fileData, typeof(T), JsonContext.Default));

  public static T? GetProjectFileDeserialized<T>(string fileName) where T : class => GetFileDeserialized<T>(Path.Join(ProjectDataFolder, fileName));

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
