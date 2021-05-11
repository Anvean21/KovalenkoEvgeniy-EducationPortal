using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Data
{
    public class JsonSet<T> : IRepository<T> where T : class
    {
        DirectoryInfo directory;
        Type type;
        public JsonSet()
        {
            this.type = typeof(T);
            this.directory = new DirectoryInfo($"{this.type.Name}");
        }
        public void Create(T item)
        {
            Directory.CreateDirectory($"{this.type.Name}");

            //Id итератор. Нужно подумать что делать если папка пустая.
            typeof(T).GetProperty("Id").SetValue(item, directory.GetFiles("*.json").OrderBy(x => x.Name).Select(x => x.Name).Select(x => Convert.ToInt32(Regex.Match(x, @"\d+").Value)).Max()+1);

            using (FileStream fs = new FileStream($"{this.type.Name}/{this.type.Name}.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, item);
                Console.WriteLine("Data has been saved to file");
            }
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            List<T> entitiesList = new List<T>();
            FileInfo[] files = directory.GetFiles("*.json");

            foreach (var file in files)
            {
                T item = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(File.ReadAllText(file.FullName));
                entitiesList.Add(item);
                Console.WriteLine("Data has been read from file");
            }
            return entitiesList;
        }
        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
