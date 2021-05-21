using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Data.Hasher;
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
        private DirectoryInfo directory;
        private Type type;
        private Regex regex;

        public JsonRepository()
        {
            type = typeof(T);
            directory = new DirectoryInfo($"{type.Name}");
        }
        public void Create(T obj)
        {
            Directory.CreateDirectory($"{type.Name}");
            int itemId = 0;
            regex = new Regex(@"\d+");

            if (directory.GetFiles("*.json").Count() == 0)
            {
                itemId++;
            }
            else
            {
                itemId = directory.GetFiles("*.json")
                  .Select(x => x.Name)
                  .Select(x => int.Parse(regex.Match(x).Value))
                  .Max() + 1;
            }

            typeof(T).GetProperty("Id").SetValue(obj, itemId);

            if (typeof(T).GetProperties().Any(x => x.Name == "Password"))
            {
                typeof(T).GetProperty("Password").SetValue(obj, PasswordHasher.Encode(typeof(T).GetProperty("Password").GetValue(obj).ToString()));
            }

            using (FileStream fs = new FileStream($"{type.Name}/{type.Name}{itemId}.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, obj);
            }
        }
        public void Delete(int id)
        {
            var file = directory.GetFiles($"*{id}.json").FirstOrDefault();
            file.Delete();
            Console.WriteLine("Operation completed successfully");
        }
        public T GetById(int id)
        {
            var file = directory.GetFiles($"*{id}.json").FirstOrDefault();

            T jsonItem = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(File.ReadAllText(file.FullName));
            if (typeof(T).GetProperties().Any(x => x.Name == "Password"))
            {
                typeof(T).GetProperty("Password").SetValue(jsonItem, PasswordHasher.Decode(typeof(T).GetProperty("Password").GetValue(jsonItem).ToString()));
            }
            return jsonItem;
        }

        public IEnumerable<T> GetAll()
        {
            List<T> entitiesList = new List<T>();
            FileInfo[] files = directory.GetFiles("*.json");

            foreach (var file in files)
            {
                T jsonItem = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(File.ReadAllText(file.FullName));
                if (typeof(T).GetProperties().Any(x => x.Name == "Password"))
                {
                    typeof(T).GetProperty("Password").SetValue(jsonItem, PasswordHasher.Decode(typeof(T).GetProperty("Password").GetValue(jsonItem).ToString()));
                }
                entitiesList.Add(jsonItem);
            }
            return entitiesList;
        }
        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
