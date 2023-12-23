using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{

    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    int score;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < 0)
            {
                transform.Rotate(0, 0, rotateAmount);
            }
            else
            {
                transform.Rotate(0, 0, -rotateAmount);
            }
        }

        WrapAround();
    }

    private void FixedUpdate(){
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other){
    if (other.gameObject.tag == "Points"){
        moveSpeed += 0.5f;
        Destroy(other.gameObject);
        score++;

        if (score >= 8){
            SceneManager.LoadScene("Game");
            print("Level Complete");
        }
    }
    else if (other.gameObject.tag == "Lost"){
        SceneManager.LoadScene("Game");
    }
}

    private void WrapAround(){
    float screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    float screenBottom = Camera.main.ScreenToWorldPoint(Vector3.zero).y;

    Vector3 newPosition = transform.position;

    if (transform.position.x < screenLeft){
        newPosition.x = screenRight;
    }
    else if (transform.position.x > screenRight){
        newPosition.x = screenLeft;
    }

    if (transform.position.y < screenBottom){
        newPosition.y = screenTop;
    }
    else if (transform.position.y > screenTop){
        newPosition.y = screenBottom;
    }

    transform.position = newPosition;
}
}
