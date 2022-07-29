using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Character
{
    [SerializeField]
    private List<Transform> transformsPatrol;
    
    private float westPatrol;
    private float eastPatrol;
    private float vertex = 1f; 

    public override void Setup()
    {
        base.Setup();

        if (transformsPatrol.Count >= 2)
        {
            SetupPatrols();
        }
    }

    public override void MyUpdate()
    {
        MoveEnemy();
        base.MyUpdate();
    }

    public override void GetPunch()
    {
        base.GetPunch();
    }

    private void MoveEnemy()
    {
        float transformX = transform.position.x;
        
        if (transformsPatrol.Count < 2)
        {
            return;
        }

        if (eastPatrol <= transformX)
        {
            vertex = -1f;
        }
        
        if (westPatrol >= transformX)
        {
            vertex = 1f;
        }

        Move(vertex, speed);
    }

    private void SetupPatrols()
    {
        if (GetPatrolPosX(0) > GetPatrolPosX(1))
        {
            eastPatrol = GetPatrolPosX(0);
            westPatrol = GetPatrolPosX(1);
            return;
        }
        eastPatrol = GetPatrolPosX(1);
        westPatrol = GetPatrolPosX(0);
    }

    private float GetPatrolPosX(int index)
    {
        if (transformsPatrol.Count <= index)
        {
            Debug.LogError("You can't check " + index + "if list length is " + transformsPatrol.Count);
            return 0f;
        }

        return transformsPatrol[index].position.x;
    }
}
