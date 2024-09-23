using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] LayerMask ballLayerMask;

    private float destroyTime;
    private float totalTime;

    private void Update()
    {
        totalTime += Time.deltaTime;
        if (totalTime > destroyTime)
        {
            TurnOff();
        }
    }

    public void TurnOn(Vector3 newPosition)
    {
        totalTime = 0;
        destroyTime = Random.Range(3f, 7f);
        gameObject.SetActive(true);
        transform.position = newPosition;
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Utilites.CheckLayerInMask(ballLayerMask, other.gameObject.layer))
        {
            TurnOff();
        }
    }
}
