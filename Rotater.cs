using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float duration;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.DORotate(new Vector3(10,0,0), duration, RotateMode.LocalAxisAdd).SetLoops(-1);
    }
}
