using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public int score = 0;
    public int bonusScore = 0;
    public int juiceBoxScore = 0;
    Rigidbody2D rb;
    GameObject cam;
    Scenes scenes;

    public int lane;

    public float cameraOffset = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera");
        scenes = GameObject.Find("Scenes").GetComponent<Scenes>();
        lane = 1;
        PlayerPrefs.SetString("newHighScore", "false");
    }

    void Update()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        transform.position = new Vector3(transform.position.x, transform.position.y, lane);
        cam.transform.position = new Vector3(rb.transform.position.x + cameraOffset, cam.transform.position.y, -15.0f);

        score = (int)((4.49+transform.position.x) * 0.75);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (lane < 3)
            {
                lane += 1;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (lane > 1)
            {
                lane -= 1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Juice Box"))
        {
            if (lane == collision.gameObject.GetComponent<Entity>().lane)
            {
                // give points?
                bonusScore += juiceBoxScore;

                // increase move speed
                movementSpeed *= 1.1f;


                Destroy(collision.gameObject);
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            // check if it is in the same lane
            if (lane == collision.gameObject.GetComponent<Entity>().lane)
            {
                Debug.Log($"Player Lane: {lane}, Enemy Lane: {collision.gameObject.GetComponent<Entity>().lane}");
                // set the score for the "you scored: [score]"
                PlayerPrefs.SetInt("recentScore", score + bonusScore);
                // if the player got a new high score
                if (score + bonusScore > PlayerPrefs.GetInt("highScore"))
                {
                    // set the new highscore
                    PlayerPrefs.SetInt("highScore", score + bonusScore);
                    PlayerPrefs.SetString("newHighScore", "true");
                }
                else
                {
                    PlayerPrefs.SetString("newHighScore", "false");
                }
                // switch to deathscreen
                scenes.DeathScreen();
            }
        }
    }
}