using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDespawnAfterPlayback : MonoBehaviour
{

    private AudioSource audioSource;

    public IEnumerator DespawnWhenFinished()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DespawnWhenFinished());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
