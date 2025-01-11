using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Player"))
      {
        Debug.Log("Enemy Here");
        GameManager.instance.player.TakeDamage(1);
        Destroy(gameObject);
      }  
    }
}
