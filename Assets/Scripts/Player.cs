using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody playerRB;
    public float bounceForce = 6;


    private AudioManager audioManager;



    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x , bounceForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            //the ball hits the safe area

        }
        else if (materialName == "Unsafe (Instance)")
        {
            //the ball hits the unsafe area
            GameManager.gameOver = true;
            audioManager.Play("game over");

        } else if (materialName == "Last Ring (Instance)" && !GameManager.levelCompleted)
        {
            //we have completed the level
            GameManager.levelCompleted = true;
            audioManager.Play("win level");
        }
    }


}
