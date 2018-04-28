using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SandwhichSpace;

public class FallingToppings : MonoBehaviour
{
    public int scorePerTop = 1;
    public int speed = 7;
    public int ID;
    public int Stack;

    public GameObject Player;
    public GameObject Tops;
    public GameObject samController;
    public GameObject[] Sam;
    public Vector3 temp = new Vector3(0F, -15F, 0);
    public string topName;
    public bool isStacked;

    float hitDetectionPrecision = 8f;
    float tmpDistance;
    float x;
    float y;
    float z;

    ScoreBoard scoreBoard;

    void Awake()
    {
        tmpDistance = 0;
        Tops = null;
        isStacked = false;
        samController = GameObject.Find("SF");
        scoreBoard = FindObjectOfType<ScoreBoard>();
        Sam = GameObject.FindGameObjectsWithTag("Stack");
        Stack = Sam.Length;
        Timer.timeStarted = true;
    }
    void Update()
    {
        if (!isStacked)
        {
            // Toppings fall
           
          transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            if (Tops != null)
            {
                // stack the toppings
                x = Mathf.SmoothDamp(transform.position.x, Tops.transform.position.x, ref z, 0.035f);
                y = Mathf.SmoothDamp(transform.position.y, Tops.transform.position.y +15 , ref z, 0.035f);
                transform.position = new Vector3(x, y, transform.position.z);
               
            }
            else
                Tops = null;
        }
    }
    // Destroy toppings that fall off the screen
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    //On trigger, check hit, then confirm stack
    public void OnTriggerEnter2D(Collider2D triggerCollider)
    {
       if (isStacked)
        {
            return; 
        }
        if (triggerCollider.tag == ("Player") || triggerCollider.tag == ("Stack")) 
        {
            if (!isStacked)
            {
                
            }
            if (CheckHit(triggerCollider.gameObject))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                isStacked = true;
                gameObject.tag = "Stack";
                Tops = triggerCollider.gameObject;
                scoreBoard.scoreHit(scorePerTop);
            }
            else
            {
                //do not catch this toppimg
                GetComponent<BoxCollider2D>().enabled = false;

                if (tmpDistance >= 0)
                    transform.rotation = Quaternion.Euler(0, 180, -35);
                else
                    transform.rotation = Quaternion.Euler(0, 180, 35);
            }
        }
        
    }
    // valid catch?
    bool CheckHit(GameObject go)
    {
        //check the distance of the centers of the two colliding object.
        tmpDistance = go.transform.position.x - gameObject.transform.position.x;
        if (Mathf.Abs(tmpDistance) <= hitDetectionPrecision)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}


