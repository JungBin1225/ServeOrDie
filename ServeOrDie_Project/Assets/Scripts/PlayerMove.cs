using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigidbody;
    private Vector3 mousePos;

    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        mousePos = UpdateMousePos();
        UpdateDirection(mousePos);

        Move();
    }

    public Vector3 UpdateMousePos()
    {
        Vector3 mousePos = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void UpdateDirection(Vector3 mouse)
    {
        if (Mathf.Abs(transform.position.x - mouse.x) > Mathf.Abs(transform.position.y - mouse.y))
        {
            if (transform.position.x - mouse.x < 0)
            {
                anim.SetInteger("direction", 2);
            }
            else
            {
                anim.SetInteger("direction", 4);
            }
        }
        else
        {
            if (transform.position.y - mouse.y < 0)
            {
                anim.SetInteger("direction", 1);
            }
            else
            {
                anim.SetInteger("direction", 3);
            }
        }
    }

    private void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        Vector2 getVel = new Vector2(xMove, yMove) * speed;
        rigidbody.velocity = getVel;

        if (rigidbody.velocity.magnitude == 0)
        {
            anim.SetBool("isMove", false);
        }
        else
        {
            anim.SetBool("isMove", true);
        }
    }
}
