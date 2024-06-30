using TMPro;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioAst;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Score score;
    private void Update()
    {
        transform.Translate(new Vector2(0,2) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("asteroid"))
        {
            audioAst.Play("cannon_01");
            Destroy(other.gameObject);

            ScoreText.text = $"Score: {score.Value++}";
        }
        if(!other.CompareTag("Player"))
            Destroy(gameObject);
    }

}
