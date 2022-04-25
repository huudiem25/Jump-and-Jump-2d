using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private Transform previousRooom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private cameraController cam;

    private void Awake()
    {
        cam = Camera.main.GetComponent<cameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
                nextRoom.GetComponent<Room>().ActivateRoom(true);
                previousRooom.GetComponent<Room>().ActivateRoom(false);
            }
                
            else
            {
                cam.MoveToNewRoom(previousRooom);
                previousRooom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }
                
        }
    }
}