
using System.Text.RegularExpressions;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterStat stat;
    MonsterMovement movement;

    void Awake()
    {
        SetData();
        movement = GetComponent<MonsterMovement>();
        movement.SetSpeed(stat.MoveSpeed);
    }

    void Update()
    {
        
    }

    private void SetData()
    {
        string key = Regex.Replace(gameObject.name, @"\s\(\d+\)$", "");
        key = key.Replace("(Clone)", "");
        MonsterData data = GameManager.Instance.dataBase.MonsterDB[key];
        stat.SetStat(data);
    }
}
