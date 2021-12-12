using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{

    GameObject player;
    [SerializeField] GameObject objective;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] string dmgTag;
    [SerializeField] int speed = 5;
   // [SerializeField] Vector3 destination;

    int _health = 3;
    float objDistance;
    float playerDistance;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        objDistance = Vector3.Distance(gameObject.transform.position, objective.transform.position);
           /*
        Debug.Log("PD: " + playerDistance);
        Debug.Log("OD: " + objDistance);

        if (playerDistance <= objDistance)
        {
            agent.SetDestination(Player.Instance.gameObject.transform.position);
        }
        else
        {
            agent.SetDestination(objective.gameObject.transform.position);
        }
         */
        //Vector3 moveVector = transform.position - player.transform.position;

        if(playerDistance <= objDistance)
        {
            transform.LookAt(player.transform.position, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .01f * speed);
        }
        else
        {
            transform.LookAt(objective.transform.position, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, objective.transform.position, .01f * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == dmgTag)
        {
            _health -= 3;
            if(_health <= 0)
            {
                GameplayManager.Instance.zCount--;
                Destroy(gameObject);
            }
        }
    }
}
