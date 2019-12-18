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
            listener.handleEvent(transform.position, transform.rotation, ClientAction.MOVE);
        }
    }
}
