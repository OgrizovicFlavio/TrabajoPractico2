using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [Header("Change Color")]
    [SerializeField] private KeyCode randomColor = KeyCode.R;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        RandomColor();
    }

    private void RandomColor()
    {
        if (Input.GetKeyUp(randomColor))
        {
            float red = Random.Range(0, 1.0f);
            float green = Random.Range(0, 1.0f);
            float blue = Random.Range(0, 1.0f);
            float alpha = Random.Range(0, 1.0f);

            spriteRenderer.color = new Color(red, green, blue, alpha);
        }
    }
}
