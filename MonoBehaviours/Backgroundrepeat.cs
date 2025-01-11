using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundrepeat : MonoBehaviour
{
    private Vector3 startingPosition;
    private float repeatDistance;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        repeatDistance = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startingPosition.x -repeatDistance)
        {
            transform.position = startingPosition;
        }
    }
}
