using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EloBuddy.Sandbox;
using EloBuddy.SDK.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpDX;

namespace Simple_Marksmans.Utils
{
    internal class FileHandler
    {
        public static string ColorFileName { get; } = "colors.json";

        public static JToken ReadDataFile(string fileName)
        {
            var filePath = Path.Combine(SandboxConfig.DataDirectory, Path.Combine("Marksman AIO", fileName));

            if (File.Exists(filePath) == false)
            {
                Logger.Error("File not found: " + filePath);
                return null;
            }
            try
            {
                return Task.Factory.StartNew(() => ReadJsonFile(filePath)).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        private static JToken ReadJsonFile(string path)
        {
            JToken token;

            using (var streamReader = new StreamReader(path))
            {
                var file = new JsonTextReader(streamReader);
                token = JToken.ReadFrom(file);
            }

            return token;
        }

        public static void WriteToDataFile(string uniqueId, ColorBGRA color)
        {
            var filePath = Path.Combine(SandboxConfig.DataDirectory, Path.Combine("Marksman AIO", ColorFileName));

            if (File.Exists(filePath) == false)
            {
                File.Create(Path.Combine(SandboxConfig.DataDirectory, Path.Combine("Marksman AIO", ColorFileName)));
            }
            else
            {
                try
                {
                    var file = ReadDataFile(ColorFileName);

                    Dictionary<string, ColorBGRA> dictionary;

                    //Empty file
                    if (file == null)
                    {
                        dictionary = new Dictionary<string, ColorBGRA> {{uniqueId, color}};
                    }
                    else
                    {
                        dictionary = file.ToObject<Dictionary<string, ColorBGRA>>();

                        if (dictionary.ContainsKey(uniqueId))
                        {
                            dictionary[uniqueId] = color;
                        }
                        else
                        {
                            dictionary.Add(uniqueId, color);
                        }
                    }

                    var fileStream = File.Open(filePath, FileMode.Open);
                    var streamWriter = new StreamWriter(fileStream);

                    using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonWriter.Formatting = Formatting.Indented;
                        new JsonSerializer().Serialize(jsonWriter, dictionary);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
        }
    }
}