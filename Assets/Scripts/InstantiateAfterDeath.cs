
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAfterDeath : MonoBehaviour
{
    [SerializeField] private float secondsToDisable;
    [SerializeField] private float headYTitleOffset;
    [SerializeField] private float valuesYTitleOffset;
    [SerializeField] private List<GameObject> headshotTitle;
    [SerializeField] private List<GameObject> fiftyPointsTitle;
    [SerializeField] private List<GameObject> hundredPointsTitle;
    
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    public void InstantiateObjects(Vector3 collidedPosition, string coliderTag)
    {
        

        if (coliderTag == "Head")
        {
            foreach (var item in headshotTitle)
            {
                if (!item.activeSelf)
                {
                    item.transform.position = collidedPosition + Vector3.up * headYTitleOffset;
                    item.SetActive(true);
                    StartCoroutine(DisableTitle(item));
                    break;
                }
            }
            
            foreach (var item in hundredPointsTitle)
            {
                if (!item.activeSelf)
                {
                    item.transform.position = collidedPosition + Vector3.up * valuesYTitleOffset;
                    item.SetActive(true);
                    StartCoroutine(DisableTitle(item));
                    break;
                }
            }
           
        }
        else
        {
            foreach (var item in fiftyPointsTitle)
            {
                if (!item.activeSelf)
                {
                    item.transform.position = collidedPosition + Vector3.up * valuesYTitleOffset;
                    item.SetActive(true);
                    StartCoroutine(DisableTitle(item));
                    break;
                }
            }
        }
    }

    private IEnumerator DisableTitle(GameObject title)
    {
        yield return new WaitForSeconds(secondsToDisable);
        title.SetActive(false);
    }
    
    
}
