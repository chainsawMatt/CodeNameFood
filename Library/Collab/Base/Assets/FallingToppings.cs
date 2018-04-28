using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingToppings : MonoBehaviour
{

    float speed = 7;
    float hitDetectionPrecision = 0.7f;
    float tmpDistance;
    public GameObject Player;
    public GameObject CaughtTops;
    public int scorePerTop = 1;
    public int ID;

    public bool isStacked;

    ScoreBoard scoreBoard;

    // Use this for initialization
    void Start()
    {
        tmpDistance = 0;
        CaughtTops = null;
        isStacked = false;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    float x;
    float y;
    float z;

    // Update is called once per frame
    void Update()
    {

        if (!isStacked)
        {
            // Toppings fall
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            if (CaughtTops != null)
            {
                // stack the toppings
                x = Mathf.SmoothDamp(transform.position.x, CaughtTops.transform.position.x, ref z, 0.035f);
                y = Mathf.SmoothDamp(transform.position.y, CaughtTops.transform.position.y + 1.5f, ref z, 0.035f);
                transform.position = new Vector3(x, y, transform.position.z);
            }
            else
                CaughtTops = null;
        }
        //cash in current toppings 
        Assemble();
    }

    // Destroy toppings that fall off the screen
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Debug.Log("Destroyed");
    }
    //On trigger, check hit, then confirm stack
    public void OnTriggerEnter2D(Collider2D triggerCollider)
    {
       if (isStacked)
        {
            return; 
        }
        if (triggerCollider.tag == ("Player") || triggerCollider.tag == ("Toppings") || triggerCollider.tag == ("Stack")) 
        {
            Debug.Log("Trigger");
            if (CheckHit(triggerCollider.gameObject))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                isStacked = true;
                gameObject.tag = "Stack";
                CaughtTops = triggerCollider.gameObject;
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

    public int Stack;

    public void Assemble()
    {
        GameObject[] Sanguich = GameObject.FindGameObjectsWithTag("Stack");
        Debug.Log("Stack");
        Stack = GameObject.FindGameObjectsWithTag("Stack").Length;

        if (Stack == 5)
        {   
            foreach(GameObject topping in Sanguich)
            {
                Destroy(topping);
                scoreBoard.scoreHit(Stack * scorePerTop);
            }
            
        }

        if (Input.GetKey(KeyCode.Space))
        {
            foreach (GameObject topping in Sanguich)
            {
                Destroy(topping);
                scoreBoard.scoreHit(Stack * scorePerTop);
            }
        }


        /*if (Input.GetKey(KeyCode.Space) && Stack < 5 )
        {
            scoreBoard.scoreHit(Stack * scorePerTop);
            Destroy(GameObject.FindWithTag("Stack"));
        }
         else if (Stack == 5)
        {
            scoreBoard.scoreHit(Stack * scorePerTop);
            Destroy(GameObject.FindWithTag("Stack"));

        }
        else
        {
            return;
        }
        */
    }
}

