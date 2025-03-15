
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerStat stat;

    void Start()
    {
        GameManager.Instance.player = this;
    }

    void Update()
    {
        
    }
}
