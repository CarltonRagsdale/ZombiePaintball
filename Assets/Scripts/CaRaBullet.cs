using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaRaBullet : MonoBehaviour {


    public float speed;
    public Rigidbody2D rb;

    private int ScoreCount;

	// Use this for initialization
	void Start () {

        rb.velocity = transform.right * speed;


	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
