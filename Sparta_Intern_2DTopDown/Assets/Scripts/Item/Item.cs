
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
        // �÷��̾� ���ȿ� ������ �����͸� �˸°� ����
    }

    public void SetData(int key)
    {
        data = GameManager.Instance.dataBase.ItemDB[key];
    }
}
