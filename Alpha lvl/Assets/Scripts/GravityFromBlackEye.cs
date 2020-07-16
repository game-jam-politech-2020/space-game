using System.Collections.Generic;
using UnityEngine;

public class GravityFromBlackEye : MonoBehaviour
{

    private HashSet<Rigidbody> affectesBodies = new HashSet<Rigidbody>();

    private Rigidbody componentRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectesBodies.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectesBodies.Remove(other.attachedRigidbody);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Rigidbody body in affectesBodies)
        {

            if(body != null)
            {
                Vector3 directionToBlackEye = (transform.position - body.position).normalized;

                body.AddForce(directionToBlackEye * componentRigidbody.mass * body.mass);
            }
            //else
            //{
            //    affectesBodies.Remove(body);
            //}
          
        }
    }
}
