using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Follow : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    [SerializeField] Transform target;


    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        transform.position = target.position + offset;

        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}
