using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private List<IResetable> _resetable;

    public void ResetAll() => _resetable.ForEach(r => r.ResetObject());
    
    private void Awake()
    {
        _resetable = 
            FindObjectsOfType<MonoBehaviour>()
            .OfType<IResetable>()
            .ToList();
    }
}