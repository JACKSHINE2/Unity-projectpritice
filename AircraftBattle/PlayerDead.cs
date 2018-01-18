using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour {
    public AudioClip clip;
    public GameObject playerExplosionPrefab;
    // Use this for initialization
    void Start () {
    }
    private void OnTriggerEnter(Collider other)
    {
        GameOver();
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    

    void GameOver()
    {
        Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
