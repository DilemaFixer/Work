using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Code.SaveServise
{
    public class JsonSavingSystem<T> : IObjectSaveService<T>
    {
        public void Save(T savingObject, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObject, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public void SaveArray(T[] savingObjects, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObjects, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public void SaveList(List<T> savingObjects, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObjects, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public void SaveDictionary<Key>(Dictionary<Key, T> savingObjects, string path)
        {
            File.WriteAllText(path,
            JsonConvert.SerializeObject(savingObjects, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
            ));
        }

        public T Load(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public T[] LoadArray(string path)
        {
            return JsonConvert.DeserializeObject<T[]>(File.ReadAllText(path));
        }

        public List<T> LoadList(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }

        public Dictionary<Key, T> LoadDictionary<Key>(string path)
        {
            return JsonConvert.DeserializeObject<Dictionary<Key, T>>(File.ReadAllText(path));
        }
    }
}