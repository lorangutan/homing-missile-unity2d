using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    private bool isActivated = false;

    [SerializeField]
    private Rigidbody2D rb = null;

    [SerializeField]
    private float speed = 0;
    
    [SerializeField]
    private float rotateSpeed = 0;

    [SerializeField]
    private Transform target = null;

    [SerializeField]
    private GameObject sparks = null;

    [SerializeField]
    private Collider2D pointyEnd = null;

    [SerializeField]
    private GameObject radarIndicator = null;

    void FixedUpdate()
    {
        if (isActivated)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActivated = true;
            rb.isKinematic = true;
            target = collision.transform;
            radarIndicator.SetActive(false);
            pointyEnd.enabled = true;
            //Destroy(radarIndicator);
        }
        else if (!radarIndicator.activeInHierarchy && pointyEnd.enabled && collision.CompareTag("Spike"))
        {
            Instantiate(sparks, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
