using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFighter : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
    public static SpaceFighter instance;
    public float movespeed = 3.0f;

    private float PositionX_min = -1.75f;
    private float PositionX_max = 1.75f;
    private float PositionY_max = 1.25f;
    private float PositionY_min = -0.25f;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal")*movespeed, Input.GetAxis("Vertical")*movespeed);
        // Vector2 thisPosition = new Vector2(rigidBody.position.x, rigidBody.position.y);
        Vector2 thisPosition = rigidBody.transform.position;
        if (!PointInsideRect(thisPosition, PositionX_min, PositionX_max, PositionY_max, PositionY_min)){
            rigidBody.transform.position = new Vector2(Mathf.Clamp(thisPosition.x, PositionX_min, PositionX_max), Mathf.Clamp(thisPosition.y, PositionY_min, PositionY_max)); 
        }

        
    }

    private bool PointInsideRect(Vector2 point,float left, float right, float top, float buttom){
        return (point.x >= left && point.x <= right && point.y >= buttom && point.y <= top);
    }

    void OnCollisionEnter2D(Collision2D collision){
    
    }


}
