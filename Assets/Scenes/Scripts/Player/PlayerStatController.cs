using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : Singleton<PlayerStatController>, ISavable<PlayerStatSaveData>
{
    [SerializeField] private int jumpCount = 1;
    public int JumpCount => jumpCount;

    [SerializeField] private bool canAttack;
    public bool CanAttack => canAttack;

    [SerializeField] private bool canSprint;
    public bool CanSprint => canSprint;

    public void AddJump()
    {
        jumpCount++;
    }

    public void EnableAttack()
    {
        canAttack = true;
    }

    public void EnableSprint()
    {
        canSprint = true;
    }

    public void ApplySavedata(PlayerStatSaveData savedata)
    {
        jumpCount = savedata.JumpCount;
        canAttack = savedata.CanAttack;
        canSprint = savedata.CanSprint;
    }

    public PlayerStatSaveData getdata()
    {
        PlayerStatSaveData saveData = new PlayerStatSaveData();

        saveData.JumpCount = JumpCount;
        saveData.CanAttack = CanAttack;
        saveData.CanSprint = CanSprint;

        return saveData;
    }
}

[System.Serializable]
public class PlayerStatSaveData
{
    public int JumpCount;
    public bool CanAttack;
    public bool CanSprint;
}
