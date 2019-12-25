using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalObserver : MonoBehaviour
{
    IDictionary<string, GameObject> animals;
    public GameObject[] prefabs;
    [SerializeField]
    private int defaultCountOfAnimals;
    private MultiListener listener;

    void Start()
    {
        animals = new Dictionary<string, GameObject>();
        listener = GameObject.FindGameObjectWithTag(MultiListener.respawnTag).GetComponent<MultiListener>();

        StartCoroutine(createDefaultAnimals());
    }

    IEnumerator createDefaultAnimals()
    {
        for (int i = 0; i < defaultCountOfAnimals; i++)
        {
            createNewAnimal(new Vector3(transform.position.x - Random.Range(2, 5), transform.position.y - Random.Range(2, 5), -20), transform.rotation, prefabs[0]);
            yield return new WaitForSeconds(3);
        }
    }

    public void createNewAnimal(Vector2 startPosition, Quaternion rot, GameObject prefab)
    {
        string newId = System.Guid.NewGuid().ToString();
        GameObject newAnimal = Instantiate(prefab, startPosition, rot);
        AnimalStatus status = newAnimal.GetComponent<AnimalStatus>();
        status.Id = newId;
        animals.Add(newId, newAnimal);
        moveAnimalServer(startPosition, rot, ClientAction.ANIMAL_MOVE);
    }

    public void moveAnimal(PlayerDefaultDto dto)
    {
        GameObject gameObject = animals[dto.Id];
        gameObject.transform.position = dto.positionToVector3();
        gameObject.transform.rotation = dto.rotationToQuaternion();
    }

    public void moveAnimalServer(Vector3 pos, Quaternion rot, ClientAction action)
    {
        pos.z = -20;
        listener.handleEvent(pos, rot, action);
    }
}
