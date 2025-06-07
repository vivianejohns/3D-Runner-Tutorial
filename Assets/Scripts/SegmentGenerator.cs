using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;
    public int camOffset = -25;

    [SerializeField]
    int zPos = 50;

    [SerializeField]
    bool creatingSegment = false;

    [SerializeField]
    int segmentNumber;

    // reference camera for calculating out of sight position
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float destroyDelay = 1;
    private List<GameObject> activeSegments = new List<GameObject>();

    void Update()
    {
        if (creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    void LateUpdate()
    {
        foreach (GameObject segment in activeSegments)
        {
            if (!IsInViewPort(segment))
            {
                StartCoroutine(DelayedDestroy(segment));
            }
        }
    }

    // co-routine, needed with timing
    IEnumerator SegmentGen()
    {
        segmentNumber = UnityEngine.Random.Range(0, segment.Length);
        GameObject newSegment = Instantiate(
            segment[segmentNumber], new Vector3(0, 0, zPos), Quaternion.identity);
        activeSegments.Add(newSegment);
        zPos += 50;
        yield return new WaitForSeconds(10);
        creatingSegment = false;
    }

    private bool IsInViewPort(GameObject segment)
    {
        // Prüfen ob das Segment innerhalb des Viewports ist
        bool isInViewPort = segment.transform.position.z >= cam.transform.position.z + camOffset;
        return isInViewPort;
    }
    
    private IEnumerator DelayedDestroy(GameObject segment)
    {
        yield return new WaitForSeconds(destroyDelay);
        activeSegments.Remove(segment);
        Destroy(segment);
    }
}
