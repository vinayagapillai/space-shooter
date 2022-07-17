using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBounds : MonoBehaviour
{
    public Transform Top;
    public Transform Bottom;
    public Transform Left;
    public Transform Right;

    public float BoundsGap;

    private void Start()
    {
        SetBounds();
    }

    public void SetBounds()
    {
        Top.position = new Vector3(0, GameManager.Instance.ScreenMaxY + BoundsGap, 0);
        Bottom.position = new Vector3(0, GameManager.Instance.ScreenMinY - BoundsGap, 0);
        Left.position = new Vector3(GameManager.Instance.ScreenMinX - BoundsGap, 0,0);
        Right.position = new Vector3(GameManager.Instance.ScreenMaxX + BoundsGap, 0,0);
    }
}
