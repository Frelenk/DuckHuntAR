
using UnityEngine;

public class TweenMoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool moveOnEnable;
    [SerializeField] Vector3 distanceToMove;
    [SerializeField] float time;
    [SerializeField] float delay;
    [SerializeField] LeanTweenType easyType;
    private void OnEnable()
    {
        if (moveOnEnable)
        {
            MoveObject(false);
        }
    }

    public void MoveObject(bool reverseRotate)
    {
        int valueForReverse = 1;
        if (reverseRotate)
            valueForReverse = -1;

        
        LeanTween.moveLocal(gameObject, transform.localPosition + (distanceToMove*valueForReverse), time)
            .setDelay(delay);
        // LeanTween.moveLocal(gameObject, transform.position + (distanceToMove * valueForReverse), time)
        //     .setDelay(delay)
        //     .setEase(easyType);
    }
}
