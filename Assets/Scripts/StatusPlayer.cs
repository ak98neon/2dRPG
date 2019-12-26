/*
 * @date 05.11.2016
 * @see Description: Script for show status of the player, its health-points, armor.
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatusPlayer : MonoBehaviour
{
    [SerializeField]
    private string id;
    [SerializeField]
    private int hpPlayer = 10;
    [SerializeField]
    private int armorPlayer;
    [SerializeField]
    private bool isClient;
    private MultiListener listener;

    public int statusHpPlayer { get; set; }
    public int statusArmorPlayer { get; set; }
    public string Id { get => id; set => id = value; }
    public bool IsClient { get => isClient; set => isClient = value; }
    public int HpPlayer { get => hpPlayer; set => hpPlayer = value; }

    // Use this for initialization
    void Start()
    {
        listener = GameObject.FindGameObjectWithTag(MultiListener.respawnTag).GetComponent<MultiListener>();
    }

    void Update()
    {
        alive();
    }

    public void hpPlayerDamage(int damage)
    {
        if (this.armorPlayer > 0)
        {
            armorPlayerDamage(damage);
        } else
        {
            this.HpPlayer -= damage;
        }
    }

    public void armorPlayerDamage(int damage)
    {
        this.armorPlayer -= damage;
    }

    public bool isAlive()
    {
        return HpPlayer > 0;
    }

    public void alive()
    {
        if (HpPlayer <= 0 && isClient)
        {
            listener.hitPlayer(ClientAction.PLAYER, Action.KILL_CLIENT, this.Id, gameObject.transform.position);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(gameObject);
        } else if (HpPlayer <= 0)
        {
            listener.hitPlayer(ClientAction.PLAYER, Action.KILL_CLIENT, this.Id, gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
