using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text nameText;
    public Text hpText;
    public ParticleSystem particle;

    private string playerName;
    private int hp;

    public void Create(string newName)
    {
        playerName = newName;
        hp = 40;
        nameText.text = playerName;
        hpText.text = hp.ToString();
    }

    public void ModifyHP(int amount)
    {
        hp = Mathf.Max(hp + amount, 0);

        if(hp <= 0)
        {
            particle.Play();
        }

        hpText.text = hp.ToString();
    }

    public void Reset()
    {
        hp = 40;
        hpText.text = hp.ToString();
    }

    public void PlayParticle()
    {
        particle.Play();
    }
}
