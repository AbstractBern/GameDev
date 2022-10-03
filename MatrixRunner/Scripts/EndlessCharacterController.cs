using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndlessCharacterController : MonoBehaviour
{
    [SerializeField] private int powerUpCount = 0;
    [SerializeField] public bool godMode = false;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private GameController gameController;
    private void Awake()
    {
        //Debug.Log("Awake - Time - " + Time.time);

    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start - Time - " + Time.time);
        if (!gameController)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update - Time - " + gameObject.transform.position);
        if (powerUpCount == 4)
        {
            godMode = true;
        }
        if ( !isGrounded && gameObject.transform.position.y < -2.0 )
        {
            gameController.health = 0;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) )
        {
            if (godMode)
            {
                gameController.jumpIntensity = 10f;
                gameController.speed = 13;
            }
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gameController.jumpIntensity * 2, ForceMode.Impulse);
        }
        if (!isGrounded && (Input.GetKeyDown(KeyCode.S)) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            //keycode .downarrow
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * gameController.jumpIntensity * 2, ForceMode.Impulse);
        }
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 1) * Time.deltaTime * gameController.speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle1" || other.gameObject.tag == "Obstacle2" )
        {
            Debug.Log("Omnipotent Powers!");
            powerUpCount += 1;
            gameController.timer -= 1;
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "RedPill" )
        {
            Debug.Log("Red Pill - Go down the rabbit hole!");

            gameController.health += 2;
            gameController.timer -= 1;
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "BluePill" || other.gameObject.tag == "agentSmith" )
        {
            Debug.Log("Blue Pill - Stay in lala land! :( or met with Agent Smith ");
            gameController.health -= 10;
        }


    }
    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate - Time - " + Time.deltaTime);

    }
}