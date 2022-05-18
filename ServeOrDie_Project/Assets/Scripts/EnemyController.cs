using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float hp;

    public float maxHp;

    void Start()
    {
        hp = maxHp;
    }

    
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void GetDamage(float damage)
    {
        Debug.Log(damage);
        hp -= damage;
    }
}
