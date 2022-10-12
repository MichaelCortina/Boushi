using System;
using System.Collections.Generic;
using UnityEngine;

public class TextInteraction : MonoBehaviour
{
    public static Action<IEnumerable<ConversationLine>> OnTextInteraction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            
        }
    }
}