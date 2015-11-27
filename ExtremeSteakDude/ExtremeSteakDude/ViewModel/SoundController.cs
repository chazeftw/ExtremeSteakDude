using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.ViewModel
{
    class SoundController
    {
        // Sound members
        // List for jump sounds to get a random one for each jump
        Random r = new Random();
        private List<System.IO.Stream> jumpSounds;
        private List<System.IO.Stream> movingSounds;
        private int decider;

        public SoundController()
        {
            // Add all the sounds to their belonging list
            jumpSounds = new List<System.IO.Stream>();
            jumpSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_jumps0);
            jumpSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_jumps1);
            jumpSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_jumps2);
            jumpSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_jumps3);
            jumpSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_jumps4);


            movingSounds = new List<System.IO.Stream>();
            movingSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_Feet_slow0);
            movingSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_Feet_slow1);
            movingSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_Feet_slow2);
            movingSounds.Add(ExtremeSteakDude.Properties.Resources.Meat_Feet_slow3);
        }

        public void playJumpSound()
        {
            decider = r.Next(0, 5);
            SoundPlayer simpleSound = new SoundPlayer(jumpSounds[decider]);
            simpleSound.Play();
            simpleSound.Stream.Position = 0;
        }

        public void playMovingSound()
        {
            decider = r.Next(0, 4);
            SoundPlayer simpleSound = new SoundPlayer(movingSounds[decider]);
            simpleSound.Play();
            simpleSound.Stream.Position = 0;
        }
        
    }
}
