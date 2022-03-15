using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EvasiveManeure : MonoBehaviour
{
    private Boundary _boundary;
    
    public Vector2 startWait;
    private float targetManeuvre;
    public float dodge;
    public Vector2 maneuvreTime;
    public float maneuvreSpeed;
    public Vector2 maneuvreWait;
    private float currentSpeed;

    public float tilt;
    private void Start()
    {
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
        StartCoroutine(Evade());
    }

    public void InitBoundary(Boundary boundary)
    {
        _boundary = boundary;
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
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, _boundary.xMin, _boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, _boundary.zMin, _boundary.zMax)
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler
           (
               0f,
               0f,
               GetComponent<Rigidbody>().velocity.x * -tilt
           );
    }

}
