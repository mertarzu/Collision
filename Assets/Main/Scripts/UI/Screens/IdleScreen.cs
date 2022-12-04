using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleScreen : UIScreen
{
    public Action OnPlayPressed;
    [SerializeField] Button playButton;
  
    public override void Hide()
    {
        gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);  
    }

    public override void Initialize()
    {
        Hide();    
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);     
    }
    public void PlayPressed()
    {
        Hide();
        OnPlayPressed();
    }

}
