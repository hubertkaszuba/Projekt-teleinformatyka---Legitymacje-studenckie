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
        private int listLenght;
        private CancellationTokenSource ctk;

        public StudentRecorder() : base()
        {
            listLenght = lStudInfo.Count;
        }

        public void OpenRecorder(int waittime)
        {
            ctk = new CancellationTokenSource();

            CancellationToken token = ctk.Token;
            state = State.READING;
            ThreadPool.QueueUserWorkItem(Listening, new object[] { waittime, token });
        }

        public int GetListLength()
        {
            return listLenght;
        }

        public void StopRecorder()
        {
            if (state == State.READING)
                ctk.Cancel();
        }

        private void Listening(object state)
        {
            int waitTime = (int)((object[])state)[0];
            CancellationToken token = (CancellationToken)((object[])state)[1];
            Stopwatch start = new Stopwatch();

            start.Start();
            while (start.Elapsed.TotalSeconds < waitTime && !token.IsCancellationRequested)
            {
                StudentInfo temp;

                if (Connect())
                {
                    temp = ReadData();
                    CheckUnique(temp);
                }
            }
            start.Stop();
            this.state = State.INITIALIZED;
        }

        private void CheckUnique(StudentInfo temp)
        {
            string lastAddedIndex = temp.index;
            IEnumerable<StudentInfo> studentInfos = lStudInfo.Where(stud => stud.index.Contains(lastAddedIndex));

            if (studentInfos.Count() == 0)
                lStudInfo.Add(temp);
        }

        public StudentInfo GetStudentByIndex(string index)
        {
            return lStudInfo.Where(stud => stud.index == index).FirstOrDefault();
        }

        public void UpdateStudent(StudentInfo stud)
        {
            StudentInfo oldStudent = lStudInfo.Where(s => s.index == stud.index).Single();
            int index = lStudInfo.IndexOf(oldStudent);
            if (index != -1)
                lStudInfo[index] = stud;
        }
    }
}
