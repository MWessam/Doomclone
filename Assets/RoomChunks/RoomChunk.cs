using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomChunk : MonoBehaviour
{
    public event Action OnRoomEnter;
    public event Action OnRoomLeave;
    private bool _isRendered = false;
    [SerializeField] Tilemap[] _walls;
    [SerializeField] Tilemap[] _floors;
    [SerializeField] Tilemap[] _doors;
    [SerializeField] EntitySpawner[] _spawners;
    public bool IsRendered { get => _isRendered; }

    private void OnEnable()
    {
        _isRendered = true;
        OnRoomEnter += RenderRoom;
        OnRoomLeave += DeRenderRoom;
    }
    private void RenderRoom()
    {
        RoomChunkManager.AddRoomChunk(this);
        gameObject.SetActive(true);
        _isRendered = true;
    }
    public void DeRenderRoom()
    {
        OnRoomEnter -= RenderRoom;
        OnRoomLeave -= DeRenderRoom;
        gameObject.SetActive(false);
    }
    public void EnteredRoom()
    {
        OnRoomEnter?.Invoke();
    }
}
