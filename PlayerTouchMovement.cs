using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private float leftSideOffset;
    private float rightSideOffset;
    private float sensitivity;

    void Start()
    {
        sensitivity = gameObject.GetComponent<PlayerSettings>().sensitivity;
        leftSideOffset = -2f;
        rightSideOffset = 2f;
        PlayerEvents.onLeftClicked += WorldPos;
        PlayerEvents.onLeftClickHolding += TargetPos;
    }

    public void WorldPos()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.localPosition - GetMouseAsWorldPoint();
    }

    public void TargetPos()
    {
        Vector3 targetPos = new Vector3(Mathf.Clamp(GetMouseAsWorldPoint().x + mOffset.x, leftSideOffset, rightSideOffset), transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = targetPos;
    }
    public Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToViewportPoint(mousePoint) * sensitivity;
    }
    public void SetRoadOffset(float min, float max)
    {
        leftSideOffset = min;
        rightSideOffset = max;
    }

}
