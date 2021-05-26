using System.Collections;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] private Rigidbody bulletRigidbody;
    public Action<Vector3, string> onBulletCollisionAction;
    private float _bulletSpeed;
    private Coroutine _deactivateBullet;
    private Vector3 _startPoint= Vector3.zero;
    private bool _bulletColided;
    private Quaternion _savedCameraRotation;
    private bool _gameObjectActive = false;

    private void Update()
    {
        if (_gameObjectActive)
        {
            BulletMove();
        }
    }
   
    public void Setup(Vector3 startPoint, float bulletSpeed, Transform cameraTransform)
    {
        gameObject.SetActive(true);
        _gameObjectActive = true;
        _bulletColided = false;
        
        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.angularDrag = 0;
        bulletRigidbody.angularVelocity = Vector3.zero;

        _savedCameraRotation = cameraTransform.rotation;
        
        _bulletSpeed = bulletSpeed;
        
        _startPoint = startPoint;
        
        transform.rotation = cameraTransform.rotation;
        transform.position = startPoint;
        
        _deactivateBullet = StartCoroutine(DeactivateBullet(5f));
    }
    
    private void BulletMove()
    {
        bulletRigidbody.velocity = transform.forward * _bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_bulletColided)
        {
            GameObject tempGameObject = other.gameObject;

            if (tempGameObject.CompareTag("Joint"))
            {
                _bulletColided = true;
                _gameObjectActive = false;
                gameObject.SetActive(false);
                StopCoroutine(_deactivateBullet);
                return;
            }
            else if (tempGameObject.CompareTag("Target"))
            {
                _bulletColided = true;
                _gameObjectActive = false;
                gameObject.SetActive(false);
                StopCoroutine(_deactivateBullet);
                return;
            }
            
            transform.rotation = _savedCameraRotation;
            Ray ray = new Ray(_startPoint, transform.forward);
            
            if (Physics.Raycast(ray))
            {
                Debug.Log(tempGameObject.name);
                tempGameObject.GetComponent<DuckCollision>().DuckShooted();
                _bulletColided = true;
                _gameObjectActive = false;
                gameObject.SetActive(false);
                onBulletCollisionAction?.Invoke(tempGameObject.transform.position, tempGameObject.tag);
                StopCoroutine(_deactivateBullet);
            }
        }
    }
    

    private IEnumerator DeactivateBullet(float time)
    {       
        yield return new WaitForSeconds(time);
        _gameObjectActive = false;
        gameObject.SetActive(false);
    }
}
 
