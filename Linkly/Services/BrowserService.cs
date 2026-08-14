using Linkly;
using Linkly.Dialogs;
using Linkly.Models;
using Microsoft.Win32;
using System.Diagnostics;
using MenuItem = Linkly.Models.MenuItem;

/// <summary>
/// Provides functionality for launching web browsers dynamically, detecting installation paths,
/// and applying options such as incognito/private mode and new-window behavior.
/// </summary>
public static class BrowserService
{
    #region Public Methods

    /// <summary>
    /// Opens the specified URL in the chosen browser, applying incognito/private mode and
    /// new-window behavior when supported by the browser.
    /// </summary>
    /// <param name="link">The link containing the URL, browser type, and launch options.</param>
    public static void OpenBrowser(MenuItem menuItem)
    {
        string exePath = FindBrowserExecutable(menuItem.LinkOptions.Browser);

        if (string.IsNullOrWhiteSpace(exePath))
        {
            /* If the browser executable cannot be found, notify the user,
               and exit the method without attempting to launch the browser. */
            MessageBox.Show($"Could not locate executable for Browser Type '{menuItem.LinkOptions.Browser}'." + 
                            Environment.NewLine +
                            "Please install this browser or update the link to a different one!",
                            $"{menuItem.LinkOptions.Browser} Browser Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            return;
        }

        if (menuItem.LinkOptions.ParamReplacementsDic != null && 
            menuItem.LinkOptions.ParamReplacementsDic.Count > 0)
        {    
            foreach (var kvp in menuItem.LinkOptions.ParamReplacementsDic)
            {
                /* Prompt the user for each parameter value and perform a 
                   search/replace on the URL before launching the browser. */
                var inputDialog = 
                    new InputDialog($"{kvp.Value} Parameter Prompt for Link --> {menuItem.Name}",
                                    $"Enter a value for the '{kvp.Value}' parameter:");

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    // Search & Replace the parameter placeholder in the URL with the user-provider value.
                    menuItem.LinkOptions.Url = menuItem.LinkOptions.Url.Replace(kvp.Key, inputDialog.OutputTextValue);
                }
                else
                {
                    return; // User canceled the input dialog, so we exit without opening the browser.
                }
            }
        }

        // Create the Process to open the browser with the specified URL and options.
        var processStartInfo = new ProcessStartInfo
        {
            FileName = exePath,
            Arguments = BuildArguments(menuItem.LinkOptions.Browser, 
                                       menuItem.LinkOptions.Url, 
                                       menuItem.LinkOptions.IsIncognito,
                                       menuItem.LinkOptions.IsNewWindow),
            UseShellExecute = true
        };

        // Start the Process
        Process.Start(processStartInfo);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Builds the command-line arguments required to launch the browser with the specified options.
    /// </summary>
    private static string BuildArguments(BrowserType browser, string url, bool incognito, bool newBrowser)
    {
        string args = string.Empty;

        switch (browser)
        {
            case BrowserType.Chrome:
                {
                    args = $"{(incognito ? "--incognito " : "")}{(newBrowser ? "--new-window " : "")}{url}";
                    break;
                }
            case BrowserType.Edge:
                {
                    args = $"{(incognito ? "--inprivate " : "")}{(newBrowser ? "--new-window " : "")}{url}";
                    break;
                }
            case BrowserType.Firefox:
                {
                    if (incognito)
                    {
                        args = $"-private-window {url}";
                    }
                    else if (newBrowser)
                    {
                        args = $"-new-window {url}";
                    }
                    else
                    {
                        args = url;
                    }
                    break;
                }
            case BrowserType.InternetExplorer:
                {
                    args = url;
                    break;
                }
            case BrowserType.Brave:
                {
                    args = $"{(incognito ? "--incognito " : "")}{(newBrowser ? "--new-window " : "")}{url}";
                    break;
                }
            case BrowserType.Opera:
                {
                    if (incognito)
                    {
                        args = $"--private {url}";
                    }
                    else if (newBrowser)
                    {
                        args = $"--new-window {url}";
                    }
                    else
                    {
                        args = url;
                    }
                    break;
                }
            case BrowserType.Safari:
                {
                    args = url;
                    break;
                }
            default:
                {
                    throw new NotSupportedException();
                }
        }

        return args;
    }

    /// <summary>
    /// Locates the executable path for the specified browser using registry lookup,
    /// known installation directories, and PATH scanning.
    /// </summary>
    private static string FindBrowserExecutable(BrowserType browser)
    {
        string result = null;

        switch (browser)
        {
            case BrowserType.Chrome:
                {
                    result = FindChrome();
                    break;
                }
            case BrowserType.Edge:
                {
                    result = FindEdge();
                    break;
                }
            case BrowserType.Firefox:
                {
                    result = FindFirefox();
                    break;
                }
            case BrowserType.InternetExplorer:
                {
                    result = FindIE();
                    break;
                }
            case BrowserType.Brave:
                {
                    result = FindBrave();
                    break;
                }
            case BrowserType.Opera:
                {
                    result = FindOpera();
                    break;
                }
            case BrowserType.Safari:
                {
                    result = FindSafari();
                    break;
                }
            default:
                {
                    result = null;
                    break;
                }
        }

        return result;
    }

    /// <summary>
    /// Attempts to locate the Google Chrome executable using registry lookup and common installation paths.
    /// </summary>
    private static string FindChrome()
    {
        string result = null;

        string regPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";
        string chromePath = Registry.GetValue($"HKEY_LOCAL_MACHINE\\{regPath}", "", null) as string;

        if (!string.IsNullOrWhiteSpace(chromePath) && File.Exists(chromePath))
        {
            result = chromePath;
        }
        else
        {
            result = SearchCommonPaths("chrome.exe");
        }

        return result;
    }

    /// <summary>
    /// Attempts to locate the Microsoft Edge executable using known installation paths and PATH scanning.
    /// </summary>
    private static string FindEdge()
    {
        string result = null;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                                   "Microsoft",
                                   "Edge",
                                   "Application",
                                   "msedge.exe");

        if (File.Exists(path))
        {
            result = path;
        }
        else
        {
            result = SearchCommonPaths("msedge.exe");
        }

        return result;
    }

    /// <summary>
    /// Attempts to locate the Mozilla Firefox executable using registry lookup and common installation paths.
    /// </summary>
    private static string FindFirefox()
    {
        string result = null;

        string regPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\firefox.exe";
        string firefoxPath = Registry.GetValue($"HKEY_LOCAL_MACHINE\\{regPath}", "", null) as string;

        if (!string.IsNullOrWhiteSpace(firefoxPath) && File.Exists(firefoxPath))
        {
            result = firefoxPath;
        }
        else
        {
            result = SearchCommonPaths("firefox.exe");
        }

        return result;
    }

    /// <summary>
    /// Attempts to locate the Internet Explorer executable using known installation paths.
    /// </summary>
    private static string FindIE()
    {
        string result = null;

        string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            "Internet Explorer", "iexplore.exe");

        if (File.Exists(path))
        {
            result = path;
        }
        else
        {
            result = SearchCommonPaths("iexplore.exe");
        }

        return result;
    }

    /// <summary>
    /// Attempts to locate the Brave browser executable using registry lookup and common installation paths.
    /// </summary>
    private static string FindBrave()
    {
        string result = null;

        string regPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\brave.exe";
        string bravePath = Registry.GetValue($"HKEY_LOCAL_MACHINE\\{regPath}", "", null) as string;

        if (!string.IsNullOrWhiteSpace(bravePath) && File.Exists(bravePath))
        {
            result = bravePath;
        }
        else
        {
            result = SearchCommonPaths("brave.exe");
        }

        return result;
    }

    /// <summary>
    /// Attempts to locate the Opera browser executable using known installation paths.
    /// </summary>
    private static string FindOpera()
    {
        string result = null;

        string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            "Opera", "opera.exe");

        if (File.Exists(path))
        {
            result = path;
        }
        else
        {
            result = SearchCommonPaths("opera.exe");
        }

        return result;
    }

    /// <summary>
    /// Returns null because Safari is not available on Windows.
    /// </summary>
    private static string FindSafari()
    {
        string result = null;
        return result;
    }

    /// <summary>
    /// Searches common installation directories and PATH entries for the specified executable name.
    /// </summary>
    private static string SearchCommonPaths(string exeName)
    {
        string result = null;

        string[] roots =
        {
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
            Environment.GetEnvironmentVariable("PATH")
        };

        foreach (string root in roots)
        {
            if (string.IsNullOrWhiteSpace(root))
            {
                continue;
            }

            foreach (string dir in root.Split(';'))
            {
                if (string.IsNullOrWhiteSpace(dir))
                {
                    continue;
                }

                try
                {
                    string candidate = Path.Combine(dir, exeName);

                    if (File.Exists(candidate))
                    {
                        result = candidate;
                        break;
                    }
                }
                catch
                {
                }
            }

            if (!string.IsNullOrWhiteSpace(result))
            {
                break;
            }
        }

        return result;
    }

    #endregion
}
