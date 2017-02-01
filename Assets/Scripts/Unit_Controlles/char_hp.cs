using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class char_hp : MonoBehaviour {

	public int HitPoints = 3;

	public Image Backdrop;
	public Image Value;

	void Start(){
		if (Backdrop) {
			Backdrop.rectTransform.sizeDelta = new Vector2(Backdrop.rectTransform.sizeDelta.x*HitPoints,Backdrop.rectTransform.sizeDelta.y);
		}
		if (Value) {
			Value.rectTransform.sizeDelta = new Vector2(Value.rectTransform.sizeDelta.x*HitPoints,Value.rectTransform.sizeDelta.y);
		}
	}

	void hit(){
		HitPoints--;
		if (Value) {
			Value.rectTransform.sizeDelta = new Vector2(Value.rectTransform.sizeDelta.x/(HitPoints+1)*HitPoints,Value.rectTransform.sizeDelta.y);
		}
		if (HitPoints <= 0) {
			Time.timeScale = 0;
		}
	}

}
