using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Name = "";
    public string currentName = "";
    public int HighScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }   

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string Name;
    }

    // Save data to json file
    public void SaveNameScore()
    {
        // Instantiate save data
        SaveData data = new SaveData();

        // Set name and high schore
        data.Name = currentName;
        data.HighScore = HighScore;

        // Convert to json and save json
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Loads save data from json
    public void LoadScore()
    {
        // Check if file exists
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            HighScore = data.HighScore;
        }
    }
}
