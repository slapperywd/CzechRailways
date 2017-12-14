using System;
using System.IO;
using System.Xml.Serialization;

namespace CZProjectFramework.Utils
{
    public static class XmlReader
    {
        public static T Read<T>(string name)
        {
            T entity;
            var xs = new XmlSerializer(typeof(T));
            using (Stream sr = File.OpenRead($@"{AppDomain.CurrentDomain.BaseDirectory}\Resources\{name}"))
            {
                entity = (T)xs.Deserialize(sr);
            }
            return entity;
        }
    }
}