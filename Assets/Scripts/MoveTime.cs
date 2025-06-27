using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTime : MonoBehaviour
{
    [Header("Asigna al menos 2 puntos")]
    [SerializeField] private PointData[] points;
    [SerializeField] private float moveSpeed = 3f;

    private Coroutine moveCoroutine;
    private int currentIndex = 0;
    private Renderer _renderer;

    private void Start()
    {
        if (points == null || points.Length < 2)
        {
            Debug.LogError(" Debes asignar al menos 2 puntos en el array 'points'");
            enabled = false;
            return;
        }

        transform.position = points[0].point.position;

        _renderer = GetComponent<Renderer>();
        if (_renderer != null)
        {
            _renderer.material.color = points[0].color;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) // clic derecho
        {
            Advance(1);
        }
        else if (Input.GetMouseButtonDown(0)) // clic izquierdo
        {
            Advance(-1);
        }
    }

    private void Advance(int direction)
    {
        currentIndex += direction;

        if (currentIndex >= points.Length)
            currentIndex = points.Length - 1;
        else if (currentIndex < 0)
            currentIndex = 0;

        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        moveCoroutine = StartCoroutine(MoveTo(points[currentIndex].point.position));

        if (_renderer != null)
        {
            _renderer.material.color = points[currentIndex].color;
        }
    }

    private System.Collections.IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
        moveCoroutine = null;
    }
}

[System.Serializable]
public struct PointData
{
    public Transform point;
    public Color color;
}