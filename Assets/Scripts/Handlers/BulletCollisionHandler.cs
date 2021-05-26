using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletCollisionHandler : MonoBehaviour
{
    [SerializeField] List<Bullet> bullets;
    [SerializeField] UnityEvent <Vector3,string> OnBulletCollision;
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in bullets)
        {
            item.onBulletCollisionAction += OnBulletCollisionEnter;
        }
    }

    void OnBulletCollisionEnter(Vector3 collisionPosition, string colliderTag)
    {
        OnBulletCollision?.Invoke(collisionPosition, colliderTag);
    }

    // Update is called once per frame
   
}
