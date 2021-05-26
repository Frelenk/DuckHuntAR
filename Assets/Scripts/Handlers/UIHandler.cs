using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private StartEndGame _startEndGame;
    [SerializeField] private TextMeshProUGUI shotedDucksAmmountText;
    [SerializeField] private GameObject reloadingText;
    [SerializeField] private RectTransform maskingPanel;

    private int _ducksAmmountToShot;
    private int _shotedDucks;
    // Start is called before the first frame update

    public void InitializeDucksAmmount(int ducksAmmount)
    {
        _ducksAmmountToShot = ducksAmmount;
        _shotedDucks = 0;
        
        shotedDucksAmmountText.text = $"{_shotedDucks}/{_ducksAmmountToShot}";
        shotedDucksAmmountText.enabled = true;
    }

    
    
    public void DeactivateDuckAmmountText()
    {
        shotedDucksAmmountText.enabled = false;
    }
    public void AddShotedDuck()
    {
        _shotedDucks++;

        if (_shotedDucks == _ducksAmmountToShot)
        {
            _startEndGame.ActivateEndGame();
        }
        
        shotedDucksAmmountText.text = $"{_shotedDucks}/{_ducksAmmountToShot}";
    }
    
    public void ShowReloadUI(float reloadTime)
    {
        reloadingText.SetActive(true);
        StartCoroutine(ReloadAnimationCoroutine(reloadTime));
    }
    
    private IEnumerator ReloadAnimationCoroutine(float reloadTime)
    {
        float time = 0;
        float lerpXScale = 0;

        while (time <= reloadTime)
        {
            time += Time.deltaTime;
            lerpXScale = Mathf.Lerp(0f, 1, (float) time / reloadTime);
            maskingPanel.localScale = new Vector3(lerpXScale, 1f, 1f);
            yield return null;
        }

        reloadingText.SetActive(false);
    }

   
}
