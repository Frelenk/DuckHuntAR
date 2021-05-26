using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private Vector3 positionOffset;

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.position + positionOffset;
        transform.rotation = objectToFollow.rotation;
    }
}
