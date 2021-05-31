using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioSource moveSound;
    public AudioSource jumpSound;
    public AudioSource playerDamage;
    public AudioSource swordHitCovid;
    public AudioSource swordHitWall;
    public AudioSource swordSwing;
    public AudioSource levelFailedRiff;
    public AudioSource levelCompleteRiff;

    public void ButtonClickPlay()
    {
        this.
        buttonClick.Play();
    }
    public void MoveSoundPlay()
    {
        moveSound.Play();
    }
    public void JumpSoundPlay()
    {
        jumpSound.Play();
    }
    public void PlayerDamagePlay()
    {
        playerDamage.Play();
    }
    public void SwordHitCovidPlay()
    {
        swordHitCovid.Play();
    }
    public void SwordHitWallPlay()
    {
        swordHitWall.Play();
    }
    public void SwordSwingPlay()
    {
        swordSwing.Play();
    }
    public void LevelFailedRiffPlay()
    {
        levelFailedRiff.Play();
    }
    public void LevelCompleteRiffPlay()
    {
        levelCompleteRiff.Play();
    }
}
