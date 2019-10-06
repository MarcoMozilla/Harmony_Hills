using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class MusicNotes : MonoBehaviour
{
    // Start is called before the first frame update
    public PathCreator pathCreator;
    float distance;
    public AudioClip MusicClip;
    public AudioSource MusicSource;


    private void Start()
    {
        float speed = pathCreator.path.length / 61.5f;
        GameObject[] musicNote = GameObject.FindGameObjectsWithTag("music_note");
        float[] musicNoteTime = {2.5f, 3, 4.25f, 4.5f, 5.25f, 5.5f, 6.25f, 6.5f, 7.25f,
            7.5f, 8.25f, 8.5f, 9.25f, 9.5f, 10.25f, 10.5f, 11.25f, 11.5f, 12.25f, 12.5f, 13,
            13.5f, 13.75f, 14.25f, 14.5f, 15.25f, 15.5f, 16.25f, 16.5f, 17.25f, 17.5f, 17.75f,
            18.25f, 18.375f, 18.5f, 19.25f, 19.5f, 19.75f, 20.25f, 20.75f, 21, 21.25f, 21.5f,
            21.75f, 22.5f, 23.5f, 24, 24.75f, 25, 27.25f, 27.5f, 27.75f, 28, 28.75f, 29,
            30.5f, 31.5f, 32, 33, 34.5f, 35.5f, 36.5f, 36.75f, 37, 37.5f, 38, 38.5f, 39, 39.25f,
            39.75f, 40, 42.25f, 42.5f, 43.25f, 43.5f, 44.25f, 44.5f, 45.25f, 45.5f, 46.25f,
            46.5f, 47.25f, 47.5f, 48.25f, 48.5f, 49, 49.5f, 49.75f, 50.25f, 50.5f, 51.25f,
            51.5f, 52.25f, 52.5f, 53.25f, 53.5f, 53.75f, 54.25f, 54.375f, 54.5f, 55.25f, 55.5f,
            55.75f, 60.25f, 60.75f, 61, 61.5f};
        Debug.Log(musicNoteTime.Length);
        for (int i = 0; i < musicNoteTime.Length; i++)
        {
            distance = speed * musicNoteTime[i];
            musicNote[i].transform.position = pathCreator.path.GetPointAtDistance(distance);
            musicNote[i].transform.rotation = pathCreator.path.GetRotationAtDistance(distance);
        }
        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
