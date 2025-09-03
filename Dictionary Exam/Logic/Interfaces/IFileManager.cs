using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Exam.Logic.Interfaces
{
    internal interface IFileManager
    {
        void SaveToFile(string fileName, WordDictionary dict);
        WordDictionary LoadFromFile(string fileName);
    }
}
