
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    Vector2 moveDir;
    public float speed;
    SpriteRenderer monsterSprite;

    private void Awake()
    {
        
    }

    void Update()
    {
        SetDir();
        if (moveDir.x < 0)
        {
            monsterSprite.flipX = true;
        }
        else if (moveDir.x > 0)
        {
            monsterSprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        transform.position += (new Vector3(moveDir.x, moveDir.y)).normalized * Time.fixedDeltaTime * speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void SetDir()
    {
        moveDir = (GameManager.Instance.player.transform.position - this.transform.position).normalized;
    }
}
