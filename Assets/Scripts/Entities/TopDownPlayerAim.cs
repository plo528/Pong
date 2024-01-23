using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerAim : MonoBehaviour
{

    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownCharacterController _controller;

    void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

}
