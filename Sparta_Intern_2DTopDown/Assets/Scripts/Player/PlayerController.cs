
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 moveDir;
    public float speed;
    SpriteRenderer playerSprite;

    void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(moveDir.x < 0)
        {
            playerSprite.flipX = true;
        }
        else if(moveDir.x > 0)
        {
            playerSprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        transform.position += (new Vector3(moveDir.x, moveDir.y)).normalized * Time.fixedDeltaTime * speed;
    }

    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
}
