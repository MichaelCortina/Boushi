using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] private KeyCode nextLine = KeyCode.X;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image portrait;
    [SerializeField] private Image frame;

    private InputHandler _inputHandler;
    [CanBeNull] private IEnumerator _conversation;

    private void Update() => _inputHandler.HandleInput();
    
    private void AnyInteractionHandler(object sender, InteractionEventArgs args)
    {
        _conversation = StartInteraction((Interactable) sender, args.Conversation);
        _conversation!.MoveNext();
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

    private void AnyInteractionEndHandler(object sender, EventArgs args)
    {
        text.enabled = false;
        portrait.enabled = false;
        frame.enabled = false;
        _conversation = null;
    }

    private void OnEnable()
    {
        GlobalEventSystem.Instance.OnAnyInteraction += AnyInteractionHandler;
        GlobalEventSystem.Instance.OnAnyInteractionEnd += AnyInteractionEndHandler;
    }
    
    private void OnDisable()
    {
        GlobalEventSystem.Instance.OnAnyInteraction -= AnyInteractionHandler;
        GlobalEventSystem.Instance.OnAnyInteractionEnd -= AnyInteractionEndHandler;
    }

    private void Awake() =>
        _inputHandler = new InputHandler()
            .SetClickEvent(nextLine, () => _conversation?.MoveNext());
}
