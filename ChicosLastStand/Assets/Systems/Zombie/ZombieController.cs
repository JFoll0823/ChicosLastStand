using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject objective;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] string dmgTag;
   // [SerializeField] Vector3 destination;

    int _health = 3;
    float objDistance;
    float playerDistance;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        objDistance = Vector3.Distance(gameObject.transform.position, objective.transform.position);

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
