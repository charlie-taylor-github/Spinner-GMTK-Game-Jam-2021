using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject otherPlayer;
    public EnemySpawner spawnerScript;

    Rigidbody2D rb;
    bool isFrozen = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * 100, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isFrozen)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                isFrozen = false;
                GetComponent<HingeJoint2D>().useMotor = true;
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                isFrozen = true;
                GetComponent<HingeJoint2D>().useMotor = false;
            }
        }
    }

    void FixedUpdate()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnModule"))
        {
            Debug.Log("New Module");
        }
    }

}
