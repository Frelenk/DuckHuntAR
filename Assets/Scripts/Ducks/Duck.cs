
using System.Collections;
using PathCreation.Examples;
using UnityEngine;

public class Duck : MonoBehaviour
{
    [SerializeField] [Range(0f, .1f)] private float fallDownTimeOffset;
    [SerializeField] private float distanceToFallDown;
    [SerializeField] private float timeToFallDown;
    [SerializeField] private RandomPathCreator randomPathCreator;
    private Animator _animator;
    private PathFollower _pathFollower;

    private static readonly int DeathBlend = Animator.StringToHash("DeathBlend");

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _pathFollower = GetComponent<PathFollower>();
    }
    

    public void DuckShooted(float timeToRespawn, float timeToPlayDeathAnimation)
    {
        _pathFollower.enabled = false;
        StartCoroutine(PlayDeathAnimationCoroutine(timeToPlayDeathAnimation));
        StartCoroutine(RespawnCoroutine(timeToRespawn));
    }

    private void FallDuck()
    {
        LeanTween.cancel(gameObject);
        LeanTween.moveY(gameObject, distanceToFallDown, timeToFallDown).setEase(LeanTweenType.easeInOutSine);
        
    }
    
    private IEnumerator RespawnCoroutine(float timeToRespawn)
    {
       
        randomPathCreator.CreateRandomPath();
        yield return  new WaitForSeconds(timeToRespawn);
        _animator.SetFloat(DeathBlend,0f);
        _pathFollower.enabled = true;
    }

    private IEnumerator PlayDeathAnimationCoroutine(float timeToPlayDeathAnimation)
    {
        FallDuck();
        
        yield return new WaitForSeconds(fallDownTimeOffset);
        
        float multiplier = (float) .8f / timeToPlayDeathAnimation;
        
        float time = 0;
        
        while (time <= timeToPlayDeathAnimation)
        {
            _animator.SetFloat(DeathBlend, time*multiplier);
            time += Time.deltaTime;
            
            yield return null;   
           
        }
        
        
        
    }

    
}
