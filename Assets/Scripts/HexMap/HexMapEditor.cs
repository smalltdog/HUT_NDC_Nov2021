﻿using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///
/// </summary>
public class HexMapEditor : MonoBehaviour
{
    public Color[] colors;
    public HexGrid hexGrid;

    private Color activeColor;
    int activeElevation;

    void EditCell(HexCell cell)
    {
        cell.Color = activeColor;
        cell.Elevation = activeElevation;
        //hexGrid.Refresh();
    }

    private void Awake()
    {
        SelectColor(0);
    }

    void Update()
    {
        if (Input.GetMouseButton(0)&&
            !EventSystem.current.IsPointerOverGameObject())
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            EditCell(hexGrid.GetCell(hit.point));
        }
    }
    public void SelectColor(int index)
    {
        activeColor = colors[index];
    }
    public void SetElevation(float elevation)
    {
        activeElevation = (int)elevation;
    }
}
