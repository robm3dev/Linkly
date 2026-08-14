using Linkly.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using MenuItem = Linkly.Models.MenuItem;

namespace Linkly.Services
{
    /// <summary>
    /// A Public Class to provider file & directory services to the Linkly Application
    /// </summary>
    public class FileServices
    {
        /// <summary>
        /// The \Linkly Settings File Directory Path
        /// </summary>
        public static string ConfigDirectoryPath { get; set; }

        /// <summary>
        /// The Linkly Config Path and File Name
        /// </summary>
        public static string ConfigFileNameAndPath { get; set; }

        /// <summary>
        /// The \Sample Directory Path
        /// </summary>
        public string SampleDirectoryPath { get; set; }

        /// <summary>
        /// The Public File Services Class Consructor
        /// </summary>
        public FileServices()
        {
            ConfigDirectoryPath =
                String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).TrimEnd('\\'),
                              "\\Linkly");

            ConfigFileNameAndPath =
                String.Concat(ConfigDirectoryPath,
                                "\\LinklyConfig.json");

            this.SampleDirectoryPath =
                String.Concat(System.Environment.CurrentDirectory.TrimEnd('\\'),
                              $"\\Samples");
        }

        /// <summary>
        /// Checks for the existence of the Config Directory and creates it if it does not exist
        /// </summary>
        /// <returns>Boolean value indicating success or failure; determines if the application be executed or not.</returns>
        public bool CheckForAndCreateConfigDirectory()
        {
            var success = true;

            try
            {
                if (!Directory.Exists(ConfigDirectoryPath))
                {
                    // Create the Settings File Directory
                    Directory.CreateDirectory(ConfigDirectoryPath);

                    // Copy all the Sample Files to the Config Directory
                    foreach (string filePath in Directory.GetFiles(this.SampleDirectoryPath))
                    {
                        string fileName = Path.GetFileName(filePath);
                        string destFile = Path.Combine(ConfigDirectoryPath, fileName);
                        File.Copy(filePath, destFile, overwrite: true);
                    }
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Checks for the existence of the Settings File and returns a boolean value indicating its existence
        /// </summary>
        /// <returns>Boolean value indicating the existence of the Linkly settings file.</returns>
        public bool CheckForSettingsFile()
        {
            var success = true;

            if (!File.Exists(ConfigFileNameAndPath))
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Loads the Linkly Settings File and deserializes it into a List of Link objects
        /// </summary>
        /// <returns>The Generic List of MenuItem Objects</returns>
        public List<MenuItem> LoadConfigurationFromFile()
        {
            var configuration = new List<MenuItem>();

            try
            {
                if (File.Exists(ConfigFileNameAndPath))
                {
                    var options = new JsonSerializerOptions 
                    { 
                        PropertyNameCaseInsensitive = true,
                        ReadCommentHandling = JsonCommentHandling.Skip 
                    }; 
                    
                    // serialize enums as their names (use CamelCase if your JSON uses camelCase)
                    options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

                    // Load the configuration file
                    using var jsonStream = File.OpenRead(ConfigFileNameAndPath);

                    // Deserialize the JSON into your configuration object
                    configuration = JsonSerializer.Deserialize<List<MenuItem>>(jsonStream, options) ?? new List<MenuItem>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading configuration file:\r\n\r\n{ex.Message} " + Environment.NewLine + Environment.NewLine +
                                "Please check the file format and try again, or delete the file and allow it to be re-generated.  " + Environment.NewLine +
                                "The application will be terminated.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                Application.Exit();
            }

            return configuration;
        }

        /// <summary>
        /// Saves the Linkly Settings File by serializing a List of Link objects 
        /// into JSON and writing it to the configuration file.
        /// </summary>
        /// <param name="configuration">The Generic List of MenuItem Objects</param>
        /// <returns>Boolean value indicating the success of the operation</returns>
        public bool SaveConfigurationToFile(List<MenuItem> configuration)
        {
            var success = false;

            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // serialize enums as their names (use CamelCase if your JSON uses camelCase)
                options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

                // Serialize the configuration object to JSON
                string jsonString = JsonSerializer.Serialize(configuration, options);

                // Write the JSON to the configuration file
                File.WriteAllText(ConfigFileNameAndPath, jsonString, System.Text.Encoding.UTF8);

                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving configuration file: {ConfigFileNameAndPath}" + Environment.NewLine + Environment.NewLine +
                                $"Error:\r\n{ex.Message}" + Environment.NewLine + Environment.NewLine +
                                "Please make sure the configuration file is not currently in use by another application and try again, or delete the file manually and try again." + Environment.NewLine +
                                "The application will be terminated.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            return success;
        }
    }
}
