using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private float xVelocity;
    [SerializeField]
    private float yVelocity;

    Material material;
    Vector2 offset;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    private void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }
    private void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
