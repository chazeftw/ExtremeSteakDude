using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SoundController
{
    public class Sounds
    {
        // Sound members
        // List for jump sounds to get a random one for each jump
        Random r = new Random();
        private List<System.IO.Stream> jumpSounds;
        private List<System.IO.Stream> movingSounds;
        private List<System.IO.Stream> deathSounds;
        private int decider;

        public Sounds()
        {
            // Add all the sounds to their belonging list
            jumpSounds = new List<System.IO.Stream>();
            jumpSounds.Add(SoundController.Properties.Resources.Meat_jumps0);
            jumpSounds.Add(SoundController.Properties.Resources.Meat_jumps1);
            jumpSounds.Add(SoundController.Properties.Resources.Meat_jumps2);
            jumpSounds.Add(SoundController.Properties.Resources.Meat_jumps3);
            jumpSounds.Add(SoundController.Properties.Resources.Meat_jumps4);


            movingSounds = new List<System.IO.Stream>();
            movingSounds.Add(SoundController.Properties.Resources.Meat_Feet_slow0);
            movingSounds.Add(SoundController.Properties.Resources.Meat_Feet_slow1);
            movingSounds.Add(SoundController.Properties.Resources.Meat_Feet_slow2);
            movingSounds.Add(SoundController.Properties.Resources.Meat_Feet_slow3);

            deathSounds = new List<System.IO.Stream>();
            deathSounds.Add(SoundController.Properties.Resources.meat_death0);
            deathSounds.Add(SoundController.Properties.Resources.meat_death1);
            deathSounds.Add(SoundController.Properties.Resources.meat_death2);
            deathSounds.Add(SoundController.Properties.Resources.meat_death3);
            deathSounds.Add(SoundController.Properties.Resources.meat_death4);
            deathSounds.Add(SoundController.Properties.Resources.meat_death5);
            deathSounds.Add(SoundController.Properties.Resources.meat_death6);
            deathSounds.Add(SoundController.Properties.Resources.meat_death7);

        }
        System.IO.Stream _soundFile;
        Thread _soundThread;
        bool _isStopped = true;

        public bool IsFinished { get { return _isStopped; } }

        public void SoundEffect(System.IO.Stream soundFile)
        {
            _soundFile = soundFile;
        }

        public void Play()
        {
            if (!_isStopped)
                return;

            _soundThread = new Thread(PlayThread);
            _soundThread.Start();
        }

        private void PlayThread()
        {
            _isStopped = false;
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(_soundFile);
            
                player.PlaySync();
            }
            catch
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(_soundFile);
            }
            _isStopped = true;
        }
        // Functions for playing sounds6301

        public void playJumpSound()
        {
            try
            {
                decider = r.Next(0, 5);
                SoundPlayer simpleSound = new SoundPlayer(jumpSounds[decider]);
                simpleSound.Play();
                simpleSound.Stream.Position = 0;
            }
            catch (Exception)
            {

            }

        }

        public void playMovingSound()
        {
            try
            {
                decider = r.Next(0, 3);
                _soundFile = movingSounds[decider];
                Play();
                //SoundPlayer simpleSound = new SoundPlayer(movingSounds[decider]);
                //simpleSound.Play();
                //simpleSound.Stream.Position = 0;
            }
            catch (Exception)
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
            catch (Exception)
            {

            }

        }

    }
}
