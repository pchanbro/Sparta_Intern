
using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterStat stat = new MonsterStat();
    MonsterMovement movement;

    void Awake()
    {
        movement = GetComponent<MonsterMovement>();
        SetData();
        movement.SetMoveStat(stat);
    }

    void Update()
    {
        
    }

    private void SetData()
    {
        string monsterName = Regex.Replace(gameObject.name, @"\s\(\d+\)$", "");
        monsterName = monsterName.Replace("(Clone)", "");
        MonsterID monsterID;
        if(Enum.TryParse(monsterName, out monsterID))
        {
            int keyNum = (int)monsterID;
            string key = $"M{keyNum:D4}"; Debug.Log(key);
            MonsterData data = GameManager.Instance.dataBase.MonsterDB[key];
            stat.SetStat(data);
        }
        else
        {
            Debug.Log("버그발생");
        }
    }
}
