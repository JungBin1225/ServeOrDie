using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed;
    private float damage;
    private Vector3 target;
    private Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Fire();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }

    public void Fire()
    {
        Vector3 direction = (startPos - target).normalized;

        transform.position -= direction * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
