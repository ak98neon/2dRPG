using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class need for enable builder mode for user.
public class BuilderMode : MonoBehaviour
{
    public Button builderButton;
    private BuilderStatus mapStatus;

    public void Start()
    {
        builderButton.onClick.AddListener(enableBuilderMode);
        mapStatus = GameObject.FindGameObjectWithTag("BuilderStatus").GetComponent<BuilderStatus>();
    }

    private void enableBuilderMode()
    {
        bool isBuilderModeEnable = mapStatus.IsBuilderModeEnable;
        if (isBuilderModeEnable)
        {
            mapStatus.IsBuilderModeEnable = false;
        } else
        {
            mapStatus.IsBuilderModeEnable = true;
        }
    }
}
