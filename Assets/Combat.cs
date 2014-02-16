using UnityEngine;

public class Combat
{


	public int getModifier(int weaponType, EnemyType enemyType) {
		if (weaponType == 0) {
			if (enemyType == EnemyType.Spider) {
				return 1;
			} else if(enemyType == EnemyType.Zombie) {
				return -1;
			} else {
				return 0;
			}
		} else if (weaponType == 1) {
			if (enemyType == EnemyType.Spider) {
				return -1;
			} else if(enemyType == EnemyType.Zombie) {
				return 0;
			} else {
				return 1;
			}
		} else if (weaponType == 2) {
			if (enemyType == EnemyType.Spider) {
				return 0;
			} else if(enemyType == EnemyType.Zombie) {
				return 1;
			} else {
				return -1;
			}
		} else {
			return 0;

		}

}


