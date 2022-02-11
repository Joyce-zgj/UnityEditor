using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;


public class PrefabUnititly : MonoBehaviour
{

    [ContextMenuItem("Apply To Prefab", nameof(ApplyToPrefab))]
    public int a = 10;
    private void ApplyToPrefab()
    {

        //if (GUILayout.Button("Apply Collider To Prefab"))
        //{
        //    //PrefabUtility.ReplacePrefab(simActor.Preview, PrefabUtility.GetPrefabParent(simActor.Preview), ReplacePrefabOptions.ConnectToPrefab);
        //}
    }
}
