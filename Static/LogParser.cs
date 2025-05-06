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
            parsedRow = new List<string>();
            if (setting == null || setting.Fields.Count == 0 || string.IsNullOrWhiteSpace(line))
                return false;

            var parts = line.Split(' ');
            if (parts.Length < 2)
                return false;

            string[] hexBytes = parts[1].Split('-');
            int cmdIndex;
            if (!int.TryParse(setting.CmdIndex, out cmdIndex) || cmdIndex < 1 || cmdIndex > hexBytes.Length)
                return false;

            string cmd = hexBytes[cmdIndex - 1];
            if (!string.Equals(cmd, setting.CmdValue, StringComparison.OrdinalIgnoreCase))
                return false;

            int cursor = cmdIndex;
            parsedRow.Add(parts[0]); // timeAndDir

            foreach (Field field in setting.Fields)
            {
                if (cursor + field.ByteCount > hexBytes.Length)
                    break;

                var chunk = hexBytes.Skip(cursor).Take(field.ByteCount).ToArray();
                cursor += field.ByteCount;

                string originalHex = string.Join("-", chunk);
                string decimalBytes = string.Join("-", chunk.Select(h =>
                {
                    int val;
                    return int.TryParse(h, System.Globalization.NumberStyles.HexNumber, null, out val) ? val.ToString() : "ERR";
                }));

                int decimalValue = 0;
                try
                {
                    byte[] bytes = chunk.Select(h => Convert.ToByte(h, 16)).ToArray();
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