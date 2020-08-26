/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
	float _positionRange;
	int _asteroidAmount;
	[SerializeField]int _minAsteroids;
	[SerializeField]int _maxAsteroids;
    [SerializeField]float _minSpawnDistance;
	[SerializeField]float _maxSpawnDistance;
	[SerializeField]int _maxScale;

	Vector3 _spawnPosition;
	Vector3 _spawnRotation;

	[SerializeField]GameObject _asteroid;

	void Start () {
		_asteroidAmount = Random.Range(_minAsteroids, _maxAsteroids);
		SpawnAsteroids(_asteroidAmount);
	}

	void SpawnAsteroids(int _asteroidNumber){
		for(int i = 0; i < _asteroidNumber; i++){	
			_positionRange = Random.Range(_minSpawnDistance, _maxSpawnDistance);
			_spawnPosition = new Vector3(Random.Range(-_positionRange, _positionRange), 
			Random.Range(-_positionRange, _positionRange), Random.Range(-_positionRange, _positionRange));
			//if(any gameObject in scene transform.position * MaxScale is within MaxScale * spawnPosition){
				//i--;
			//}
			//else{
				Instantiate(_asteroid, _spawnPosition, Quaternion.identity, transform);
				//int scale = Random.Range(1, maxScale);
				//asteroid.transform.localScale = new Vector3(scale, scale, scale);
			//}
		}
	}
}