using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaggedImages : ScriptableObject
{
    [SerializeField] private List<TaggedImage> taggedImages;

    public Sprite GetImageFromTag(string imageTag) => 
        taggedImages.Find(image => image.Tag == imageTag)?.Sprite;


    [System.Serializable]
    private class TaggedImage
    {
        [field: SerializeField]
        public string Tag { get; set; }
        [field: SerializeField]
        public Sprite Sprite { get; set; }
    }
}