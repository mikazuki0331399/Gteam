using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject starPrefab;

    [SerializeField]
    private Transform parentObject;

    [SerializeField]
    private int starCount = 30;

    void Start()
    {
        for (int i = 0; i < starCount; i++)
        {
            GameObject star =
                Instantiate(starPrefab, parentObject);

            RectTransform rect =
                star.GetComponent<RectTransform>();

            rect.localPosition = new Vector3(
                Random.Range(-900f, 900f),
                Random.Range(-600f, 600f),
                0f);
        }
    }
}