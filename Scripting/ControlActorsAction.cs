using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp.Scripting
{
    public class ControlActorsAction: Action
    {
        InputService _input;

        public ControlActorsAction()
        {
            _input = new InputService();
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
           Point direction = _input.GetDirection();

           Actor paddle = cast["paddle"][0];

           Point velocity = direction.Scale(Constants.PADDLE_SPEED);
           paddle.SetVelocity(velocity);
        }
    }
}