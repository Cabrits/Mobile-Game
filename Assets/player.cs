using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    float rotate;
    int score;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(mousePos.x < 0){
                rotate = rotateAmount;
            }
            else{
                rotate = -rotateAmount;
            }

            transform.Rotate(0, 0, rotate);
        }
    }

    private void FixedUpdate(){
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D colllision){

        if(colllision.gameObject.tag == "Points"){
            Destroy(colllision.gameObject);
            score++;

            if(score >= 7){
                print("Level Complete");
            }
        }
        else if(colllision.gameObject.tag == "Lost"){
            SceneManager.LoadScene("Game");
        }
    }
}
