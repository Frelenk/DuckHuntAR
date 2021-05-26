using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRotateObject : MonoBehaviour
{
    [SerializeField] private bool rotateOnEnable;
    [SerializeField] private float timeToComplete;
    [SerializeField] private float delay;
    [SerializeField] private Vector3 rotateAxis;
    [SerializeField] private float rotateAmmount;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (rotateOnEnable)
        {
            
        }
    }

    // Update is called once per frame
    public void RotateObject(bool reverseRotate)
    {
        int valueForReverse = 1;
        if (reverseRotate)
            valueForReverse = -1;
        LeanTween.rotateAroundLocal(gameObject, rotateAxis, valueForReverse*rotateAmmount, timeToComplete).setDelay(delay);
    }

   
}
