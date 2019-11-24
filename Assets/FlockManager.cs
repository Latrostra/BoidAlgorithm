using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    [SerializeField] private GameObject boidPrefab;
    private List<GameObject> _boids;

    public void Start()
    {
        _boids = new List<GameObject>();
        InstantiateBoids();
    }
    public void InstantiateBoids()
    {   
        for(int i = 0; i < 100; i++)
        {
            var _boid = Instantiate(
                boidPrefab, 
                Random.insideUnitCircle * 5, 
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), 
                transform);

            var _boidAgent = _boid.GetComponent<BoidAgent>();
            _boidAgent.Initialize("Boid: " + (i + 1));
            _boidAgent.SetVelocity(transform.right);
            _boids.Add(_boid);
        }
    }
}
