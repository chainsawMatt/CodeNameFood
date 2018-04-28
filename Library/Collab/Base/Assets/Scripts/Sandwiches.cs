using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SandwhichSpace
{
    public class Sandwiches : MonoBehaviour
    {

        public int scorePerTop = 1;
        public int Stack;
        public int samKey;
        private int ID;

        IsMatchSign isMatch;
        ScoreBoard scoreBoard;

        //  Sandwiches Sprite Arrays
        public Sprite[] OneTops = new Sprite[0];//7
        public Sprite[] TwoTops = new Sprite[0];//28
        public Sprite[] ThreeTops = new Sprite[0];//84
        public Sprite[] FourTops = new Sprite[0];//209
        public Sprite[] FiveTops = new Sprite[0];//463

        //  Sandwhich Dicks
        public Dictionary<int, Sprite> OneTopsDick = new Dictionary<int, Sprite>();
        public Dictionary<int, Sprite> TwoTopsDick = new Dictionary<int, Sprite>();
        public Dictionary<int, Sprite> ThreeTopsDick = new Dictionary<int, Sprite>();
        public Dictionary<int, Sprite> FourTopsDick = new Dictionary<int, Sprite>();
        public Dictionary<int, Sprite> FiveTopsDick = new Dictionary<int, Sprite>();
        public GameObject Toppings;
        public GameObject SamPrefab;

        int length;
        public Vector2 samPos;
        public Vector2 newSamPos;
        public Vector2 temp = new Vector2(1.5f, 0);
        public int listPos;

        public GameObject[] caughtToppingsgo;
        public int caughtToppingsint;

        public List<GameObject> finishedSams = new List<GameObject>();
        public GameObject FinishedSam;
        Sprite Sandwhich;
        public bool firstSam;

        private int numTops;



        public void Start()
        {
            scoreBoard = FindObjectOfType<ScoreBoard>();
            isMatch = FindObjectOfType<IsMatchSign>();

            /*      Load the Dictionaries - samKey(int) ---> Sprite Array(Sprite)
            *       We may need to change the way we load dictionaries later, depending on if loading the dictionary is faster to do at Start()
            *       or dynamically in FindSam()
            */


            //      Initialize one-topping dictionary    
            OneTopsDick.Add(0, OneTops[0]);
            OneTopsDick.Add(1, OneTops[1]);
            OneTopsDick.Add(2, OneTops[2]);
            OneTopsDick.Add(3, OneTops[3]);
            OneTopsDick.Add(4, OneTops[4]);
            OneTopsDick.Add(5, OneTops[5]);
            OneTopsDick.Add(6, OneTops[6]);

            //      Initalize two-topping dictionary
            TwoTopsDick.Add(00, TwoTops[0]); TwoTopsDick.Add(01, TwoTops[1]); TwoTopsDick.Add(02, TwoTops[2]); TwoTopsDick.Add(03, TwoTops[3]);
            TwoTopsDick.Add(04, TwoTops[4]); TwoTopsDick.Add(05, TwoTops[5]); TwoTopsDick.Add(06, TwoTops[6]); TwoTopsDick.Add(11, TwoTops[7]);
            TwoTopsDick.Add(12, TwoTops[8]); TwoTopsDick.Add(13, TwoTops[9]); TwoTopsDick.Add(14, TwoTops[10]); TwoTopsDick.Add(15, TwoTops[11]);
            TwoTopsDick.Add(16, TwoTops[12]); TwoTopsDick.Add(22, TwoTops[13]); TwoTopsDick.Add(23, TwoTops[14]); TwoTopsDick.Add(24, TwoTops[15]);
            TwoTopsDick.Add(25, TwoTops[16]); TwoTopsDick.Add(26, TwoTops[17]); TwoTopsDick.Add(33, TwoTops[18]); TwoTopsDick.Add(34, TwoTops[19]);
            TwoTopsDick.Add(35, TwoTops[20]); TwoTopsDick.Add(36, TwoTops[21]); TwoTopsDick.Add(44, TwoTops[22]); TwoTopsDick.Add(45, TwoTops[23]);
            TwoTopsDick.Add(46, TwoTops[24]); TwoTopsDick.Add(55, TwoTops[25]); TwoTopsDick.Add(56, TwoTops[26]); TwoTopsDick.Add(66, TwoTops[27]);

            //      Initialize Three-Topping Dictionary -- Click the plus sign to "Uncollapse" the block of code, it looked real ugly 

            #region ThreeTopsDick.Add(000, ThreeTops[0]);ThreeTopsDick.Add(001 , ThreeTops[1]);ThreeTopsDick.Add(002 , ThreeTops[2]);ThreeTopsDick.Add(003 , ThreeTops[3]);
            ThreeTopsDick.Add(004, ThreeTops[4]); ThreeTopsDick.Add(005, ThreeTops[5]); ThreeTopsDick.Add(006, ThreeTops[6]); ThreeTopsDick.Add(011, ThreeTops[7]);
            ThreeTopsDick.Add(012, ThreeTops[8]); ThreeTopsDick.Add(013, ThreeTops[9]); ThreeTopsDick.Add(014, ThreeTops[10]); ThreeTopsDick.Add(015, ThreeTops[11]);
            ThreeTopsDick.Add(016, ThreeTops[12]); ThreeTopsDick.Add(022, ThreeTops[13]); ThreeTopsDick.Add(023, ThreeTops[14]); ThreeTopsDick.Add(024, ThreeTops[15]);
            ThreeTopsDick.Add(025, ThreeTops[16]); ThreeTopsDick.Add(026, ThreeTops[17]); ThreeTopsDick.Add(033, ThreeTops[18]); ThreeTopsDick.Add(034, ThreeTops[19]);
            ThreeTopsDick.Add(035, ThreeTops[20]); ThreeTopsDick.Add(036, ThreeTops[21]); ThreeTopsDick.Add(044, ThreeTops[22]); ThreeTopsDick.Add(045, ThreeTops[23]);
            ThreeTopsDick.Add(046, ThreeTops[24]); ThreeTopsDick.Add(055, ThreeTops[25]); ThreeTopsDick.Add(056, ThreeTops[26]); ThreeTopsDick.Add(066, ThreeTops[27]);
            ThreeTopsDick.Add(111, ThreeTops[28]); ThreeTopsDick.Add(112, ThreeTops[29]); ThreeTopsDick.Add(113, ThreeTops[30]); ThreeTopsDick.Add(114, ThreeTops[31]);
            ThreeTopsDick.Add(115, ThreeTops[32]); ThreeTopsDick.Add(116, ThreeTops[33]); ThreeTopsDick.Add(122, ThreeTops[34]); ThreeTopsDick.Add(123, ThreeTops[35]);
            ThreeTopsDick.Add(124, ThreeTops[36]); ThreeTopsDick.Add(125, ThreeTops[37]); ThreeTopsDick.Add(126, ThreeTops[38]); ThreeTopsDick.Add(134, ThreeTops[39]);
            ThreeTopsDick.Add(133, ThreeTops[40]); ThreeTopsDick.Add(135, ThreeTops[41]); ThreeTopsDick.Add(136, ThreeTops[42]); ThreeTopsDick.Add(144, ThreeTops[43]);
            ThreeTopsDick.Add(145, ThreeTops[44]); ThreeTopsDick.Add(146, ThreeTops[45]); ThreeTopsDick.Add(155, ThreeTops[46]); ThreeTopsDick.Add(156, ThreeTops[47]);
            ThreeTopsDick.Add(166, ThreeTops[48]); ThreeTopsDick.Add(222, ThreeTops[49]); ThreeTopsDick.Add(223, ThreeTops[50]); ThreeTopsDick.Add(224, ThreeTops[51]);
            ThreeTopsDick.Add(225, ThreeTops[52]); ThreeTopsDick.Add(226, ThreeTops[53]); ThreeTopsDick.Add(233, ThreeTops[54]); ThreeTopsDick.Add(234, ThreeTops[55]);
            ThreeTopsDick.Add(235, ThreeTops[56]); ThreeTopsDick.Add(236, ThreeTops[57]); ThreeTopsDick.Add(244, ThreeTops[58]); ThreeTopsDick.Add(245, ThreeTops[59]);
            ThreeTopsDick.Add(246, ThreeTops[60]); ThreeTopsDick.Add(255, ThreeTops[61]); ThreeTopsDick.Add(256, ThreeTops[62]); ThreeTopsDick.Add(266, ThreeTops[63]);
            ThreeTopsDick.Add(333, ThreeTops[64]); ThreeTopsDick.Add(334, ThreeTops[65]); ThreeTopsDick.Add(335, ThreeTops[66]); ThreeTopsDick.Add(336, ThreeTops[67]);
            ThreeTopsDick.Add(344, ThreeTops[68]); ThreeTopsDick.Add(345, ThreeTops[69]); ThreeTopsDick.Add(346, ThreeTops[70]); ThreeTopsDick.Add(355, ThreeTops[71]);
            ThreeTopsDick.Add(356, ThreeTops[72]); ThreeTopsDick.Add(366, ThreeTops[73]); ThreeTopsDick.Add(444, ThreeTops[74]); ThreeTopsDick.Add(445, ThreeTops[75]);
            ThreeTopsDick.Add(446, ThreeTops[76]); ThreeTopsDick.Add(455, ThreeTops[77]); ThreeTopsDick.Add(456, ThreeTops[78]); ThreeTopsDick.Add(466, ThreeTops[79]);
            ThreeTopsDick.Add(555, ThreeTops[80]); ThreeTopsDick.Add(556, ThreeTops[81]); ThreeTopsDick.Add(566, ThreeTops[82]); ThreeTopsDick.Add(666, ThreeTops[83]);
            #endregion

            //      Initalize Four-Topping Dictionary
            #region FourTopsDick.Add(0000),FourTops[0]);
            FourTopsDick.Add(0001, FourTops[1]);
            FourTopsDick.Add(0002, FourTops[2]);
            FourTopsDick.Add(0003, FourTops[3]);
            FourTopsDick.Add(0004, FourTops[4]);
            FourTopsDick.Add(0005, FourTops[5]);
            FourTopsDick.Add(0006, FourTops[6]);
            FourTopsDick.Add(0011, FourTops[7]);
            FourTopsDick.Add(0012, FourTops[8]);
            FourTopsDick.Add(0013, FourTops[9]);
            FourTopsDick.Add(0014, FourTops[10]);
            FourTopsDick.Add(0015, FourTops[11]);
            FourTopsDick.Add(0016, FourTops[12]);
            FourTopsDick.Add(0022, FourTops[13]);
            FourTopsDick.Add(0023, FourTops[14]);
            FourTopsDick.Add(0024, FourTops[15]);
            FourTopsDick.Add(0025, FourTops[16]);
            FourTopsDick.Add(0026, FourTops[17]);
            FourTopsDick.Add(0033, FourTops[18]);
            FourTopsDick.Add(0034, FourTops[19]);
            FourTopsDick.Add(0035, FourTops[20]);
            FourTopsDick.Add(0036, FourTops[21]);
            FourTopsDick.Add(0044, FourTops[22]);
            FourTopsDick.Add(0045, FourTops[23]);
            FourTopsDick.Add(0046, FourTops[24]);
            FourTopsDick.Add(0055, FourTops[25]);
            FourTopsDick.Add(0056, FourTops[26]);
            FourTopsDick.Add(0066, FourTops[27]);
            FourTopsDick.Add(0111, FourTops[28]);
            FourTopsDick.Add(0112, FourTops[29]);
            FourTopsDick.Add(0113, FourTops[30]);
            FourTopsDick.Add(0114, FourTops[31]);
            FourTopsDick.Add(0115, FourTops[32]);
            FourTopsDick.Add(0116, FourTops[33]);
            FourTopsDick.Add(0122, FourTops[34]);
            FourTopsDick.Add(0123, FourTops[35]);
            FourTopsDick.Add(0124, FourTops[36]);
            FourTopsDick.Add(0125, FourTops[37]);
            FourTopsDick.Add(0126, FourTops[38]);
            FourTopsDick.Add(0133, FourTops[39]);
            FourTopsDick.Add(0134, FourTops[40]);
            FourTopsDick.Add(0135, FourTops[41]);
            FourTopsDick.Add(0136, FourTops[42]);
            FourTopsDick.Add(0144, FourTops[43]);
            FourTopsDick.Add(0145, FourTops[44]);
            FourTopsDick.Add(0146, FourTops[45]);
            FourTopsDick.Add(0155, FourTops[46]);
            FourTopsDick.Add(0156, FourTops[47]);
            FourTopsDick.Add(0166, FourTops[48]);
            FourTopsDick.Add(0222, FourTops[49]);
            FourTopsDick.Add(0223, FourTops[50]);
            FourTopsDick.Add(0224, FourTops[51]);
            FourTopsDick.Add(0225, FourTops[52]);
            FourTopsDick.Add(0226, FourTops[53]);
            FourTopsDick.Add(0233, FourTops[54]);
            FourTopsDick.Add(0234, FourTops[55]);
            FourTopsDick.Add(0235, FourTops[56]);
            FourTopsDick.Add(0236, FourTops[57]);
            FourTopsDick.Add(0244, FourTops[58]);
            FourTopsDick.Add(0245, FourTops[59]);
            FourTopsDick.Add(0246, FourTops[60]);
            FourTopsDick.Add(0255, FourTops[61]);
            FourTopsDick.Add(0256, FourTops[62]);
            FourTopsDick.Add(0266, FourTops[63]);
            FourTopsDick.Add(0333, FourTops[64]);
            FourTopsDick.Add(0334, FourTops[65]);
            FourTopsDick.Add(0335, FourTops[66]);
            FourTopsDick.Add(0336, FourTops[67]);
            FourTopsDick.Add(0344, FourTops[68]);
            FourTopsDick.Add(0345, FourTops[69]);
            FourTopsDick.Add(0346, FourTops[70]);
            FourTopsDick.Add(0355, FourTops[71]);
            FourTopsDick.Add(0356, FourTops[72]);
            FourTopsDick.Add(0366, FourTops[73]);
            FourTopsDick.Add(0444, FourTops[74]);
            FourTopsDick.Add(0445, FourTops[75]);
            FourTopsDick.Add(0446, FourTops[76]);
            FourTopsDick.Add(0455, FourTops[77]);
            FourTopsDick.Add(0456, FourTops[78]);
            FourTopsDick.Add(0466, FourTops[79]);
            FourTopsDick.Add(0555, FourTops[80]);
            FourTopsDick.Add(0556, FourTops[81]);
            FourTopsDick.Add(0566, FourTops[82]);
            FourTopsDick.Add(0666, FourTops[83]);
            FourTopsDick.Add(1111, FourTops[84]);
            FourTopsDick.Add(1112, FourTops[85]);
            FourTopsDick.Add(1113, FourTops[86]);
            FourTopsDick.Add(1114, FourTops[87]);
            FourTopsDick.Add(1115, FourTops[88]);
            FourTopsDick.Add(1116, FourTops[89]);
            FourTopsDick.Add(1122, FourTops[90]);
            FourTopsDick.Add(1123, FourTops[91]);
            FourTopsDick.Add(1124, FourTops[92]);
            FourTopsDick.Add(1125, FourTops[93]);
            FourTopsDick.Add(1126, FourTops[94]);
            FourTopsDick.Add(1133, FourTops[95]);
            FourTopsDick.Add(1134, FourTops[96]);
            FourTopsDick.Add(1135, FourTops[97]);
            FourTopsDick.Add(1136, FourTops[98]);
            FourTopsDick.Add(1144, FourTops[99]);
            FourTopsDick.Add(1145, FourTops[100]);
            FourTopsDick.Add(1146, FourTops[101]);
            FourTopsDick.Add(1155, FourTops[102]);
            FourTopsDick.Add(1156, FourTops[103]);
            FourTopsDick.Add(1166, FourTops[104]);
            FourTopsDick.Add(1222, FourTops[105]);
            FourTopsDick.Add(1223, FourTops[106]);
            FourTopsDick.Add(1224, FourTops[107]);
            FourTopsDick.Add(1225, FourTops[108]);
            FourTopsDick.Add(1226, FourTops[109]);
            FourTopsDick.Add(1233, FourTops[110]);
            FourTopsDick.Add(1234, FourTops[111]);
            FourTopsDick.Add(1235, FourTops[112]);
            FourTopsDick.Add(1236, FourTops[113]);
            FourTopsDick.Add(1244, FourTops[114]);
            FourTopsDick.Add(1245, FourTops[115]);
            FourTopsDick.Add(1246, FourTops[116]);
            FourTopsDick.Add(1255, FourTops[117]);
            FourTopsDick.Add(1256, FourTops[118]);
            FourTopsDick.Add(1266, FourTops[119]);
            FourTopsDick.Add(1333, FourTops[120]);
            FourTopsDick.Add(1334, FourTops[121]);
            FourTopsDick.Add(1335, FourTops[122]);
            FourTopsDick.Add(1336, FourTops[123]);
            FourTopsDick.Add(1344, FourTops[124]);
            FourTopsDick.Add(1345, FourTops[125]);
            FourTopsDick.Add(1346, FourTops[126]);
            FourTopsDick.Add(1355, FourTops[127]);
            FourTopsDick.Add(1356, FourTops[128]);
            FourTopsDick.Add(1366, FourTops[129]);
            FourTopsDick.Add(1444, FourTops[130]);
            FourTopsDick.Add(1445, FourTops[131]);
            FourTopsDick.Add(1446, FourTops[132]);
            FourTopsDick.Add(1455, FourTops[133]);
            FourTopsDick.Add(1456, FourTops[134]);
            FourTopsDick.Add(1466, FourTops[135]);
            FourTopsDick.Add(1555, FourTops[136]);
            FourTopsDick.Add(1556, FourTops[137]);
            FourTopsDick.Add(1566, FourTops[138]);
            FourTopsDick.Add(1666, FourTops[139]);
            FourTopsDick.Add(2222, FourTops[140]);
            FourTopsDick.Add(2223, FourTops[141]);
            FourTopsDick.Add(2224, FourTops[142]);
            FourTopsDick.Add(2225, FourTops[143]);
            FourTopsDick.Add(2226, FourTops[144]);
            FourTopsDick.Add(2233, FourTops[145]);
            FourTopsDick.Add(2234, FourTops[146]);
            FourTopsDick.Add(2235, FourTops[147]);
            FourTopsDick.Add(2236, FourTops[148]);
            FourTopsDick.Add(2244, FourTops[149]);
            FourTopsDick.Add(2245, FourTops[150]);
            FourTopsDick.Add(2246, FourTops[151]);
            FourTopsDick.Add(2255, FourTops[152]);
            FourTopsDick.Add(2256, FourTops[153]);
            FourTopsDick.Add(2266, FourTops[154]);
            FourTopsDick.Add(2333, FourTops[155]);
            FourTopsDick.Add(2334, FourTops[156]);
            FourTopsDick.Add(2335, FourTops[157]);
            FourTopsDick.Add(2336, FourTops[158]);
            FourTopsDick.Add(2344, FourTops[159]);
            FourTopsDick.Add(2345, FourTops[160]);
            FourTopsDick.Add(2346, FourTops[161]);
            FourTopsDick.Add(2355, FourTops[162]);
            FourTopsDick.Add(2356, FourTops[163]);
            FourTopsDick.Add(2366, FourTops[164]);
            FourTopsDick.Add(2444, FourTops[165]);
            FourTopsDick.Add(2445, FourTops[166]);
            FourTopsDick.Add(2446, FourTops[167]);
            FourTopsDick.Add(2455, FourTops[168]);
            FourTopsDick.Add(2456, FourTops[169]);
            FourTopsDick.Add(2466, FourTops[170]);
            FourTopsDick.Add(2555, FourTops[171]);
            FourTopsDick.Add(2556, FourTops[172]);
            FourTopsDick.Add(2566, FourTops[173]);
            FourTopsDick.Add(2666, FourTops[174]);
            FourTopsDick.Add(3333, FourTops[175]);
            FourTopsDick.Add(3334, FourTops[176]);
            FourTopsDick.Add(3335, FourTops[177]);
            FourTopsDick.Add(3336, FourTops[178]);
            FourTopsDick.Add(3344, FourTops[179]);
            FourTopsDick.Add(3345, FourTops[180]);
            FourTopsDick.Add(3346, FourTops[181]);
            FourTopsDick.Add(3355, FourTops[182]);
            FourTopsDick.Add(3356, FourTops[183]);
            FourTopsDick.Add(3366, FourTops[184]);
            FourTopsDick.Add(3444, FourTops[185]);
            FourTopsDick.Add(3445, FourTops[186]);
            FourTopsDick.Add(3446, FourTops[187]);
            FourTopsDick.Add(3455, FourTops[188]);
            FourTopsDick.Add(3456, FourTops[189]);
            FourTopsDick.Add(3466, FourTops[190]);
            FourTopsDick.Add(3555, FourTops[191]);
            FourTopsDick.Add(3556, FourTops[192]);
            FourTopsDick.Add(3566, FourTops[193]);
            FourTopsDick.Add(3666, FourTops[194]);
            FourTopsDick.Add(4444, FourTops[195]);
            FourTopsDick.Add(4445, FourTops[196]);
            FourTopsDick.Add(4446, FourTops[197]);
            FourTopsDick.Add(4455, FourTops[198]);
            FourTopsDick.Add(4456, FourTops[199]);
            FourTopsDick.Add(4466, FourTops[200]);
            FourTopsDick.Add(4555, FourTops[201]);
            FourTopsDick.Add(4556, FourTops[202]);
            FourTopsDick.Add(4566, FourTops[203]);
            FourTopsDick.Add(4666, FourTops[204]);
            FourTopsDick.Add(5555, FourTops[205]);
            FourTopsDick.Add(5556, FourTops[206]);
            FourTopsDick.Add(5566, FourTops[207]);
            FourTopsDick.Add(5666, FourTops[208]);
            FourTopsDick.Add(6666, FourTops[209]);

            #endregion
            //      Initialize Five-topping Dictionary
            #region FiveTopsDick.Add(00000, FiveTops[0]);
            FiveTopsDick.Add(00001, FiveTops[1]);
            FiveTopsDick.Add(00002, FiveTops[2]);
            FiveTopsDick.Add(00003, FiveTops[3]);
            FiveTopsDick.Add(00004, FiveTops[4]);
            FiveTopsDick.Add(00005, FiveTops[5]);
            FiveTopsDick.Add(00006, FiveTops[6]);
            FiveTopsDick.Add(00011, FiveTops[7]);
            FiveTopsDick.Add(00012, FiveTops[8]);
            FiveTopsDick.Add(00013, FiveTops[9]);
            FiveTopsDick.Add(00014, FiveTops[10]);
            FiveTopsDick.Add(00015, FiveTops[11]);
            FiveTopsDick.Add(00016, FiveTops[12]);
            FiveTopsDick.Add(00022, FiveTops[13]);
            FiveTopsDick.Add(00023, FiveTops[14]);
            FiveTopsDick.Add(00024, FiveTops[15]);
            FiveTopsDick.Add(00025, FiveTops[16]);
            FiveTopsDick.Add(00026, FiveTops[17]);
            FiveTopsDick.Add(00033, FiveTops[18]);
            FiveTopsDick.Add(00034, FiveTops[19]);
            FiveTopsDick.Add(00035, FiveTops[20]);
            FiveTopsDick.Add(00036, FiveTops[21]);
            FiveTopsDick.Add(00044, FiveTops[22]);
            FiveTopsDick.Add(00045, FiveTops[23]);
            FiveTopsDick.Add(00046, FiveTops[24]);
            FiveTopsDick.Add(00055, FiveTops[25]);
            FiveTopsDick.Add(00056, FiveTops[26]);
            FiveTopsDick.Add(00066, FiveTops[27]);
            FiveTopsDick.Add(00111, FiveTops[28]);
            FiveTopsDick.Add(00112, FiveTops[29]);
            FiveTopsDick.Add(00113, FiveTops[30]);
            FiveTopsDick.Add(00114, FiveTops[31]);
            FiveTopsDick.Add(00115, FiveTops[32]);
            FiveTopsDick.Add(00116, FiveTops[33]);
            FiveTopsDick.Add(00122, FiveTops[34]);
            FiveTopsDick.Add(00123, FiveTops[35]);
            FiveTopsDick.Add(00124, FiveTops[36]);
            FiveTopsDick.Add(00125, FiveTops[37]);
            FiveTopsDick.Add(00126, FiveTops[38]);
            FiveTopsDick.Add(00133, FiveTops[39]);
            FiveTopsDick.Add(00134, FiveTops[40]);
            FiveTopsDick.Add(00135, FiveTops[41]);
            FiveTopsDick.Add(00136, FiveTops[42]);
            FiveTopsDick.Add(00144, FiveTops[43]);
            FiveTopsDick.Add(00145, FiveTops[44]);
            FiveTopsDick.Add(00146, FiveTops[45]);
            FiveTopsDick.Add(00155, FiveTops[46]);
            FiveTopsDick.Add(00156, FiveTops[47]);
            FiveTopsDick.Add(00166, FiveTops[48]);
            FiveTopsDick.Add(00222, FiveTops[49]);
            FiveTopsDick.Add(00223, FiveTops[50]);
            FiveTopsDick.Add(00224, FiveTops[51]);
            FiveTopsDick.Add(00225, FiveTops[52]);
            FiveTopsDick.Add(00226, FiveTops[53]);
            FiveTopsDick.Add(00233, FiveTops[54]);
            FiveTopsDick.Add(00234, FiveTops[55]);
            FiveTopsDick.Add(00235, FiveTops[56]);
            FiveTopsDick.Add(00236, FiveTops[57]);
            FiveTopsDick.Add(00244, FiveTops[58]);
            FiveTopsDick.Add(00245, FiveTops[59]);
            FiveTopsDick.Add(00246, FiveTops[60]);
            FiveTopsDick.Add(00255, FiveTops[61]);
            FiveTopsDick.Add(00256, FiveTops[62]);
            FiveTopsDick.Add(00266, FiveTops[63]);
            FiveTopsDick.Add(00333, FiveTops[64]);
            FiveTopsDick.Add(00334, FiveTops[65]);
            FiveTopsDick.Add(00335, FiveTops[66]);
            FiveTopsDick.Add(00336, FiveTops[67]);
            FiveTopsDick.Add(00344, FiveTops[68]);
            FiveTopsDick.Add(00345, FiveTops[69]);
            FiveTopsDick.Add(00346, FiveTops[70]);
            FiveTopsDick.Add(00355, FiveTops[71]);
            FiveTopsDick.Add(00356, FiveTops[72]);
            FiveTopsDick.Add(00366, FiveTops[73]);
            FiveTopsDick.Add(00444, FiveTops[74]);
            FiveTopsDick.Add(00445, FiveTops[75]);
            FiveTopsDick.Add(00446, FiveTops[76]);
            FiveTopsDick.Add(00455, FiveTops[77]);
            FiveTopsDick.Add(00456, FiveTops[78]);
            FiveTopsDick.Add(00466, FiveTops[79]);
            FiveTopsDick.Add(00555, FiveTops[80]);
            FiveTopsDick.Add(00556, FiveTops[81]);
            FiveTopsDick.Add(00566, FiveTops[82]);
            FiveTopsDick.Add(00666, FiveTops[83]);
            FiveTopsDick.Add(01111, FiveTops[84]);
            FiveTopsDick.Add(01112, FiveTops[85]);
            FiveTopsDick.Add(01113, FiveTops[86]);
            FiveTopsDick.Add(01114, FiveTops[87]);
            FiveTopsDick.Add(01115, FiveTops[88]);
            FiveTopsDick.Add(01116, FiveTops[89]);
            FiveTopsDick.Add(01122, FiveTops[90]);
            FiveTopsDick.Add(01123, FiveTops[91]);
            FiveTopsDick.Add(01124, FiveTops[92]);
            FiveTopsDick.Add(01125, FiveTops[93]);
            FiveTopsDick.Add(01126, FiveTops[94]);
            FiveTopsDick.Add(01133, FiveTops[95]);
            FiveTopsDick.Add(01134, FiveTops[96]);
            FiveTopsDick.Add(01135, FiveTops[97]);
            FiveTopsDick.Add(01136, FiveTops[98]);
            FiveTopsDick.Add(01144, FiveTops[99]);
            FiveTopsDick.Add(01145, FiveTops[100]);
            FiveTopsDick.Add(01146, FiveTops[101]);
            FiveTopsDick.Add(01155, FiveTops[102]);
            FiveTopsDick.Add(01156, FiveTops[103]);
            FiveTopsDick.Add(01166, FiveTops[104]);
            FiveTopsDick.Add(01222, FiveTops[105]);
            FiveTopsDick.Add(01223, FiveTops[106]);
            FiveTopsDick.Add(01224, FiveTops[107]);
            FiveTopsDick.Add(01225, FiveTops[108]);
            FiveTopsDick.Add(01226, FiveTops[109]);
            FiveTopsDick.Add(01233, FiveTops[110]);
            FiveTopsDick.Add(01234, FiveTops[111]);
            FiveTopsDick.Add(01235, FiveTops[112]);
            FiveTopsDick.Add(01236, FiveTops[113]);
            FiveTopsDick.Add(01244, FiveTops[114]);
            FiveTopsDick.Add(01245, FiveTops[115]);
            FiveTopsDick.Add(01246, FiveTops[116]);
            FiveTopsDick.Add(01255, FiveTops[117]);
            FiveTopsDick.Add(01256, FiveTops[118]);
            FiveTopsDick.Add(01266, FiveTops[119]);
            FiveTopsDick.Add(01333, FiveTops[120]);
            FiveTopsDick.Add(01334, FiveTops[121]);
            FiveTopsDick.Add(01335, FiveTops[122]);
            FiveTopsDick.Add(01336, FiveTops[123]);
            FiveTopsDick.Add(01344, FiveTops[124]);
            FiveTopsDick.Add(01345, FiveTops[125]);
            FiveTopsDick.Add(01346, FiveTops[126]);
            FiveTopsDick.Add(01355, FiveTops[127]);
            FiveTopsDick.Add(01356, FiveTops[128]);
            FiveTopsDick.Add(01366, FiveTops[129]);
            FiveTopsDick.Add(01444, FiveTops[130]);
            FiveTopsDick.Add(01445, FiveTops[131]);
            FiveTopsDick.Add(01446, FiveTops[132]);
            FiveTopsDick.Add(01455, FiveTops[133]);
            FiveTopsDick.Add(01456, FiveTops[134]);
            FiveTopsDick.Add(01466, FiveTops[135]);
            FiveTopsDick.Add(01555, FiveTops[136]);
            FiveTopsDick.Add(01556, FiveTops[137]);
            FiveTopsDick.Add(01566, FiveTops[138]);
            FiveTopsDick.Add(01666, FiveTops[139]);
            FiveTopsDick.Add(02222, FiveTops[140]);
            FiveTopsDick.Add(02223, FiveTops[141]);
            FiveTopsDick.Add(02224, FiveTops[142]);
            FiveTopsDick.Add(02225, FiveTops[143]);
            FiveTopsDick.Add(02226, FiveTops[144]);
            FiveTopsDick.Add(02233, FiveTops[145]);
            FiveTopsDick.Add(02234, FiveTops[146]);
            FiveTopsDick.Add(02235, FiveTops[147]);
            FiveTopsDick.Add(02236, FiveTops[148]);
            FiveTopsDick.Add(02244, FiveTops[149]);
            FiveTopsDick.Add(02245, FiveTops[150]);
            FiveTopsDick.Add(02246, FiveTops[151]);
            FiveTopsDick.Add(02255, FiveTops[152]);
            FiveTopsDick.Add(02256, FiveTops[153]);
            FiveTopsDick.Add(02266, FiveTops[154]);
            FiveTopsDick.Add(02333, FiveTops[155]);
            FiveTopsDick.Add(02334, FiveTops[156]);
            FiveTopsDick.Add(02335, FiveTops[157]);
            FiveTopsDick.Add(02336, FiveTops[158]);
            FiveTopsDick.Add(02344, FiveTops[159]);
            FiveTopsDick.Add(02345, FiveTops[160]);
            FiveTopsDick.Add(02346, FiveTops[161]);
            FiveTopsDick.Add(02355, FiveTops[162]);
            FiveTopsDick.Add(02356, FiveTops[163]);
            FiveTopsDick.Add(02366, FiveTops[164]);
            FiveTopsDick.Add(02444, FiveTops[165]);
            FiveTopsDick.Add(02445, FiveTops[166]);
            FiveTopsDick.Add(02446, FiveTops[167]);
            FiveTopsDick.Add(02455, FiveTops[168]);
            FiveTopsDick.Add(02456, FiveTops[169]);
            FiveTopsDick.Add(02466, FiveTops[170]);
            FiveTopsDick.Add(02555, FiveTops[171]);
            FiveTopsDick.Add(02556, FiveTops[172]);
            FiveTopsDick.Add(02566, FiveTops[173]);
            FiveTopsDick.Add(02666, FiveTops[174]);
            FiveTopsDick.Add(03333, FiveTops[175]);
            FiveTopsDick.Add(03334, FiveTops[176]);
            FiveTopsDick.Add(03335, FiveTops[177]);
            FiveTopsDick.Add(03336, FiveTops[178]);
            FiveTopsDick.Add(03344, FiveTops[179]);
            FiveTopsDick.Add(03345, FiveTops[180]);
            FiveTopsDick.Add(03346, FiveTops[181]);
            FiveTopsDick.Add(03355, FiveTops[182]);
            FiveTopsDick.Add(03356, FiveTops[183]);
            FiveTopsDick.Add(03366, FiveTops[184]);
            FiveTopsDick.Add(03444, FiveTops[185]);
            FiveTopsDick.Add(03445, FiveTops[186]);
            FiveTopsDick.Add(03446, FiveTops[187]);
            FiveTopsDick.Add(03455, FiveTops[188]);
            FiveTopsDick.Add(03456, FiveTops[189]);
            FiveTopsDick.Add(03466, FiveTops[190]);
            FiveTopsDick.Add(03555, FiveTops[191]);
            FiveTopsDick.Add(03556, FiveTops[192]);
            FiveTopsDick.Add(03566, FiveTops[193]);
            FiveTopsDick.Add(03666, FiveTops[194]);
            FiveTopsDick.Add(04444, FiveTops[195]);
            FiveTopsDick.Add(04445, FiveTops[196]);
            FiveTopsDick.Add(04446, FiveTops[197]);
            FiveTopsDick.Add(04455, FiveTops[198]);
            FiveTopsDick.Add(04456, FiveTops[199]);
            FiveTopsDick.Add(04466, FiveTops[200]);
            FiveTopsDick.Add(04555, FiveTops[201]);
            FiveTopsDick.Add(04556, FiveTops[202]);
            FiveTopsDick.Add(04566, FiveTops[203]);
            FiveTopsDick.Add(04666, FiveTops[204]);
            FiveTopsDick.Add(05555, FiveTops[205]);
            FiveTopsDick.Add(05556, FiveTops[206]);
            FiveTopsDick.Add(05566, FiveTops[207]);
            FiveTopsDick.Add(05666, FiveTops[208]);
            FiveTopsDick.Add(06666, FiveTops[209]);
            FiveTopsDick.Add(11111, FiveTops[210]);
            FiveTopsDick.Add(11112, FiveTops[211]);
            FiveTopsDick.Add(11113, FiveTops[212]);
            FiveTopsDick.Add(11114, FiveTops[213]);
            FiveTopsDick.Add(11115, FiveTops[214]);
            FiveTopsDick.Add(11116, FiveTops[215]);
            FiveTopsDick.Add(11122, FiveTops[216]);
            FiveTopsDick.Add(11123, FiveTops[217]);
            FiveTopsDick.Add(11124, FiveTops[218]);
            FiveTopsDick.Add(11125, FiveTops[219]);
            FiveTopsDick.Add(11126, FiveTops[220]);
            FiveTopsDick.Add(11133, FiveTops[221]);
            FiveTopsDick.Add(11134, FiveTops[222]);
            FiveTopsDick.Add(11135, FiveTops[223]);
            FiveTopsDick.Add(11136, FiveTops[224]);
            FiveTopsDick.Add(11144, FiveTops[225]);
            FiveTopsDick.Add(11145, FiveTops[226]);
            FiveTopsDick.Add(11146, FiveTops[227]);
            FiveTopsDick.Add(11155, FiveTops[228]);
            FiveTopsDick.Add(11156, FiveTops[229]);
            FiveTopsDick.Add(11166, FiveTops[230]);
            FiveTopsDick.Add(11222, FiveTops[231]);
            FiveTopsDick.Add(11223, FiveTops[232]);
            FiveTopsDick.Add(11224, FiveTops[233]);
            FiveTopsDick.Add(11225, FiveTops[234]);
            FiveTopsDick.Add(11226, FiveTops[235]);
            FiveTopsDick.Add(11233, FiveTops[236]);
            FiveTopsDick.Add(11234, FiveTops[237]);
            FiveTopsDick.Add(11235, FiveTops[238]);
            FiveTopsDick.Add(11236, FiveTops[239]);
            FiveTopsDick.Add(11244, FiveTops[240]);
            FiveTopsDick.Add(11245, FiveTops[241]);
            FiveTopsDick.Add(11246, FiveTops[242]);
            FiveTopsDick.Add(11255, FiveTops[243]);
            FiveTopsDick.Add(11256, FiveTops[244]);
            FiveTopsDick.Add(11266, FiveTops[245]);
            FiveTopsDick.Add(11333, FiveTops[246]);
            FiveTopsDick.Add(11334, FiveTops[247]);
            FiveTopsDick.Add(11335, FiveTops[248]);
            FiveTopsDick.Add(11336, FiveTops[249]);
            FiveTopsDick.Add(11344, FiveTops[250]);
            FiveTopsDick.Add(11345, FiveTops[251]);
            FiveTopsDick.Add(11346, FiveTops[252]);
            FiveTopsDick.Add(11355, FiveTops[253]);
            FiveTopsDick.Add(11356, FiveTops[254]);
            FiveTopsDick.Add(11366, FiveTops[255]);
            FiveTopsDick.Add(11444, FiveTops[256]);
            FiveTopsDick.Add(11445, FiveTops[257]);
            FiveTopsDick.Add(11446, FiveTops[258]);
            FiveTopsDick.Add(11455, FiveTops[259]);
            FiveTopsDick.Add(11456, FiveTops[260]);
            FiveTopsDick.Add(11466, FiveTops[261]);
            FiveTopsDick.Add(11555, FiveTops[262]);
            FiveTopsDick.Add(11556, FiveTops[263]);
            FiveTopsDick.Add(11566, FiveTops[264]);
            FiveTopsDick.Add(11666, FiveTops[265]);
            FiveTopsDick.Add(12222, FiveTops[266]);
            FiveTopsDick.Add(12223, FiveTops[267]);
            FiveTopsDick.Add(12224, FiveTops[268]);
            FiveTopsDick.Add(12225, FiveTops[269]);
            FiveTopsDick.Add(12226, FiveTops[270]);
            FiveTopsDick.Add(12233, FiveTops[271]);
            FiveTopsDick.Add(12234, FiveTops[272]);
            FiveTopsDick.Add(12235, FiveTops[273]);
            FiveTopsDick.Add(12236, FiveTops[274]);
            FiveTopsDick.Add(12244, FiveTops[275]);
            FiveTopsDick.Add(12245, FiveTops[276]);
            FiveTopsDick.Add(12246, FiveTops[277]);
            FiveTopsDick.Add(12255, FiveTops[278]);
            FiveTopsDick.Add(12256, FiveTops[279]);
            FiveTopsDick.Add(12266, FiveTops[280]);
            FiveTopsDick.Add(12333, FiveTops[281]);
            FiveTopsDick.Add(12334, FiveTops[282]);
            FiveTopsDick.Add(12335, FiveTops[283]);
            FiveTopsDick.Add(12336, FiveTops[284]);
            FiveTopsDick.Add(12344, FiveTops[285]);
            FiveTopsDick.Add(12345, FiveTops[286]);
            FiveTopsDick.Add(12346, FiveTops[287]);
            FiveTopsDick.Add(12355, FiveTops[288]);
            FiveTopsDick.Add(12356, FiveTops[289]);
            FiveTopsDick.Add(12366, FiveTops[290]);
            FiveTopsDick.Add(12444, FiveTops[291]);
            FiveTopsDick.Add(12445, FiveTops[292]);
            FiveTopsDick.Add(12446, FiveTops[293]);
            FiveTopsDick.Add(12455, FiveTops[294]);
            FiveTopsDick.Add(12456, FiveTops[295]);
            FiveTopsDick.Add(12466, FiveTops[296]);
            FiveTopsDick.Add(12555, FiveTops[297]);
            FiveTopsDick.Add(12556, FiveTops[298]);
            FiveTopsDick.Add(12566, FiveTops[299]);
            FiveTopsDick.Add(12666, FiveTops[300]);
            FiveTopsDick.Add(13333, FiveTops[301]);
            FiveTopsDick.Add(13334, FiveTops[302]);
            FiveTopsDick.Add(13335, FiveTops[303]);
            FiveTopsDick.Add(13336, FiveTops[304]);
            FiveTopsDick.Add(13344, FiveTops[305]);
            FiveTopsDick.Add(13345, FiveTops[306]);
            FiveTopsDick.Add(13346, FiveTops[307]);
            FiveTopsDick.Add(13355, FiveTops[308]);
            FiveTopsDick.Add(13356, FiveTops[309]);
            FiveTopsDick.Add(13366, FiveTops[310]);
            FiveTopsDick.Add(13444, FiveTops[311]);
            FiveTopsDick.Add(13445, FiveTops[312]);
            FiveTopsDick.Add(13446, FiveTops[313]);
            FiveTopsDick.Add(13455, FiveTops[314]);
            FiveTopsDick.Add(13456, FiveTops[315]);
            FiveTopsDick.Add(13466, FiveTops[316]);
            FiveTopsDick.Add(13555, FiveTops[317]);
            FiveTopsDick.Add(13556, FiveTops[318]);
            FiveTopsDick.Add(13566, FiveTops[319]);
            FiveTopsDick.Add(13666, FiveTops[320]);
            FiveTopsDick.Add(14444, FiveTops[321]);
            FiveTopsDick.Add(14445, FiveTops[322]);
            FiveTopsDick.Add(14446, FiveTops[323]);
            FiveTopsDick.Add(14455, FiveTops[324]);
            FiveTopsDick.Add(14456, FiveTops[325]);
            FiveTopsDick.Add(14466, FiveTops[326]);
            FiveTopsDick.Add(14555, FiveTops[327]);
            FiveTopsDick.Add(14556, FiveTops[328]);
            FiveTopsDick.Add(14566, FiveTops[329]);
            FiveTopsDick.Add(14666, FiveTops[330]);
            FiveTopsDick.Add(15555, FiveTops[331]);
            FiveTopsDick.Add(15556, FiveTops[332]);
            FiveTopsDick.Add(15566, FiveTops[333]);
            FiveTopsDick.Add(15666, FiveTops[334]);
            FiveTopsDick.Add(16666, FiveTops[335]);
            FiveTopsDick.Add(22222, FiveTops[336]);
            FiveTopsDick.Add(22223, FiveTops[337]);
            FiveTopsDick.Add(22224, FiveTops[338]);
            FiveTopsDick.Add(22225, FiveTops[339]);
            FiveTopsDick.Add(22226, FiveTops[340]);
            FiveTopsDick.Add(22233, FiveTops[341]);
            FiveTopsDick.Add(22234, FiveTops[342]);
            FiveTopsDick.Add(22235, FiveTops[343]);
            FiveTopsDick.Add(22236, FiveTops[344]);
            FiveTopsDick.Add(22244, FiveTops[345]);
            FiveTopsDick.Add(22245, FiveTops[346]);
            FiveTopsDick.Add(22246, FiveTops[347]);
            FiveTopsDick.Add(22255, FiveTops[348]);
            FiveTopsDick.Add(22256, FiveTops[349]);
            FiveTopsDick.Add(22266, FiveTops[350]);
            FiveTopsDick.Add(22333, FiveTops[351]);
            FiveTopsDick.Add(22334, FiveTops[352]);
            FiveTopsDick.Add(22335, FiveTops[353]);
            FiveTopsDick.Add(22336, FiveTops[354]);
            FiveTopsDick.Add(22344, FiveTops[355]);
            FiveTopsDick.Add(22345, FiveTops[356]);
            FiveTopsDick.Add(22346, FiveTops[357]);
            FiveTopsDick.Add(22355, FiveTops[358]);
            FiveTopsDick.Add(22356, FiveTops[359]);
            FiveTopsDick.Add(22366, FiveTops[360]);
            FiveTopsDick.Add(22444, FiveTops[361]);
            FiveTopsDick.Add(22445, FiveTops[362]);
            FiveTopsDick.Add(22446, FiveTops[363]);
            FiveTopsDick.Add(22455, FiveTops[364]);
            FiveTopsDick.Add(22456, FiveTops[365]);
            FiveTopsDick.Add(22466, FiveTops[366]);
            FiveTopsDick.Add(22555, FiveTops[367]);
            FiveTopsDick.Add(22556, FiveTops[368]);
            FiveTopsDick.Add(22566, FiveTops[369]);
            FiveTopsDick.Add(22666, FiveTops[370]);
            FiveTopsDick.Add(23333, FiveTops[371]);
            FiveTopsDick.Add(23334, FiveTops[372]);
            FiveTopsDick.Add(23335, FiveTops[373]);
            FiveTopsDick.Add(23336, FiveTops[374]);
            FiveTopsDick.Add(23344, FiveTops[375]);
            FiveTopsDick.Add(23345, FiveTops[376]);
            FiveTopsDick.Add(23346, FiveTops[377]);
            FiveTopsDick.Add(23355, FiveTops[378]);
            FiveTopsDick.Add(23356, FiveTops[379]);
            FiveTopsDick.Add(23366, FiveTops[380]);
            FiveTopsDick.Add(23444, FiveTops[381]);
            FiveTopsDick.Add(23445, FiveTops[382]);
            FiveTopsDick.Add(23446, FiveTops[383]);
            FiveTopsDick.Add(23455, FiveTops[384]);
            FiveTopsDick.Add(23456, FiveTops[385]);
            FiveTopsDick.Add(23466, FiveTops[386]);
            FiveTopsDick.Add(23555, FiveTops[387]);
            FiveTopsDick.Add(23556, FiveTops[388]);
            FiveTopsDick.Add(23566, FiveTops[389]);
            FiveTopsDick.Add(23666, FiveTops[390]);
            FiveTopsDick.Add(24444, FiveTops[391]);
            FiveTopsDick.Add(24445, FiveTops[392]);
            FiveTopsDick.Add(24446, FiveTops[393]);
            FiveTopsDick.Add(24455, FiveTops[394]);
            FiveTopsDick.Add(24456, FiveTops[395]);
            FiveTopsDick.Add(24466, FiveTops[396]);
            FiveTopsDick.Add(24555, FiveTops[397]);
            FiveTopsDick.Add(24556, FiveTops[398]);
            FiveTopsDick.Add(24566, FiveTops[399]);
            FiveTopsDick.Add(24666, FiveTops[400]);
            FiveTopsDick.Add(25555, FiveTops[401]);
            FiveTopsDick.Add(25556, FiveTops[402]);
            FiveTopsDick.Add(25566, FiveTops[403]);
            FiveTopsDick.Add(25666, FiveTops[404]);
            FiveTopsDick.Add(26666, FiveTops[405]);
            FiveTopsDick.Add(33333, FiveTops[406]);
            FiveTopsDick.Add(33334, FiveTops[407]);
            FiveTopsDick.Add(33335, FiveTops[408]);
            FiveTopsDick.Add(33336, FiveTops[409]);
            FiveTopsDick.Add(33344, FiveTops[410]);
            FiveTopsDick.Add(33345, FiveTops[411]);
            FiveTopsDick.Add(33346, FiveTops[412]);
            FiveTopsDick.Add(33355, FiveTops[413]);
            FiveTopsDick.Add(33356, FiveTops[414]);
            FiveTopsDick.Add(33366, FiveTops[415]);
            FiveTopsDick.Add(33444, FiveTops[416]);
            FiveTopsDick.Add(33445, FiveTops[417]);
            FiveTopsDick.Add(33446, FiveTops[418]);
            FiveTopsDick.Add(33455, FiveTops[419]);
            FiveTopsDick.Add(33456, FiveTops[420]);
            FiveTopsDick.Add(33466, FiveTops[421]);
            FiveTopsDick.Add(33555, FiveTops[422]);
            FiveTopsDick.Add(33556, FiveTops[423]);
            FiveTopsDick.Add(33566, FiveTops[424]);
            FiveTopsDick.Add(33666, FiveTops[425]);
            FiveTopsDick.Add(34444, FiveTops[426]);
            FiveTopsDick.Add(34445, FiveTops[427]);
            FiveTopsDick.Add(34446, FiveTops[428]);
            FiveTopsDick.Add(34455, FiveTops[429]);
            FiveTopsDick.Add(34456, FiveTops[430]);
            FiveTopsDick.Add(34466, FiveTops[431]);
            FiveTopsDick.Add(34555, FiveTops[432]);
            FiveTopsDick.Add(34556, FiveTops[433]);
            FiveTopsDick.Add(34566, FiveTops[434]);
            FiveTopsDick.Add(34666, FiveTops[435]);
            FiveTopsDick.Add(35555, FiveTops[436]);
            FiveTopsDick.Add(35556, FiveTops[437]);
            FiveTopsDick.Add(35566, FiveTops[438]);
            FiveTopsDick.Add(35666, FiveTops[439]);
            FiveTopsDick.Add(36666, FiveTops[440]);
            FiveTopsDick.Add(44444, FiveTops[441]);
            FiveTopsDick.Add(44445, FiveTops[442]);
            FiveTopsDick.Add(44446, FiveTops[443]);
            FiveTopsDick.Add(44455, FiveTops[444]);
            FiveTopsDick.Add(44456, FiveTops[445]);
            FiveTopsDick.Add(44466, FiveTops[446]);
            FiveTopsDick.Add(44555, FiveTops[447]);
            FiveTopsDick.Add(44556, FiveTops[448]);
            FiveTopsDick.Add(44566, FiveTops[449]);
            FiveTopsDick.Add(44666, FiveTops[450]);
            FiveTopsDick.Add(45555, FiveTops[451]);
            FiveTopsDick.Add(45556, FiveTops[452]);
            FiveTopsDick.Add(45566, FiveTops[453]);
            FiveTopsDick.Add(45666, FiveTops[454]);
            FiveTopsDick.Add(46666, FiveTops[455]);
            FiveTopsDick.Add(55555, FiveTops[456]);
            FiveTopsDick.Add(55556, FiveTops[457]);
            FiveTopsDick.Add(55566, FiveTops[458]);
            FiveTopsDick.Add(55666, FiveTops[459]);
            FiveTopsDick.Add(56666, FiveTops[460]);
            FiveTopsDick.Add(66666, FiveTops[461]);

            #endregion


            //      Set firstSam flag to true;    
            firstSam = true;

        }
        private void Update()
        {
            caughtToppingsgo = GameObject.FindGameObjectsWithTag("Stack");
            caughtToppingsint = caughtToppingsgo.Length;
            if (caughtToppingsint == 5)
            {
                Assemble();
            }
        }
        /*      FindSam()
                1 Make a List from the "stack' array
                2 List will parsed into unique key for dictionary
                3 Sort the list, so that the elements are in ascending order
                4 Switch statement to decide which dictionary to point to
                5 Adjust sandwhich position
        */
        public void FindSam()
        {
            List<int> keyList = new List<int> { };

            for (int i = 0; i < caughtToppingsgo.Length; i++)
            {
                keyList.Add(caughtToppingsgo[i].GetComponent<FallingToppings>().ID);
            }
            keyList.Sort();

            //////////////////////////////////////////////////////////////////////////////////
            /*      The loop inside this here box is JUST to print out the elments in       //
                    mother fuckin' keyList in the console on the same gd line.              //
                    There's literally no other way. So dumb.                                //
                    So this number should match both the samKey AND the number displayed on //
                    the TwoTops Sprites. If there's a mismatch between any of them then     //
                    somethings...the foot.                                                  //
            */                                                                              //  
            string bugCheck = "";                                                   //
            for (int i = 0; i < keyList.Count; i++)                                 //
            {                                                                       //    
                bugCheck += int.Parse(keyList[i].ToString());                       //
            }                                                                       //
            Debug.Log("Sorted key in keyList - should match samKey in" +            //
                " Debug 1 or 2 \r\n" + bugCheck);                                   //
                                                                                    //////////////////////////////////////////////////////////////////////////////////


            switch (caughtToppingsint)
            {
                case 1:
                    samKey = keyList[0];
                    Sandwhich = OneTopsDick[samKey];
                    break;
                case 2:
                    samKey = int.Parse(keyList[0].ToString() + keyList[1].ToString());
                    Sandwhich = TwoTopsDick[samKey];
                    break;
                case 3:
                    samKey = int.Parse(keyList[0].ToString() + keyList[1].ToString() + keyList[2].ToString());
                    Sandwhich = ThreeTopsDick[samKey];
                    break;
                case 4:
                    samKey = int.Parse(keyList[0].ToString() + keyList[1].ToString() + keyList[2].ToString() + keyList[3].ToString());
                    Sandwhich = FourTopsDick[samKey];
                    break;
                case 5:
                    samKey = int.Parse(keyList[0].ToString() + keyList[1].ToString() + keyList[2].ToString() +
                        keyList[3].ToString() + keyList[4].ToString());
                    Sandwhich = FiveTopsDick[samKey];
                    break;
                default:
                    break;
            }
        }
        public void PutSam()
        {

            if (firstSam == true)                                           // checks if this is the first sandwich being made
            {
                newSamPos = SamPrefab.transform.position;               // position of instantiation at the position of SamPrefab

                GameObject FinishedSam = Instantiate(SamPrefab,
                    newSamPos, Quaternion.identity);
                finishedSams.Add(FinishedSam);                          // Adds the completed sandwich to the list finishedSams
                firstSam = false;

                FinishedSam.name = Sandwhich.name;
                FinishedSam.GetComponent<Sam>().sandwichName = Sandwhich.name;
                FinishedSam.GetComponent<SpriteRenderer>().sprite = Sandwhich;

                Debug.Log("Debug 1 - After if block in PutSam() \r\n" +
                      "newSamPos:" + newSamPos.ToString() + "\r\n" +
                      "First Sam?:" + firstSam.ToString() + "\r\n" +
                      "listPos:  " + listPos.ToString() + "\r\n" +
                      "FinishedSams:" + finishedSams.Count + "\r\n" +
                      "SandwhichName:" + Sandwhich.name + "\r\n" +
                      "samKey:       " + samKey);

            }
            else
            {
                listPos = finishedSams.Count - 1;                             // finds the last sandwich made in the list
                samPos = finishedSams[listPos].transform.position;            // finds the position of the last sandwich made
                newSamPos = samPos + temp;                                    // adds an offset to the x axis 
                GameObject FinishedSam = Instantiate(SamPrefab,               // creates a new sandwich sprite at the newSamPos 
                    newSamPos, Quaternion.identity);
                finishedSams.Add(FinishedSam);                                // Adds the new sandwich to the list

                FinishedSam.name = Sandwhich.name;
                FinishedSam.GetComponent<Sam>().sandwichName = Sandwhich.name;
                FinishedSam.GetComponent<SpriteRenderer>().sprite = Sandwhich;

                Debug.Log("Debug 2 - After else block in PutSam() \r\n" + "\r\n" +
                     "newSamPos:" + newSamPos.ToString() + "\r\n" +
                     "First Sam?:" + firstSam.ToString() + "\r\n" +
                     "listPos:  " + listPos.ToString() + "\r\n" +
                     "FinishedSams:" + finishedSams.Count + "\r\n" +
                     "SandwhichName:" + Sandwhich.name + "\r\n" +
                     "samKey:       " + samKey + "\r\n" + "\r\n");
            }

        }


        public void Assemble()
        {
            Debug.Log("Assemble");
            if (caughtToppingsint == 5)
            {
                FindSam();
                PutSam();
                isMatch.IsMatchedOn(samKey);

                foreach (GameObject topping in caughtToppingsgo)
                {
                    Destroy(topping);
                    scoreBoard.scoreHit(caughtToppingsint * scorePerTop);
                }
            }

            if (Input.GetKey(KeyCode.Space) && caughtToppingsint >= 1)
            {
                FindSam();
                PutSam();
                isMatch.IsMatchedOn(samKey);

                foreach (GameObject topping in caughtToppingsgo)
                {
                    ID = topping.GetComponent<FallingToppings>().ID;
                    Destroy(topping);
                    scoreBoard.scoreHit(caughtToppingsint * scorePerTop);
                    // Debug.Log(ID);

                }

            }

        }
    }
}


/* Old code, just in case*******************************************************
            Pos = GameObject.Find("Topping 1").transform.position; // for next finished sam
            Debug.Log(length);
            length = OneTops.Length;
            Sprite Sandwich = OneTops[ID];
            string sandwichName = Sandwich.name; 
            GameObject FinishedSam = Instantiate(SamPrefab, transform.position + transform.forward, transform.rotation);  // Weird bug
            GameObject FinishedSam = Instantiate(SamPrefab, , Quaternion.identity);
            Pos.x += 1f;
            transform.position = Pos;


    /*public int CaughtTops(int topID)
    {
        int numbTops = 0;
        for(int i = 0; i < currentSam.Count; i++)
        {
            if (currentSam[i] == topID)
            {
                numbTops++;
            }
        }
        return numbTops;
    }*/
// Find the name and asset of the assembled sandwich
//Load the dick
//********************************************************************************/
