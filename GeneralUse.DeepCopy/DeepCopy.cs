﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GeneralUse.DeepCopy
{
    public static class DeepCopy
    {
        public static T Deepcopy<T>(T obj)

        {

            if (!typeof(T).IsSerializable)
                throw new Exception("The source object must be serializable");


            if (Object.ReferenceEquals(obj, null))
                throw new Exception("The source object must not be null");


            T result = default(T);

            using (var memoryStream = new MemoryStream())

            {

                var formatter = new BinaryFormatter();

                formatter.Serialize(memoryStream, obj);

                memoryStream.Seek(0, SeekOrigin.Begin);

                result = (T)formatter.Deserialize(memoryStream);

                memoryStream.Close();

            }

            return result;

        }
    }
}
