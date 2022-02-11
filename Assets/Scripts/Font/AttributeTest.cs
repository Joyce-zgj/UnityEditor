using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeTest : MonoBehaviour
{    
    [Tooltip("t")]
    [SerializeField]
    private string test;

    [MinMax(3,8)]
    [SerializeField]
    public Vector2 value;
    
    public AnimationCurve curve;

    
    // Start is called before the first frame update
    void Start()
    {
#if tes
 Debug.LogError("eee");
#else

#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
