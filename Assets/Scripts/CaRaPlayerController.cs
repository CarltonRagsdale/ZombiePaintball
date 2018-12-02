using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaRaPlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingRight;
    private float nextFire;
    private AudioSource fire;
    private CaRaGameController gameController;

    public Transform shotSpawn;
    public GameObject player;
    public GameObject[] shots;
    public float speed;
    public float jumpforce;
    public float fireRate;
    public bool isGround;

    private bool isFiring;

	// Use this for initialization
	void Start () {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<CaRaGameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find script :(");
        }

        rb2d = GetComponent<Rigidbody2D>();
        isFiring = false;
        }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey("j") && Time.time > nextFire) //Shooting Code
        {
            nextFire = Time.time + fireRate;
            shoot();
            fire = GetComponent<AudioSource>();
            fire.Play();
            isFiring = true;
        }
        else if (! Input.GetKey("j")) //For Strafing
        {
            isFiring = false;
        }

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Run Code
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);

        if (facingRight == true && moveHorizontal > 0 && isFiring == false)  //Strafe/Flip Code
        {
            flip();
        }
        if (facingRight == false && moveHorizontal < 0 && isFiring == false) //Strafe/Flip Code
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void shoot() //Spawn Bullets
    {
        GameObject shot = shots[Random.Range(0, shots.Length)];
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    private void OnCollisionStay2D(Collision2D collision) //Jump Code
    {
        if(collision.collider.tag == "Ground" && isGround)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                Vector2 movement = new Vector2(moveHorizontal, 0);
                rb2d.velocity = (movement/3 + Vector2.up) * jumpforce;
                rb2d.AddForce(movement * speed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundry" || other.tag == "Paintball") //Can't die by boundry or shots
        {
            Debug.Log("Touched The Boundry");
            return;
        }

        if (other.tag == "Zombie") //CAN die by Zombie
        {
            Debug.Log("Touched a Zombie");
            gameController.GameOver();
            
        }
        Destroy(player);
    }
}
