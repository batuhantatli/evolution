using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int dateDowner;
    public void DateMultipier(int dayCounter, GameObject player)
    {
        player.GetComponent<PlayerDateCalculation>().dayCounter += dateDowner *-1;
    }
}
