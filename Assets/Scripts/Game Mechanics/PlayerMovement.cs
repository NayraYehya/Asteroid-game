using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerDataScriptable playerData;

    [SerializeField] BulletsManager bulletPrefab;

    [SerializeField] Score PlayerScore;

    //[SerializeField] private IntEvents OnPlayerHealthChanging;

    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private Animator animator;

    [SerializeField] private AudioManager audio;
    [SerializeField] private UIManager Uimanage;
    //Movement
    [SerializeField] private PlayerInput playerInput;
    private Rigidbody2D rb;
    private Vector2 movementVect;
    private int life = 3;
    public int Life => life;

    private bool spwaning = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerData.currentHealth = playerData.InitialHealth;
        HealthText.text = $"Health: {playerData.currentHealth}";
    }
    private void Update()
    {
        if (movementVect != Vector2.zero)
        {
            rb.velocity = playerData.Speed * movementVect;
        }
        if(life == 0)
        {
            playerInput.enabled = false;
            Uimanage.GameOverFunc();
        }
        if(playerData.currentHealth == 0)
        {
            animator.SetBool("dead", true);
            spwaning = true;
            RespawnPlayer();
            life--;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("asteroid"))
        {
            if(spwaning == false)
            {
                playerData.currentHealth -= 1;
                HealthText.text = $"Health: {playerData.currentHealth}";
            }
            Debug.Log(playerData.currentHealth);
        }
        if (other.CompareTag("healthPU"))
        {
            if (playerData.currentHealth != playerData.MaxHealth)
            {
                playerData.currentHealth += 1;
                HealthText.text = $"Health: {playerData.currentHealth}";
                StartCoroutine(Uimanage.HealthEarned());
                Debug.Log("Power Up!!");
            }
        }
    }
    private void OnFire()
    {
        Debug.Log("Fire");
        BulletsManager bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        audio.Play("laser_02");
    }
    private void OnMove(InputValue value)
    {
        Vector2 val = value.Get<Vector2>();
        movementVect = new Vector2(val.x, val.y);
    }

    private void RespawnPlayer()
    {
        transform.position = Vector3.zero;
        playerData.currentHealth = playerData.InitialHealth;
        HealthText.text = $"Health: {playerData.InitialHealth}";
        PlayerScore.Value = PlayerScore.OriginalValue;
        StartCoroutine(PlayerSaver());

    }
    private IEnumerator PlayerSaver()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("dead", false);
        spwaning = false;
    }
}
