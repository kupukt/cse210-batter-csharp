using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    public class MoveActorsAction: Action
    {
        public MoveActorsAction()
        {

        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values)
            {
                foreach(Actor actor in group)
                {
                    moveActors(actor);
                }
            }
        }

        private void moveActors(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();

            int dx = actor.GetVelocity().GetX();
            int dy = actor.GetVelocity().GetY();

            int newX = (x+dx) % Constants.MAX_X;
            int newY = (y+dy) % Constants.MAX_Y;

            actor.SetPosition(new Point(newX, newY));
        }


    }
}