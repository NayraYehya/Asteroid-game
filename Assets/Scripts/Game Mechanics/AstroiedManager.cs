using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class AstroiedManager : MonoBehaviour
{
    [SerializeField] private AsteroidData asteroidData;
    public GameObject[] enemyPrefab;
    public AsteroidData AsteroidData { get => asteroidData; set => asteroidData = value; }

    private void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
