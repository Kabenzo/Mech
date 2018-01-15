using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {

	public new string name;
	public string description;

	public Sprite icon;

	public GameObject projectile;

	public int damage;

	//0 Is Gun, 1 Is Sword, 2 Is Shield
	public int weaponID;

	public float fireRate;
	public float fireSpeed;
	public float turnSpeed;

	public int ammo;

}
