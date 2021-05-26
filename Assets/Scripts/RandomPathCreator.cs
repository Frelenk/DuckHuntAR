
using System;
using PathCreation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomPathCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> regularPositions;
    [SerializeField] private List<Transform> startPositions;
    [SerializeField] private int minPositions;
    [SerializeField] private int maxPositions;
    [SerializeField] private PathCreator _pathCreator;

    private List<Transform> tempRegularPositions;

    

    private void OnEnable()
    {
        tempRegularPositions = new List<Transform>();
        CreateRandomPath();
    }

    public void CreateRandomPath()
    {
        tempRegularPositions = regularPositions.ToList();
        int positionsAmmount = Random.Range(minPositions, maxPositions);
        

        List<Transform> tempList = new List<Transform>();

        tempList.Add(startPositions[Random.Range(0, startPositions.Count - 1)]);

        int tempIndex = 0;
        
        for (int i = 0; i < positionsAmmount; i++)
        {
            tempIndex = Random.Range(0, tempRegularPositions.Count - 1);
            tempList.Add(tempRegularPositions[tempIndex]);
            tempRegularPositions.RemoveAt(tempIndex);
        }

        BezierPath bezierPath = new BezierPath(tempList, true, PathSpace.xyz);
        bezierPath.GlobalNormalsAngle = 270f;
        bezierPath.ControlPointMode = BezierPath.ControlMode.Free;
        
        _pathCreator.bezierPath = bezierPath;
        
    }

}
