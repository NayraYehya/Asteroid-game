using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/VoidEvent")]
public class VoidEvents : ScriptableObject
{
        public UnityAction OnPlayerHealthChanged;
   
}
