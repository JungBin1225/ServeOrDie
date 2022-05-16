using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private PlayerMove player;
    private SpriteRenderer playerSprite;
    private SpriteRenderer weaponSprite;
    private Vector3 mousePos;
    private float coolTime;
    private bool shootAble;

    public float shootDuration;
    public GameObject bullet;

    void Start()
    {
        player = transform.parent.parent.gameObject.GetComponent<PlayerMove>();
        playerSprite = transform.parent.parent.gameObject.GetComponent<SpriteRenderer>();
        weaponSprite = GetComponent<SpriteRenderer>();

        coolTime = 0;
        shootAble = true;
    }

    
    void Update()
    {
        SetTransform();

        if(coolTime > 0)
        {
            coolTime -= Time.deltaTime;
            shootAble = false;
        }
        else
        {
            shootAble = true;
        }
        
        if(Input.GetMouseButton(0))
        {
            if(shootAble)
            {
                Debug.Log("das"); // ÃÑ¾Ë »ý¼º
                coolTime = shootDuration;
            }
            
        }
    }

    private void SetTransform()
    {
        mousePos = player.UpdateMousePos();
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        transform.localPosition = mousePos.normalized * 0.3f;

        Vector2 direction = (mousePos.normalized * 100) - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        if (mousePos.y > 0)
        {
            weaponSprite.sortingOrder = playerSprite.sortingOrder - 1;
        }
        else
        {
            weaponSprite.sortingOrder = playerSprite.sortingOrder + 1;
        }
    }
}
