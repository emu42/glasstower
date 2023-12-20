using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpactShatter : MonoBehaviour
{
    public GameObject spawnThisOnShatter;

    private static float SHATTER_THRESHOLD = 2.5f;

    private bool cameToRest = false;

    private int forbiddenLayer = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = collision.relativeVelocity;

        print("Collision detected with magnitude: " + velocity.magnitude);
        if (velocity.magnitude > SHATTER_THRESHOLD || 
            collision.collider.gameObject.layer == forbiddenLayer)
        {
            print("Die die die!!");
            GameController.SINGLETON.CollisionEnd();
            Destroy(gameObject);

            // play sound
            Instantiate(spawnThisOnShatter, transform.parent.position, Quaternion.identity);
            // TODO: particles
        }
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cameToRest && gameObject.activeSelf)
        {

            Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            if (rb == null)
            {
                print("OMG!!! rigid body missing!!");
            }
            if (rb != null && !rb.isKinematic)
            {
                print("check proximity");
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.3f, 1 << 7);  // check on proximity layer
                print("num colliders " + hitColliders.Length);
                if (hitColliders == null || (hitColliders.Length == 0) && rb.velocity.magnitude <= 0.01)
                {
                    print("zero movement");
                    GameController.SINGLETON.CameToRest(gameObject);
                    print("Piece came to rest");
                    cameToRest = true;

                }
            }
        }
    }
}
