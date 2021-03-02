/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
namespace MDD4All.Configuration.Contracts
{
    public interface IConfigurationReaderWriter<T>
    {
        T GetConfiguration();

        void StoreConfiguration(T configurationData);
    }
}
