using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            soundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
