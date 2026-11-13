# CWG Art Installer

A small Windows installer that sets up the custom art (models and textures) for **CWG**, a Warcraft III custom game.

## What it does

Warcraft III only loads custom art from your game folder if a hidden setting called **"Allow Local Files"** is switched on. Doing this by hand means editing the Windows registry and copying files into the right place. This installer does both for you:

1. **Turns on "Allow Local Files"** for Warcraft III.
2. **Finds your Warcraft III folder** automatically (you can also pick it yourself).
3. **Downloads the CWG art pack** and unpacks it into a `war3mapImported` folder inside your Warcraft III folder.

If the art is already installed, the installer opens a menu instead:

| Button | What it does |
| --- | --- |
| **Validate** | Checks that "Allow Local Files" is on and that the art files are in place. |
| **Reinstall** | Downloads the art pack again and overwrites the old files. |
| **Uninstall** | Turns "Allow Local Files" back off and deletes the `war3mapImported` folder. |

## How to use it

1. Download `CWGArtInstaller.exe` from the [Releases](../../releases) page.
2. Run it. Windows will ask for administrator permission — this is needed because Warcraft III usually lives in `C:\Program Files (x86)`, which normal programs can't write to.
3. Click **Install**, confirm your Warcraft III folder, then click **Install Models**.
4. Wait for **Complete**, then start Warcraft III.

Requirements: Windows 10 or 11 and an internet connection. Nothing else needs to be installed.

> **Note:** Uninstall deletes the whole `war3mapImported` folder. If you keep local files from other maps or mods in that folder, back them up first.

---

## Technical details

### Stack

- C# Windows Forms application
- Targets **.NET Framework 4.8** (`net48`), which ships with Windows 10 and 11, so players need no runtime install
- SDK-style project (`Microsoft.NET.Sdk` with `UseWindowsForms`)
- No NuGet packages; only framework references (`System.IO.Compression`, `System.IO.Compression.FileSystem`, `System.Net.Http`)
- The build produces a single `CWGArtInstaller.exe`; the files in `assets/` are compiled into it as embedded resources

### Project layout

```
CWGArtInstaller.sln
CWGArtInstaller/
├── CWGArtInstaller.csproj
├── app.manifest              Requests administrator rights (requireAdministrator)
├── Program.cs                Entry point; enables TLS 1.2 for HTTPS downloads
├── MainForm.cs               All wizard logic: install, download, extract, validate, uninstall
├── MainForm.Designer.cs      Form layout (edit with the Visual Studio designer)
├── WizardTabControl.cs       TabControl with tabs hidden at runtime, used as the wizard pages
├── WarcraftPathFinder.cs     Locates the Warcraft III folder (registry, then Program Files)
├── LocalFilesRegistry.cs     Reads and sets the "Allow Local Files" registry value
├── EmbeddedAssets.cs         Reads the embedded files from assets/
├── assets/
│   ├── EnableWC3LocalFiles.reg    Sets "Allow Local Files" to 1
│   ├── DisableWC3LocalFiles.reg   Sets "Allow Local Files" to 0
│   └── download_url.txt           URL of the art pack zip
└── Properties/PublishProfiles/FolderProfile.pubxml
```

### Prerequisites

Building requires Windows and either of:

- **Visual Studio 2022 or newer** with the **.NET desktop development** workload, or
- the **.NET SDK** (6.0 or newer) plus the **.NET Framework 4.8 Developer Pack**

### Build with Visual Studio

1. Open `CWGArtInstaller.sln`.
2. Set the configuration to **Release**.
3. Choose **Build > Build Solution** (`Ctrl+Shift+B`).

### Build from the command line

```powershell
dotnet build CWGArtInstaller.sln -c Release
```

The output is `CWGArtInstaller\bin\Release\net48\CWGArtInstaller.exe`. That one file is all that needs to be distributed; the `.pdb` and `.exe.config` next to it are optional.

To use the included publish profile instead:

```powershell
dotnet publish CWGArtInstaller\CWGArtInstaller.csproj -p:PublishProfile=FolderProfile
```

This writes to `CWGArtInstaller\bin\Release\net48\publish\`.

Because the manifest requests administrator rights, running or debugging the app triggers a UAC prompt. To debug, start Visual Studio as administrator.

### Changing the art pack

The download link is the first non-comment line of `CWGArtInstaller/assets/download_url.txt` (lines starting with `#` are ignored). It is embedded at compile time, so **rebuild after changing it**.

The link must return a `.zip` file directly. The zip is extracted as-is into the selected Warcraft III folder, so it should contain a top-level `war3mapImported/` folder holding the models and textures.

### How it works

**Registry.** The installer sets the DWORD value `Allow Local Files` under `HKEY_CURRENT_USER\Software\Blizzard Entertainment\Warcraft III` to `1` (install) or `0` (uninstall). It imports the matching embedded `.reg` file with `reg.exe import`, then verifies the value and writes it directly if the import did not take effect.

**Finding Warcraft III.** It first reads `InstallPath` from the same registry key, then falls back to `Warcraft III` under Program Files (x86) and Program Files. If a `_retail_` subfolder exists (Reforged), that folder is used as the install target. A folder is recognised as a Warcraft III install by the presence of files such as `Warcraft III.exe`, `Warcraft III Launcher.exe` or `war3.exe`.

**Install.** The zip is downloaded to `war3mapImported.zip` in the target folder with progress reporting, extracted over any existing files, and then deleted. Zip entries that would land outside the target folder are rejected. Closing the window during an install cancels it cleanly.

**Detecting an existing install.** On startup, if a `war3mapImported` folder exists in the Warcraft III root or its `_retail_` folder, the Manage page (Validate / Reinstall / Uninstall) is shown instead of the Welcome page.

**Uninstall.** Sets `Allow Local Files` to `0` and deletes the `war3mapImported` folder(s) found for the install.

## Disclaimer

This is an unofficial fan-made tool. It is not affiliated with or endorsed by Blizzard Entertainment. Warcraft III is a trademark of Blizzard Entertainment, Inc.
