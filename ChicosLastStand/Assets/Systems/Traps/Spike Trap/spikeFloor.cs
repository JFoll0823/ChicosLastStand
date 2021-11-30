using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeFloor : MonoBehaviour
{
    [SerializeField] GameObject spikes;
    [SerializeField] GameObject desired;
    Vector3 aPos;

    //spike rise vars
    bool isTriggering;
    float start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spikes rise on trigger
        if (isTriggering && (Time.time - start > .75))
        {
            if (Vector3.Distance(spikes.transform.position, desired.transform.position) >= .9)
            {
                spikes.transform.Translate(Vector3.up * Time.deltaTime * 10, Space.Self);
            }
            else
            {
                isTriggering = false;
                spikes.GetComponent<BoxCollider>().enabled = true;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            //Debug.Log("triggered");
            aPos = spikes.transform.position;
            isTriggering = true;
            start = Time.time;
            //spikes.transform.position += new Vector3(0, 1, 0);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
