using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    [SerializeField] private int boidsToSpawn = 10;
    [SerializeField] private int speedBoids = 2;
    [SerializeField] private GameObject boidPrefab;
    [SerializeField] private List<Behaviour> agentBehaviour;
    private List<BoidAgent> _boids;

    public void Start()
    {
        _boids = new List<BoidAgent>();
        InstantiateBoids();
    }

    public void Update()
    {
        foreach (BoidAgent boid in _boids)
        {
            Vector2 move = Vector2.zero;
            foreach (Behaviour behaviour in agentBehaviour)
            {
                move += behaviour.CalculateVelocity(boid); 
            }
            boid.SetVelocity(Vector2.ClampMagnitude(move, speedBoids));
        }
    }
    
    private void InstantiateBoids()
    {   
        for(int i = 0; i < boidsToSpawn; i++)
        {
            var _boid = Instantiate(
                boidPrefab, 
                Random.insideUnitCircle * 5, 
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), 
                transform);

            var _boidAgent = _boid.GetComponent<BoidAgent>();
            _boidAgent.Initialize("Boid: " + (i + 1));
            _boidAgent.SetVelocity(new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
            _boids.Add(_boidAgent);
        }
    }
}
