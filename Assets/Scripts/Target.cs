using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TweenMoveObject targetTweenMoveObject;
    [SerializeField] private GameObject title;
    public Action onTargetCollision;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        
        onTargetCollision?.Invoke();
        StartCoroutine(DisableObjects());
    }

    public void ActiveMovement(bool inversion)
    {
        title.SetActive(true);
        gameObject.SetActive(true);
        targetTweenMoveObject.MoveObject(inversion);
        title.GetComponent<TweenMoveObject>().MoveObject(inversion);
    }

    
    
    private IEnumerator DisableObjects()
    {
        yield return new WaitForSeconds(.5f);
        title.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        
    }
}
