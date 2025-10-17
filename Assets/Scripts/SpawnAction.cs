using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAction : MonoBehaviour
{
    [SerializeField] float width = 0.5f;
    [SerializeField] float height = 0.6f;
    [Header("Tile Settings")]
    [SerializeField] GameObject tilePrefab;
    [SerializeField] Transform[] spawnLines;

    [Header("Music Sync")]
    [SerializeField] AudioSource music;
    public AudioSource tap;
    [SerializeField] float bpm = 120f; // song tempo
    [SerializeField] float startDelay = 1f; // wait before song starts
    [SerializeField] float beatLineY = -3.5f; // Y position of tap line
    [SerializeField] float spawnY = 6f; // where tiles start falling

    private float secondsPerBeat;
    private float nextBeatTime;
    private bool started = false;
    void Start()
    {
        Application.runInBackground = true;
        secondsPerBeat = 60f / bpm;
        nextBeatTime = startDelay;
        music.PlayDelayed(startDelay);
    }

    [SerializeField] GameObject menu;
    void Update()
    {
        if(menu.activeInHierarchy)
        {
            music.Pause();
            return;
        }
        if (!started && Time.time >= startDelay)
        {
            started = true;
        }

        if (!music.isPlaying) return;

        // Each beat → spawn tile
        float currentTime = music.time;
        if (currentTime >= nextBeatTime - secondsPerBeat * 1.5f) // spawn 1.5 beats early
        {
            SpawnTile(nextBeatTime);
            nextBeatTime += secondsPerBeat;
        }
    }

    void SpawnTile(float beatTime)
    {
        int index = Random.Range(0, spawnLines.Length);
        Vector3 spawnPos = new Vector3(spawnLines[index].position.x, spawnY, 0f);

        GameObject tileObj = Instantiate(tilePrefab, spawnPos, Quaternion.identity);
        TileAction tile = tileObj.GetComponent<TileAction>();

        // Compute time left until the beat occurs
        float timeUntilBeat = beatTime - music.time;
        float fallDistance = spawnY - beatLineY;

        // Calculate required fall speed
        float fallSpeed = fallDistance / timeUntilBeat;

        tile.fallSpeed = fallSpeed;
        tile.beatTargetY = beatLineY;
        tile.beatTime = beatTime;
    }
}
