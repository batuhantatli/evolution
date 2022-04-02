using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSettings : MonoBehaviour
{
    public enum State{
        Idle,
        Run,
    }
    private Rigidbody rb;

    public State state;
    public float sensitivity;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float growDuration ,sizeDecrease , sizeGrowth ;
    void Start()
    {
        state = State.Idle;
        rb = gameObject.GetComponent<Rigidbody>();
        PlayerEvents.onLeftClicked += StartRun;
    }
    void Update()
    {
        if(state == State.Run)
        {
            rb.velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        }
    }

    public void Tiny()
    {
        transform.DOScale(sizeDecrease , growDuration).OnComplete(LevelUp);
    }
    public void LevelUp()
    {
        transform.DOScale(sizeGrowth, growDuration); //SetLoops(2,LoopType.Yoyo)
        gameObject.GetComponent<PlayerDateCalculation>().DateSettings();
    }

    public void StartRun()
    {
        state = PlayerSettings.State.Run;
    }
}
