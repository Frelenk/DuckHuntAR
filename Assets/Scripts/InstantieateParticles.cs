using System.Collections;
using UnityEngine;

public class InstantieateParticles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float secondsToContinue;
    [SerializeField] Transform instantiatePosition;
    [SerializeField] GameObject particle;
    

    // Update is called once per frame
    public void Instantiate()
    {
        StartCoroutine(SpawnFireParticle());
    }

    IEnumerator SpawnFireParticle()
    {
        Destroy(Instantiate(particle, instantiatePosition.position, instantiatePosition.rotation),secondsToContinue);
        yield return new WaitForSeconds(secondsToContinue);
        

    }
}
