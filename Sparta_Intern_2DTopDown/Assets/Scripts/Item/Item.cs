
using UnityEngine;

public class Item : MonoBehaviour
{
    ItemData data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetItem(collision);
            Destroy(gameObject);
        }
    }

    void GetItem(Collider2D collision)
    {
        // 플레이어 스탯에 아이템 데이터를 알맞게 적용
    }

    public void SetData(int key)
    {
        data = GameManager.Instance.dataBase.ItemDB[key];
    }
}
