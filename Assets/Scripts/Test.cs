using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicketSpace;

public class Test : MonoBehaviour {

    public Dictionary<int, Sprite> dick = new Dictionary<int, Sprite>();
    public Sprite [] tops = new Sprite[0];
    public List<GOTuple> testList = new List<GOTuple>();
    public Vector2 testV1= new Vector2(-100, 90);
    public Vector2 testV2 = new Vector2(-100, 70);
    public Vector2 testV3 = new Vector2(-100, 50);
    public Vector2 testV4 = new Vector2(-100, 30);
    GameObject ticket1;
    GameObject ticket2;
    GOTuple testTup;
    GOTuple testTup2;
    GOTuple testTuple;

    void Start () {
        dick.Add(1, tops[0]);
        dick.Add(2, tops[1]);
        testTup = PrintTicket(dick[1], "1", testV1, testV2, 0, "");
        testTup2 = PrintTicket(dick[2], "2", testV3,testV4, 0, "");
        Debug.Log("WORKING");
        testList.Add(testTup);
        testList.Add(testTup2);
        Debug.Log(testList[0].first.GetComponent<Ticket>().item1_ID.ToString() + "   " + testList[0].second.GetComponent<Ticket>().item2_ID.ToString());
        //Debug.Log(testList[1].first.GetComponent<Ticket>().item1_ID.ToString() + "   " + testList[1].second.GetComponent<Ticket>().item2_ID.ToString());
        Invoke("DestroyMe", 3);
        Invoke("DestroyMe2", 5);
    }
	
	// Update is called once per frame
	void Update () {
        if (testList.Count > 0)
        {
            foreach(GOTuple ticket in testList)
            {
                testList.RemoveAll(x => x.ThisIsNull(x));
            }
        }
	}
    public void DestroyMe()
    {
        Destroy(testList[0].first);
        Debug.Log("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOM!!!!!!!");
    }
    public void DestroyMe2()
    {
        Destroy(testList[0].second);
        Debug.Log("BOOOOOOMMMMMMMMMMM22222222222222222222222");
    }
    public GOTuple PrintTicket(Sprite first, string id_1, Vector2 pos1, Vector2 buffer, int index, string bID)
    {
        
        ticket1 = Instantiate(Resources.Load("OrderGO"), pos1, Quaternion.identity) as GameObject;
        ticket1.GetComponent<SpriteRenderer>().sprite = first;
        ticket1.GetComponent<Ticket>().item1 = first;
        ticket1.GetComponent<Ticket>().item1_ID = id_1;
        ticket1.GetComponent<Ticket>().item2_ID = null;
        ticket1.GetComponent<Ticket>().TicketID = bID;
        ticket1.GetComponent<Ticket>().railIndex = index;
        ticket1.GetComponent<Ticket>().isFirst = true;
        ticket1.GetComponent<Ticket>().item_pos = pos1;


    
        ticket2 = Instantiate(Resources.Load("OrderGO"), buffer, Quaternion.identity) as GameObject;
        ticket2.GetComponent<SpriteRenderer>().sprite = first;
        ticket2.GetComponent<Ticket>().item2 = first;
        ticket2.GetComponent<Ticket>().item2_ID = id_1;
        ticket2.GetComponent<Ticket>().item1_ID = null;
        ticket2.GetComponent<Ticket>().TicketID = bID;
        ticket2.GetComponent<Ticket>().railIndex = index;
        ticket2.GetComponent<Ticket>().isFirst = false;
        //ticket2.GetComponent<Ticket>().item_pos = testV + new Vector2(0f, 10f);

        testTuple = new GOTuple(ticket1,ticket2);
        return testTuple;
    }
}
