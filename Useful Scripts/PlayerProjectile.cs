using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //loading levels
using UnityEngine.UI; //UI text and images

public class PlayerProjectile : MonoBehaviour
{

    public float speed = 50;
    bool moveRight;
    public static int kills = 0;
    public static int totalEnemies = 9;

    // Use this for initialization
    void Start()
    {
        //detect whether player is facing right
        moveRight = GameObject.Find("Player").GetComponent<PlayerController>().faceRight;

        if (!moveRight)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0);
        }

        //clean-up: if projectile is off screen by a fair margin, DESTROY IT
        if (Camera.main.WorldToViewportPoint(transform.position).x > 1.2f || Camera.main.WorldToViewportPoint(transform.position).x < -0.2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            kills++;
        }
        if (collision.tag == "Platform")
        {
            Destroy(this.gameObject);
        }
    }
}
