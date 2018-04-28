using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GOTuple : Tuple<GameObject,GameObject>
{
    /*public static GOTuple Zero
    {
        get { return new GOTuple(0, 0); }
    }*/

    public GOTuple(GameObject a, GameObject b)
        : base(a, b)
    {
    }
    public bool ThisIsNull(GOTuple tup)
    {
        if (tup.first == null && tup.second == null)
            return true;
        else
            return false;
    }
}
