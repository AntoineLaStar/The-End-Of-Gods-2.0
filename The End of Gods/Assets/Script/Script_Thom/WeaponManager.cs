using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    [SerializeField] Sprite PodiumSprite;
    [SerializeField] Sprite PodiumSpriteWeapon;
    [SerializeField] GameObject Character;

    void Start () {
		if (Player_Info.CharacterName == Character.name)
        {
            podiumSpearChangeSprite(PodiumSprite);
        }
        else
        {
            podiumSpearChangeSprite(PodiumSpriteWeapon);
        }
	}

    public void podiumSpearChangeSprite(Sprite goodSprite)
    {
        Sprite podium;
        GameObject Spear = gameObject;
        podium = goodSprite;
        Spear.GetComponent<SpriteRenderer>().sprite = podium;

    }

}
