// ReSharper disable PossibleMultipleEnumeration

using System.Diagnostics;
using System.Reflection;

var root = $"../../..";
var swaggerFileName = $"manglerapi-openapi-spec.json";
var apiSwaggerFilePath = $"{root}/../../ManglerAPI/swagger.json";
var swaggerFilePath = $"{root}/../../ManglerAPI.Client/{swaggerFileName}";
var backupFolderPath = $"{root}/backups";

Print("** Mangler API CodeGen **");

var backups = Directory.GetFiles(backupFolderPath)
    .Select(f => new FileInfo(f))
    .OrderBy(fi => fi.LastWriteTimeUtc);

if (backups.Count() >= 10)
{
    var oldestFile = backups.First();
    
    Print($"Deleting oldest backup: {oldestFile.FullName}");    
    File.Delete(oldestFile.FullName);
}

var newBackupFilePath= $"{backupFolderPath}/{swaggerFileName}.backup-{DateTime.UtcNow:O}";
Print($"Creating new backup of the swagger file: {newBackupFilePath}");
File.Copy(swaggerFilePath, newBackupFilePath);

Print($"Deleting {swaggerFilePath}");
File.Delete(swaggerFilePath);

Print("Copying SwaggerFile from API into client project");
File.Copy(apiSwaggerFilePath, swaggerFilePath);

Print("Done.  ManglerAPI.Client will update upon building.");

Print("Rebuild full solution");

return;

void Print(string str)
{
    Console.WriteLine("[ManglerAPI.CodeGen]: " + str);
}