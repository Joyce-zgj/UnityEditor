using UnityEngine;

[ExecuteInEditMode]
public class PrintAwake : MonoBehaviour
{
    [ColorUsage(true,true)]
    public Color m_color;

    [ContextMenuItem("Reset", "ResetBiography")]
    [Multiline(8)]
    public string playerBiography = "";

    void ResetBiography()
    {
        playerBiography = "";
    }
}