using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SandwhichSpace;
using UnityEngine.UI;
public class IsMatchSign : MonoBehaviour {

    Sandwiches SamRef;
    Text isMatch;
    public GameObject ticketController;
    List<string> orders = new List<string>();
    void Start () {
        isMatch = GetComponent<Text>();
    }
    private void Update()
    {
        
    }
    public int IsMatchedOn(string key)
    {
        orders = ticketController.gameObject.GetComponent<Tickets>().Orders;
        
        #region SammichHelper.PrintAList("IS MATCHED ON ORDER!!!!!!!!!!!!!!!!!!!!!: ", orders);
        Debug.Log("ORDER KEY IN ISMATCH!!!!!!!!!!!!!!!!!!!!!!: " + key);
        #endregion


        for (int i = 0; i < orders.Count; i++)
        {
            if (key == orders[i])
            {
                orders.RemoveAt(i);
                Debug.Log("IS MATCH ORDERS.COUNT: " + orders.Count +"????????");
                break;
            }
        }
        if ((orders.Count) == 0) { 
            isMatch.text = "GOT IT";
            #region Debug.Log("IF YOU SEE THIS YOU SHOULD ALSO BE SEEING GOT IT");
            Debug.Log(" ORDERS COUNT AFTER ISMATCH: " + orders.Count);
            #endregion
            Destroy(isMatch, 5);
        }
        return 0;
    }
}
