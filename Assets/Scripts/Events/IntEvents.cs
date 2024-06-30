using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/IntEvent")]
public class IntEvents : ScriptableObject
{
    public UnityAction<int> OnPlayerHealthChanged;
}
