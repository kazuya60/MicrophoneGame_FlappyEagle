using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPositionRepeat : MonoBehaviour
{
    public GameObject position_1;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadToTheGame",5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Position2"))
        {
            transform.position = position_1.transform.position;
        }
    }

    void LoadToTheGame()
    {
        SceneManager.LoadScene(3);
    }
}
