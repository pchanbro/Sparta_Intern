
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    Vector2 moveDir;
    public int attackRange;
    public float attackSpeed;
    public float moveSpeed;
    SpriteRenderer monsterSprite;
    bool attack = false;

    private void Awake()
    {
        monsterSprite = GetComponent<SpriteRenderer>();
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
        IsInRange();
    }

    private void FixedUpdate()
    {
        if (!attack)
        {
            transform.position += (new Vector3(moveDir.x, moveDir.y)).normalized * Time.fixedDeltaTime * moveSpeed;
        }
    }

    public void SetMoveStat(MonsterStat stat)
    {
        attackRange = stat.AttackRange;
        attackSpeed = stat.AttackSpeed;
        moveSpeed = stat.MoveSpeed;
    }

    private void SetDir()
    {
        moveDir = GameManager.Instance.player.transform.position - this.transform.position;
    }

    public void IsInRange()
    {
        if (moveDir.magnitude <= attackRange)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }
    }
}
