using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaRaGameController : MonoBehaviour {

    public GameObject Zombie;
    public Transform[] Spawns;
    public float spawnTime = 3f;
    public Text endText;

    private float timer;
    private bool isAlive;


    void Start () {

        InvokeRepeating("Spawn", spawnTime, spawnTime);
        timer = 10;
        isAlive = true;
        endText.text = "";

    }

    private void Update()
    {
        if (timer > 0 && isAlive == true)
        {
            timer = timer - Time.deltaTime;
        }

        else if (timer <= 0 || isAlive == false)
        {

            int wholeTime = (int)timer;

            endText.text = "YOU SURVIVED FOR " + (10 - wholeTime) + " SECONDS!";

          GameLoader.AddScore(wholeTime);

            StartCoroutine(ByeAfterDelay(2));

        }
    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, Spawns.Length);
        Instantiate(Zombie, Spawns[spawnPointIndex].position, Spawns[spawnPointIndex].rotation);
    }

    public void GameOver()
    {
        isAlive = false;
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        GameLoader.gameOn = false;
    }
}
