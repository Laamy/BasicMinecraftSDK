using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhop.IO
{
    public class YaamiIO // I made this library years ago and just found it wtf
    {
        private static List<string> loadedConfig = new List<string>();
        public static string dataFileName = "yaamiIO.cfg";
        private static bool loadedConfigFile = false;

        public static string errorCode_0x000 = "No Yaami files :(";
        public static string errorCode_0x00C = "null";

        /// <summary>
        /// Log data into the console as YaamiIO
        /// </summary>
        public static void log(string value) => Console.WriteLine($"YaamiIO> {value}");

        /// <summary>
        /// Add data to the config with the set address
        /// </summary>
        public static void add(string Datatag, string value)
        {
            bool foundObj = false;
            foreach (var datatag in loadedConfig)
                if (datatag == Datatag)
                    foundObj = true;
            if (foundObj) remove(Datatag);
            loadedConfig.Add($"New DataTag(\"{Datatag}={value}\")");
        }

        /// <summary>
        /// Remove data from the config with the set address
        /// </summary>
        public static void remove(string Datatag)
        {
            foreach (var datatag in loadedConfig)
                if (datatag == Datatag)
                    loadedConfig.Remove(datatag);
        }

        /// <summary>
        /// Read data from the config with the set address
        /// </summary>
        public static string read(string Datatag)
        {
            foreach (var datatag in loadedConfig)
                if (datatag == Datatag)
                    return datatag.Split('"')[1].Split('=')[1];
            log($"Cant find {dataFileName} Datatag '{Datatag}'");
            return errorCode_0x000;
        }

        /// <summary>
        /// Load the config
        /// </summary>
        public static void loadConfig(string configFilePath)
        {
            if (hasConfig())
            {
                dataFileName = configFilePath;
                loadedConfig.Clear();
                foreach (var line in File.ReadAllLines(dataFileName))
                    loadedConfig.Add(line);
                loadedConfigFile = true;
            }
        }

        /// <summary>
        /// Save the config
        /// </summary>
        public static void saveConfig(string configFilePath)
        {
            dataFileName = configFilePath;
            TextWriter SW = new StreamWriter(dataFileName);
            foreach (var line in loadedConfig)
                SW.WriteLine(line);
            SW.Dispose();
        }

        /// <summary>
        /// Check if the config exists
        /// </summary>
        /// <returns></returns>
        public static bool hasConfig()
        {
            if (File.Exists(dataFileName))
                return true;
            return false;
        }

        /// <summary>
        /// Config has been loaded already check
        /// </summary>
        /// <returns></returns>
        public static bool hasLoadedConfig() => loadedConfigFile;
    }
}
