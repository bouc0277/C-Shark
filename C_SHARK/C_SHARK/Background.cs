using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace C_SHARK
{
    class Background
    {
        #region Fields

            //This is the sprite for the tiles
            Texture2D Sprite;

            //This is the array for the tiles.
            char[,] Tiles;
 
            //
            Rectangle SourceRectangle = new Rectangle(0, 0, 32, 32);

            //
            Rectangle DestinationRectangle = new Rectangle(0, 0, 32, 32);

        #endregion

        #region Properties

        #endregion 

        #region Methods

            //This loads the content 
            public void LoadContent(ContentManager contentManager)
            {
                Sprite = contentManager.Load<Texture2D>("tiles");
            }

            //
            public void SetCurrentMap(char[,] tilePosition)
            {
                Tiles = tilePosition;
            }

            //Draws the tile at the right spot
            public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
            {
                for (int i = 0; i < Tiles.GetLength(0); i++)
                {
                    for (int j = 0; j < Tiles.GetLength(1); j++)
                    {
                        SourceRectangle.X = (Tiles[i, j]-34) * 32;
                        DestinationRectangle.X = j * 32;
                        DestinationRectangle.Y = i * 32;

                        spriteBatch.Draw(Sprite,
                                         DestinationRectangle,
                                         SourceRectangle,
                                         Color.White);
                        
                    }
                }
            }

            public char[,] getTileArray()
            {
                return Tiles;
            }


        #endregion



    }
}
