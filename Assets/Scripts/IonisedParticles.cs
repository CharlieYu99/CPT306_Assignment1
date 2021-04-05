using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonisedParticles : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallingSpeedMax = -2.0f;
    private Rigidbody2D rigidBody;
    public IonisedParticles instance;
    void Awake() {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        //limit the maxspeed
        if (rigidBody.velocity.y < fallingSpeedMax) rigidBody.velocity = new Vector2(rigidBody.velocity.x, fallingSpeedMax);
    }
}
