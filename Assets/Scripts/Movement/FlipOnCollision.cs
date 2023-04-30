using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipOnCollision : MonoBehaviour
{
    private AutoMove _autoMove;
    public string XFlipTag;
    public string YFlipTag;
    void Start()
    {
        _autoMove = GetComponent<AutoMove>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (_autoMove == null)
            return;
        var collVelocity = coll.relativeVelocity;
        Debug.Log(collVelocity);
        bool flipX, flipY;
        if (XFlipTag != "")
            flipX = coll.gameObject.CompareTag(XFlipTag);
        else 
            flipX = Mathf.Abs(collVelocity.x) > 0.1f;
        if (YFlipTag != "")
            flipY = coll.gameObject.CompareTag(YFlipTag);
        else 
            flipY = Mathf.Abs(collVelocity.y) > 0.1f;
        _autoMove.FlipDirection(flipX, flipY);
    }
}
