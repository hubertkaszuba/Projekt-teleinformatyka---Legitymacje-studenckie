using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pt_legitymacjestudenckie.SmartCardRelated
{
    class StudentRecorder : CardReader
    {
        int listLenght;

        public StudentRecorder() : base()
        {
            listLenght = lStudInfo.Count;
        }

        public void OpenRecorder(int waittime)
        {
            state = State.READING;
            ThreadPool.QueueUserWorkItem(Listening, new object[] { waittime });
        }

        public int GetListLength()
        {
            return listLenght;
        }

        private void Listening(object state)
        {
            int waitTime = (int)((object[])state)[0];
            Stopwatch start = new Stopwatch();

            start.Start();
            while (start.Elapsed.TotalSeconds < waitTime)
            {
                if (Connect())
                    ReadData();
            }
            start.Stop();
            this.state = State.INITIALIZED;
        }
    }
}
