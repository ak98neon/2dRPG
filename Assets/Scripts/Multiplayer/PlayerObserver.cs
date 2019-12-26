using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    private MultiListener listener;
    private Vector3 oldCoordinats;

    // Use this for initialization
    void Start()
    {
        listener = GameObject.FindGameObjectWithTag(MultiListener.respawnTag).GetComponent<MultiListener>();
        oldCoordinats = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldCoordinats != transform.position)
        {
            oldCoordinats = transform.position;
            Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, -20);
            listener.handleEvent(currentPos, transform.rotation, ClientAction.PLAYER, Action.PLAYER_MOVE);
        }
    }
}
