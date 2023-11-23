namespace Code.SaveServise
{
    public interface ISaveServise
    {
        void SaveInt(string key, int value);
        int GetInt(string key);
        void SaveString(string key, string value);
        string GetString(string key);
        void SaveFloat(string key, float value);
        float GetFloat(string key);
        void DeleteAll();
    }
}