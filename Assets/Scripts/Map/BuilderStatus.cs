using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderStatus : MonoBehaviour
{
    [SerializeField]
    private bool isBuilderModeEnable;
    [SerializeField]
    private Sprite currentBuildSprite;

    public bool IsBuilderModeEnable { get => isBuilderModeEnable; set => isBuilderModeEnable = value; }
    public Sprite CurrentBuildSprite { get => currentBuildSprite; set => currentBuildSprite = value; }

    void Start()
    {
        IsBuilderModeEnable = false;
    }
}
