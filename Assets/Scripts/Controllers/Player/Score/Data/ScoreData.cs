using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScoreData
{
    public int hightScore;
    public int previewScore;

    public ScoreData(int hightScore, int previewScore)
    {
        this.hightScore = hightScore;
        this.previewScore = previewScore;
    }
}

