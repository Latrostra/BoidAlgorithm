using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : Behaviour
{
    public override Vector2 CalculateVelocity(BoidAgent boid)
    {
        Vector2 alignmentMove = Vector2.zero;

        if (boid.Neighbours.Count == 0)
        {
            return boid.transform.up;
        }

        foreach (BoidAgent neighbourBoid in boid.Neighbours)
        {
            alignmentMove += neighbourBoid.GetComponent<Rigidbody2D>().velocity;
        }
        
        if (boid.Neighbours.Count > 0)
        {
            alignmentMove /= boid.Neighbours.Count;
            alignmentMove -= boid.GetComponent<Rigidbody2D>().velocity;
        }

        return alignmentMove;
    }
}
