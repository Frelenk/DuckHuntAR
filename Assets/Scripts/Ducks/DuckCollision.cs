using System;
using UnityEngine;

public class DuckCollision : MonoBehaviour
{
    public Duck duckInfo;
    public Action<Duck> duckShooted;

    // Start is called before the first frame update
    
    public void DuckShooted()
    {
        duckShooted?.Invoke(duckInfo);
    }
    
    
}
