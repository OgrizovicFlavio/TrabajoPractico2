using UnityEngine;

public class PaddleSize : MonoBehaviour
{
    [Header("Height")]
    [SerializeField] private Transform paddleTransform;
    [SerializeField] private float sizeX = 3.0f;

    private void Awake()
    {
        paddleTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        ChangeHeight();
    }

    private void ChangeHeight()
    {
        paddleTransform.localScale = new Vector3(sizeX, paddleTransform.localScale.y, paddleTransform.localScale.z);
    }

    public void SetSizeX(float newSizeX)
    {
        sizeX = newSizeX;
    }

    public float GetSizeX()
    {
        return sizeX;
    }

}
