using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SandwhichSpace;

public class Tickets : MonoBehaviour {

    public float timeBetweenTickets;                        // Set in the inspector
    float nextTicket;                                       // When the next ticket comes
    int numTops;                                      // Number of toppings customer wants on Sam
    int numTops2;
    public int itemsPerTicket;
    public GameObject TicketPreFab;                         // Currently unused
    public GameObject OrderPreFab;                          // Empty GameObject to display the sprite of the topping the customer wants 
    public string TicketKey;
    public GameObject[] Toppings;                           // Small versions of the falling toppings
    public Dictionary<string, Sprite> ProperDick = new Dictionary<string, Sprite>(); // Empty Dick that points to the right Dick
    public Dictionary<string, Sprite> ProperDick2 = new Dictionary<string, Sprite>();// Empty Dick that points to the right Dick for the second item on the ticket
    public List<GameObject> ticketList = new List<GameObject>();                     // Comprehensive list of collected toppings, only using it for Vector2s should probably be a list of Vector2s instead of GO
    public List<string> Orders = new List<string>();                                 // List of the customer orders being fed into IsMatchSign
                                                                                     //public CurrentTicket ThisTicket = new CurrentTicket();
                                                                                     //                                                   ALLLLLLLLLL THEEEEEEEEEEE VEEEECCCCCCCCTTTTTTTTTOOOOOORRRRRRRSSSSSSSSS!!!!!!!!!!!!!!!!!!
    public CurrentTicket curtick;
    Vector2 temp = new Vector2(1.5f, 0);            // Buffer for x position of ticket
    Vector2 temp2 = new Vector2(0, -1f);            // Buffer for y position of secondItem
    Vector2 firstPos;                               // Used to place GO
    Vector2 lastPos;                                // Transform position
    Vector2 firstItemPos;                           //
    Vector2 secondItemPos;                          //
    Vector2 newTickPos;                             //

    bool firstTicket;                               // Flag to determine to determine proper ticket position
    public int LoseCon = 5;                         // Number of tickets on screen at the same time to force loss
    void Start () {
        firstTicket = true;
	}
	
	void Update () {

       
        if (Time.time > nextTicket)                         // Creates a new ticket every 15 seconds
        {
            nextTicket = Time.time + timeBetweenTickets;
            CreateTicket();
        }
    }

    /* Will update this as we push!
     * ---------------------------
     * Create order makes the key(s) for the item(s) on each ticket
     * Logic is as follows:
     * 1. Initialize numTops - The number of toppings that each sandwhich is comprised of via topping ID
     *    Initialize itemsPerTicket - Obviously it's the number of items per ticket. I'm going to write it so that we can have up to
     *    5 items per ticket, but for testing purposes we should  probably stick with 1-2 per.
     *    
     * 2. Switch statement takes the case of numTops - The number of toppings determine the sandwhich that will be created.
     *    In each case, List <string> Orders is assigned the return value of MakeOrder (See SammichHelper.cs) - this is our list of items to
     *    display on the ticket.
     *    Then, ProperDick is assigned the value of the appropriate dictionary of Sprites ( See Sandwhiches.cs). Break out of Switch.
     *    
     * 3. We then check to see if there is more than one item. If so , all we need to do is point to which dictionary each sprite in the List
     *    should use (assigned to ProperDick2). Note that we are NOT running MakeOrder again in the second Switch statement. All 
     *    sammich keys in the list are generated in MakeOrder in the first Switch. 
     *    THEN WE DONE HERE --> CreateOrder();
     */    
    public void CreateOrder()
    {

        numTops = Random.Range(0,6);
        itemsPerTicket = Random.Range(0,3);
 
        switch (numTops) { 
            case 1:
                Orders = (SammichHelper.MakeOrder(numTops, itemsPerTicket));
                ProperDick = Sandwiches.OneTopsDick;
                Debug.Log("TICKETS ORDER CHAOS :" + Orders[0]);
                break;
            case 2:
                Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket);
                ProperDick = Sandwiches.TwoTopsDick;
                SammichHelper.PrintAList("TICKETS ORDER @ CASE 2: ", Orders,-1);
                break;
            case 3:
                Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket);
                ProperDick = Sandwiches.ThreeTopsDick;
                SammichHelper.PrintAList("TICKETS ORDER @ CASE 3: ", Orders,-1);
                break;
            case 4:
                Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket);
                ProperDick = Sandwiches.FourTopsDick;
                SammichHelper.PrintAList("TICKETS ORDER @ CASE 4: ", Orders,-1);
                break;
            case 5:
                Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket);
                ProperDick = Sandwiches.FiveTopsDick;
                SammichHelper.PrintAList("TICKETS ORDER @ CASE 5: ", Orders,-1);
                break;
            default:
                break;
               
        }
        if (itemsPerTicket > 1)
        {
            for (int i = 1; i < Orders.Count; i++)
            {
                int x = Orders[i].Length;
                Debug.Log("ORDERS LENGTH PEOPLE: " + Orders[i].Length + " " + Orders[i]);

                switch (x)
                {
                    case 1:
                        ProperDick2 = Sandwiches.OneTopsDick;
                        break;
                    case 2:
                        ProperDick2 = Sandwiches.TwoTopsDick;
                        SammichHelper.PrintAList("TICKETS ITEM @ CASE 2 PT2: ", Orders, i);
                        break;
                    case 3:
                        ProperDick2 = Sandwiches.ThreeTopsDick;
                        SammichHelper.PrintAList("TICKETS ITEM @ CASE 3 PT2: ", Orders, i);
                        break;
                    case 4:
                        ProperDick2 = Sandwiches.FourTopsDick;
                        SammichHelper.PrintAList("TICKETS ITEM @ CASE 4 PT2: ", Orders, i);
                        break;
                    case 5:
                        ProperDick2 = Sandwiches.FiveTopsDick;
                        SammichHelper.PrintAList("TICKETS ITEM @ CASE 5 PT2: ", Orders, i);
                        break;
                    default:
                        break;
                }

            }
        }
    }


    /* Logic is as follows:
     * If it's the first ticket - Set firstPos to be the OrderGameObject. Create a GameObject newTicket and instantiate it on top of the
     *                            order prefab
     *                            
     *                            Then render the sprite on top of that new GameObject. It is assigned the proper dictionary, passing the
     *                            first element in the Orders List, which holds the keys we created earlier. We're just passing a random key
     *                            into an appropriate dictionary just like in Assemble(), only the key in Assemble() (samKey) is generated by
     *                            the ID's of objects on your (sandwhich) stack.
     *                            
     *                            Check the losing condition
     *                            
     * Else                       Do the same shit, but update the relative positions ( as they will change as time progresses), and access
     *                            the second dictionary  (ProperDick2).                                                                      */

    public void CreateTicket()
    {
        CreateOrder();

        if (firstTicket == true)
        {
            //Debug.Log("ORDER" + Orders[Orders.Count - 1]);
            firstPos = GameObject.Find("OrderGO").transform.position;

            GameObject newTicket = Instantiate(OrderPreFab, firstPos, Quaternion.identity);
            newTicket.GetComponent<SpriteRenderer>().sprite = ProperDick[Orders[0]];
            ticketList.Add(newTicket);


            if (itemsPerTicket > 1)
            {
                firstItemPos = ticketList[ticketList.Count - 1].transform.position;
                secondItemPos = firstItemPos + temp2;
                GameObject SecondItem = Instantiate(OrderPreFab, secondItemPos, Quaternion.identity);
                SecondItem.GetComponent<SpriteRenderer>().sprite = ProperDick2[Orders[1]];
                SecondItem.transform.parent = newTicket.transform;
            }

            TicketKey = SammichHelper.MakeKey(Orders.Count, Orders);
            if (ticketList.Count > LoseCon)
            {
                FindObjectOfType<GameManager>().EndGame();
            }

            firstTicket = false;
        }
        else
        {
            Debug.Log(Orders.Count + "!!!!!!!!?????????!!!!!!");


            lastPos = ticketList[ticketList.Count - 1].transform.position;
            newTickPos = lastPos + temp;
            GameObject newTicket = Instantiate(OrderPreFab, newTickPos, Quaternion.identity);
            newTicket.GetComponent<SpriteRenderer>().sprite = ProperDick[Orders[0]];
            ticketList.Add(newTicket);

            if (itemsPerTicket > 1)
            {
                firstItemPos = ticketList[ticketList.Count - 1].transform.position;
                secondItemPos = firstItemPos + temp2;
                GameObject SecondItem = Instantiate(OrderPreFab, secondItemPos, Quaternion.identity);
                SecondItem.GetComponent<SpriteRenderer>().sprite = ProperDick2[Orders[1]];
                SecondItem.transform.parent = newTicket.transform;
            }
            TicketKey = SammichHelper.MakeKey(Orders.Count, Orders);
            Debug.Log(Orders.Count + "!!!!!!!!?????????!!!!!!");

        }
        if (ticketList.Count > LoseCon)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
