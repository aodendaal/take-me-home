using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MouseClick();
	}

    private void MouseClick()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f, 1 << 5))
            {
                var s = hitInfo.collider.gameObject.GetComponent<SwitchBehaviour>();

                var target = hitInfo.collider.transform.Find("StandNode").position;

                if (transform.position != target)
                {
                    LeanTween
                        .move(gameObject, target, 1f)
                        .setOnComplete(() => s.Toggle());
                }
                else
                {
                    s.Toggle();
                }
            }
        }
    }
}
