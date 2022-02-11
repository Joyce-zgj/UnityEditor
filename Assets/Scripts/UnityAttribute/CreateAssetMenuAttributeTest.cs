using System;

using UnityEngine;
using UnityEngine.UI;

public class CreateAssetMenuAttributeTest:MonoBehaviour
{    
    public Data m_data;

    [ImageEffectAfterScale]
    public Image m_image;
}
[CreateAssetMenu(menuName = "data_asset",fileName ="CreatData",order = 1)]
public class Data:ScriptableObject
{
    public int ID;
}