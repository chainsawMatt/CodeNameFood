using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TicketSpace
{
    /* Variable Documentation ************************************************************************************************************************************
     * TicketID    ----> This is the "BigID" - a concatenation of both item IDs to insure that they're unique - it's also how they (both items) know about one another*
     * item1_ID    ----> Unique ID for the first sandwhich/item on the ticket                                                                                       *
     * item2_ID    ----> Unique ID for the second sandwhich/item on the ticket                                                                                      *
     * item1       ----> Sprite variable to hold the appropriate sprite for the first item                                                                          *   
     * item2       ----> Sprite variable to hold the appropirate sprite for the second item                                                                         *
     * item_pos    ----> Position on the rail in which the GameObjects were first instantiated                                                                      *
     * OrderPreFab ----> Empty GameObject in which our items will be instantiated on                                                                                *
     * fItem       ----> GameObject for our first item to be instantiated on                                                                                        *
     * sItem       ----> GameObject for our second item to be instantiated on                                                                                       *
     * index       ----> The index of railPosition at time of ticket creation                                                                                       *
     * ***********************************************************************************************************************************************************/
    public class Ticket : MonoBehaviour
    {
        //public string TicketID = null;
        //public Vector2 item_pos = new Vector2();
        //public int index;
        List<GameObject> listOfTickets = new List<GameObject>();
        public string item1_ID = null;
        public string item2_ID = null;
        public Sprite item1 = new Sprite();
        public Sprite item2 = new Sprite();
        public GameObject OrderPrefab;
        public GameObject fItem;
        public GameObject sItem;
        public GOTuple newTicket;
        public int railIndex;
        public bool isFirst = false;
        public bool selfDestruct = true;
        public bool posReached = false;
        float lerpTime = 0.5f;
        float currentLerpTime;
        float moveDistance = 35f;

        Vector3 startPos;
        Vector3 endPos;
        public int lastIndex;
        void Start()
        {
            startPos = transform.position;
            endPos = transform.position + Vector3.left * moveDistance;
            listOfTickets = (GameObject.Find("ticketController").GetComponent<Tickets>().ticketList);
            if (isFirst)
                Invoke("SelfDestruct", 6);
        }
        private void Update()
        {
            if (GameObject.Find("ticketController").GetComponent<Tickets>().up) 
            {
                if (railIndex >= GameObject.Find("ticketController").GetComponent<Tickets>().destroyedIndex)
                {
                    StartCoroutine(Slide());
                    
                }
            }
        }

        private void LateUpdate()
        {
            if (gameObject == listOfTickets.Last() && gameObject.GetComponent<Ticket>().posReached)
            {
                
                GameObject.Find("ticketController").GetComponent<Tickets>().indexer = listOfTickets.Last().GetComponent<Ticket>().railIndex;
                GameObject.Find("ticketController").GetComponent<Tickets>().up = false;
                GameObject.Find("ticketController").GetComponent<Tickets>().destroyedIndex = 0;
                foreach (GameObject ticket in listOfTickets)
                    ticket.GetComponent<Ticket>().posReached = false;
            }
        }

        private void OnDestroy()
        {
            foreach (GameObject ticket in listOfTickets)
            {
                Debug.Log("INSIDE FOREACH!!!!!!!!!!!!!!!!!!!!!!!");

                    Debug.Log("INSIDE IF STATEMENT INSIDE FOREACH!!!!!!!!!!!!!!");
                    ticket.GetComponent<Ticket>().index = listOfTickets.IndexOf(gameObject);
                    ticket.GetComponent<Ticket>().railIndex--;
                
            }
        }
        public IEnumerator Slide()
        {
            while (GameObject.Find("ticketController").GetComponent<Tickets>().up)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime > lerpTime)
                {
                    currentLerpTime = lerpTime;
                }

                float perc = currentLerpTime / lerpTime;
                transform.position = Vector3.Lerp(startPos, endPos, perc);

                if (transform.position == endPos)
                {
                    posReached = true;
                    yield break;
                }
                else
                    yield return null;
            }
        }
/*        public void UpdateIndexes()
        {
            foreach (GameObject ticket in listOfTickets)
            {
                Debug.Log("WE ARE UPDATING TICKET AT (RAIL) POSITION :  " + ticket.GetComponent<Ticket>().railIndex.ToString() + " \r\n" +
                          "WHO'S TICKET ID IS                        :  " + ticket.GetComponent<Ticket>().TicketID.ToString() + "\r\n" +
                          "WHO'S **TICKET LIST** INDEX IS : " + ticket.GetComponent<Ticket>().index.ToString() + " \r\n" +
                          "AND THE POSITION REACHED FLAG IS CURRENTLY : " + ticket.GetComponent<Ticket>().posReached + "\r\n");



                Debug.Log("**WE HAVE UPDATED** TICKET AT (RAIL) POSITION :  " + ticket.GetComponent<Ticket>().railIndex.ToString() + " \r\n" +
                          "WHO'S TICKET ID IS                        :  " + ticket.GetComponent<Ticket>().TicketID.ToString() + "\r\n" +
                          "WHO'S **TICKET LIST** INDEX IS **NOW** : " + ticket.GetComponent<Ticket>().index.ToString() + " \r\n" +
                          "AND THE POSITION REACHED FLAG IS CURRENTLY : " + ticket.GetComponent<Ticket>().posReached);

            }
        }*/

        public void SelfDestruct()
        {
            //int railIndex = listOfTickets.IndexOf(gameObject);
            GameObject.Find("ticketController").GetComponent<Tickets>().destroyedIndex = gameObject.GetComponent<Ticket>().railIndex;
            Debug.Log("DESTROYED INDEX DURING SELF DESTRUCT ------------> " + gameObject.GetComponent<Ticket>().index.ToString());
            if (TicketID == listOfTickets[index + 1].GetComponent<Ticket>().TicketID)
            {
                Debug.Log("TWO ITEMS: BOTH INDEXES OF TICKETS ABOUT TO DESTRUCT ----------------------->>>>>>  " + railIndex.ToString() + (railIndex + 1).ToString());
                Debug.Log("FIRST ITEM DESTROYED ------------------------> " + gameObject.GetComponent<Ticket>().TicketID.ToString());

                Debug.Log("SECOND ITEM DESTROYED ------------------------> " + listOfTickets[railIndex + 1].GetComponent<Ticket>().TicketID.ToString());
                Destroy(listOfTickets[gameObject.GetComponent<Ticket>().index + 1]);
                Destroy(gameObject);
                GameObject.Find("ticketController").GetComponent<Tickets>().up = true;
                //Debug.Log("UP ISSSSSSSSSSSSSS.......--------------->>>>>>>> " + GameObject.Find("ticketController").GetComponent<Tickets>().up + "!");
                return;
            }
            else
            {
                
                Debug.Log(" ONE ITEM: INDEXE OF TICKETS ABOUT TO DESTRUCT ----------------------->>>>>>  " + railIndex.ToString());
                Debug.Log("FIRST ITEM DESTROYED ------------------------> " + gameObject.GetComponent<Ticket>().TicketID.ToString());
                Destroy(gameObject);
                GameObject.Find("ticketController").GetComponent<Tickets>().up = true;
                //Debug.Log("UP ISSSSSSSSSSSSSS.......--------------->>>>>>>> " + GameObject.Find("ticketController").GetComponent<Tickets>().up + "!");
                return;
            }

        }

        public GOTuple PrintTicket1(Sprite first, string id_1, Vector2 pos1, int index)
        {
            fItem = Instantiate(Resources.Load("OrderGo"), pos1, Quaternion.identity) as GameObject;
            fItem.GetComponent<SpriteRenderer>().sprite = first;
            fItem.GetComponent<Ticket>().item1_ID = id_1;
            fItem.GetComponent<Ticket>().railIndex = index;
            fItem.GetComponent<Ticket>().isFirst = true;

            newTicket = new GOTuple(fItem, null);
            return newTicket;
            
        }

        public GOTuple PrintTicket2(Sprite first, string id_1, Vector2 pos1, int index, Sprite Second, string id_2, Vector2 pos2)
        {
            fItem = Instantiate(Resources.Load("OrderGo"), pos1, Quaternion.identity) as GameObject;
            fItem.GetComponent<SpriteRenderer>().sprite = first;
            fItem.GetComponent<Ticket>().item1_ID = id_2;
            fItem.GetComponent<Ticket>().railIndex = index;
            fItem.GetComponent<Ticket>().isFirst = true;

            sItem = Instantiate(Resources.Load("OrderGO"), pos2, Quaternion.identity) as GameObject;
            sItem.GetComponent<Ticket>().item2_ID = id_2;
            sItem.GetComponent<Ticket>().railIndex = index;
            sItem.GetComponent<Ticket>().isFirst = false;

            newTicket = new GOTuple(fItem, sItem);
            return newTicket;
        }
        /*public GameObject PrintTicket(Sprite first, string id_1, Vector2 pos1, int index, string bID)
        {
            fItem = Instantiate(Resources.Load("OrderGO"), pos1, Quaternion.identity) as GameObject;
            fItem.GetComponent<SpriteRenderer>().sprite = first;
            fItem.GetComponent<Ticket>().item1 = first;
            fItem.GetComponent<Ticket>().item1_ID = id_1;
            fItem.GetComponent<Ticket>().item2_ID = null;
            fItem.GetComponent<Ticket>().TicketID = bID;
            fItem.GetComponent<Ticket>().railIndex = index;
            fItem.GetComponent<Ticket>().isFirst = true;
            fItem.GetComponent<Ticket>().item_pos = pos1;
            
            return fItem;
        }

        public GameObject PrintTicket2(Sprite secondItem, string id_2, Vector2 pos2, int index, string bID)
        {
            sItem = Instantiate(Resources.Load("OrderGO"), pos2, Quaternion.identity) as GameObject;
            sItem.GetComponent<SpriteRenderer>().sprite = secondItem;
            sItem.GetComponent<Ticket>().item2 = secondItem;
            sItem.GetComponent<Ticket>().item2_ID = id_2;
            sItem.GetComponent<Ticket>().item1_ID = null;
            sItem.GetComponent<Ticket>().TicketID = bID;
            sItem.GetComponent<Ticket>().railIndex = index;
            sItem.GetComponent<Ticket>().isFirst = false;
            sItem.GetComponent<Ticket>().item_pos = pos2 + new Vector2(0f, 10f);
            return sItem;
        }*/
    }
 }