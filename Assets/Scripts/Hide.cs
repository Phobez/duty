﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

    private SpriteRenderer sprRend;

    private Vector2 currDir;
    private Vector3 hidePos;

    private bool isHiding;
    private bool isFacingRight;
    private bool isHidingBehind;

    private int hideableLayer;
    
	// Use this for initialization
	void Start () {
        sprRend = GetComponent<SpriteRenderer>();

        isHiding = false;

        hideableLayer = LayerMask.GetMask("Hideable");
	}
	
	// Update is called once per frame
	void Update () {
        isFacingRight = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().GetM_FacingRight();

        if (isFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 1.0f, hideableLayer);

        if (hit)
        {
            if (hit.transform.gameObject.tag == "Hideable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isHiding)
                    {
                        sprRend.enabled = true;
                        isHiding = false;
                        isHidingBehind = false;
                    }
                    else
                    {
                        sprRend.enabled = false;
                        isHiding = true;
                        isHidingBehind = true;
                        hidePos = transform.position;
                    }
                }
            }
            else if (hit.transform.gameObject.tag == "HideBehind")
            {
                isHiding = true;
            }
        }
        else
        {
            isHiding = false;
        }

        if (isHidingBehind)
        {
            transform.position = hidePos;
        }

	}

    public bool GetIsHiding()
    {
        return isHiding;
    }
}
