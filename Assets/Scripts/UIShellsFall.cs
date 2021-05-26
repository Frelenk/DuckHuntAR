using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShellsFall : MonoBehaviour
{
    
    [SerializeField] private Rigidbody [] shells;
    [SerializeField] private float secondsToStopShellFall;

    private int _fallShellsCount = 0;

    private List<Bounds> _shellsBounds;
    private List<Vector3> _startShellsPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startShellsPosition = new List<Vector3>();
        _shellsBounds = new List<Bounds>();

        foreach (var item in shells)
        {
            _startShellsPosition.Add(item.position);
            _shellsBounds.Add(item.GetComponent<MeshCollider>().bounds);
        }
        
    }

    // Update is called once per frame
    

    public void Reload(float reloadTime)
    {
        _fallShellsCount = 0;
        StartCoroutine(ReloadCoroutine(reloadTime));
    }
    
    public void FallShell()
    {
        float yOffset = Random.Range(-_shellsBounds[_fallShellsCount].extents.y, _shellsBounds[_fallShellsCount].extents.y);
        float xOffset = Random.Range(-_shellsBounds[_fallShellsCount].extents.x, _shellsBounds[_fallShellsCount].extents.x);
        float zOffset = Random.Range(0f, _shellsBounds[_fallShellsCount].extents.z);
        // float yOffset = Random.Range(-_shellsBounds[_fallShellsCount].extents.y, _shellsBounds[_fallShellsCount].extents.y);
        // float xOffset = Random.Range(-_shellsBounds[_fallShellsCount].extents.x, _shellsBounds[_fallShellsCount].extents.x);
        // float zOffset = Random.Range(0f, _shellsBounds[_fallShellsCount].extents.z);

        Vector3 hitPosition = _shellsBounds[_fallShellsCount].center + new Vector3(xOffset, yOffset, 0f);

        Vector3 hitForce = new Vector3( Random.Range(0, 150f),Random.Range(-50f,50f),100f);//Random.Range(0, 150f), Random.Range(-50f,50f), Random.Range(-150f, 150f)

        shells[_fallShellsCount].useGravity = true;
        shells[_fallShellsCount].isKinematic = false;

        shells[_fallShellsCount].AddForceAtPosition(hitForce, hitPosition);

        StartCoroutine(StopShellFromFalling(shells[_fallShellsCount]));
        
        _fallShellsCount++;
        
    }

    private IEnumerator StopShellFromFalling(Rigidbody rigidbody)
    {
        yield return new WaitForSeconds(secondsToStopShellFall);
        rigidbody.useGravity = false;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    private IEnumerator ReloadCoroutine(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        
        for (int i = 0; i < shells.Length; i++)
        {
            shells[i].isKinematic = true;
            shells[i].useGravity = false;
            shells[i].velocity = Vector3.zero;
            shells[i].angularVelocity = Vector3.zero;
            shells[i].transform.localPosition = Vector3.zero;
            shells[i].transform.localRotation = Quaternion.identity;
            shells[i].transform.eulerAngles = new Vector3(90f, 0f, 0f);
        }
    }
}
