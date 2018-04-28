using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SandwhichSpace;
using TicketSpace;
using System.Linq;
public class Tickets : MonoBehaviour
{
    /** Variable Documentation **********************************************************************************************************************************************
     * ProperDick   ----> Empty Dictionary that points to the appropriate dictionary contatining needed sprite                                                                  *
     * ProperDick2  ----> Empty Dick that points to the right Dick for the second item on the ticket                                                                            *
     * TheDicks     ----> List Dictionary that holds references to  the dictionary of keys/sprites                                                                              *
     * ticketList   ----> List of all current ticket ITEMS - that is, its a list of GameObjects with Ticket class instances attached to them each GO is an item on a ticket     *
     * Orders       ----> List holding the keys of the items that will be put on a ticket (may want to change this to an array at some point for faster operations/less overhead)*
     * HiddenOrders ----> List containing the same keys as Orders, but with prepended alpha characters to insure unique IDs for each item                                       *
     * railPosition ----> List of Vector2 values that represent the position in which the next ticket printed will be placed                                                    *
     * currentPos   ----> Vector2 value that holds the position for the next ticket based on the indexer variable                                                               *
     * xBuffer      ----> Vector2 value that pads space between each ticket (currently set to 35f)                                                                              *
     * yBuffer      ----> Vector2 value that pads the second item on the ticket                                                                                                 *
     * railStartPos ----> Starting position of the rail. Not entirely necessary but could be useful to have this value be accessable                                            *
     * OrderPrefab  ----> Empty GameObject in which our sprites will be instantiated on                                                                                         *
     * timeBetween  ----> Amount of that passes before next ticket is printed to the screen                                                                                     *
     * nextTicket   ----> Checked against to see if it is time to print the next ticket                                                                                         *
     * indexer      ----> Int variable that holds the index on the railPostition List                                                                                           *
     * destroyedInd ----> Int variable used to hold the index value of the last position of the GameObject that was destroyed                                                   *
     * itemsPerTick ----> Int variable that holds the number of items to be prtinted on each ticket (as of right now it can only be 1 or 2                                      *
     * LoseCon      ----> Number of tickets that can be on screen before GameOver                                                                                               *
     * numtops      ----> Int variable that holds the number of toppings per item on a ticket                                                                                   *
     * up           ----> Boolean flag that triggers the rail to slide                                                                                                          *
     * **********************************************************************************************************************************************************************/

    public Dictionary<int, Sprite> ProperDick = new Dictionary<int, Sprite>();
    public Dictionary<int, Sprite> ProperDick2 = new Dictionary<int, Sprite>();
    public SortedList<int, Dictionary<int, Sprite>> TheDicks = new SortedList<int, Dictionary<int, Sprite>>();
    public List<GOTuple> ticketList = new List<GOTuple>();
    public List<Vector2> railPosition = new List<Vector2>();
    public List<int> Orders = new List<int>();
    public List<string> HiddenOrders = new List<string>();


    public Vector2 currentPos;
    Vector2 xBuffer = new Vector2(35f, 0);
    Vector2 railStartPos = new Vector2(-120f, 105f);

    public GameObject OrderPreFab;

    public float timeBetweenTickets;
    public float nextTicket;
    public int indexer;
    public int destroyedIndex;
    public int itemsPerTicket;
    public int LoseCon;
    int numTops;

    public bool up = false;
    public bool SelfD = false;
    float step;
    int speed = 2;

    float lerpTime = 1f;
    float currentLerpTime;

    float moveDistance = 35f;
    public bool moving;
    Vector3 start;
    Vector3 end;

    void Start()
    {
        TheDicks.Add(1, Sandwiches.OneTopsDick);
        TheDicks.Add(2, Sandwiches.TwoTopsDick);
        TheDicks.Add(3, Sandwiches.ThreeTopsDick);
        TheDicks.Add(4, Sandwiches.FourTopsDick);
        TheDicks.Add(5, Sandwiches.FiveTopsDick);

        indexer = 0;
        railPosition.Add(railStartPos);
        for (int i = 1; i < 10; i++)
        {
            railPosition.Add(railPosition[i - 1] + xBuffer);
        }
    }
    void Update()
    {
        if (ticketList.Count > 0)
        {
            ticketList.RemoveAll(x => x == null);
        }

        if (Time.time > nextTicket)
        {
            nextTicket = Time.time + timeBetweenTickets;
            StartCoroutine(WaitToPrint());
            CreateTicket();
            UpdatePosition();

        }

        if (up)
        {
            //StartCoroutine(FlipUpFlag(moving));
        }
        
    }
    /* WaitToPrint()***************************************************************
    *  WaitToPrint() runs before we create a ticket and update position           *
    *  It's essentially saying while up is true (this means the rail is sliding)  *
    *  yield until that method completes, then control is returned back to where  *
    *  it left off when WaitToPrint() ran                                         *
    * ****************************************************************************/
    IEnumerator WaitToPrint()
    {
        while (up)
        {
            Debug.Log("<<<<<<<<<<<<<<<<<WAITING>>>>>>>>>>>>>>>>>");
            yield return null;
            
        }
    }

    public void UpdatePosition()
    {
        Debug.Log("INDEXER IN UPDATE POSITION BEFORE UPDATE IS RUN ----> : " + indexer.ToString());
        Debug.Log("DESTROYED INDEX IN UPDATE BEFORE UPDATE IS RUN -----> : " + destroyedIndex.ToString());
        if (indexer == railPosition.Count - 1)
            timeBetweenTickets = 1000000000;
        else
        {
            if (ticketList.Count > 0)
            {
                /*if (ticketList.Count > 0)
                {
                    ticketList.RemoveAll(x => x == null);
                }*/
                currentPos = railPosition[indexer];
                indexer++;
                Debug.Log("INDEXER IN UPDATE POSITION **AFTER** UPDATE IS RUN ----> : " + indexer.ToString());
                Debug.Log("DESTROYED INDEX IN UPDATE **AFTER** UPDATE IS RUN -----> : " + destroyedIndex.ToString());
            }
        }
    }
    /*public void SlideRail()
    {
        ticketList.RemoveAll(x => x == null);

        indexer = railPosition.IndexOf(ticketList.Last().GetComponent<Ticket>().item_pos);
        up = false;
    }
    /* 
     *         int count = ticketList.Count;
        Vector3 moveUnits = new Vector3(-35, 0, 0);
        //float waitTime = 0.04f;
        // Vector3 buffer = Vector3.zero;
        for (int i = destroyedIndex; i < ticketList.Count; i++)
        {
            start = ticketList[i].transform.position;
            end = ticketList[i].transform.position + Vector3.left * moveDistance;
            Debug.Log("DESTROYED INDEX RIGHT HERE -------___-------------__------------>>>>>>>> " + destroyedIndex.ToString());
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float perc = currentLerpTime / lerpTime;    
            ticketList[i].transform.position = Vector3.Lerp(start, end, perc);
        }
        yield return new WaitForEndOfFrame();
        Debug.Log("INDEXER AT TEND OF SLIDERAIL()------------------------> " + indexer.ToString());
        Debug.Log("LAST ITEM VECTOR IN TICKET LIST =====================-> " + ticketList.Last().GetComponent<Ticket>().item_pos);if (!yield return new WaitForSeconds(waitTime);
            ticketList[i].transform.Translate( Vector3.left * 35 * speed * waitTime);
                ticketList[i].GetComponent<Ticket>().index--;[i].GetComponent<Ticket>().isFirst)
                buffer = new Vector3(-35f, -10f);

            if (ticketList[i] != null)
            {
                while (Vector3.Distance(ticketList[i].transform.position, ticketList[i].transform.position + buffer ) > 0)
                {
                    yield return new WaitForSeconds(waitTime);
                    ticketList[i].transform.position = Vector3.MoveTowards(ticketList[i].transform.position, ticketList[i].transform.position + buffer, speed * waitTime);

                    if (Vector3.Distance(ticketList[i].transform.position, ticketList[i].transform.position + buffer) == 0)
                        break;
                }*/
    public void CreateOrder()
    {
        numTops = Random.Range(1,6);
        itemsPerTicket = Random.Range(1, 3);
        Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket);
        int DickLength1;
        int DickLength2;
        
        if (Orders.Count > 1)
        {
            DickLength1 = Orders[0].ToString().Length;
            DickLength2 = Orders[1].ToString().Length;
            ProperDick = TheDicks[DickLength1];
            ProperDick2 = TheDicks[DickLength2];
        }
        else
        {
            DickLength1 = Orders[0].ToString().Length;
            ProperDick = TheDicks[DickLength1];
        }
    }

    public void CreateTicket()
    {
        CreateOrder();

        Debug.Log("ORDER COUNT AT TICKET CREATION: " + Orders.Count);
        Debug.Log("INDEXER FOR TICKET BEING CREATED, THIS SHOULD BE RAILINDEX OF PREVIOUS TICKET + 1(RIGHT???) :" + indexer.ToString());
        currentPos = railPosition[indexer];
        HiddenOrders = SammichHelper.HideKeys(Orders);

        Ticket newTicket = new Ticket();
        Vector2 tempPos = currentPos + new Vector2(0f, -10f);

        if (Orders.Count > 1)
            ticketList.Add(newTicket.PrintTicket2(ProperDick[Orders[0]], HiddenOrders[0], currentPos, indexer, ProperDick2[Orders[1]], HiddenOrders[1], tempPos));
        else
            ticketList.Add(newTicket.PrintTicket1(ProperDick[Orders[0]], HiddenOrders[0], currentPos, indexer));

        if (ticketList.Count > LoseCon)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
/* ------------------------------------------------------------------------------------------------------------------------------------------- 
 * Old code just in case:
 *         
 *         
 *             if (Orders.Count > 1)
        {
            bigID = HiddenOrders[0] + HiddenOrders[1];
            ticketList.Add(newTicket.PrintTicket(ProperDick[Orders[0]], HiddenOrders[0], currentPos, indexer, bigID));

            tempPos = currentPos + new Vector2(0f, -10f);
            ticketList.Add(newTicket.PrintTicket2(ProperDick2[Orders[1]], HiddenOrders[1], tempPos, indexer, bigID));
        }
        else
        {
            bigID = HiddenOrders[0];
            ticketList.Add(newTicket.PrintTicket(ProperDick[Orders[0]], HiddenOrders[0], currentPos, indexer, bigID));
        }
 *         
 *         
 *         
 *         
 *         
 *         
 *         /*switch (numTops) { 
            case 1:
                Orders = (SammichHelper.MakeOrder(numTops, itemsPerTicket,OpenTickets));
                ProperDick = Sandwiches.OneTopsDick;
                
                break;
            case 2:
                Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket, OpenTickets);
                ProperDick = Sandwiches.TwoTopsDick;
                
                SammichHelper.PrintAList("TICKETS ORDER @ CASE 2: ", Orders,-1);
                break;
            case 3:
                Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket, OpenTickets);
                ProperDick = Sandwiches.ThreeTopsDick;
            
                SammichHelper.PrintAList("TICKETS ORDER @ CASE 3: ", Orders,-1);
                break;
            case 4:
                Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket, OpenTickets);
                ProperDick = Sandwiches.FourTopsDick;
                
                SammichHelper.PrintAList("TICKETS ORDER @ CASE 4: ", Orders,-1);
                break;
            case 5:
                Orders = SammichHelper.MakeOrder(numTops, itemsPerTicket, OpenTickets);
                ProperDick = Sandwiches.FiveTopsDick;
                
                SammichHelper.PrintAList("TICKETS ORDER @ CASE 5: ", Orders,-1);
                break;
            default:
                break;
               
        }
        
        /*switch (DickLength1)
        {
            case 1:
                ProperDick = Sandwiches.OneTopsDick;
                break;
            case 2:
                ProperDick = Sandwiches.TwoTopsDick;
                //SammichHelper.PrintAList("TICKETS ORDER @ CASE 2: ", Orders, -1);
                break;
            case 3:
                ProperDick = Sandwiches.ThreeTopsDick;
                //SammichHelper.PrintAList("TICKETS ORDER @ CASE 3: ", Orders, -1);
                break;
            case 4:
                ProperDick = Sandwiches.FourTopsDick;
                //SammichHelper.PrintAList("TICKETS ORDER @ CASE 4: ", Orders, -1);
                break;
            case 5:
                ProperDick = Sandwiches.FiveTopsDick;
                //SammichHelper.PrintAList("TICKETS ORDER @ CASE 5: ", Orders, -1);
                break;
            default:
                break;
        }

        /*Debug.Log("ORDERS COUNT AFTER ORDERS LIST IS CREATED =" + Orders.Count);
        if (Orders.Count > 1)
        {
            DickLength2 = Orders[1].ToString().Length;

            switch (DickLength2)
            {
                case 1:
                    ProperDick2 = Sandwiches.OneTopsDick;
                    break;
                case 2:
                    ProperDick2 = Sandwiches.TwoTopsDick;
                    //SammichHelper.PrintAList("TICKETS ITEM @ CASE 2 PT2: ", Orders, -1);
                    break;
                case 3:
                    ProperDick2 = Sandwiches.ThreeTopsDick;
                    //SammichHelper.PrintAList("TICKETS ITEM @ CASE 3 PT2: ", Orders, -1);
                    break;
                case 4:
                    ProperDick2 = Sandwiches.FourTopsDick;
                    //SammichHelper.PrintAList("TICKETS ITEM @ CASE 4 PT2: ", Orders, -1);
                    break;
                case 5:
                    ProperDick2 = Sandwiches.FiveTopsDick;
                    //SammichHelper.PrintAList("TICKETS ITEM @ CASE 5 PT2: ", Orders, -1);
                    break;
                default:
                    break;
            }
        }
/* if (firstTicket && Orders.Count == 1)
{
   firstPos = GameObject.Find("OrderGO").transform.position;
   GameObject newTicket = Instantiate(OrderPreFab, firstPos, Quaternion.identity);
   newTicket.GetComponent<SpriteRenderer>().sprite = ProperDick[Orders[0]];
   ticketList.Add(newTicket);

   firstTicket = false;
        Orders.Clear();
        HiddenOrders.Clear();
}
else if (firstTicket && Orders.Count > 1)
{
   firstPos = GameObject.Find("OrderGO").transform.position;
   GameObject newTicket = Instantiate(OrderPreFab, firstPos, Quaternion.identity);
   newTicket.GetComponent<SpriteRenderer>().sprite = ProperDick[Orders[0]];
   ticketList.Add(newTicket);
   firstItemPos = ticketList[ticketList.Count - 1].transform.position;
   secondItemPos = firstItemPos + temp2;
   GameObject SecondItem = Instantiate(OrderPreFab, secondItemPos, Quaternion.identity);

   SecondItem.transform.parent = newTicket.transform;
   SecondItem.GetComponent<SpriteRenderer>().sprite = ProperDick2[Orders[1]];

   HiddenOrders = SammichHelper.HideKeys(Orders);

   newTicket.GetComponent<IDscript>().ID = HiddenOrders[0];
   SecondItem.GetComponent<IDscript>().ID = HiddenOrders[1];

   OpenTickets.Add(newTicket.GetComponent<IDscript>().ID, newTicket);
   OpenTickets.Add(SecondItem.GetComponent<IDscript>().ID, SecondItem);
}
else
{
   HiddenOrders = SammichHelper.HideKeys(Orders);

   //newTicket.GetComponent<IDscript>().ID = HiddenOrders[0];
   //OpenTickets.Add(newTicket.GetComponent<IDscript>().ID, newTicket);
}

   foreach (string key in OpenTickets.Keys)
   {
       Debug.Log(key + "<-----------------------------KEY");
}
else
{
    SammichHelper.PrintAList("ORDER LIST AGAIN FIND THAT ERROR NIGGA! :", Orders, -1);

    lastPos = ticketList[ticketList.Count - 1].transform.position;
    newTickPos = lastPos + temp;
    GameObject newTicket = Instantiate(OrderPreFab, newTickPos, Quaternion.identity);
    newTicket.GetComponent<SpriteRenderer>().sprite = ProperDick[Orders[0]];
    ticketList.Add(newTicket);

    if (Orders.Count > 1)
    {
        firstItemPos = ticketList[ticketList.Count - 1].transform.position;
        secondItemPos = firstItemPos + temp2;
        GameObject SecondItem = Instantiate(OrderPreFab, secondItemPos, Quaternion.identity);

        SecondItem.transform.parent = newTicket.transform;
        SecondItem.GetComponent<SpriteRenderer>().sprite = ProperDick2[Orders[1]];

        HiddenOrders = SammichHelper.HideKeys(Orders);

        newTicket.GetComponent<IDscript>().ID = HiddenOrders[0];
        SecondItem.GetComponent<IDscript>().ID = HiddenOrders[1];

        OpenTickets.Add(newTicket.GetComponent<IDscript>().ID, newTicket);
        OpenTickets.Add(SecondItem.GetComponent<IDscript>().ID, SecondItem);

        foreach (string key in OpenTickets.Keys)
        {
            Debug.Log(key + "<-----------------------------KEY");
        }
    }
    else
    {
        HiddenOrders = SammichHelper.HideKeys(Orders);
        newTicket.GetComponent<IDscript>().ID = HiddenOrders[0];
        OpenTickets.Add(newTicket.GetComponent<IDscript>().ID, newTicket);
    }

    Orders.Clear();
    HiddenOrders.Clear();

    Debug.Log(OpenTickets.Count + "OPEN TICKETS");
    Debug.Log(Orders.Count + "!!!!!!!!?????????!!!!!!");

}
-------------------------------------------------------------------------------------------------------------------------------------------*/
