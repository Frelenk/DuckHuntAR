using UnityEngine;
using UnityEngine.Events;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private GunFire gun;
    [SerializeField] private UnityEvent<float>  gunReload;
    [SerializeField] private UnityEvent gunFire;

    [SerializeField] private AudioSource gunShotAudio;
    // Start is called before the first frame update

    private void Awake()
    {
        gun.GunFireAction += GunShooted;
        gun.GunReloadingAction += GunReloading;
    }

    // Update is called once per frame
    private void GunShooted()
    {
        gunShotAudio.Play();
        gunFire?.Invoke();
    }

    private void GunReloading(float reloadTime)
    {
        gunReload?.Invoke(reloadTime);
    }
}
