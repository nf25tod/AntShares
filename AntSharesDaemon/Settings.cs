﻿using Microsoft.Extensions.Configuration;

namespace AntShares
{
    internal class Settings
    {
        public string DataDirectoryPath { get; private set; }
        public ushort NodePort { get; set; }

        public static Settings Default { get; private set; }

        static Settings()
        {
            IConfigurationSection section = new ConfigurationBuilder().AddJsonFile("config.json").Build().GetSection("ApplicationConfiguration");
            Default = new Settings
            {
                DataDirectoryPath = section.GetSection("DataDirectoryPath").Value,
                NodePort = ushort.Parse(section.GetSection("NodePort").Value)
            };
        }
    }
}
