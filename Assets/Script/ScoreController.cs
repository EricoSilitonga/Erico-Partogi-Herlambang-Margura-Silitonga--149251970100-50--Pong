using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text skorKiri;
    [SerializeField]
    private Text skorKanan; 
 
    public ScoreManager manager;

    private void Update()
    {
        skorKiri.text = manager.leftScore.ToString();
        skorKanan.text = manager.rightScore.ToString();
    }

}
