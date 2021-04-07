using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParticleType{
    Red = 1,
    Green = 2,
    Blue = 3,
    Gray = 0

}

public class FallingParticles : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallingSpeedMax = -2.0f;
    private float speedDecreaseRate = 0.95f;
    private Rigidbody2D rigidBody;
    public FallingParticles instance;
    public ParticleType particleType;
    void Awake() {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        switch (Random.Range(0,4)){
            case 0:
                particleType = ParticleType.Gray;
                gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(128,128,128,255);
                break;
            case 1:
                particleType = ParticleType.Red;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
                break;
            case 2:
                particleType = ParticleType.Green;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.green;
                break;
            case 3:
                particleType = ParticleType.Blue;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.blue;
                break;
            default:
                break;
        }
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
        if (rigidBody.velocity.y < fallingSpeedMax){
            rigidBody.velocity = new Vector2(rigidBody.velocity.x * speedDecreaseRate, fallingSpeedMax);
        } else{
            rigidBody.velocity = new Vector2(rigidBody.velocity.x * speedDecreaseRate, rigidBody.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        
    }

}
