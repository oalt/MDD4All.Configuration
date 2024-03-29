﻿/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.Configuration.Contracts;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace MDD4All.Configuration
{
    public class FileConfigurationReaderWriter<T> : IConfigurationReaderWriter<T>
    {

        private T _configurationData;

        private string _configurationPathExtension = "";

        public FileConfigurationReaderWriter()
        {
        }

        public FileConfigurationReaderWriter(string configurationPathExtension)
        {
            if(configurationPathExtension != null)
            {
                _configurationPathExtension = configurationPathExtension;
            }
        }

        public T GetConfiguration()
        {
            T result = default;

            if (_configurationData == null)
            {
                try
                {
                    string json = File.ReadAllText(GetConfigurationFilename());

                    result = JsonConvert.DeserializeObject<T>(json);

                    _configurationData = result;
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            }
            else
            {
                result = _configurationData;
            }

            return result;
        }


        public void StoreConfiguration(T configurationData)
        {
            try
            {
                string json = JsonConvert.SerializeObject(configurationData);

                File.WriteAllText(GetConfigurationFilename(), json);

                _configurationData = configurationData;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private string GetConfigurationFilename()
        {
            string result = "";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if(!string.IsNullOrEmpty(_configurationPathExtension))
            {
                path += "/" + _configurationPathExtension;
            }

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            result = path + "/" + typeof(T).Name + ".json";

            return result;
        }
    }
}
