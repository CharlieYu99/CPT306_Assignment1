using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFighter : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
    public static SpaceFighter instance;
    public float movespeed = 3.0f;

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

    }

    void OnCollisionEnter2D(Collision2D collision){
    
    }


}
