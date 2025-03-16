using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 moveDir;
    public float damage { get; private set; } = 20f;
    public float speed = 7;

    private void Awake()
    {
        //SetDamage();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        transform.position = GameManager.Instance.player.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position += (new Vector3(moveDir.x, moveDir.y)).normalized * Time.fixedDeltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetDir(Transform target)
    {
        moveDir = target.position - GameManager.Instance.player.transform.position;
    }
}
