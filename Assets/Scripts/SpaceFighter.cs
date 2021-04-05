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
        // if (Input.GetKey(KeyCode.UpArrow)) rigidBody.position = new Vector2(rigidBody.position.x, rigidBody.position.y + movespeed);
        // if (Input.GetKey(KeyCode.DownArrow)) rigidBody.position = new Vector2(rigidBody.position.x, rigidBody.position.y - movespeed);
        // if (Input.GetKey(KeyCode.LeftArrow)) rigidBody.position = new Vector2(rigidBody.position.x - movespeed, rigidBody.position.y);
        // if (Input.GetKey(KeyCode.RightArrow)) rigidBody.position = new Vector2(rigidBody.position.x + movespeed, rigidBody.position.y);

        if (Input.GetKeyDown(KeyCode.UpArrow)) rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y + movespeed);
        if (Input.GetKeyDown(KeyCode.DownArrow)) rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y - movespeed);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) rigidBody.velocity = new Vector2(rigidBody.velocity.x - movespeed, rigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.RightArrow)) rigidBody.velocity = new Vector2(rigidBody.velocity.x + movespeed, rigidBody.velocity.y);
    }

    private void FixedUpdate() {

    }
}
