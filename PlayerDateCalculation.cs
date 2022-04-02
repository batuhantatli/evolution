using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerDateCalculation : MonoBehaviour
{
    [SerializeField] private int date;
    private int dateUp;
    public int dayCounter;
    [SerializeField] private TMP_Text dateText;

    [SerializeField] private int startingDate;
    [SerializeField] private List<GameObject> playerModels = new List<GameObject>();
    [SerializeField] private GameObject currentPlayerPrefabs;
    private MeshFilter currentPlayerMesh;
    private Material currentPlayerMaterial;
    
    void Start()
    {
        date = startingDate;
        dateText.text = "" + date;
        currentPlayerMesh = currentPlayerPrefabs.GetComponent<MeshFilter>();
        currentPlayerMaterial = currentPlayerPrefabs.GetComponent<MeshRenderer>().material;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("DatePlate"))
        {
            other.GetComponent<DatePlate>().DateMultipier(this.dayCounter,gameObject);
            gameObject.GetComponent<PlayerSettings>().Tiny();
            DateUpdate();
        }
        if(other.CompareTag("Obstacle"))
        {
            other.GetComponent<Obstacles>().DateMultipier(this.dayCounter,gameObject);
            gameObject.transform.GetChild(0).transform.DOShakePosition(.15f , new Vector3(.1f,0,.1f), 40, 50, false, true);
            DateUpdate();
            DateSettings();
        }
    }

    private void DateUpdate()
    {
        if(dayCounter >= 365)
        {
            dateUp = dayCounter / 365;
            date += dateUp;
            dayCounter = dayCounter % 365;
            DateTextUpdate();
        }
        else if (dayCounter <= -365)
        {
            dateUp = dayCounter / 365;
            date += dateUp;
            dayCounter = 0;
            DateTextUpdate();
        }
    }
    private void DateTextUpdate()
    {
        dateText.text = ""+date;
    }

    public void DateSettings()
    {
        if(date >= 1870)
        {
            ModelChanger(3);
        }
        else if (date >= 1865)
        {
            ModelChanger(2);
        }
        else if (date >= 1860)
        {
            ModelChanger(1);
        }
        else 
        {
            ModelChanger(0);
        }
        
    }

    private void ModelChanger(int k)
    {
        if(currentPlayerMesh.sharedMesh != playerModels[k].GetComponent<MeshFilter>().sharedMesh)
        {
            currentPlayerPrefabs.transform.DORotate(new Vector3 (0,360,0), .7f, RotateMode.FastBeyond360);
            currentPlayerMesh.sharedMesh = playerModels[k].GetComponent<MeshFilter>().sharedMesh;
            currentPlayerMaterial = playerModels[k].GetComponent<MeshRenderer>().sharedMaterial;
        }
    }
}

