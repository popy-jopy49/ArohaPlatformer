using UnityEngine;
using UnityEngine.Audio;
using SWAssets;

public class GameAssets : Singleton<GameAssets> {

	[Header("Prefabs")]
	public GameObject MessagePrefab;
	public GameObject BulletHoleEffect;
	public GameObject BulletDamageEffect;
	public GameObject[] Enemies;

	[Header("Ammo Prefabs")]
	public GameObject pistolAmmo;
	public GameObject shotgunAmmo;
	public GameObject lmgAmmo;
	public GameObject smgAmmo;
	public GameObject m4arAmmo;

	void Awake()
	{
		RegisterSingleton(this);
	}

	public GameObject RandomEnemy() => Enemies[Random.Range(0, Enemies.Length)];
	public GameObject RandomAmmo()
	{
		int index = Random.Range(0, 5);
		return index switch
		{
			0 => pistolAmmo,
			1 => shotgunAmmo,
			2 => lmgAmmo,
			3 => smgAmmo,
			4 => m4arAmmo,
			_ => lmgAmmo,
		};
	}

}
