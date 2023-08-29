using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pScript
{
    public class FlashAnim : EditCommands
    {
        int reps = 0;
        bool endOnOdd = false;
        Color flashColor = Color.Black;
        Color origColor = Color.Black;

        int timer = 0;
        public FlashAnim(int interval, int reps, bool endOnFlashColor, Color flashColor)
        {
            DoFlash(interval, reps, endOnFlashColor, flashColor);
        }

        private void DoFlash(int interval, int reps, bool endOnOdd, Color color)
        {
            this.reps = reps;
            this.endOnOdd = endOnOdd;
            flashColor = color;
            FlashTimer.Interval = interval;
            FlashTimer.Tick += FlashTick;
            FlashTimer.Enabled = true;
        }

        private void FlashTick(object sender, EventArgs e)
        {
            if (timer < reps)
            {
                if (timer % 2 == 0)
                {

                }
                timer++;
            }
            else
            {
                FlashTimer.Enabled = false;
                if (endOnOdd)
                {

                }
            }
        }
    }
}
