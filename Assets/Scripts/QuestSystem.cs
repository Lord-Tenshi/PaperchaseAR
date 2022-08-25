using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [SerializeField]
    TextAsset JsonFile;

    public List<Quest> quests;
    // Start is called before the first frame update
    void Start()
    {
        quests = new List<Quest>();
        Debug.Log("Start of QuestSystem");
        LoadPrefabs();
        Instantiate(quests[0].Marker);
        Instantiate(quests[0].Marker);
    }
    void LoadPrefabs()
    {
        Debug.Log("hello contents:\r" + JsonFile.ToString());

        quests = Deserialize(JsonFile.ToString());
        Debug.Log(quests.Count);
        foreach (Quest q in quests)
        {
            q.Marker = Resources.Load(q.PrefabName) as GameObject;

            Debug.Log("Gameobject created = " + q.Marker);
        }
    }
    List<Quest> Deserialize(string jsonString)
    {

        Debug.Log(JsonHelper.FromJson<Quest>(jsonString)[0]);
        Debug.Log(JsonHelper.FromJson<Quest>(jsonString)[1]);

        return new List<Quest>(JsonHelper.FromJson<Quest>(jsonString));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
