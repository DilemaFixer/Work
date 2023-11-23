using System.Collections.Generic;
using Newtonsoft.Json;

namespace Code.SaveServise
{
    public interface IObjectSaveService<SaveType>
    {
        void Save(SaveType savingObject, string path);
        void SaveArray(SaveType[] savingObjects, string path);
        void SaveList(List<SaveType> savingObjects, string path);
        void SaveDictionary<Key>(Dictionary<Key, SaveType> savingObjects, string path);
        
        SaveType Load(string path);
        SaveType[] LoadArray(string path);
        List<SaveType> LoadList(string path);
        Dictionary<Key, SaveType> LoadDictionary<Key>(string path);

    }
}