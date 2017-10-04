using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ckeck_collision : MonoBehaviour
{
    public Vector3 point;
    public int type;
    public bool touch;
    // Use this for initialization
    void Start()
    {
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "object")
        {
            this.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
   
  
    }
}