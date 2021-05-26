
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartEndGame : MonoBehaviour
{
    
    [SerializeField] private List<TweenMoveObject> moveGates;
    [SerializeField] private TweenRotateObject rotateGate;
    [SerializeField] private Target startTarget;
    [SerializeField] private UnityEvent onGameStart;
    [SerializeField] private UnityEvent onGameEnd;
    // Start is called before the first frame update

    private void Awake()
    {
        startTarget.onTargetCollision += OnGameStart;
        startTarget.onTargetCollision += StartGame;
        
    }
    //
    // Update is called once per frame
    public void StartGame()
    {
        startTarget.ActiveMovement(false);
        
        foreach (var item in moveGates)
        {
            item.MoveObject(false);
        }
        
        rotateGate.RotateObject(false);
    }
    
    public void EndGame()
    {
        startTarget.ActiveMovement(true);
        
        foreach (var item in moveGates)
        {
            item.MoveObject(true);
        }
        
        rotateGate.RotateObject(true);
    }

    private void OnGameEnd()
    {
        
        onGameEnd?.Invoke();
    }

    private void OnGameStart()
    {
        onGameStart?.Invoke();
    }

    public void ActivateEndGame()
    {
        EndGame();
        OnGameEnd();
    }
}
