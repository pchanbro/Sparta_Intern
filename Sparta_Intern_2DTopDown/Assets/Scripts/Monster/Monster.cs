using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    MonsterStat stat = new MonsterStat();
    float curHp;
    MonsterMovement movement;
    public Image hpBar;

    void Awake()
    {
        movement = GetComponent<MonsterMovement>();
        SetData();
        movement.SetMoveStat(stat);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        curHp = stat.MaxHP;
    }

    void Update()
    {
        hpBar.fillAmount = GetPercentage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Weapon"))
        {
            return;
        }

        curHp -= collision.GetComponent<Bullet>().damage;

        if(curHp <= 0)
        {
            Die();
            ItemDrop();
        }
    }


    private void ItemDrop()
    {
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Item/Item");
        Instantiate(itemPrefab);
        itemPrefab.transform.position = this.transform.position;
        Item item = itemPrefab.GetComponent<Item>();
        int rand = UnityEngine.Random.Range(0, stat.DropItem.Length);
        int itemKey = stat.DropItem[rand];
        item.SetData(itemKey);
    }

    private void SetData()
    {
        string monsterName = Regex.Replace(gameObject.name, @"\s\(\d+\)$", "");
        monsterName = monsterName.Replace("(Clone)", "");
        MonsterID monsterID;
        if(Enum.TryParse(monsterName, out monsterID))
        {
            int keyNum = (int)monsterID;
            string key = $"M{keyNum:D4}";
            MonsterData data = GameManager.Instance.dataBase.MonsterDB[key];
            stat.SetStat(data);
        }
        else
        {
            Debug.Log("버그발생");
        }
    }

    private float GetPercentage()
    {
        return curHp / (float)stat.MaxHP;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
