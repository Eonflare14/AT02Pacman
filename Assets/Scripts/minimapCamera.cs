using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCamera : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;

    //Private variables
    private Transform target;
    private Vector3 offsetVector;

    /// <summary>
    /// Find necessary references
    /// </summary>
    private void Awake()
    {
        //Find target
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            //Calculate desired position
            offsetVector = target.position + offset;
            if (Vector3.Distance(transform.position, offsetVector) > 0.1f)
            {
                transform.position = offsetVector;
            }

        }
        else
        {
            Debug.LogError("Camera Controller: Camera target must be tagged as 'Player'!");
        }
    }
}
