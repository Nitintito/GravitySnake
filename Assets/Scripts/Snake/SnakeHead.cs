using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    Transform[] bodyPartsA;
    public List<Transform> bodyParts = new List<Transform>();
    public float speed = 4f;
    public float currentRotation;
    public float rotationSensitivuty = 300f;
    public Transform snakeBody;

    [SerializeField]PointsUi pointsUi;

    private void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void Rotation()
    {
        /*
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));

        if (Input.GetKey(KeyCode.A))
        {
            currentRotation += rotationSensitivuty * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentRotation -= rotationSensitivuty * Time.deltaTime;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {

        /*
         * Make ARRay instead of list!!!!!!!!!!!!!
         * 
         */
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            pointsUi.UpdateScore();
            if (bodyParts.Count == 0)
            {
                Vector3 currentPos = transform.position;
                Transform newBodyPart = Instantiate(snakeBody, currentPos, Quaternion.identity);
                newBodyPart.GetComponent<SphereCollider>().enabled = false;
                bodyParts.Add(newBodyPart);
            }
            else
            {
                Vector3 currentPos = bodyParts[bodyParts.Count - 1].position;
                Transform newBodyPart = Instantiate(snakeBody, currentPos, Quaternion.identity);
                if (bodyParts.Count < 5)
                    newBodyPart.GetComponent<SphereCollider>().enabled = false;
                bodyParts.Add(newBodyPart);
            }
        }

        if (other.CompareTag("SnakeBody") && bodyParts.Count > 3)
        {
            //Destroy(gameObject);
            Time.timeScale = 0;
            Debug.Log("DEAD");
        }
    }
}
