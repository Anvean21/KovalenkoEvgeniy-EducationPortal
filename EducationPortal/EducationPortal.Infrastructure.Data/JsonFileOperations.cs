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
        public void JsonSave(List<T> item, string path)
        {
            //изначальная база
            List<T> list = JsonFileOperations<T>.JsonDeserializer(path);
            //Добавляем новые обьекты в бд
            list.AddRange(item);
            //сохранение данных
            File.WriteAllText(path, JsonConvert.SerializeObject(list));
            Console.WriteLine("Data has been saved to file");


        }
        static public List<T> JsonDeserializer(string path)
        {
            //var list = JsonExtensions.FromDelimitedJson<T>(new StringReader(path));
            List<T> restoredItem = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            Console.WriteLine("Data has been read from file");
            return restoredItem;
        }
    }
}
