using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class DucksHandler : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> ducksPathCreator;
    [SerializeField] private List<GameObject> ducks;
    [SerializeField] private List<DuckCollision> duckCollisions;
    [SerializeField] private UIHandler uiHandler;
    [SerializeField] private int minShotedDuck;
    [SerializeField] private int maxShotedDuck;
    [SerializeField] private float minimalTimeDuckRespawn;
    [SerializeField] private float maximalTimeDuckRespawn;
    [SerializeField] private float timeToPlayDeathAnimation;
    [SerializeField] private AudioSource duckSound;
    
    private int activeDuckAmmount;
    // Start is called before the first frame update

    private void Awake()
    {
        activeDuckAmmount = Random.Range(minShotedDuck, maxShotedDuck);
        //uiHandler.InitializeDucksAmmount(activeDuckAmmount);
        foreach (var item in duckCollisions)
        { 
            item.duckShooted += HandleShootedDuck;
        }
    }

    public void HandleShootedDuck(Duck duckInfo)
    {
        duckSound.pitch = Random.Range(.9f, 1f);
        duckSound.Play();
        uiHandler.AddShotedDuck();
        duckInfo.DuckShooted(Random.Range(minimalTimeDuckRespawn, maximalTimeDuckRespawn), timeToPlayDeathAnimation);
    }

    public void ActivateDucks()
    {
        activeDuckAmmount = Random.Range(minShotedDuck, maxShotedDuck);
        uiHandler.InitializeDucksAmmount(activeDuckAmmount);
        
        for (int i = 0; i < activeDuckAmmount; i++)
        {
            ducks[i].SetActive(true);
            ducksPathCreator[i].SetActive(true);
        }
    }
    
    public void DeactivateDucks()
    {
        for (int i = 0; i < activeDuckAmmount; i++)
        {
            ducks[i].SetActive(false);
            ducksPathCreator[i].SetActive(false);
        }
    }
    
}
