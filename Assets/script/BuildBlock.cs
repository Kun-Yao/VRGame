using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildBlock : MonoBehaviour {

    public GameObject newBlock;
    public int slotIndex = 1;
    public GameObject[] blocks;

    void Start() {
        newBlock = blocks[1];
    }

    public void SetBlock(int num) {
        newBlock = blocks[num];
    }

    void Update() {
        
        //newBlock = blocks[slotIndex];
        UpdateCar();
    }

    

    void UpdateCar() {

        RaycastHit hit;
        Ray ray;
        Vector3 blockPos;
        GameObject block;
        Vector3 oldPos;

        if (Input.GetMouseButtonDown(0)) {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f)) {

                oldPos = hit.collider.gameObject.transform.position;
                blockPos = hit.point + hit.normal/2.0f;

                blockPos.x = (float) Math.Round(blockPos.x, MidpointRounding.AwayFromZero);
                blockPos.y = (float) Math.Round(blockPos.y, MidpointRounding.AwayFromZero);
                blockPos.z = (float) Math.Round(blockPos.z, MidpointRounding.AwayFromZero);

                if (newBlock == blocks[2]) {
                    
                    if (blockPos.x != oldPos.x) {
                    if (blockPos.x < 0)
                        blockPos.x += 0.3f;
                    else
                        blockPos.x -= 0.3f;
                    block = Instantiate(newBlock, blockPos, Quaternion.Euler(0, 0, 90));
                    }
                    else if (blockPos.z != oldPos.z) {
                    if (blockPos.z < 0)
                        blockPos.z += 0.3f;
                    else
                        blockPos.z -= 0.3f;
                    block = Instantiate(newBlock, blockPos, Quaternion.Euler(90, 0, 0));
                    }
                    else {
                    if (blockPos.y < 0)
                        blockPos.y += 0.3f;
                    else
                        blockPos.y -= 0.3f;
                    block = Instantiate(newBlock, blockPos, Quaternion.Euler(0, 0, 0));
                    }
                    
                }
                else
                    block = Instantiate(newBlock, blockPos, Quaternion.identity);
                block.transform.parent = this.transform;
            }   
        }
        if (Input.GetMouseButtonDown(1)) {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f)) {

                block = hit.collider.gameObject;
                if (block != blocks[0])
                    Destroy(block);
            }
        }
    }
}
