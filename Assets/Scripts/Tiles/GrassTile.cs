﻿using DefaultNamespace;
using UnityEngine;

namespace Tiles
{
    public class GrassTile : BaseTile
    {
        public GrassTile() : base(TileSpriteContainer.GrassTileSprite)
        {

        }
        
        /// <summary>
        /// to be invoked when the Tile is clicked, handles the actions following on the click
        /// </summary>
        /// <param name="usable">the UsableItem that the Tile was clicked on with</param>
        /// <returns>a subclass of BaseTile if the Tile has to change, null if it stays the same type</returns>
        public override BaseTile Clicked(UsableItem usable) {
            BaseTile rv = null;
            if (usable != null)
            {
                base.Clicked(usable);
                if (usable.id == ItemContainer.Instance.GetItemIdByName(new string("Hoe")))
                {
                    rv = new FarmlandTile();
                }
            }
            return rv;
        }
    }
}