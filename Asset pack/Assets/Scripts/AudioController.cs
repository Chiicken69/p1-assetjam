using UnityEngine;

public class FootstepAudioController : MonoBehaviour
{
    public AudioSource audioSource;     // Reference to the player's audio source
    public AudioClip[] footstepSounds;  // Array to store footstep audio clips
    public float minPitch = 0.9f;       // Minimum pitch variation
    public float maxPitch = 1.1f;       // Maximum pitch variation
    public float minVolume = 0.8f;      // Minimum volume variation
    public float maxVolume = 1.0f;      // Maximum volume variation
    public float stepInterval = 0.5f;   // Time between steps when walking
    public float runningStepInterval = 0.3f; // Time between steps when running
    public float runningPitchModifier = 1.2f; // Pitch increase when running

    private Vector3 lastPosition;       // Stores the player's previous position
    private float nextStepTime;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        lastPosition = transform.position;  // Initialize lastPosition to the current position
    }

    void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);  // Check if shift is pressed

        // Check if the player's position has changed (movement detection)
        if (Vector3.Distance(transform.position, lastPosition) > 0.01f && Time.time >= nextStepTime)
        {
            PlayFootstepSound(isRunning);
            nextStepTime = Time.time + (isRunning ? runningStepInterval : stepInterval); // Use faster step interval for running
        }

        // Update the last known position
        lastPosition = transform.position;
    }

    void PlayFootstepSound(bool isRunning)
    {
        // Choose a random footstep sound
        AudioClip footstep = footstepSounds[Random.Range(0, footstepSounds.Length)];

        // Set random pitch and volume
        float pitch = Random.Range(minPitch, maxPitch);
        if (isRunning)
        {
            pitch *= runningPitchModifier;  // Increase pitch when running
        }

        audioSource.pitch = pitch;
        audioSource.volume = Random.Range(minVolume, maxVolume);

        // Play the sound
        audioSource.PlayOneShot(footstep);
    }
}
