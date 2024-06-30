using System.Collections;
using UnityEngine;

public class PowerUPs : MonoBehaviour
{
    [SerializeField] private GameObject PowerPrefab;
    private GameObject power;

    private void Start()
    {
        StartCoroutine(SpwanPower());
    }

    public IEnumerator SpwanPower()
    {
        yield return new WaitForSeconds(10);
        float randomX = Random.Range(0, Screen.width);
        Vector3 randomScreenPosition = new Vector3(randomX, Screen.height, 10);
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(randomScreenPosition);
        power = Instantiate(PowerPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(SpwanPower());
    }
    
}
