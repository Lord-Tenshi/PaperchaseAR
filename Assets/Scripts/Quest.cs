using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class QuestList
{
    public List<Quest> Quests;

    public class Quest
    {
        public string Description { get; set; }
        /*public GameObject Marker { get; set; }*/
        public string PrefabName { get; set; }
    }

}