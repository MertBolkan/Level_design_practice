using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollect : MonoBehaviour
{
    public static int NumCoinsRemaining = 0;
    private Renderer coinRenderer; // Reference to the Renderer component.
    private AudioSource audioSource; // Reference to the AudioSource component.
    private bool isCollected = false; // Flag to track if the coin has been collected.

    void Start()
    {
        NumCoinsRemaining += 1;
        coinRenderer = GetComponent<Renderer>(); // Get the Renderer component.
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || isCollected) return;

        NumCoinsRemaining -= 1;

        // Deactivate the Renderer to make the coin invisible.
        coinRenderer.enabled = false;

        // Play the audio clip if the AudioSource component is assigned.
        if (audioSource != null)
        {
            audioSource.Play();
        }

        isCollected = true; // Set the flag to prevent further collection of this coin.

        if (NumCoinsRemaining == 0)
        {
            // Win Condition
            SceneManager.LoadScene("SceneCompleted");
        }
    }
}
