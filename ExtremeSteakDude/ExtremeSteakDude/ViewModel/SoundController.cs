using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
        private List<System.IO.Stream> deathSounds;
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

            deathSounds = new List<System.IO.Stream>();
            deathSounds.Add(ExtremeSteakDude.Properties.Resources.meat_death0);
            deathSounds.Add(ExtremeSteakDude.Properties.Resources.meat_death1);
            deathSounds.Add(ExtremeSteakDude.Properties.Resources.meat_death2);
            deathSounds.Add(ExtremeSteakDude.Properties.Resources.meat_death3);
            deathSounds.Add(ExtremeSteakDude.Properties.Resources.meat_death4);
            deathSounds.Add(ExtremeSteakDude.Properties.Resources.meat_death5);
            deathSounds.Add(ExtremeSteakDude.Properties.Resources.meat_death6);
            deathSounds.Add(ExtremeSteakDude.Properties.Resources.meat_death7);

        }

        // Functions for playing sounds

        public void playJumpSound()
        {
            try
            {
                decider = r.Next(0, 5);
                SoundPlayer simpleSound = new SoundPlayer(jumpSounds[decider]);
                simpleSound.Play();
                simpleSound.Stream.Position = 0;
            }
            catch(Exception e)
            {

            }
            
        }

        public void playMovingSound()
        {
            try
            {
                decider = r.Next(0, 4);
                SoundPlayer simpleSound = new SoundPlayer(movingSounds[decider]);
                simpleSound.Play();
                simpleSound.Stream.Position = 0;
            }
            catch(Exception e)
            {

            }
        }
        
        public void playDeathSound()
        {
            try
            {
                decider = r.Next(0, 8);
                SoundPlayer simpleSound = new SoundPlayer(deathSounds[decider]);
                simpleSound.Play();
                simpleSound.Stream.Position = 0;
            }
            catch(Exception e)
            {

            }
            
        }

    }
}
