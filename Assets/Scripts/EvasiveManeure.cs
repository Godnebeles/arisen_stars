using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeure : MonoBehaviour
{
    public Vector2 startWait;
    private float targetManeuvre;
    public float dodge;
    public Vector2 maneuvreTime;
    public float maneuvreSpeed;
    public Vector2 maneuvreWait;
    private float currentSpeed;

    public Boundary boundary;
    public float tilt;
    void Start()
    {
        if (Screen.width < Screen.height)
        {
            float width = Screen.width;
            float height = Screen.height;
            float x = width / height * 10f;
            boundary.xMin = -x + 0.6f;
            boundary.xMax = x - 0.6f;
        }
        else
        {
            float width = Screen.width;
            float height = Screen.height;
            float x = height / width * 10f;
            boundary.xMin = -x - 1.3f;
            boundary.xMax = x + 1.3f;
        }
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds
        (
            Random.Range(
                startWait.x,
                startWait.y)       
        );

        while (true)
        {
            targetManeuvre = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds
            (
                Random.Range(
                    maneuvreTime.x,
                    maneuvreTime.y)
            );
            targetManeuvre = 0;

            yield return new WaitForSeconds
            (
                Random.Range(
                    maneuvreWait.x,
                    maneuvreWait.y)
            );

        }
    }

    private void FixedUpdate()
    {
        float newManeuvre = Mathf.MoveTowards
        (
            GetComponent<Rigidbody>().velocity.x,
            targetManeuvre,
            maneuvreSpeed * Time.deltaTime
    
        );

        GetComponent<Rigidbody>().velocity = new Vector3(newManeuvre, 0.0f, currentSpeed);

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler
           (
               0f,
               0f,
               GetComponent<Rigidbody>().velocity.x * -tilt
           );
    }

}
