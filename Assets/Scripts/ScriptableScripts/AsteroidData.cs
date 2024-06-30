using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Asteroid Data")]
public class AsteroidData : ScriptableObject
{
    public float spawnRadius = 10f;
    public float minForce = 1f;
    public float maxForce = 5f;

}
