using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerStat stat;

    void Awake()
    {
        GameManager.Instance.Player = this;
    }

    void Update()
    {
        
    }
}
