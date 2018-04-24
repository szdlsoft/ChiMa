using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public  class CrawlerDataStoreDefault
        : ICrawlerDataStore
    {
        readonly string Path;
        public CrawlerDataStoreDefault(params string[] paths)
        {
            List<string> rootPaths = new List<string>
            {
                CrawlerConfig.RootPath,
                @"CrawlerData",
            };
            rootPaths.AddRange(paths);

            Path = System.IO.Path.Combine(rootPaths.ToArray());
        }

        private  string GetLoaclFilePath( string fileName)
        {
            return System.IO.Path.Combine( Path, $"{fileName}.json");
        }
        public virtual bool Exist(ICrawlerObject obj)
        {
            return System.IO.File.Exists(GetLoaclFilePath( obj.CrawlerFileName));
        }

        public List<T> GetByPrefix<T>(string prefix, Action<T,string> OnAfterDeserialize)
        {
            List<T> list = new List<T>();
            foreach ( var fileName in System.IO.Directory.GetFiles(Path, $"{prefix}_*.json"))
            {
                T instance = Get<T>(fileName);

                var fi = new System.IO.FileInfo(fileName);
                string name = fi.Name.Substring(0, fi.Name.IndexOf(".json"));
                string objName = name.Substring($"{prefix}_".Length );

                OnAfterDeserialize?.Invoke(instance, objName);


                list.Add( instance );
            }
            return list;
        }

        private  T Get<T>(string fileName)
        {
            string fullPath = fileName;
            if (System.IO.File.Exists(fullPath))
            {
                using (var fs = System.IO.File.OpenText(fullPath))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(fs.ReadToEnd());
                }
            }

            return default(T);
        }

        public virtual void Save(ICrawlerObject obj)
        {
            string path = GetLoaclFilePath( obj.CrawlerFileName);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };
            var json = JsonConvert.SerializeObject(obj, settings);
            using (var file = System.IO.File.CreateText(path))
            {
                file.Write(json);
                file.Flush();
            }
        }

        public List<T> GetAll<T>()
        {
            List<T> list = new List<T>();
            foreach (var fileName in System.IO.Directory.GetFiles(Path, $"*.json"))
            {
                T instance = Get<T>(fileName);
                list.Add(instance);
            }
            return list;
        }
    }
}
