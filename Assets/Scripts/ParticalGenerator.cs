using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public static ParticalGenerator instance;
    public FallingParticles basePartical;
    public List<FallingParticles> particalList = new List<FallingParticles>();
    public Vector2 generatePoint;
    public ParticleType lastParticalTypeGenerated = ParticleType.Gray;
    public int timeInterval = 2;


    private void Awake() {
        instance = this;
    }
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

        particalList.Add(partical);
        lastParticalTypeGenerated = partical.particleType;

        yield return new WaitForSeconds(timeInterval);
        }
    }

    public void destroyPartical(FallingParticles partical){
        particalList.Remove(partical);
        Destroy(partical.gameObject);
    }
}
