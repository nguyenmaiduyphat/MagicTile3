using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;

    void Start()
    {
        music.PlayDelayed(1f);
    }

    public float CurrentTime => music.time;
}
