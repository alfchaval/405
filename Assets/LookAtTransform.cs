using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTransform : MonoBehaviour
{
    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController rfpc;

    private void Start()
    {
        rfpc = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
    }

    public void Look(Transform t)
    {
        StartCoroutine(LookCoroutine(t, 1));
    }

    public void Look(Transform t, float speed)
    {
        StartCoroutine(LookCoroutine(t, speed));
    }

    private IEnumerator LookCoroutine(Transform t, float speed)
    {
        rfpc.controllerLocked = true;
        Vector3 targetAngles = Quaternion.LookRotation(t.position - rfpc.cam.transform.position, Vector3.up).eulerAngles;
        float startingX = CloserAngle(rfpc.cam.transform.eulerAngles.x, targetAngles.x);
        float startingY = CloserAngle(rfpc.transform.eulerAngles.y, targetAngles.y);
        float time = 0;
        while (time < 1)
        {
            rfpc.cam.transform.eulerAngles = new Vector3(Mathf.Lerp(startingX, targetAngles.x, time), rfpc.cam.transform.eulerAngles.y, rfpc.cam.transform.eulerAngles.z);
            rfpc.transform.eulerAngles = new Vector3(rfpc.transform.eulerAngles.x, Mathf.Lerp(startingY, targetAngles.y, time), rfpc.transform.eulerAngles.z);
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime * speed;
        }
        rfpc.mouseLook.Init(rfpc.transform, rfpc.cam.transform);
        rfpc.controllerLocked = false;
    }

    private float CloserAngle(float currentAngle, float targetAngle)
    {
        float resultAngle = currentAngle;
        resultAngle -= 360 * (int)((resultAngle - targetAngle) / 360);
        int angledistance = (int)((resultAngle - targetAngle) / 180);
        if (angledistance != 0)
        {
            resultAngle -= 360 * angledistance;
        }
        return resultAngle;
    }
}
