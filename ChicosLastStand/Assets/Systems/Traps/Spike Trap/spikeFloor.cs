using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeFloor : MonoBehaviour
{
    [SerializeField] GameObject spikes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Debug.Log("triggered");
            spikes.transform.position += new Vector3(0, 1, 0);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
