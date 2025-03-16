using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    void Awake()
    {
        GameManager.Instance.pool = this;

        prefabs = Resources.LoadAll<GameObject>("Prefabs/Monster");        

        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
            for(int j = 0; j < 10; j++)
            {
                GameObject gameObject = Instantiate(prefabs[i], transform);
                pools[i].Add(gameObject);
            }
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        return select;
    }
    
    void Update()
    {
        
    }
}
