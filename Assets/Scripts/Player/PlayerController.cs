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
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, -20);
            transform.position = Vector3.MoveTowards(pos, target, speed * Time.deltaTime);
            if (transform.position == target)
            {
                isMoving = false;
            }
        }
    }
}
