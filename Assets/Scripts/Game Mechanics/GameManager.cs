using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptable playerD;
    [SerializeField] private Score PScore;
    void Start()
    {
        PScore.Value = PScore.OriginalValue;
        playerD.currentHealth = playerD.InitialHealth;
    }
}
