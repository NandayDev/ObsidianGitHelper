using System.Diagnostics;
using System.Management.Automation;
using System.Text.Json;

// Gets the configuration JSON //
string jsonPath = Path.Combine(AppContext.BaseDirectory, "config.json");
JsonElement configJson = JsonDocument.Parse(File.ReadAllText(jsonPath)).RootElement;

// Git pull
string gitRepository = configJson.GetProperty("repositoryLocalFolder").GetString()!;
using PowerShell powershell = PowerShell.Create();
powershell.AddScript($"cd {gitRepository}");
powershell.AddScript(@"git pull");
powershell.Invoke();

// Gets the Obsidian EXE location, starts it and waits for it to exit //
string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
string obsidianPathFromJson = configJson.GetProperty("obsidianPathInLocalFolder").GetString()!;
string obsidianExe = Path.Combine(localAppData, obsidianPathFromJson);
Process obsidianProcess = Process.Start(obsidianExe);
obsidianProcess.WaitForExit();

// Git push //
using PowerShell powershell2 = PowerShell.Create();
powershell2.AddScript($"cd {gitRepository}");
powershell2.AddScript(@"git add .");
powershell2.AddScript("git commit -m \"Automatic commit\"");
powershell2.AddScript("git push");
powershell2.Invoke();