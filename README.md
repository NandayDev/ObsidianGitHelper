# ObsidianGitHelper
A simple C# (.NET 6) script to integrate your Obsidian vault with a Git repository under Windows.

I created this to add an automatic pull -> push mechanism to my Obsidian vault. What the script does is simply perform a git pull on your Git repository (remote Obsidian vault), open Obsidian from your PC, then, as soon as you close Obsidian, commit and push to your remote repository.

*It ain't much, but it's an honest job!*

To make it work, just add a file config.json to the ObsidianGitHelper folder, with these properties (remove the comments of course):

    {
        "obsidianPathInLocalFolder": "Obsidian\\Obsidian.exe", // Relative path of the location in your C:\Users\user\AppData\Local\ folder where Obsidian is installed. At the time I wrote this the location is up-to-date, but who knows if it might change in the future.
        "repositoryUrl": "https://github.com/User/ObsidianRepo.git", // Git repository where your Obsidian repo is
        "repositoryLocalFolder": "C:\\your-repo-folder\\your-obsidian-repository" // Local folder where your Obsidian repo is cloned
    }
