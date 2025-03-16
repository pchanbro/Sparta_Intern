
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerStat stat;
    public PlayerController controller { get; private set; }

    void Awake()
    {
        GameManager.Instance.player = this;
        controller = gameObject.GetComponent<PlayerController>();
    }

    
}
