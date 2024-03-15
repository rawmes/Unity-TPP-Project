using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerPrefLooks : ScriptableObject
{
    public bool hasSaved;

    public int bodyIndex;
    public int eyesIndex;
    public int irisIndex;
    public int hairIndex;
    public int beardIndex;
    public int browIndex;
    public int earIndex;
    public int hatIndex;
    public int noseIndex;
    public int pantIndex;
    public int shirtIndex;
    public int shoeIndex;
    public int teethIndex;

    public void WipePref()
    {
        hasSaved = false;
    }



}
