using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Character : MonoBehaviour
{
    public PathCreator pathCreator;

    float distanceTravelled;
    //List<double> musicNoteTime = new List<double>();

    // Update is called once per frame
    void Update()
    {
        float speed = pathCreator.path.length / 61.5f;
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
