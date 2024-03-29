﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Separation")]
public class SeparationBehaviour : Behaviour
{
    [SerializeField] private float _separationRange = 1f;

    public override Vector2 CalculateVelocity(BoidAgent boid)
    {
        Vector2 separationMove = Vector2.zero;

        if (boid.Neighbours.Count == 0)
        {
            return boid.transform.up;
        }

        foreach (BoidAgent neighbourBoid in boid.Neighbours)
        {
            if (Mathf.Abs(Vector2.Distance(boid.transform.position, neighbourBoid.transform.position)) < _separationRange)
            {
                separationMove += (Vector2)(boid.transform.position - neighbourBoid.transform.position);
            }
        }
        return separationMove;
    }
}
