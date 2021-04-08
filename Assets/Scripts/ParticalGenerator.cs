using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public FallingParticles basePartical;
    public Vector2 generatePoint;
    public int timeInterval = 2;

    void Start()
    {
        StartCoroutine(generatePartical());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator generatePartical(){
        while (true){
        FallingParticles partical = (FallingParticles)Instantiate(basePartical);
        partical.transform.SetParent(this.transform, false);
        partical.transform.position = generatePoint;
        yield return new WaitForSeconds(timeInterval);
        }
    }
}
