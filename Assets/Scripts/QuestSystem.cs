using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    /*[SerializeField]
    TextAsset JsonFile;*/

    public QuestList JsonQuestList;
    public List<QuestList.Quest> listOfQuests;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start of QuestSystem");
        /*JsonQuestList = JsonUtility.FromJson<QuestList>(JsonFile.text);*/


        listOfQuests = ReadListFromJSON<QuestList.Quest>("MarkerData.json");
        Debug.Log(listOfQuests.Count);

        foreach (QuestList.Quest q in listOfQuests)
        {
            Debug.Log("Prefab = " + q.PrefabName);
        }

        //LoadPrefabs();
        /*        Instantiate(quests[0].Marker);
                Instantiate(quests[0].Marker);*/
    }
    /*void LoadPrefabs()
    {
        Debug.Log("hello contents:\r" + JsonFile.ToString());

        quests = Deserialize(JsonFile.ToString());
        Debug.Log(quests.Count);
        foreach (Quest q in quests)
        {
            q.Marker = Resources.Load(q.PrefabName) as GameObject;

            Debug.Log("Gameobject created = " + q.Marker);
        }
    }*/

    /*List<Quest> Deserialize(string jsonString)
    {

        Debug.Log(JsonHelper.FromJson<Quest>(jsonString)[0]);
        Debug.Log(JsonHelper.FromJson<Quest>(jsonString)[1]);

        return new List<Quest>(JsonHelper.FromJson<Quest>(jsonString));
    }*/

    public static List<T> ReadListFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        Debug.Log("Json:\n" + content);

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> res = new List<T>(JsonHelper.FromJson<T>(content));

        return res;

    }
    private static string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }

        Debug.LogError("Couldn't find MarkerData");
        Debug.LogError("Path: " + path);
        return "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
