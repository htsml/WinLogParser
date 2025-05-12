using System.Collections.Generic;
using System.Linq;
using System;
using WinLogParser.Model;

namespace WinLogParser
{
    public static class LogParser
    {
        public static bool TryParseLine(string line, CmdSetting setting, out List<string> parsedRow)
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
                timestampDir = parts[0].Trim('[', ']');
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
                if (cursor + field.ByteCount > hexBytes.Length)
                    break;

                chunk = hexBytes.Skip(cursor).Take(field.ByteCount).ToArray();
                cursor += field.ByteCount;

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