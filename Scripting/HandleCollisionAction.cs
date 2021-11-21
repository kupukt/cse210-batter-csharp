using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp.Scripting
{
    public class HandleCollisionAction: Action
    {
        PhysicsService physics = new PhysicsService();

        HandleOffScreenAction bounce = new HandleOffScreenAction();

        AudioService audio = new AudioService();

        public HandleCollisionAction()
        {
            physics = new PhysicsService();
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor paddle = cast["paddle"][0];
            Actor balls = cast["balls"][0];
            List<Actor> bricks = cast["bricks"];
            List<Actor> removeBricks = new List<Actor>();

            foreach(Actor ball in cast["balls"])
            {
                foreach(Actor brick in bricks)
                {
                    if(physics.IsCollision(ball, brick))
                    {
                        bounce.bounceVertical(ball);
                        removeBricks.Add(brick);
                        audio.PlaySound(Constants.SOUND_BOUNCE);

                    }
                }
                
                if(physics.IsCollision(ball,paddle))
                {
                    bounce.bounceVertical(ball);
                    audio.PlaySound(Constants.SOUND_BOUNCE);
                }
            }
            
            foreach(Actor brick in removeBricks)
            {
                cast["bricks"].Remove(brick);
            }
        }
    }
}