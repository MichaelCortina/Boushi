using System;
using System.Collections.Generic;
using UnityEngine;

public class DialougeInteration : MonoBehaviour
{
    public static Action<IEnumerable<ConversationLine>> OnDialogueInteraction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            
        }
    }
}