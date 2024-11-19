// using UnityEngine;

// public class DynamicCameraAdjuster : MonoBehaviour
// {
//     [Tooltip("The desired size of the object in portrait mode.")]
//     [SerializeField] private float portraitSize = 1f;

//     [Tooltip("The object to scale.")]
//     [SerializeField] private Transform targetObject;

//     void Update()
//     {
//         AdjustObjectSize();
//     }

//     private void AdjustObjectSize()
//     {
//         if (targetObject == null)
//         {
//             Debug.LogError("Target object is not assigned!");
//             return;
//         }

//         // Calculate the screen's aspect ratio
//         float screenWidth = (float)Screen.width;
//         float screenHeight = (float)Screen.height;

//         if (screenWidth > screenHeight) // Landscape mode
//         {
//             // Adjust the object's size using the formula
//             float landscapeScaleFactor = screenWidth / screenHeight;
//             targetObject.localScale = Vector3.one * (portraitSize * landscapeScaleFactor);
//         }
//         else // Portrait mode
//         {
//             // Set the object's size to the specified portrait size
//             targetObject.localScale = Vector3.one * portraitSize;
//         }
//     }
// }


// using UnityEngine;
// using System.Collections.Generic;

// public class DynamicCameraAdjuster : MonoBehaviour
// {
//     [Tooltip("The desired size of objects in portrait mode.")]
//     [SerializeField] private float portraitSize = 1f;

//     void Update()
//     {
//         AdjustAllObjectsSize();
//     }

//     private void AdjustAllObjectsSize()
//     {
//         // Calculate the screen's aspect ratio
//         float screenWidth = (float)Screen.width;
//         float screenHeight = (float)Screen.height;

//         // Determine if we are in landscape mode
//         bool isLandscape = screenWidth > screenHeight;

//         // Calculate the scale factor
//         float scaleFactor = isLandscape ? (screenWidth / screenHeight) : 1f;

//         // Find all transforms in the scene
//         foreach (Transform obj in FindObjectsOfType<Transform>())
//         {
//             // Adjust each object's size
//             obj.localScale = Vector3.one * (portraitSize * scaleFactor);
//         }
//     }
// }


// --------------------------------------------------------------------------------


using UnityEngine;
using System.Collections.Generic;

public class DynamicCameraAdjuster : MonoBehaviour
{
    // Dictionary to store each object's original size
    private Dictionary<Transform, Vector3> originalScales = new Dictionary<Transform, Vector3>();

    [Tooltip("The size multiplier for objects in portrait mode.")]
    [SerializeField] private float portraitSize = 1f;

    void Start()
    {
        // Store the original sizes of all objects in the scene
        foreach (Transform obj in FindObjectsOfType<Transform>())
        {
            originalScales[obj] = obj.localScale;
        }
    }

    void Update()
    {
        AdjustAllObjectsSize();
    }

    private void AdjustAllObjectsSize()
    {
        // Calculate the screen's aspect ratio
        float screenWidth = (float)Screen.width;
        float screenHeight = (float)Screen.height;

        // Determine if we are in landscape mode
        bool isLandscape = screenWidth > screenHeight;

        // Calculate the scale factor
        float scaleFactor = isLandscape ? ( screenWidth / screenHeight) : 1f;

        // Iterate through all stored objects
        foreach (var pair in originalScales)
        {
            Transform obj = pair.Key;
            Vector3 originalScale = pair.Value;

            // Adjust the size based on the original size, portrait size, and scale factor
            obj.localScale = originalScale * (portraitSize * scaleFactor);
        }
    }
}
