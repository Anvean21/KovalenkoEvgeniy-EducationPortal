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
        /// <summary>
        /// Для запуска из коробки необходимо что-бы база данных была инициализирована, иначе выскочит null
        /// </summary>
        public void JsonSave(List<T> item, string path)
        {

            List<T> list = JsonFileOperations<T>.JsonDeserializer(path);
            list.AddRange(item);
            File.WriteAllText(path, JsonConvert.SerializeObject(list));
            Console.WriteLine("Data has been saved to file");

            // Расскоменитровать это и закоментировать то что сверху. + расскоментировать EducationPortalDbInitializer
            // File.WriteAllText(path, JsonConvert.SerializeObject(item));

        }
        static public List<T> JsonDeserializer(string path)
        {
            List<T> restoredItem = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            Console.WriteLine("Data has been read from file");
            return restoredItem;
        }
    }
}
