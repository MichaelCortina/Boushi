using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Modifiers;
using Modifiers.Interact;
using Modifiers.Interactable;

public class TextController : MonoBehaviour
{
    [SerializeField] private KeyCode nextLine = KeyCode.X;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image portrait;
    [SerializeField] private Image frame;
    
    private InputHandler _inputHandler;
    [CanBeNull] private IEnumerator _conversation;

    private void Update() => _inputHandler.HandleInput();

    public void StartTextInteractionHandler(TextInteraction interactable)
    {
        _conversation = StartInteraction(interactable, interactable.Lines);
    }

    private IEnumerator StartInteraction(Interactable sender, IEnumerable<ConversationLine> conversation)
    {
        text.enabled = true;
        portrait.enabled = true;
        frame.enabled = true;
        
        foreach (var line in conversation)
        {
            text.text = line.Text;
            portrait.sprite = line.Sprite;
            yield return null;
        }
        sender.EndInteraction();
    }

    public void EndTextInteractionHandler()
    {
        text.enabled = false;
        portrait.enabled = false;
        frame.enabled = false;
        _conversation = null;
    }

    private void Awake()
    {
        _inputHandler = new InputHandler()
            .SetClickEvent(nextLine, () => _conversation?.MoveNext());
    }
}
