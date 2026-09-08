using Microsoft.Win32;

namespace Linkly.Services
{
    /// <summary>
    /// Provides methods for managing Windows-level settings for the
    /// application
    /// </summary>
    public class WindowsSettingsService
    {
        /// <summary>
        /// The RunKeyPath constant defines the registry path for the Windows startup programs.
        /// </summary>
        private const string RunKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// Checks whether the application is currently registered to launch
        /// automatically when Windows starts.
        /// </summary>
        /// <param name="appName">
        /// The same unique name used when it was added.
        /// </param>
        /// <returns>
        /// <c>true</c> if the application is registered for startup;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool IsRegisteredForStartup(string appName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKeyPath))
            {
                return key?.GetValue(appName) != null;
            }
        }

        /// <summary>
        /// Adds (or updates) the running application in the Windows startup
        /// registry key, so it launches automatically when Windows starts.
        /// </summary>
        /// <param name="appName">
        /// A unique name for the registry value (typically the app name).
        /// </param>
        public void AddToWindowsStartup(string appName)
        {
            string exePath = Application.ExecutablePath;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKeyPath, writable: true))
            {
                if (key != null)
                {
                    // Quote the path in case it contains spaces.
                    key.SetValue(appName, $"\"{exePath}\"");
                }
            }
        }

        /// <summary>
        /// Removes the application from the Windows startup registry key,
        /// if it exists there.
        /// </summary>
        /// <param name="appName">
        /// The same unique name used when it was added.
        /// </param>
        public void RemoveFromWindowsStartup(string appName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKeyPath, writable: true))
            {
                if (key?.GetValue(appName) != null)
                {
                    key.DeleteValue(appName, throwOnMissingValue: false);
                }
            }
        }
    }
}
