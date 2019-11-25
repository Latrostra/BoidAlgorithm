using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : Behaviour
{
    public override Vector2 CalculateVelocity(BoidAgent boid)
    {
        Vector2 cohesionMove = Vector2.zero;

        if (boid.Neighbours.Count == 0)
        {
            return boid.transform.up;
        }

        foreach (BoidAgent neighbourBoid in boid.Neighbours)
        {
            cohesionMove += (Vector2)neighbourBoid.transform.position;
        }
        
        if (boid.Neighbours.Count > 0)
        {
            cohesionMove /= boid.Neighbours.Count;
            cohesionMove -= (Vector2)boid.transform.position;
        }

        return cohesionMove;
    }
}
