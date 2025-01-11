using UnityEngine;
using TMPro;
using System.Collections;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        healthText.text = $"Health: {GameManager.instance.playerHealth}";
        
    }

    void OnEnable()
    {
        
        StartCoroutine(WaitForGameManager());        
    }

    private IEnumerator WaitForGameManager()
    {
        while(GameManager.instance == null)
        {
            yield return null;
        }

        if (GameManager.instance != null)
        {
            GameManager.instance.player.OnHealthChanged += UpdateHealthUI;
        }
    }

    void OnDisable()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.player != null)
            {
                GameManager.instance.player.OnHealthChanged -= UpdateHealthUI;
            }

            else Debug.Log("Player is null");
        }

        else Debug.Log("GameManager is null");
    }

    

    // Update is called once per frame
    private void UpdateHealthUI(int health)
    {
        healthText.text = $"Health: {health}";
    }
}
