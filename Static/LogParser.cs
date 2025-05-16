using System.Collections.Generic;
using System.Linq;
using System;
using WinLogParser.Model;
using System.Text.RegularExpressions;

namespace WinLogParser
{
    public static class LogParser
    {
        public static bool TryParseMachineCommand(string line, CmdSetting setting, out List<string> parsedRow)
        {
            parsedRow = new List<string>();

            int cursor = 0;

            string data = string.Empty;
            string slice = string.Empty;
            string timestamp = string.Empty;
            string cmdPattern = string.Empty;

            Match match;
            Match timestampMatch;

            if (string.IsNullOrWhiteSpace(line) || setting == null || string.IsNullOrEmpty(setting.From) || string.IsNullOrEmpty(setting.CMD))
                return false;

            try
            {
                timestampMatch = Regex.Match(line, @"^\[(.*?)\]");
                if (!timestampMatch.Success)
                    return false;

                timestamp = timestampMatch.Groups[1].Value; // ex: xxxx-xx-xx_xx:xx:xx.xx
                parsedRow.Add(timestamp);

                if (!line.Contains("[" + setting.From + "]"))
                    return false;

                cmdPattern = $@"\[@{setting.CMD}([A-Za-z0-9\.]+?)(?=[,\]])";
                match = Regex.Match(line, cmdPattern);

                if (!match.Success || match.Groups.Count < 2)
                    return false;

                data = match.Groups[1].Value;  // ex: "0010000025.0407E"

                foreach (var field in setting.Fields)
                {
                    slice = string.Empty;

                    if (field.Count == -1)
                    {
                        parsedRow.Add(field.FieldName + ": " + data.Substring(cursor));
                        break;
                    }

                    if (cursor + field.Count > data.Length)
                        break;

                    slice = data.Substring(cursor, field.Count);
                    parsedRow.Add(slice);
                    cursor += field.Count;
                }

                return parsedRow.Count > 1; 
            }
            catch
            {
                return false;
            }
        }
        public static bool TryParseDirectionLogLine(string line, CmdSetting setting, out List<string> parsedRow)
        {
            int cursor = 0;

            string to = string.Empty;
            string from = string.Empty;
            string fullData = string.Empty;
            string fieldValue = string.Empty;

            Match cmdMatch = null;
            Match routeMatch = null;

            parsedRow = new List<string>();

            if (string.IsNullOrEmpty(line) || setting == null || string.IsNullOrEmpty(setting.From) || string.IsNullOrEmpty(setting.To) || string.IsNullOrEmpty(setting.CMD))
                return false;

            try
            {
                routeMatch = Regex.Match(line, @"\[(\w+)\s*->\s*(\w+)\]");

                if (routeMatch.Success == false)
                    return false;

                from = routeMatch.Groups[1].Value;
                to = routeMatch.Groups[2].Value;

                if (string.Equals(from, setting.From, StringComparison.OrdinalIgnoreCase) == false ||
                    string.Equals(to, setting.To, StringComparison.OrdinalIgnoreCase) == false)
                    return false;
                        
                cmdMatch = Regex.Match(line, $@"\[@({setting.CMD})([A-Fa-f0-9]+)\]");
                if (cmdMatch.Success == false || cmdMatch.Groups.Count < 3)
                    return false;

                fullData = cmdMatch.Groups[2].Value;

                foreach(var field in setting.Fields)
                {
                    if (cursor + field.Count > fullData.Length)
                        break;

                    fieldValue = fullData.Substring(cursor, field.Count);
                    parsedRow.Add($"{field.FieldName}: {fieldValue}");
                    cursor += field.Count;
                }

                return parsedRow.Count > 0;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static bool TryParseHexLogLine(string line, CmdSetting setting, out List<string> parsedRow)
        {
            int cursor = 0;
            int cmdIndex = 0;
            int decimalValue = 0;

            string cmd = string.Empty;
            string originalHex = string.Empty;
            string decimalBytes = string.Empty;
            string timestampDir = string.Empty;
            string directionAndHex = string.Empty;

            string direction = string.Empty;
            string hex = string.Empty;

            byte[] bytes = null;

            string[] parts = null;
            string[] chunk = null;
            string[] hexBytes = null;
            string[] directionAndHexSplit = null;

            parsedRow = new List<string>();
            if (setting == null || setting.Fields.Count == 0 || string.IsNullOrWhiteSpace(line))
                return false;

            parts = line.Split('/');

            if (setting.IsRead && parts.Length == 2)
            {
                // 형태: [timestamp]/[R] [hex]
                timestampDir = parts[0].Trim('[', ']');
                directionAndHex = parts[1].Trim();
                directionAndHexSplit = directionAndHex.Split(' ');
                timestampDir = $"{timestampDir} {directionAndHexSplit[0]}";
                hexBytes = directionAndHexSplit[1].Split('-');
                // directionAndHex: "[R] 02-01-30"
            }
            else if (!setting.IsRead && parts.Length == 3)
            {
                // 형태: [timestamp]/[W]/[hex]
                timestampDir = $"{parts[0].Trim('[', ']')}/[W]";
                direction = parts[1].Trim('[', ']');
                hex = parts[2].Trim();
                hexBytes = hex.Split('-');
            }
            else
            {
                return false;
            }

            if (!int.TryParse(setting.CmdIndex, out cmdIndex) || cmdIndex < 1 || cmdIndex > hexBytes.Length)
                return false;

            cmd = hexBytes[cmdIndex - 1];
            if (!string.Equals(cmd, setting.CmdValue, StringComparison.OrdinalIgnoreCase))
                return false;

            cursor = 0;
            parsedRow.Add(timestampDir);

            foreach (Field field in setting.Fields)
            {
                if (cursor + field.Count > hexBytes.Length)
                    break;

                chunk = hexBytes.Skip(cursor).Take(field.Count).ToArray();
                cursor += field.Count;

                originalHex = string.Join("-", chunk);
                decimalBytes = string.Join("-", chunk.Select(h =>
                {
                    int val;
                    return int.TryParse(h, System.Globalization.NumberStyles.HexNumber, null, out val) ? val.ToString() : "ERR";
                }));

                decimalValue = 0;

                try
                {
                    bytes = chunk.Select(h => Convert.ToByte(h, 16)).ToArray();
                    foreach (byte b in bytes)
                        decimalValue = (decimalValue << 8) | b;
                }
                catch { decimalValue = -1; }

                parsedRow.Add(string.Format("{0} / {1} / {2}", originalHex, decimalBytes, decimalValue));
            }
            return true;
        }
    }
}