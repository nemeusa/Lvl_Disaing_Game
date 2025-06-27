using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    private Vector3 moveDirection;
    private Transform currentPlatform;
    private PlatformController movingPlatform;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical);
        //controller.Move(moveDirection * speed * Time.deltaTime);

        // Si está sobre una plataforma, muévelo con ella
        if (movingPlatform != null)
        {
            controller.Move(movingPlatform.GetPlatformDelta());
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Detectar si el jugador está pisando una plataforma movible
        if (hit.collider.CompareTag("Platform") && Vector3.Dot(hit.normal, Vector3.up) > 0.5f)
        {
            movingPlatform = hit.collider.GetComponent<PlatformController>();
        }
        else
        {
            movingPlatform = null;
        }
    }
}
