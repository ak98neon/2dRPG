using UnityEngine;
using System.Collections;

public class AnimalAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.05f;
    [SerializeField]
    private bool isMoving = false;
    [SerializeField]
    private float maxRange = 10f;
    [SerializeField]
    private float waitTime = 3f;
    [SerializeField]
    private Vector2 targetPos;

    private AnimalObserver animalObserver;

    private void Start()
    {
        animalObserver = GameObject.FindGameObjectWithTag(MultiListener.respawnTag).GetComponent<AnimalObserver>();
    }

    void Update()
    {
        if (!isMoving) {
        FindNewTargetPos();
        }
        //TODO Add check distance to everybody player, and move from player.
        //checkDistanceToPlayer();
    }

    private void checkDistanceToPlayer(Vector2 playerPos)
    {
        if (Vector2.Distance(transform.position, playerPos) < 5)
        {
            FindNewTargetPos();
        }
    }

    private void FindNewTargetPos() {
      Vector2 pos = transform.position;
      targetPos = new Vector2();
      targetPos.x  = Random.Range(pos.x - maxRange, pos.x + maxRange);
      targetPos.y = Random.Range(pos.y - maxRange, pos.x + maxRange);
      StartCoroutine(Move());
    }

    IEnumerator Move() {
      isMoving = true;

      for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * speed) {
          transform.position = Vector2.MoveTowards(transform.position, targetPos, t);
          AnimalStatus animalStatus = GetComponent<AnimalStatus>();
          animalObserver.sendAnimalDataToServer(animalStatus.Id, transform.position, transform.rotation, ClientAction.ANIMAL, Action.ANIMAL_MOVE);
          yield return null;
      }

      yield return new WaitForSeconds(waitTime);
      isMoving = false;
      yield return null;
    }
}
