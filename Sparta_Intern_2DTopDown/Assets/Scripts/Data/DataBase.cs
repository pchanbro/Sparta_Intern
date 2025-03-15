using System.Collections.Generic;
using UnityEngine;

public class DataBase
{
    public Dictionary<int, ItemData> ItemDB;
    public Dictionary<string, MonsterData> MonsterDB;

    public void SetData()
    {
        {
            TextAsset textAsset = Resources.Load<TextAsset>("Json/ItemData");
            ItemDataList itemDataList = JsonUtility.FromJson<ItemDataList>(textAsset.text);

            foreach (ItemData data in itemDataList.ItemData)
            {
                ItemDB.Add(data.ItemID, data);
            }
        }

        {
            TextAsset textAsset = Resources.Load<TextAsset>("Json/MonsterData");
            MonsterDataList monsterDataList = JsonUtility.FromJson<MonsterDataList>(textAsset.text);

            foreach (MonsterData data in monsterDataList.MonsterData)
            {
                MonsterDB.Add(data.MonsterID, data);
            }
        }
    }
}