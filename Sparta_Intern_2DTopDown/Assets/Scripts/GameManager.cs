
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public Player player;

    public DataBase dataBase;

    public ObjectPool pool;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        dataBase = new DataBase();
        dataBase.SetData();

        GameObject poolObject = Resources.Load<GameObject>("Prefabs/UtilObj/MonsterPool");
        Instantiate(poolObject);

        GameObject spawnerObject = Resources.Load<GameObject>("Prefabs/UtilObj/Spawner");
        Instantiate(spawnerObject);
    }
}
