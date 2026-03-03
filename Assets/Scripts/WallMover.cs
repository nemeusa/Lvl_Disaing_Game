using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    [Header("Destino")]
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float moveDuration = 1f;

    private Vector3 startPosition;
    private bool hasMoved = false;

    private void Start()
    {
        startPosition = transform.position;

        if (targetPoint == null)
        {
            Debug.LogError("WallMover necesita un Transform destino asignado.");
            enabled = false;
        }
    }

    private void OnEnable()
    {
        Flicker.OnFlickerClicked += MoveWall;
    }

    private void OnDisable()
    {
        Flicker.OnFlickerClicked -= MoveWall;
    }

    private void MoveWall()
    {
        if (!hasMoved)
        {
            StartCoroutine(MoveRoutine());
            hasMoved = true;
        }
    }

    IEnumerator MoveRoutine()
    {
        Vector3 initialPos = transform.position;
        Vector3 targetPos = targetPoint.position;

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;

            transform.position = Vector3.Lerp(initialPos, targetPos, t);
            yield return null;
        }

        transform.position = targetPos;
    }
}
