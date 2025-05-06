using WinLogParser.Model;
using Newtonsoft.Json;
using System.IO;

namespace WinLogParser
{
    public static class SettingsStorage
    {
        public static void SaveToFile(CmdSetting setting, string filePath)
        {
            string json = JsonConvert.SerializeObject(setting, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static CmdSetting LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Settings file not found.");

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<CmdSetting>(json);
        }
    }
}