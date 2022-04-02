using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void TouchEvent();
    public static event TouchEvent onLeftClicked;
    public static event TouchEvent onLeftClickHolding;

    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            onLeftClicked();
        }
        if (Input.GetMouseButton(0))
        {
            onLeftClickHolding();
        }
    }
}
