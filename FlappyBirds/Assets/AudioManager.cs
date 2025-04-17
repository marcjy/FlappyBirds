using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip PlayerScores;
    public AudioClip PlayerCrashes;

    public PlayerController Player;

    private AudioSource PermanentAudioSource;
    private void Awake()
    {
        Player.OnCrash += HandlePlayerCrashed;
        Player.OnScorePoints += HandlePlayerScored;
    }

    private void Start()
    {
        PermanentAudioSource = new GameObject("ScoreAS").AddComponent<AudioSource>();
        PermanentAudioSource.clip = PlayerScores;

        PermanentAudioSource.gameObject.transform.parent = transform.parent;
    }

    private void HandlePlayerScored(object sender, int e)
    {
        PermanentAudioSource.Play();
    }

    private void HandlePlayerCrashed(object sender, System.EventArgs e)
    {
        GameObject audioObject = new GameObject();
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = PlayerCrashes;
        audioSource.Play();

        Destroy(audioObject, audioSource.clip.length);
    }
}
