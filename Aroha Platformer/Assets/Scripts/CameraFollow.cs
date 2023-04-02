using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset =1f;
    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
