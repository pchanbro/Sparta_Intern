using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float detectionRange;
    public LayerMask targetLayer;
    public Collider2D[] targets;
    public Transform nearestTarget;

    float timer = 0f;

    List<GameObject> bulletBox;
    int maxBulletNum = 50;

    private void Awake()
    {
        bulletBox = new List<GameObject>();
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Weapon/Bullet");
        for(int i = 0; i< maxBulletNum; i++)
        {
            GameObject bullet = Instantiate(prefab, transform);
            bulletBox.Add(bullet);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (!GameManager.Instance.player.controller.move)
        {
            if (timer > 0.3f)
            {
                if (nearestTarget != null)
                {
                    Fire();
                    timer = 0f;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        targets = Physics2D.OverlapCircleAll(transform.position, detectionRange, targetLayer);
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float minDistance = float.MaxValue;

        foreach (Collider2D target in targets)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                result = target.transform;
            }
        }

        return result;
    }

    void Fire()
    {
        foreach (GameObject bulletObject in bulletBox)
        {
            if (!bulletObject.activeSelf)
            {
                bulletObject.SetActive(true);
                Bullet bullet = bulletObject.GetComponent<Bullet>();
                bullet.SetDir(nearestTarget);
                break;
            }
        }
    }
}
