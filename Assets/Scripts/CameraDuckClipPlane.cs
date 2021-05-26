using UnityEngine;
using Vuforia;

public class CameraDuckClipPlane : MonoBehaviour
{
    [SerializeField] private TrackableBehaviour trackableBehaviour;
    [SerializeField] private Camera arCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform stencilPlane;


    private bool _imageTracked = false;
    // Start is called before the first frame update
    void Start()
    {
         trackableBehaviour.RegisterOnTrackableStatusChanged(OnTrackableStateChanged);
    }

    // Update is called once per frame
    void Update()
    {
        if (_imageTracked)
        {
            mainCamera.farClipPlane = Vector3.Distance(stencilPlane.transform.position, mainCamera.transform.position);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.StatusChangeResult obj)
    {
        if (obj.NewStatus == TrackableBehaviour.Status.TRACKED)
        {
            _imageTracked = true;
            mainCamera.fieldOfView = arCamera.fieldOfView;
        }
    }
}
