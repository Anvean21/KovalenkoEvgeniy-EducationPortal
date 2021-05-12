using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Data
{
    public class JsonRepository<T> : IRepository<T> where T : class
    {
        DirectoryInfo directory;
        Type type;
        Regex regex;
        Match match;
        public JsonRepository()
        {
            type = typeof(T);
            directory = new DirectoryInfo($"{type.Name}");
        }
        public void Create(T item)
        {
            Directory.CreateDirectory($"{type.Name}");
            //Если в директории не будет юзеров, выскочит эксепшн =(
            regex = new Regex(@"\d+");

            int itemId = directory.GetFiles("*.json")
                .Select(x => x.Name)
                .Select(x => int.Parse(regex.Match(x).Value))
                .Max() + 1;

            typeof(T).GetProperty("Id")
                .SetValue(item, itemId);
            
            using (FileStream fs = new FileStream($"{type.Name}/{type.Name}{itemId}.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, item);
               // Console.WriteLine("Data has been saved to file");
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
               // Console.WriteLine("Data has been read from file");
            }
            return entitiesList;
        }
        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
