using System;
namespace TapTheDot
{
    public class SharedResources
    {
        private int score;
        private int level;

        public SharedResources(int score, int level)
        {
            this.score = score;
            this.level = level;
        }


        public SharedResources() { }


        public int getScore()
        {
            return this.score;
        }


        public void setScore(int score)
        {
            this.score = score;
        }


        public int getLevel()
        {
            return this.level;
        }


        public void setLevel(int level)
        {
            this.level = level;
        }


        public void incrementScore()
        {
            this.score++;
        }


        public void incrementLevel()
        {
            this.level++;
        }

        /*
        public void defaultValues()
        {
            this.score = 0;
            this.level = 1;
        }
        */
    }
}
