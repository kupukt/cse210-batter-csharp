using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["bricks"] = new List<Actor>();

            List<Brick> _bricks = new List<Brick>();

            // TODO: Add your bricks here

            for (int x = Constants.BRICK_SPACE; x < 760; x += (Constants.BRICK_WIDTH + Constants.BRICK_SPACE))
            {
                for (int y = 0; y < 200; y += (Constants.BRICK_HEIGHT + Constants.BRICK_SPACE))
                {
                    Brick _brick = new Brick();
                    Point _point = new Point(x,y);
                    _brick.SetPosition(_point);
                    cast["bricks"].Add(_brick);
                }
            }

            

            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();
            Ball _balls = new Ball();
            

            // TODO: Add your ball here

            _balls.SetPosition(new Point(Constants.BALL_X, Constants.BALL_Y));

            cast["balls"].Add(_balls);

            // The paddle
            cast["paddle"] = new List<Actor>();
            Paddle paddle = new Paddle();

            // TODO: Add your paddle here

            paddle.SetPosition(new Point(Constants.PADDLE_X, Constants.PADDLE_Y));
            cast["paddle"].Add(paddle);

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.
            MoveActorsAction move = new MoveActorsAction();
            script["update"].Add(move);

            HandleOffScreenAction wallbounce = new HandleOffScreenAction();
            script["update"].Add(wallbounce);

            HandleCollisionAction bounce = new HandleCollisionAction();
            script["update"].Add(bounce);

            ControlActorsAction movePaddle = new ControlActorsAction();
            script["input"].Add(movePaddle);
            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
