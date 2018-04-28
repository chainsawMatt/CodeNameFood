using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TicketSpace;

public class SammichHelper : MonoBehaviour
{

    public static List<char> alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()[]+-_".ToList();

    /* BITCH THIS SHIT IS CAKEY
     * THIS BITCH MAKES A KEY YOU SEE?
     * GIVE THIS LIL BITCH A NUMBER DEPENDING ON HOW MANY TOPPINGS IT GON BE
     * PASS THAT BITCH THE LOOP HOLDIN' THEM VALUES
     * BAM THERE'S YO KEY */
    public static int MakeKey(int nLoops, List<int> ListToLoop)
    {
        int tempKey = 0;
        for (int i = 0; i < ListToLoop.Count; i++)
        {
            tempKey = 10 * tempKey + ListToLoop[i];
        }
        return tempKey;
    }

    /* MakeOrder: Make a variable to hold our key (tempKey)
     * List<int> intKey holds each digit of the key. The first for loop runs n times, which determines how many digits (toppings) are in the
     * key.
     * Sort the int key
     * Second for loop walks down the intKey list, parses each integer into a string and appends it to the tempKey string, creating our key
     * We add the key to tempList - this is the list containing our items to be displayed on each ticket. It will eventually be returned and it's value
     * passed to Orders back in Tickets.cs
     * Then clear the tempKey string and clear contents of intKey List (want them empty so we can add new values to them)
     * Increase the count. It runs this process for as many items as their are on this ticket. If there are 3 items on the ticket, you will
     * (or at least you should) return a List with 3 elements in it, eg. tempList = {"00,"01",12"}                                          */
    public static List<int> MakeOrder(int nLoops, int NumItems)
    {
        int tempKey = 0;
        List<int> rndKey = new List<int>();
        List<int> tempList = new List<int>();

        int count = 0;
        int countdown = 0;

        while (count < NumItems)
        {
            for (int j = 0; j < nLoops; j++)
            {
                countdown++;
                rndKey.Add((Random.Range(1, 8)));
                rndKey.Sort();
            }
            countdown = 0;
            for (int i = 0; i < rndKey.Count; i++)
            {
                //Debug.Log("----------------------------" + int.Parse(rndKey[i].ToString()) + ":-----------------------");
                tempKey = 10 * tempKey + rndKey[i];
            }
            tempList.Add(tempKey);
            tempKey = 0;
            rndKey.Clear();
            nLoops = Random.Range(1, 6);
            count++;
        }
        return tempList;
    }
    public static List<string> HideKeys(List<int> Listy)
    {
        int index = 0;
        int indexy = 0;
        int indexiest = 0;
        string held = "";
        List<string> tempList = new List<string>();

        for (int i = 0; i < Listy.Count; i++)
        {
            index = Random.Range(0, alpha.Count);
            indexy = Random.Range(0, alpha.Count);
            indexiest = Random.Range(0, alpha.Count);

            held = System.String.Concat(alpha[index], alpha[indexy], alpha[indexiest], Listy[i]);
            tempList.Add(held);

            Shuffle(alpha);
        }
        return tempList;
    }
    public static void Shuffle(List<char> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            char temp = list[i];
            int rndIndex = Random.Range(0, list.Count);
            list[i] = list[rndIndex];
            list[rndIndex] = temp;
        }
    }

    public static int SeekAndDestroy(int key, GOTuple ticket)
    {
        if (ticket == null)
            return 0;

        int itemID;
        int.TryParse(ticket.first.GetComponent<Ticket>().item1_ID.Substring(3), out itemID);
        if (ticket.first.GetComponent<Ticket>().item1_ID)





       /* if (ticket == list.First() || ticket.GetComponent<Ticket>().item1_ID != null )
        {
            int.TryParse(ticket.GetComponent<Ticket>().item1_ID.Substring(3), out itemID);
            if (key == itemID)
                if (list[ticketIndex + 1].GetComponent<Ticket>().TicketID == id)
                    return 1;
                else
                    return 2;
            else
                return 0;
        }
        else if ( ticket == list.Last() ||  ticket.GetComponent<Ticket>().item2_ID != null )
        {
            int.TryParse(ticket.GetComponent<Ticket>().item2_ID.Substring(3), out itemID);
            if (key == itemID)
                if (list[ticketIndex - 1].GetComponent<Ticket>().TicketID == id)
                    return 1;
                else
                    return 2;
            else
                return 0;
        }
        else
            return 0;*/
    }
    /* IT'S SUPER SIMPLE - IT PRINTS A LIST
     * FEED THIS BITCH A STRING FOR SOME BUG SHIT YOU TRYINA CHECK
     * FEED HIS ASS A LIST
     * AND THIS MOTHER FUCKER WILL PRINT OUT THAT MOTHA FUCKIN' LISSSSSSSSSSSSSSSSTTTTTTTTTTTT
     * YOU CAN ALSO OPTIONALLY THROW IN AN INDEX YOU MIGHT WANNA SEE NIGGAAAAAAAAAAAAAAAAAAAAAAAAAAAA
     * LIKE MAYBE YOU DON'T NEED A WHOLE LIST PRINTED BUT YOU TRYINA SEE LIKE ONE OF DEM VALUES RIGHT?
     * JUST PUT THE MA FUCKING INT VALUE OF THE APPROPRIATE INDEX YOU TRYINA SEE AND THAT SHIT WILL SHOW YA
     * IF YOU DON'T WANT TO USE THE THIRD PARAMETER, JUST PUT -1 BIIIIIIIIIIIIIIIIIIIIIIIIIIIITTTTTTTTTTTTTTTTTTTCCCCCCHHHHHH*/
    public static void PrintAList(string info, List<int> list, int index)
    {
        if (index > -1)
        {
            Debug.Log(info + "[AT INDEX [" + index + "] =" + list[index].ToString());
        }
        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log(info + list[i] + "//");
            }
        }

    }

}
/* Old code just in case:************************************************************************************************************************
 * 
 *     
 *             /*if (ticketIndex > 0)
        {
            if ((list[ticketIndex - 1].GetComponent<Ticket>().TicketID != id) && (list[ticketIndex + 1].GetComponent<Ticket>().TicketID == id))
            {
                int.TryParse(ticket.GetComponent<Ticket>().item1_ID.Substring(3), out itemID);
                if (key == itemID)
                    return 1;
                else
                    return 0;
            }
            else if ((list[ticketIndex + 1].GetComponent<Ticket>().TicketID != id) && (list[ticketIndex - 1].GetComponent<Ticket>().TicketID == id))
            {
                int.TryParse(ticket.GetComponent<Ticket>().item2_ID.Substring(3), out itemID);
                if (key == itemID)
                    return 1;
                else
                    return 0;
            }
            else if ((list[ticketIndex + 1].GetComponent<Ticket>().TicketID != id) && (list[ticketIndex - 1].GetComponent<Ticket>().TicketID != id))
            {
                if (ticket.GetComponent<Ticket>().item1_ID == null)
                {
                    int.TryParse(ticket.GetComponent<Ticket>().item2_ID.Substring(3), out itemID);
                    if (key == itemID)
                        return 2;
                    else
                        return 0;
                }
                else
                {
                    int.TryParse(ticket.GetComponent<Ticket>().item1_ID.Substring(3), out itemID);
                    if (key == itemID)
                        return 2;
                    else
                        return 0;
                }
            }
            else
            {
                Debug.Log("ERROR, ERROR, ERROR, ERROR, ERROR");
                return 0;
            }
        }
        else
            return 0;



 //int itemID;
 //string id = ticket.GetComponent<Ticket>().TicketID;
 //int ticketIndex = list.IndexOf(ticket);
 *
 *     /*int itemID;
        List<string> tempList = new List<string>(ticket.GetComponent<Ticket>().onTicket.Keys);

        for (int i = 0; i < tempList.Count; i++)
        { 
            int.TryParse(tempList[i].Substring(3), out itemID);
            if (key == itemID)
            {
                Destroy(ticket.GetComponent<Ticket>().onTicket[tempList[i]]);
                ticket.GetComponent<Ticket>().onTicket.Remove(tempList[i]);
                break;
                
            }
        }
        if (ticket.GetComponent<Ticket>().onTicket.Count == 0)
            return true;
        else
            return false;
 *
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * */
