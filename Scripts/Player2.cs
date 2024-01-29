using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public GameObject otherPlayer;

    Rigidbody2D rb;
    bool isFrozen = false;

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

}
