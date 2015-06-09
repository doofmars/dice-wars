using System;
using System.Collections.Generic;
using System.Text;

namespace HexagonalTest
{
    public class DTOClass{

        private string name;
        private int enemyCount;
        private string fieldSize;
        private System.Diagnostics.Stopwatch time;
        private DateTime startTimer;
        private string timeAsString;

        public void setName(string name)
        {
            this.name = name;
        }

        public void setEnemyCount(int enemy)
        {
            this.enemyCount = enemy;
        }

        public void setFieldSize(string size)
        {
            this.fieldSize = size;
        }

        public void setStopwatch(System.Diagnostics.Stopwatch time)
        {
            this.time = time;
        }
        //function to start the timer 
        public void startTimerGo()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            setStopwatch(stopwatch);

        }
        public void stopTimer()
        {
            System.Diagnostics.Stopwatch stopwatchEnd = getStopwatch();
            stopwatchEnd.Stop();
            setTimeAsString(stopwatchEnd.Elapsed.ToString());
        }
        public void setTimeAsString(string timeX)
        {
            this.timeAsString = timeX;
        }

        //----------------------getter from the DTO Object
        public string getName()
        {
            return name;
        }
        public int getEnemyCount()
        {
            return enemyCount;
        }
        public string getFieldSize()
        {
            return fieldSize;
        }
        public string getTime()
        {
            return timeAsString;
        }
        public System.Diagnostics.Stopwatch getStopwatch()
        {
            return this.time;
        }
        
    }
}
