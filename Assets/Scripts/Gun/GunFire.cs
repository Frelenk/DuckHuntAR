using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InstantieateParticles))]
[RequireComponent(typeof(Animator))]
public class GunFire : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform arCamera;
    [SerializeField] private float bulletSpeed;
    [SerializeField] Transform bulletStartPosition;
    [SerializeField] Bullet [] bulletsList;
    [SerializeField] private AnimationClip reloadAnimation;

    private float _reloadTime;
    
    public Action<float> GunReloadingAction;
    public Action GunFireAction;

    private InstantieateParticles _instantiateParticles;
    private Animator _animator;
    
    private bool _isReloading, _isFiring;
    private int _currentRoundsAmmount;
    
    private static readonly int IsFire = Animator.StringToHash("IsFire");
    private static readonly int IsReload = Animator.StringToHash("IsReload");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _instantiateParticles = GetComponent<InstantieateParticles>();
    }
    void Start()
    {
        GunFireAction += GunShoot;
        GunReloadingAction += ReloadGun;
        
        _reloadTime = reloadAnimation.length;

        _currentRoundsAmmount = bulletsList.Length;

        _isReloading = false;
        _isFiring = false;
       
    }

    public void Fire()
    {
        if (!_isFiring && !_isReloading && _currentRoundsAmmount > 0)
        {
            GunFireAction?.Invoke();
            _currentRoundsAmmount--;
            _instantiateParticles.Instantiate();//instantiate smoke particles
        }
    }
    // Update is called once per frame
    void Update()
    {
        //invoking actions on FireAction (it`s method GunShoot). Instantiating smoke particles
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isFiring && !_isReloading && _currentRoundsAmmount > 0)
            {
                GunFireAction?.Invoke();
                _currentRoundsAmmount--;
                _instantiateParticles.Instantiate();//instantiate smoke particles
            }
        }
    }

    public void EndFireAnimationEvent()//shows when animation end. When bullets == 0, fire action GunRealoading. Event calls from animation
    {
      
        //Makes animation going to reload. If bullets == 0, invoking actions on ReloadingAction (it`s method GunShoot, and will be method connected with UI)
        if (_currentRoundsAmmount == 0)
            GunReloadingAction?.Invoke(_reloadTime);
        
        // makes animation going to idle, if not reloading
        _isFiring = false;
        _animator.SetBool(IsFire, false);
    
    }
    
    private void GunShoot()
    {
        
        bulletsList[_currentRoundsAmmount - 1].Setup(bulletStartPosition.position,
            bulletSpeed, arCamera);
        
        _isFiring = true;
        _animator.SetBool(IsFire, true);
    }
    

    private void ReloadGun(float reloadTime)
    {
        _animator.SetBool(IsReload, true);
        _currentRoundsAmmount = bulletsList.Length;
        _isReloading = true;

        StartCoroutine(StopReloadAnimationCoroutine(reloadTime));
    }

    private IEnumerator StopReloadAnimationCoroutine(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime - .05f);
        
        _animator.SetBool(IsReload, false);
        _isReloading = false;
    }

  
    
}
