using Newtonsoft.Json;
using System;
using System.IO;

namespace IO.JsonFile
{
    public static class UtilityFileReader
    {
        static public T ReadJsonFromFile<T>(string FilePath)
        {
            using StreamReader r = new StreamReader(FilePath);
            T Object = default(T);
            try
            {
                Object = JsonConvert.DeserializeObject<T>(r.ReadToEnd());
            }
            catch (Exception e) {}

            return Object;
        }

        static public void WriterJsonToFile<T>(string FilePath, T Object)
        {
            using StreamWriter r = new StreamWriter(FilePath);
            var s = JsonConvert.SerializeObject(Object);
            r.Write(s);
        }
    }
}
