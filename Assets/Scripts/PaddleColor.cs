using UnityEngine;

public class PaddleColor : MonoBehaviour
{
    [Header("Color")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private KeyCode randomColor = KeyCode.R;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
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

    public void SetColor(float newColor)
    {
        spriteRenderer.color = Color.HSVToRGB(newColor, 1, 1);
    }

    public Color GetColor()
    {
        return spriteRenderer.color;
    }
}
