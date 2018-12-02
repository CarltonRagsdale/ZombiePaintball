using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaRaEnemyMovement : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;

    private bool facingRight;

    /*Transform ZombiePrefab;

    private void Start()
    {
        var Zombie = Instantiate(ZombiePrefab) as Transform;
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }*/
    

    void Update () {

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Flip();
        }
    }

    void Flip()
    {

        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
