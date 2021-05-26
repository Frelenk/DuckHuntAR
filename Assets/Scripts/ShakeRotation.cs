using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeRotation : MonoBehaviour
{
    [SerializeField] Vector3 rotationAxis;
    [SerializeField] float turnDegree;
    [SerializeField] float periodRotationTime;
    [SerializeField] float overallRotationTime;
    [SerializeField] float tweenDelay;
    private void OnEnable()
    {
        LTDescr rotateAnimation = LeanTween.rotateAroundLocal(gameObject, rotationAxis, turnDegree, periodRotationTime)
          .setEaseShake()
          .setRepeat(-1)
          ;

        LeanTween.value(gameObject, turnDegree, 0f, overallRotationTime).setDelay(tweenDelay).setOnUpdate(
                (float value) => {
                    rotateAnimation.setTo(Vector3.right * value);
                }
            ).setEase(LeanTweenType.easeOutQuad);
    }
    // Start is called before the first frame update
   

}
