using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<health>();
    }

    public void Respawn()
    {
       
        transform.position = currentCheckpoint.position; //Move player to checkpoint location
        playerHealth.Respawn(); //Restore player health and reset animation

        //Move the camera to the checkpoint's room
        Camera.main.GetComponent<cameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            currentCheckpoint = collision.transform;
            soundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}