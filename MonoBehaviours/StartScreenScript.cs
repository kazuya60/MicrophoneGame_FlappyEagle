using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    public Animator animator;
    public float time = 1;
    public GameObject panel;
   
    public void StartTheGame()
    {
        panel.SetActive(false);
        animator.SetBool("Leave",true);
        Invoke("WaitAmin",2f);
        
        
    }

    void Start()
    {
        Time.timeScale = time;
        
    }

    private void WaitAmin()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited the game");
    }


}
