using TMPro;
using UnityEngine;
using System;

/// <summary>
/// Updates the time display on the maths puzzle
/// desktop
/// </summary>
public class TimeUpdate : MonoBehaviour
{
    /// <summary>
    /// Object to display time
    /// </summary>
    private TextMeshProUGUI display;

    private void Start()
    {
        // Attempt to get a ref to time display obj
        display = GetComponent<TextMeshProUGUI>();
        if (!display)
        {
            Debug.Log("Time display object is not present.");
            Destroy(this);
        }
    }

    private void LateUpdate()
    {
        display.text = DateTime.Now.ToShortTimeString();
    }
}
