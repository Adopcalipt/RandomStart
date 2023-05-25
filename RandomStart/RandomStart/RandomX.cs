using GTA;
using GTA.Native;
using System.IO;
using RandomStart.Classes;
using System.Xml.Serialization;
using System.Collections.Generic; 

namespace RandomStart
{
    public class RandomX
    {
        private static readonly string sRanStore = "" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/RanNums";

        public static float RandFlow(float fMin, float fMax)
        {
            float f = fMin;
            if (fMin < fMax)
                f = Function.Call<int>(Hash.GET_RANDOM_FLOAT_IN_RANGE, fMin, fMax);
            return f;
        }
        public static int RandInt(int iMin, int iMax)
        {
            return Function.Call<int>(Hash.GET_RANDOM_INT_IN_RANGE, iMin, iMax);
        }
        public static int FindRandom(string id, int iMin, int iMax)
        {
            LoggerLight.Loggers("FindRandom, id == " + id + ", iMin == " + iMin + ", iMax == " + iMax);

            if (!Directory.Exists(sRanStore))
                Directory.CreateDirectory(sRanStore);

            List<int> MyNums = new List<int>();

            int iRandX;

            if (iMin == iMax)
                iRandX = iMin;
            else
            {
                if (File.Exists(sRanStore + "/" + id + ".xml"))
                {
                    RandX THisNum = LoadXmlRand(sRanStore + "/" + id + ".xml");

                    bool newList = false;
                    for (int i = 0; i < THisNum.RandNumbers.Count; i++)
                    {
                        if (THisNum.RandNumbers[i] > iMax)
                        {
                            newList = true;
                            break;
                        }
                        else if (THisNum.RandNumbers[i] < iMin)
                        {
                            newList = true;
                            break;
                        }
                    }

                    if (THisNum.RandNumbers.Count > 0 && !newList)
                        MyNums = THisNum.RandNumbers;
                    else
                        MyNums = NewList(iMin, iMax);
                }
                else
                    MyNums = NewList(iMin, iMax);

                int iRem = RandInt(0, MyNums.Count - 1);
                iRandX = MyNums[iRem];
                MyNums.RemoveAt(iRem);

                ReWiteXml(id, MyNums);
            }
            return iRandX;
        }
        public static int FindRandomList(string id, List<int> MyNums)
        {
            LoggerLight.Loggers("FindRandomList, id == " + id);

            if (!Directory.Exists(sRanStore))
                Directory.CreateDirectory(sRanStore);

            int iRandX;

            if (File.Exists(sRanStore + "/" + id + ".xml"))
            {
                bool newList = false;
                RandX THisNum = LoadXmlRand(sRanStore + "/" + id + ".xml");

                for (int i = 0; i < THisNum.RandNumbers.Count; i++)
                {
                    if (MyNums.Contains(THisNum.RandNumbers[i]))
                    {

                    }
                    else
                    {
                        newList = true;
                        break;
                    }
                }

                if (THisNum.RandNumbers.Count > 0 && !newList)
                    MyNums = THisNum.RandNumbers;
            }

            int iRem = RandInt(0, MyNums.Count - 1);
            iRandX = MyNums[iRem];
            MyNums.RemoveAt(iRem);

            ReWiteXml(id, MyNums);
            return iRandX;
        }
        private static List<int> NewList(int iMin, int iMax)
        {
            LoggerLight.Loggers("NewList, iMin == " + iMin + ", iMax == " + iMax);
            List<int> MyNums = new List<int>();
            for (int i = iMin; i < iMax + 1; i++)
                MyNums.Add(i);
            return MyNums;
        }
        public static void ReWiteXml(string id, List<int> MyNums)
        {
            RandX MyNum = new RandX();
            MyNum.RandNumbers = MyNums;
            SaveXmlRand(MyNum, sRanStore + "/" + id + ".xml");
        }
        public static void SaveXmlRand(RandX config, string fileName)
        {
            LoggerLight.Loggers("SaveXmlRand : fileName :" + fileName);

            XmlSerializer xml = new XmlSerializer(typeof(RandX));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public static RandX LoadXmlRand(string fileName)
        {
            LoggerLight.Loggers("LoadXmlRand : " + fileName);

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(RandX));
                using (StreamReader sr = new StreamReader(fileName))
                {
                    return (RandX)xml.Deserialize(sr);
                }
            }
            catch
            {
                UI.Notify("Catch ; Corupt File ; ~r~" + fileName);
                return new RandX();
            }
        }
    }
}
