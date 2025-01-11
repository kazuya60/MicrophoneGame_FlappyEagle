using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.player.IsDead())
        {
        transform.Translate(new Vector3(-1 * speed,0,0) * Time.deltaTime);
        }
        
    }
}
