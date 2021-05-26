using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRepeatMove : MonoBehaviour
{
    [SerializeField] private Vector3 distanceToMove;
    [SerializeField] private float time;

    // Start is called before the first frame update
    private void OnEnable()
    {
       
       
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            go(); 
        }
        
    }

    public void go()
    {
        LeanTween.move(gameObject, transform.localPosition + distanceToMove, time).setLoopPingPong(0);
    }

    public void EndRepeatMove()
    {
        LeanTween.cancel(gameObject);
    }
}
