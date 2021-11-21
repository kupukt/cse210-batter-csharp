using System;

namespace cse210_batter_csharp.Casting
{
    public class Ball: Actor
    {
        public Ball()
        {
            SetWidth(Constants.BALL_WIDTH);
            SetHeight(Constants.BALL_HEIGHT);
            SetImage(Constants.IMAGE_BALL);
            Point velocity = new Point(3,-5);
            SetVelocity(velocity);
        }
        
    }
}