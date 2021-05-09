using EducationPortal.Domain.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Data
{
    public class JsonFileOperations<T> where T : class
    {
        public void JsonSave(T item)
        {
            // сохранение данных
            File.WriteAllText(@"D:\Users.json", JsonConvert.SerializeObject(item));
            Console.WriteLine("Data has been saved to file");
        }
        static public  List<T> JsonDeserializer()
        {
            // чтение данных
            T restoredItem = JsonConvert.DeserializeObject<T>(File.ReadAllText(@"D:\Users.json"));
            Console.WriteLine("Data has been read from file");
            List<T> list = new List<T>();
            list.Add(restoredItem);
            return list;
        }
    }
}
