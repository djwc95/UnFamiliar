using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGroundAngle : MonoBehaviour
{
    public Transform rearRayPos;
    public Transform frontRayPos;
    public LayerMask layerMask;
    public float surfaceAngle;

    // Update is called once per frame
    void Update()
    {
        rearRayPos.rotation = Quaternion.Euler(-gameObject.transform.rotation.x, 0, 0);
        frontRayPos.rotation = Quaternion.Euler(-gameObject.transform.rotation.x, 0, 0);

        RaycastHit rearHit;
        if (Physics.Raycast(rearRayPos.position, rearRayPos.TransformDirection(-Vector3.up), out rearHit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(rearRayPos.position, rearRayPos.TransformDirection(-Vector3.up) * rearHit.distance, Color.yellow);
            surfaceAngle = Vector3.Angle(rearHit.normal, Vector3.up);
            Debug.Log(surfaceAngle);
        }
        else
        {
            Debug.DrawRay(rearRayPos.position, rearRayPos.TransformDirection(-Vector3.up) * 1000, Color.red);
            Debug.Log("downhill");
        }

        RaycastHit frontHit;
        Vector3 frontRayStartPos = new Vector3 (frontRayPos.position.x, rearRayPos.position.y, frontRayPos.position.z);
        if(Physics.Raycast(frontRayStartPos, frontRayPos.TransformDirection(-Vector3.up), out frontHit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(frontRayStartPos, frontRayPos.TransformDirection(-Vector3.up) * frontHit.distance, Color.yellow);
        }
        else
        {
            Debug.Log("uphill");
        }
    }
}
