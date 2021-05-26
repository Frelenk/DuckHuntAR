using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialQueue : MonoBehaviour
{
    [SerializeField] private List<Material> materials;
  
    [SerializeField] private int materialQueue;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in materials)
        {
            item.renderQueue = materialQueue;
        }
    }

    // Update is called once per frame
}
