﻿

using System.Xml.Serialization;
using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Ship  {

    
    public  string name;
    public List<Block> blocks;

    [Serializable]
    public class Block
    {

        public string name;
        public Vector2 pos; 

        public Block() { }
         
        public Block(string _name,Vector2 _pos) 
        {
            name = _name;
            pos = _pos;
        }
    }
    
      public Ship()
    {
        blocks = new List<Block>();
        name = "NoName";
    }
     
    public void addBlock(string _name, Vector2 _pos)
    {       
    blocks.Add(new Block(_name, _pos));
     }


	 
}
