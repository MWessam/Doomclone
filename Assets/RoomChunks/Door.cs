using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] RoomChunk _roomItBelongsTo;
    [SerializeField] float _doorOpenTime;
    [SerializeField] Animator _animator;
    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }
    public void OpenDoorHandler()
    {
        if (_roomItBelongsTo.IsRendered)
        {
            OpenDoor();
        }
        else
        {
            RoomChunkManager.AddRoomChunk(_roomItBelongsTo);
        }
    }
    public void CloseDoorHandler()
    {
        CloseDoor();
    }
    private void OpenDoor()
    {
        _animator.SetBool("CanOpen", true);
    }
    private void CloseDoor()
    {
        _animator.SetBool("CanOpen", false);
    }
}
