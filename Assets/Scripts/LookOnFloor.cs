using UnityEngine;
using System.Collections;

public class LookOnFloor : MonoBehaviour {
    Transform parent;
    void Start()
    {
        parent = transform.parent;
    }
	void Update () {
        Vector3 localR = transform.localRotation.eulerAngles;
        float angle = parent.localRotation.eulerAngles.x;
        localR.y = 0f;
        localR.z = 0f;
        localR.x = 360-angle;
        transform.localRotation = Quaternion.Euler(localR);
	}
}
