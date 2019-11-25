using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAgent : MonoBehaviour
{
    public List<BoidAgent> Neighbours { get; private set; }

    private Vector3 _velocity;
    private ISearchArea searchArea;
    private Rigidbody2D rb2D;
 
    public void Awake()
    {
        searchArea = GetComponent<ISearchArea>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        Neighbours = new List<BoidAgent>();
    }

    public void Update()
    {
        Neighbours = searchArea.GetNeighbours();
        rb2D.velocity = _velocity;
        Rotate();
    }
    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }
    public void Initialize(string _name)
    {
        name = _name;
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}
