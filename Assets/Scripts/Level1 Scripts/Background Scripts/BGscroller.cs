using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BGscroller : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
        
        if(transform.position.x > StartPosition.x)
        {
            transform.position = StartPosition;
        }
        
    }
}
