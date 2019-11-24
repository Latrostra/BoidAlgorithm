using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCircleSearch : MonoBehaviour, ISearchArea
{
    [SerializeField] private float _radius = 1f;
    public List<BoidAgent> GetNeighbours()
    {
        var _colNeighbours = Physics2D.OverlapCircleAll(this.transform.position, _radius);
        var _neighbours = new List<BoidAgent>();
        foreach (Collider2D col in _colNeighbours)
        {
            if (col != GetComponent<CircleCollider2D>())
            {
                _neighbours.Add(col.GetComponent<BoidAgent>());
            }
        }
        return _neighbours;
    }
}
