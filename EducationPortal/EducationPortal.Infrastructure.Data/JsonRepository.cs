using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Data.Hasher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Text.Json;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace EducationPortal.Infrastructure.Data
{
    public class JsonRepository<T> : IRepository<T> where T : class
    {
        private readonly DirectoryInfo directory;
        private readonly Type type;
        private Regex regex;
        private readonly JsonSerializer serializer;

        public JsonRepository(Regex regex)
        {
            this.regex = regex;
        }

        public JsonRepository()
        {
            type = typeof(T);
            directory = new DirectoryInfo($"{type.Name}");
            serializer = new JsonSerializer();
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

            using (StreamWriter sw = new StreamWriter(@$"{type.Name}/{type.Name}{itemId}.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }
        public void Delete(int id)
        {
            var file = directory.GetFiles($"*{id}.json").FirstOrDefault();
            file.Delete();
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
            var id = typeof(T).GetProperty("Id").GetValue(item);

            using FileStream fs = new FileStream($"{type.Name}/{type.Name}{id}.json", FileMode.Open);
            System.Text.Json.JsonSerializer.SerializeAsync(fs, item);
        }
    }
}
