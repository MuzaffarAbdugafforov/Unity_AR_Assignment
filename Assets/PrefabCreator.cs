using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine.XR.ARFoundation.VisualScripting;
using System;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject dragon;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();

        // Subscribe to the trackedImagesChanged event
        aRTrackedImageManager.trackedImagesChanged += OnImagesChanged;
    }

    private void OnDisable()
    {
        // Unsubscribe from the trackedImagesChanged event
        aRTrackedImageManager.trackedImagesChanged -= OnImagesChanged;
    }

    private void OnImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach(ARTrackedImage image in obj.added) {
            dragon = Instantiate(dragonPrefab, image.transform);
            dragon.transform.position += prefabOffset;
        }
    }
}