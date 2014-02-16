using UnityEngine;

public class Combat
{


		public static int getModifier (WeaponType weaponType, EnemyType enemyType)
		{
				if (weaponType == WeaponType.BARE_HANDS) {
						if (enemyType == EnemyType.Spider) {
								return 1;
						} else if (enemyType == EnemyType.Zombie) {
								return -1;
						} else {
								return 0;
						}
				} else if (weaponType == WeaponType.STAFF) {
						if (enemyType == EnemyType.Spider) {
								return -1;
						} else if (enemyType == EnemyType.Zombie) {
								return 0;
						} else {
								return 1;
						}
				} else if (weaponType == WeaponType.SWORD) {
						if (enemyType == EnemyType.Spider) {
								return 0;
						} else if (enemyType == EnemyType.Zombie) {
								return 1;
						} else {
								return -1;
						}
				} else {
						return 0;

				}
		}

}


