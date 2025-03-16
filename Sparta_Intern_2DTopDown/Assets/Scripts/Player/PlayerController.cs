
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 moveDir;
    public float speed;
    SpriteRenderer playerSprite;
    public bool move = false;

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

        if(moveDir.magnitude > 0.1f)
        {
            move = true;
        }
        else
        {
            move = false;
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
