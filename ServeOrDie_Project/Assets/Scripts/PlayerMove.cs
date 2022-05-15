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

        if(Mathf.Abs(transform.position.x - mousePos.x) > Mathf.Abs(transform.position.y - mousePos.y))
        {
            if(transform.position.x - mousePos.x < 0)
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
            if(transform.position.y - mousePos.y < 0)
            {
                anim.SetInteger("direction", 1);
            }
            else
            {
                anim.SetInteger("direction", 3);
            }
        }

        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        Vector2 getVel = new Vector2(xMove, yMove) * speed;
        rigidbody.velocity = getVel;

        if(rigidbody.velocity.magnitude == 0)
        {
            anim.SetBool("isMove", false);
        }
        else
        {
            anim.SetBool("isMove", true);
        }
    }

    private Vector3 UpdateMousePos()
    {
        Vector3 mousePos = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
