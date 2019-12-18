using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector3 target;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position == target)
            {
                isMoving = false;
            }
        }
    }
}
