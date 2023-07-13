using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class RoomChunkManager
{
    private static Queue<RoomChunk> _currentlyRenderedRoomChunks = new Queue<RoomChunk>(2);
    public static event Action onRoomChunkLoaded;
    public static void AddRoomChunk(RoomChunk roomChunk)
    {
        if (_currentlyRenderedRoomChunks.Count < 2)
        {
            _currentlyRenderedRoomChunks.Enqueue(roomChunk);
            roomChunk.EnteredRoom();
        }
        else
        {
            _currentlyRenderedRoomChunks.Dequeue().DeRenderRoom();
            _currentlyRenderedRoomChunks.Enqueue(roomChunk);
        }
        onRoomChunkLoaded?.Invoke();
    }
    public static void RemoveRoomChunk(RoomChunk roomChunk)
    {
        _currentlyRenderedRoomChunks.Dequeue().DeRenderRoom();
    }
}
