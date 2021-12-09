using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieTest : MonoBehaviour
{
    [SerializeField] GameObject objective;
    [SerializeField] NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(objective.gameObject.transform.position);
    }
}
