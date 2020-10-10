using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public GameObject focus;
    private Vector3 offset;
    // Start is called before the first frame update
    private void Start()
    {
        
        focus = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - focus.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = focus.transform.position + offset;
    }
}
