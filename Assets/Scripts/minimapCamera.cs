using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCamera : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private Vector3 offset;

    //Private variables
    private Transform target;
    private Vector3 offsetVector;

    /// <summary>
    /// Find necessary references
    /// </summary>
    private void Awake()
    {
        //Find target by getting the transform of the game object tagged as "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        //make sure a target is found
        if (target != null)
        {
            //Calculate desired position according to offset
            offsetVector = target.position + offset;
            //if too far away from the target position
            if (Vector3.Distance(transform.position, offsetVector) > 0.1f)
            {
                //set position to offset
                transform.position = offsetVector;
            }

        }
        else
        {
            Debug.LogError("Camera Controller: Camera target must be tagged as 'Player'!");
        }
    }
}
