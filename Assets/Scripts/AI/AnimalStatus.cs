using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStatus : MonoBehaviour
{
    [SerializeField]
    private string id;
    [SerializeField]
    private int hp;
    [SerializeField]
    private string animalType;
    private AnimalObserver animalObserver;

    private void Start()
    {
        animalObserver = GameObject.FindGameObjectWithTag(MultiListener.respawnTag).GetComponent<AnimalObserver>();
    }

    public string Id { get => id; set => id = value; }
    public int Hp { get => hp; set => hp = value; }
    public string AnimalType { get => animalType; set => animalType = value; }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }

    public void hitAnimal(int damage)
    {
        hp--;
    }

    public void Die()
    {
        animalObserver.sendAnimalDataToServer(this.Id, transform.position, transform.rotation, ClientAction.ANIMAL, Action.ANIMAL_DIE);
        Destroy(gameObject);
    }
}
