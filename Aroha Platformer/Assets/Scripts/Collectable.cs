using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField] private float magnitude;
    [SerializeField] private float frequency;

    private float yOffset;

    private void Awake()
    {
        yOffset = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, yOffset + magnitude * Mathf.Sin(Time.time * frequency));
    }

}
