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
    public Rigidbody2D rigidBody;
    public FallingParticles instance;
    public ParticleType particleType;

    public bool touchPlayer = false;

    // private float fix_X = 5.0f;
    // private bool active = true;

    // private Vector2 lastPosition;

    void Awake() {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        while (setParticalType() == ParticalGenerator.instance.lastParticalTypeGenerated);
        // lastPosition = transform.position;
    }
    void Start()
    {
        rigidBody.velocity = new Vector2(0, fallingSpeedMax);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        //limit the maxspeed
        var v = new Vector2(rigidBody.velocity.x * speedDecreaseRate, fallingSpeedMax);
        
        rigidBody.velocity = Vector2.ClampMagnitude(v, -fallingSpeedMax);

        
    }


    private void OnCollisionEnter2D(Collision2D other) {
        // if the space fighter touches the debris on the top and then destory it
        if (other.gameObject.tag == "Player"){
            if (particleType == ParticleType.Gray){
                Vector2 thisPosition = rigidBody.position;
                Vector2 otherPosition = other.gameObject.transform.position;
                if (thisPosition.y > otherPosition.y && Mathf.Abs(thisPosition.x - otherPosition.x) <= Mathf.Abs(thisPosition.y - otherPosition.y)){
                    ParticalGenerator.instance.destroyPartical(instance);
                }
            }
            touchPlayer = true;
        }else if (other.gameObject.tag == "GameElement"){
            if (other.gameObject.GetComponent<FallingParticles>().touchPlayer){
                // Opps! Space Fighter has been destroyed! in Red
                GameManager.instance.GameOver();
            }
        }

        if (other.gameObject.tag == "Bottom"){
            gameObject.tag = "Bottom";
            // see if could vanish
            


            if (rigidBody.position.y > -1.0f){
                // the storage area is filled with non-lined ionised particles; "Opps! Ionised particles are not successfully lined in the storage! " in Orange
                GameManager.instance.GameOver();
            }
        }

    }

    private ParticleType setParticalType(){
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
        return particleType;
    }


}
