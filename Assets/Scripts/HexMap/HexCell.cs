﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单元格类
/// </summary>
public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;
    public Color color;

    [SerializeField]
    HexCell[] neighbors;

    public int elevation;
    public HexCell GetNeighbor(HexDirection direction) 
    {
        return neighbors[(int)direction];
    }

    public void SetNeighbor(HexDirection direction, HexCell cell)
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }
}