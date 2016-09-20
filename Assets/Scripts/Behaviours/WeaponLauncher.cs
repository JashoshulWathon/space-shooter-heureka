﻿using UnityEngine;
using System.Collections;

public class WeaponLauncher : MonoBehaviour {
	[SerializeField]
	GameObject _prefab;

	string _keyCode = "Fire0";

	Collectable.WeaponType _curWeapon = Collectable.WeaponType.None;

	public void setFireKeyCode(string keycode) {
		_keyCode = keycode;
	}

	public void addWeapon(Collectable collectable) {
		//TODO allow possibly multiple simultaneous weapons, based on type
		_curWeapon = collectable.Weapon;
	}

	// Update is called once per frame
	void Update () {
		bool pressed = Input.GetButtonDown(_keyCode);
		if (pressed && _curWeapon != Collectable.WeaponType.None) {
			GameObject weapon = Instantiate(_prefab) as GameObject;

			weapon.GetComponent<ProjectileBehaviour>().Source = this.gameObject;

			//TODO Select prefab based on weapontype

			MeshCollider shipCollider = GetComponent<MeshCollider>();

			Vector3 shipDirection = this.transform.forward;
			//let's try to position the projectile so it's ahead. Should take the max speed of the ship into account..
			weapon.transform.localPosition = this.transform.localPosition + 2.0f * shipCollider.bounds.extents.z * shipDirection;
			weapon.transform.localRotation = this.transform.rotation;
		}


	}
}