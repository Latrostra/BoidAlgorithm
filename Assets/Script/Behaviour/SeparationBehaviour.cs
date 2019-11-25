using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Separation")]
public class SeparationBehaviour : Behaviour
{
    [SerializeField] private float _separationRange = 1f;

    public override Vector2 CalculateVelocity(BoidAgent boid)
    {
        Vector2 separationMove = Vector2.zero;
        int nVoid = 0;

        if (boid.Neighbours.Count == 0)
        {
            return boid.transform.up;
        }

        foreach (BoidAgent neighbourBoid in boid.Neighbours)
        {
            if (Vector2.Distance(boid.transform.position, neighbourBoid.transform.position) < _separationRange)
            {
                separationMove += (Vector2)(boid.transform.position - neighbourBoid.transform.position);
                nVoid++;
            }

            if (nVoid > 0)
            {
                separationMove /= nVoid;
            }
        }
        return separationMove;
    }
}
