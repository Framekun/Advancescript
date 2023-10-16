using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string TargetName;
    [SerializeField] private int GainIndex;
    public delegate void addJumpIndex(int gainindex);
    public addJumpIndex AddJumpIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroyTarget()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == TargetName)
        {
            AddJumpIndex.Invoke(GainIndex);
            OnDestroyTarget();
        }
    }
}
