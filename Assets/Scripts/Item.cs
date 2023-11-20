using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IUpgradeItem
{
    public void GiveUpgrade(PlayerMovement player)
    {
        player.AddJump(1);
    }
}
