using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManager : MonoBehaviour {

	public List<RadioStation> radioStations = new List<RadioStation> ();

	public int currStationIndex;

	public AudioSource Audio;

	public bool playAudio = false;

	public RadioStation currStation {
		get { return radioStations [currStationIndex];}
	}

	// Use this for initialization
	void Start () {
		// playAudio = false;

		//set to no radio at start
		currStationIndex = 0;
		// Audio.loop = currStation.tracks [currStation.currTrackIndex].loop;

		// Audio.clip = currStation.tracks [currStation.currTrackIndex].Audio;
		// Audio.Play();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.H)) {
			playAudio = true;
		}

		if(!playAudio) {
			return;
		}

		//check if song is playing
		if (!Audio.isPlaying) {
			
			if (currStation.loopAtEnd && currStation.tracks.IndexOf (currStation.tracks [currStation.currTrackIndex]) == currStation.tracks.Count - 1 && !currStation.tracks [currStation.currTrackIndex].loop) {
				currStation.currTrackIndex = 0;
				//set the audio object to the current song on the station
				Audio.loop = currStation.tracks [currStation.currTrackIndex].loop;
				Audio.clip = currStation.tracks [currStation.currTrackIndex].Audio;

				Audio.Play ();
			} else {

				if (currStation.tracks.IndexOf (currStation.tracks [currStation.currTrackIndex]) == currStation.tracks.Count - 1) {
					Audio.Stop ();
				} else {
					if (!currStation.tracks [currStation.currTrackIndex].loop) {
						currStation.currTrackIndex++;
					}

					//set the audio object to the current song on the station
					Audio.loop = currStation.tracks [currStation.currTrackIndex].loop;

					Audio.clip = currStation.tracks [currStation.currTrackIndex].Audio;
					Audio.Play();
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.KeypadPlus) && Audio.volume < 1) {
			Audio.volume += 0.1f;
		}

		if (Input.GetKeyDown (KeyCode.KeypadMinus) && Audio.volume > 0) {
			Audio.volume -= 0.1f;
		}

		// if (Input.GetKeyDown (KeyCode.LeftBracket) && currStationIndex > 0) {
		// 	Debug.Log ("Previous Station");
		// 	currStationIndex--;
		// 	Audio.Stop ();
		// }

		// if(Input.GetKeyDown(KeyCode.RightBracket) && currStationIndex < radioStations.Count - 1) {
		// 	Debug.Log ("Next station");
		// 	currStationIndex++;
		// 	Audio.Stop ();
		// }
	}
}

[System.Serializable]

public class RadioStation
{
	public string stationName;
	public List<RadioStationTrack> tracks = new List<RadioStationTrack>();

	public bool loopAtEnd = true;
	public int currTrackIndex;

	[System.Serializable]
	public class RadioStationTrack
	{
		public AudioClip Audio;
		public bool loop;
	}
}
