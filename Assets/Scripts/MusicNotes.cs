using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using System.IO;

public class MusicNotes : MonoBehaviour
{
    // Start is called before the first frame update
    public PathCreator pathCreatorLeft;
    public PathCreator pathCreatorMiddle;
    public PathCreator pathCreatorRight;
    private PathCreator pathCreatorSelected;
    float distance;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public static System.Random random = new System.Random();

    public Character character;
    // private int position = 0;
    public Text st;
    static public float[] musicNoteTime = {2.5f, 3, 4.25f, 4.5f, 5.25f, 5.5f, 6.25f, 6.5f, 7.25f,
            7.5f, 8.25f, 8.5f, 9.25f, 9.5f, 10.25f, 10.5f, 11.25f, 11.5f, 12.25f, 12.5f, 13,
            13.5f, 13.75f, 14.25f, 14.5f, 15.25f, 15.5f, 16.25f, 16.5f, 17.25f, 17.5f, 17.75f,
            18.25f, 18.375f, 18.5f, 19.25f, 19.5f, 19.75f, 20.25f, 20.75f, 21, 21.25f, 21.5f,
            21.75f, 22.5f, 23.5f, 24, 24.75f, 25, 27.25f, 27.5f, 27.75f, 28, 28.75f, 29,
            30.5f, 31.5f, 32, 33, 34.5f, 35.5f, 36.5f, 36.75f, 37, 37.5f, 38, 38.5f, 39, 39.25f,
            39.75f, 40, 42.25f, 42.5f, 43.25f, 43.5f, 44.25f, 44.5f, 45.25f, 45.5f, 46.25f,
            46.5f, 47.25f, 47.5f, 48.25f, 48.5f, 49, 49.5f, 49.75f, 50.25f, 50.5f, 51.25f,
            51.5f, 52.25f, 52.5f, 53.25f, 53.5f, 53.75f, 54.25f, 54.375f, 54.5f, 55.25f, 55.5f,
            55.75f, 60.25f, 60.75f, 61, 61.5f};
    private int[] musicNotePositions = new int[musicNoteTime.Length];
    public int score = 0;
    public int max_score = 0;
    private void Start()
    {
        float speed = 20;
        GameObject[] musicNote = GameObject.FindGameObjectsWithTag("music_note");
        Debug.Log(musicNoteTime.Length);
        max_score = musicNoteTime.Length;
        for (int i = 0; i < musicNoteTime.Length; i++)
        {
            (PathCreator pathCreatorSelected, int position) = selectRandomPath();
            musicNotePositions[i] = position;
            distance = speed * musicNoteTime[i];
            musicNote[i].transform.position = pathCreatorSelected.path.GetPointAtDistance(distance);
            musicNote[i].transform.rotation = pathCreatorSelected.path.GetRotationAtDistance(distance);
        }
        //MusicSource.clip = MusicClip;
        //MusicSource.Play();
        st = GameObject.Find("score_text").GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] musicNotes = GameObject.FindGameObjectsWithTag("music_note");
        GameObject hitMusicNote = null;
        for (int i = 0; i < musicNotes.Length; i++)
        {
            float dist = Vector3.Distance(character.transform.position, musicNotes[i].transform.position);
            if (dist < 3)
            {
                Debug.Log(dist);
                Debug.Log("Distance to character: " + dist);
                hitMusicNote = musicNotes[i];
                break;
            }
        }
        if(hitMusicNote)
        {
            Destroy(hitMusicNote);
            // hitMusicNote.GetComponent<Music_Note_scpt>().hit();
            score += 1;
            double synchronization = score * 100.00/max_score;
            st.text = "Synchronization: " + String.Format("{0:F2}", synchronization);
        }
    }
    (PathCreator pathSelected, int position) selectRandomPath()
    {
        int num = random.Next(3);
        int position = 0;
        PathCreator pathSelected;
        if(num == 0)
        {
            pathSelected = pathCreatorLeft;
            position = -2;
        } else if (num == 1)
        {
            pathSelected = pathCreatorMiddle;
            position = 0;
        } else 
        {
            pathSelected = pathCreatorRight;
            position = 2;
        }
        return (pathSelected, position);
    }
}
