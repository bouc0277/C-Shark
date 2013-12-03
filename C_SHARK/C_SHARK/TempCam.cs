using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace C_SHARK
{
    class TempCam
    {
        #region fields

            Viewport viewport;

            Vector2 CurrentPosition;

            public Vector2 DestinationPosition;

            public Rectangle OuterBounds;

            public Vector2 Origin;


        #endregion


        #region Properties

            public Matrix ViewMatrix
            {
                get
                {
                    return Matrix.CreateTranslation(new Vector3(-CurrentPosition, 0)) *
                           Matrix.CreateTranslation(new Vector3(-Origin, 0));
                }
            }


        #endregion

        #region methods


            public void Update(GameTime gameTime)
            {
                float TimePassed = (float)gameTime.ElapsedGameTime.TotalSeconds;

                Vector2 nextPos = new Vector2((int)MathHelper.Lerp(CurrentPosition.X, DestinationPosition.X, 1.75f * TimePassed),
                                              (int)MathHelper.Lerp(CurrentPosition.Y, DestinationPosition.Y, 1.75f * TimePassed));

                CurrentPosition = nextPos;
            }

        public TempCam(Viewport Vp)
        {
            this.viewport = Vp;
            Origin = new Vector2(viewport.Width / 2, viewport.Height / 2 );
        }

        public void lookAt(Vector2 targetPosition)
        {

            DestinationPosition = targetPosition - Origin;
        }

        public void CameraPushBack(int push)
        {
            push = (push * +1);
            DestinationPosition.X = DestinationPosition.X + push;
        }


        #endregion



    }
}
