using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement; //loading levels
using UnityEngine.UI; //UI text and images

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2d; // reference to RigidBody2d
    public float speed = 15;
    public float jump = 200;
    public GameObject platTest1, platTest2;
    int numGrenades = 0;
    int totalGrenades = 7;
    public bool faceRight;
    public Text scoreText, objectiveText;
    public Image objectiveBackground;
    public GameObject bulletPrefab;
    AudioSource aud;
    public AudioClip winSound, startCor;
    public int counter = 0;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        faceRight = true;
        aud = GetComponent<AudioSource>();
        aud.PlayOneShot(startCor);

        scoreText.text = "Score: " + numGrenades;
        objectiveText.text = "\t   OBJECTIVE: \nSURVIVE AND COLLECT";
        objectiveBackground.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Left-right movement
        //A = left, D = Right
        if (Input.GetKey(KeyCode.A))
        {
            if (faceRight)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                faceRight = !faceRight;
            }

            transform.position -= new Vector3(speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!faceRight)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                faceRight = !faceRight;
            }

            transform.position += new Vector3(speed * Time.deltaTime, 0);
            faceRight = true;
        }

        //Thruster (F)
        if (Input.GetKey(KeyCode.F))
        {
            if (faceRight)
            {
                transform.position += new Vector3(speed * 3 * Time.deltaTime, 0);
            }
            else
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0);
            }

        }

        //Jump (= SPACE) when on a platform, not air
        bool canJump = true;
        if (Physics2D.OverlapArea(platTest1.transform.position, platTest2.transform.position))
            canJump = (Physics2D.OverlapArea(platTest1.transform.position, platTest2.transform.position).tag == "Platform") || (Physics2D.OverlapArea(platTest1.transform.position, platTest2.transform.position).tag == "Enemy Projectile");
        else canJump = false;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.AddForce(new Vector3(0, jump));
        }


        //Fire (left click)
        if (Input.GetMouseButtonDown(0))
        {
            //create player projectile, player position, default rotation
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

        if(numGrenades >= totalGrenades)
        {
            objectiveText.text = "\tOBJECTIVE: \nFINISH THE FIGHT";
            counter++;
            if (counter == 1)
            {
                aud.PlayOneShot(winSound);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //"pickup" tag collision
        if(collision.tag == "Pickup")
        {
            Destroy(collision.gameObject);
            numGrenades++;

            //Display score to console
            print("Grenades: " + numGrenades);
            scoreText.text = "Score: " + numGrenades;
        }

        ///respawn zone collision
        if(collision.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
        }

        //Enemy shot collision
        if(collision.tag == "Enemy Projectile")
        {
            //reload the scene due to death. He is Spartan 1 now
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //"enemy" tag collision
        if(collision.gameObject.tag == "Enemy"){
            print("HYAH!");
        }
    }
}
