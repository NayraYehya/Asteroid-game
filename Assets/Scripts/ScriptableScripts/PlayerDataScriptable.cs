using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Player Data")]
public class PlayerDataScriptable : ScriptableObject
{
    [SerializeField] private int maxHealth = 4;
    [SerializeField] private int initialHealth = 3;
    [HideInInspector] public int currentHealth;
    [SerializeField] private int speed = 5;

    public int MaxHealth => maxHealth;
    public float Speed => speed;
    public int InitialHealth => initialHealth;
}