using GTA.Native;
using System.IO;
using System.Linq;
using System.Collections.Generic; 

namespace RandomStart
{
    public class RandomNum
    {
        private static readonly string sRanStore = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RanNums";

        public static int ReadMyInt(string sTing)
        {
            LoggerLight.Loggers("IniSettings.ReadMyInt == " + sTing);
            int iNum = 0;
            int iTimes = 0;
            for (int i = sTing.Length - 1; i > -1; i--)
            {
                int iAdd = 0;
                string sComp = sTing.Substring(i, 1);

                if (sComp == "1")
                    iAdd = 1;
                else if (sComp == "2")
                    iAdd = 2;
                else if (sComp == "3")
                    iAdd = 3;
                else if (sComp == "4")
                    iAdd = 4;
                else if (sComp == "5")
                    iAdd = 5;
                else if (sComp == "6")
                    iAdd = 6;
                else if (sComp == "7")
                    iAdd = 7;
                else if (sComp == "8")
                    iAdd = 8;
                else if (sComp == "9")
                    iAdd = 9;

                if (iTimes == 0)
                {
                    iNum = iAdd;
                    iTimes = 1;
                }
                else
                    iNum += iAdd * iTimes;
                iTimes *= 10;
            }
            return iNum;
        }
        public static float RandFlow(float fMin, float fMax)
        {
            return Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, fMin, fMax);
        }
        public static int RandInt(int iMin, int iMax)
        {
            return Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, iMin, iMax);
        }
        public static void WriteObj(string sLogs, TextWriter tEx)
        {
            try
            {
                tEx.WriteLine(sLogs);
            }
            catch
            {

            }
        }
        public static void RandSave(string myRan, string sFile, bool bClear)
        {
            if (bClear)
            {
                using (StreamWriter tEx = File.CreateText(sFile))
                    WriteObj(myRan, tEx);
            }
            else
            {
                using (StreamWriter tEx = File.AppendText(sFile))
                    WriteObj(myRan, tEx);
            }
        }
        public static int FindRandom(int iRan, int iMin, int iMax)
        {
            LoggerLight.Loggers("RandomNum.MakeRand, sRan == " + iRan + ", iMin == " + iMin + ", iMax == " + iMax);

            if (!Directory.Exists(sRanStore))
                Directory.CreateDirectory(sRanStore);


            List<int> randList = new List<int>();
            string[] sDirect = Directory.GetFiles(sRanStore);
            string sList = "";
            int iRandX;

            if (iMin == iMax)
            {
                iRandX = iMin;
            }
            else
            {
                for (int i = 0; i < sDirect.Count(); i++)
                {
                    if (sDirect[i].Contains("Rand" + iRan + ".txt"))
                    {
                        sList = sDirect[i];
                        break; 
                    }
                }

                if (sList != "")
                {
                    string[] readNote = File.ReadAllLines(sList);
                    if (readNote[0] == "")
                    {
                        for (int i = iMin; i < iMax + 1; i++)
                            randList.Add(i);
                    }
                    else
                    {
                        for (int i = 0; i < readNote.Count(); i++)
                            randList.Add(ReadMyInt(readNote[i]));
                    }

                    for (int i = 0; i < randList.Count; i++)
                    {
                        if (iMax < randList[i] || iMin > randList[i])
                            randList.RemoveAt(i);
                    }

                    if (randList.Count == 0)
                    {
                        for (int i = iMin; i < iMax + 1; i++)
                            randList.Add(i);
                    }
                }
                else
                {
                    for (int i = iMin; i < iMax + 1; i++)
                        randList.Add(i);
                }

                int iRem = RandInt(0, randList.Count - 1);
                iRandX = randList[iRem];
                randList.RemoveAt(iRem);
            }

            if (randList.Count == 0)
            {
                for (int i = iMin; i < iMax + 1; i++)
                    randList.Add(i);
            }

            RandSave("" + randList[0], sRanStore + "/Rand" + iRan + ".txt", true);
            for (int i = 1; i < randList.Count; i++)
                RandSave("" + randList[i], sRanStore + "/Rand" + iRan + ".txt", false);

            return iRandX;
        }
    }
}
