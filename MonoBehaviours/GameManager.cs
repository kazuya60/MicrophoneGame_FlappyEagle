using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerHealth = 5;
    public Player player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (instance != this) Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = new(playerHealth);
    }

    public void ResetPlayer()
    {
        player.ResetHealth();
    }

    
}
