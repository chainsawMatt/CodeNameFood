using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SandwhichSpace;

public class PlayerMovement : MonoBehaviour
{
    public int Stack;
    public int TopID;
    public float speed = 20;
    public float pressed;
    float screenHalfWidthInWorldUnits;
    
    public GameObject[] Sanguich;
    public GameObject samController;

    ScoreBoard ScoreBoard;
    private void Start()
    {
        samController = GameObject.Find("SF");
        // Scales camera with consideration for the player size
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }
    void Update()
    {
        PlayerControl();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            samController.GetComponent<Sandwiches>().Assemble();
        }
        if (Stack == 5)
        {
            samController.GetComponent<Sandwiches>().Assemble();
        }
    }
  
    private void PlayerControl()
    {
        // horiziontal input data
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        // player movement based on input
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        // Screen wrap around
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        
    }
}
  
  



