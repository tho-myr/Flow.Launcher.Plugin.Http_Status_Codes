<div align="center">
  <img src="Flow.Launcher.Plugin.Http_Status_Codes/Images/icon.png" alt="Shortcuts logo" width="75">  
  
<h1>Http Status Codes <br> Quickly search for http status codes</h1>
  <br>
</div>


<div align="center">
    <div>
        <a href="https://github.com/Flow-Launcher/Flow.Launcher.PluginsManifest">
            <img src="https://img.shields.io/badge/Flow%20Launcher-Plugin-blue" alt="Flow Launcher Plugin">
        </a>
        <a href="https://github.com/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes/issues">
            <img src="https://img.shields.io/github/issues/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes" alt="GitHub issues">
        </a>
        <a href="https://github.com/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes/pulls">
            <img src="https://img.shields.io/github/issues-pr/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes" alt="GitHub pull requests">
        </a>
        <a href="https://github.com/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes/actions/workflows/release.yml">
            <img src="https://img.shields.io/github/actions/workflow/status/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes/release.yml?branch=master" alt="GitHub workflow status">
        </a>
        <a href="https://github.com/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes/commits">
            <img src="https://img.shields.io/github/last-commit/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes" alt="GitHub last commit">
        </a>
    </div>
</div>

<br>

Flow.Launcher.Plugin.Http_Status_Codes
==================

> [!NOTE]
>
> Feel free to leave suggestions or report bugs in
> the [issues](https://github.com/tho-myr/Flow.Launcher.Plugin.Http_Status_Codes/issues) section.

A plugin to search for http response status codes with [Flow launcher](https://github.com/Flow-Launcher/Flow.Launcher).


### Usage

```cmd
hs <status_code>

or

hs <search_query>
```

### Development

#### Prerequisites

- Install dotnet version <=8.x.x from Microsoft [here](https://dotnet.microsoft.com/en-us/download). 
- Install latest version of [Flow launcher](https://github.com/Flow-Launcher/Flow.Launcher). (default installation path is recommended for faster testing)

#### Build project

Run the following command in the root folder of the repository/project.

Exit [Flow launcher](https://github.com/Flow-Launcher/Flow.Launcher), build with `dotnet build` 
and then restart [Flow launcher](https://github.com/Flow-Launcher/Flow.Launcher)

```cmd
dotnet build
```

> [!WARNING]
> The output folder during `dotnet build` is set to the default flow launcher installation path.
> 
> ```$(UserProfile)\AppData\Roaming\FlowLauncher\Plugins\Http Status Codes-DEBUG\```
>
> To build the project in the project directory remove or comment out the following line from [Flow.Launcher.Plugin.Http_Status_Codes.csproj](Flow.Launcher.Plugin.Http_Status_Codes/Flow.Launcher.Plugin.Http_Status_Codes.csproj).
>
> ```<OutputPath>$(UserProfile)\AppData\Roaming\FlowLauncher\Plugins\Http Status Codes-DEBUG\</OutputPath>```
>
> If commented out you have to manually paste the build files from the folder `/Flow.Launcher.Plugin.Http_Status_Codes/bin/Debug` to the plugin folder of your [Flow launcher](https://github.com/Flow-Launcher/Flow.Launcher) installation.

### Release plugin

1. Update [CHANGELOG.md](CHANGELOG.md) for new release.
2. Update version in [plugin.json](Flow.Launcher.Plugin.Http_Status_Codes/plugin.json)
3. Create the tag on the `master` branch and build the release.
4. Follow the steps [here](https://github.com/Flow-Launcher/Flow.Launcher.PluginsManifest?tab=readme-ov-file#how-to-submit-your-plugin) to submit plugin 