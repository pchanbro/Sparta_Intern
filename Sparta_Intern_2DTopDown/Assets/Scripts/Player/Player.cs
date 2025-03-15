
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerStat stat;

    void Awake()
    {
        GameManager.Instance.player = this;
    }

    void Update()
    {
        
    }
}
