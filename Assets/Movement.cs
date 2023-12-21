using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Vector2 targetPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector2(0,0);
    }

    void Update()
    {
       this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
    }
}
