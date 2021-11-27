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
        agent.destination = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == dmgLayer)
        {
            _health -= 3;
            if(_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
