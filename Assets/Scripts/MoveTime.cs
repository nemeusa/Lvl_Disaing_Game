using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTime : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 3f;

    private bool goingToB = true;
    private bool isMoving = false;
    private Vector3 targetPosition;

    private void Start()
    {
        transform.position = pointA.position;
        targetPosition = pointB.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    private void OnMouseDown()
    {
            goingToB = !goingToB;
            targetPosition = goingToB ? pointB.position : pointA.position;
            isMoving = true;
    }
}
