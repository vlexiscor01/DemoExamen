using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float speed;
    public bool canJump;
    public float forceJump;

    public Transform _initialPos;

    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MoveController(); 
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            transform.position = _initialPos.position;
        }

        if (other.CompareTag("PowerUpJump"))
        {
            canJump = true;
           
        }
    }
    void MoveController()
    {
        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, moveV * speed * Time.deltaTime);
        transform.Rotate(0, moveH,0 * speed * Time.deltaTime);

        if(canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * forceJump, ForceMode.Impulse);

            }
        }
    }
}
