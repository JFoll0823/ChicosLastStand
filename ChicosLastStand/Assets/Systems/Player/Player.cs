using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    //object placement code from https://www.youtube.com/watch?v=YI6F1x4pzpg
    [SerializeField] GameObject spikeTrapPrefab;
    [SerializeField] KeyCode spikeTrapHotKey = KeyCode.Alpha1;
    [SerializeField] GameObject currentPlaceableObject;
    private float mouseWheelRotation;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleNewObjectHotKey();

        if (currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject.gameObject.GetComponent<BoxCollider>().enabled = true;
            currentPlaceableObject = null;
        }
    }

    private void RotateFromMouseWheel()
    {
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void HandleNewObjectHotKey()
    {
        if (Input.GetKeyDown(spikeTrapHotKey))
        {
            currentPlaceableObject = Instantiate(spikeTrapPrefab);
        }
    }
}
