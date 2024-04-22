using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 50f;

    public SoundManager sound_manager;

    public AudioClip clip_room1;
    public AudioClip succes;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0,verticalInput);
        movementDirection.Normalize();

        transform.position = transform.position + movementDirection * speed * Time.deltaTime;
        if (movementDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movementDirection),rotationSpeed * Time.deltaTime );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room1"))
        {
            sound_manager.ChangeMusic(clip_room1);
            sound_manager.ChangeSFX(succes);
        }
    }
}

