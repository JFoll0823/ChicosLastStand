using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] int dmgLayer;

    int _health = 3;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Position");
        Debug.Log(player.gameObject.transform.position);
        agent.SetDestination(player.gameObject.transform.position);
        Debug.Log("Agent Destination:");
        Debug.Log(agent.destination);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == dmgLayer)
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
