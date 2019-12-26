using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalObserver : MonoBehaviour
{
    IDictionary<string, GameObject> animals;
    public GameObject[] prefabs;
    private MultiListener listener;

    void Start()
    {
        animals = new Dictionary<string, GameObject>();
        listener = GameObject.FindGameObjectWithTag(MultiListener.respawnTag).GetComponent<MultiListener>();
    }

    public void createNewAnimal(PlayerDefaultDto dto)
    {
        Vector3 pos = dto.positionToVector3();
        Quaternion rot = dto.rotationToQuaternion();
        if (pos.x == 0 && pos.y == 0)
        {
            pos = new Vector3(transform.position.x - Random.Range(1, 10), transform.position.y - Random.Range(1, 15), -20);
            rot = transform.rotation;
        } 

        string newId = System.Guid.NewGuid().ToString();
        GameObject newAnimal = Instantiate(prefabs[0], pos, rot);
        AnimalStatus status = newAnimal.GetComponent<AnimalStatus>();
        status.Id = newId;
        animals.Add(newId, newAnimal);
    }

    public void moveAnimal(PlayerDefaultDto dto)
    {
        GameObject gameObject = animals[dto.Id];
        gameObject.transform.position = dto.positionToVector3();
        gameObject.transform.rotation = dto.rotationToQuaternion();
    }

    public void destroyAnimal(PlayerDefaultDto dto)
    {
        GameObject gameObject = animals[dto.Id];
        Destroy(gameObject);
    }

    public void sendAnimalDataToServer(string id, Vector3 pos, Quaternion rot, ClientAction actionType, Action action)
    {
        Vector3 movePos = new Vector3(transform.position.x, transform.position.y, -20);
        listener.handleAnimalAction(id, movePos, rot, actionType, action);
    }
}
