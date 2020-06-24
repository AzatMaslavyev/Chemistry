using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class InteractingController : MonoBehaviour {
    public static Transform PickPoint;
    Collider collider;
    Transform defaultParent;
    Vector3 startPosition;
    Quaternion startRotation;
    public float glowValue;
    public Vector3 rotationInHand = Vector3.zero;
    public void Start()
    {
        collider = GetComponent<Collider>();
        defaultParent = transform;

        while (defaultParent.parent!=null)
            defaultParent = defaultParent.parent;

        startPosition = defaultParent.position;
        startRotation = defaultParent.rotation;
    }

    public void PutInsideAnotherObject(Transform parent)
    {
        defaultParent.parent = parent;
        defaultParent.transform.localRotation = Quaternion.Euler(rotationInHand);
        defaultParent.transform.localPosition = Vector3.zero;
    }

    internal void Throw()
    {

        defaultParent.SetParent(null);
        collider.enabled = true;
        defaultParent.position = startPosition;
        defaultParent.rotation = startRotation;
    }      
}

