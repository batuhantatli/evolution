using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DatePlate : MonoBehaviour
{
    public enum Type{
        Day,
        Weak,
        Mounth,
        Year,
    }

    public Type dateType;
    public int multipier;
    [HideInInspector] public int isUp ;
    public bool isPositive;
    [SerializeField] private TMP_Text dateType_text;
    [SerializeField] private TMP_Text dateMultipier_text;

    private void Start() 
    {
        if(dateType == Type.Day)
        {
            dateType_text.text = "days";
        }
        if(dateType == Type.Weak)
        {
            dateType_text.text = "weaks";
        }
        if(dateType == Type.Mounth)
        {
            dateType_text.text = "months";
        }
        if(dateType == Type.Year)
        {
            dateType_text.text = "years";
        }
        if(isPositive)
        {
            dateMultipier_text.text = "+" +multipier+ "";
            isUp = 1 ;
        }
        else if (!isPositive)
        {
            dateMultipier_text.text = "-" +multipier+ "";
            isUp = -1;
        }
        
    }

    public void DateMultipier(int dayCounter, GameObject player)
    {
        if(dateType == Type.Day)
        {
            player.GetComponent<PlayerDateCalculation>().dayCounter += multipier *1* isUp;
        }
        if(dateType == Type.Weak)
        {
            player.GetComponent<PlayerDateCalculation>().dayCounter += multipier *7* isUp;
        }
        if(dateType == Type.Mounth)
        {
            player.GetComponent<PlayerDateCalculation>().dayCounter += multipier*30* isUp;
        }
        if(dateType == Type.Year)
        {
            player.GetComponent<PlayerDateCalculation>().dayCounter += multipier*365* isUp;
        }
    }
}
