using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TicketSpace;

namespace SandwhichSpace
{
    public class Sandwiches : MonoBehaviour
    {
        public static Dictionary<int, Sprite> OneTopsDick = new Dictionary<int, Sprite>();
        public static Dictionary<int, Sprite> TwoTopsDick = new Dictionary<int, Sprite>();
        public static Dictionary<int, Sprite> ThreeTopsDick = new Dictionary<int, Sprite>();
        public static Dictionary<int, Sprite> FourTopsDick = new Dictionary<int, Sprite>();
        public static Dictionary<int, Sprite> FiveTopsDick = new Dictionary<int, Sprite>();
        public List<GOTuple> ticketRail = new List<GOTuple>();
        public List<GameObject> finishedSams = new List<GameObject>();
        public List<Vector2> railPos = new List<Vector2>();

        public Sprite [] OneTops = new Sprite[0];
        public Sprite [] TwoTops = new Sprite[0];
        public Sprite [] ThreeTops = new Sprite[0];
        public Sprite [] FourTops = new Sprite[0];
        public Sprite [] FiveTops = new Sprite[0];
        Sprite Sandwhich;
        
        public GameObject SamPrefab;
        public GameObject [] caughtToppingsgo;
        public GameObject [] sideSams1;
        public GameObject [] sideSams2;
        public GameObject FinishedSam;

        public int caughtToppingsint;
        public int scorePerTop = 1;
        public int Stack;
        public int samKey;
        public int listPos;
        public string newKey;

        public Vector2 samPos;
        public Vector2 newSamPos;
        public Vector2 temp = new Vector2(15f, 0);
        public Vector3 slot1 = new Vector3(-225f, 70);

        public bool firstSam;
        public bool upFlag;
        public bool sideSam1Full = false;
        public bool sideSam2Full = false;

        ScoreBoard scoreBoard;
        public void Start()
        {
            scoreBoard = FindObjectOfType<ScoreBoard>();
            firstSam = true;

            OneTopsDick.Add(1, OneTops[0]);
            OneTopsDick.Add(2, OneTops[1]);
            OneTopsDick.Add(3, OneTops[2]);
            OneTopsDick.Add(4, OneTops[3]);
            OneTopsDick.Add(5, OneTops[4]);
            OneTopsDick.Add(6, OneTops[5]);
            OneTopsDick.Add(7, OneTops[6]);
            #region 
            TwoTopsDick.Add(11, TwoTops[0]);
            TwoTopsDick.Add(12, TwoTops[1]);
            TwoTopsDick.Add(13, TwoTops[2]);
            TwoTopsDick.Add(14, TwoTops[3]);
            TwoTopsDick.Add(15, TwoTops[4]);
            TwoTopsDick.Add(16, TwoTops[5]);
            TwoTopsDick.Add(17, TwoTops[6]);
            TwoTopsDick.Add(22, TwoTops[7]);
            TwoTopsDick.Add(23, TwoTops[8]);
            TwoTopsDick.Add(24, TwoTops[9]);
            TwoTopsDick.Add(25, TwoTops[10]);
            TwoTopsDick.Add(26, TwoTops[11]);
            TwoTopsDick.Add(27, TwoTops[12]);
            TwoTopsDick.Add(33, TwoTops[13]);
            TwoTopsDick.Add(34, TwoTops[14]);
            TwoTopsDick.Add(35, TwoTops[15]);
            TwoTopsDick.Add(36, TwoTops[16]);
            TwoTopsDick.Add(37, TwoTops[17]);
            TwoTopsDick.Add(44, TwoTops[18]);
            TwoTopsDick.Add(45, TwoTops[19]);
            TwoTopsDick.Add(46, TwoTops[20]);
            TwoTopsDick.Add(47, TwoTops[21]);
            TwoTopsDick.Add(55, TwoTops[22]);
            TwoTopsDick.Add(56, TwoTops[23]);
            TwoTopsDick.Add(57, TwoTops[24]);
            TwoTopsDick.Add(66, TwoTops[25]);
            TwoTopsDick.Add(67, TwoTops[26]);
            TwoTopsDick.Add(77, TwoTops[27]);
            #endregion
            #region
            ThreeTopsDick.Add(111, ThreeTops[0]);
            ThreeTopsDick.Add(112, ThreeTops[1]);
            ThreeTopsDick.Add(113, ThreeTops[2]);
            ThreeTopsDick.Add(114, ThreeTops[3]);
            ThreeTopsDick.Add(115, ThreeTops[4]);
            ThreeTopsDick.Add(116, ThreeTops[5]);
            ThreeTopsDick.Add(117, ThreeTops[6]);
            ThreeTopsDick.Add(122, ThreeTops[7]);
            ThreeTopsDick.Add(123, ThreeTops[8]);
            ThreeTopsDick.Add(124, ThreeTops[9]);
            ThreeTopsDick.Add(125, ThreeTops[10]);
            ThreeTopsDick.Add(126, ThreeTops[11]);
            ThreeTopsDick.Add(127, ThreeTops[12]);
            ThreeTopsDick.Add(133, ThreeTops[13]);
            ThreeTopsDick.Add(134, ThreeTops[14]);
            ThreeTopsDick.Add(135, ThreeTops[15]);
            ThreeTopsDick.Add(136, ThreeTops[16]);
            ThreeTopsDick.Add(137, ThreeTops[17]);
            ThreeTopsDick.Add(144, ThreeTops[18]);
            ThreeTopsDick.Add(145, ThreeTops[19]);
            ThreeTopsDick.Add(146, ThreeTops[20]);
            ThreeTopsDick.Add(147, ThreeTops[21]);
            ThreeTopsDick.Add(155, ThreeTops[22]);
            ThreeTopsDick.Add(156, ThreeTops[23]);
            ThreeTopsDick.Add(157, ThreeTops[24]);
            ThreeTopsDick.Add(166, ThreeTops[25]);
            ThreeTopsDick.Add(167, ThreeTops[26]);
            ThreeTopsDick.Add(177, ThreeTops[27]);
            ThreeTopsDick.Add(222, ThreeTops[28]);
            ThreeTopsDick.Add(223, ThreeTops[29]);
            ThreeTopsDick.Add(224, ThreeTops[30]);
            ThreeTopsDick.Add(225, ThreeTops[31]);
            ThreeTopsDick.Add(226, ThreeTops[32]);
            ThreeTopsDick.Add(227, ThreeTops[33]);
            ThreeTopsDick.Add(233, ThreeTops[34]);
            ThreeTopsDick.Add(234, ThreeTops[35]);
            ThreeTopsDick.Add(235, ThreeTops[36]);
            ThreeTopsDick.Add(236, ThreeTops[37]);
            ThreeTopsDick.Add(237, ThreeTops[38]);
            ThreeTopsDick.Add(244, ThreeTops[39]);
            ThreeTopsDick.Add(245, ThreeTops[40]);
            ThreeTopsDick.Add(246, ThreeTops[41]);
            ThreeTopsDick.Add(247, ThreeTops[42]);
            ThreeTopsDick.Add(255, ThreeTops[43]);
            ThreeTopsDick.Add(256, ThreeTops[44]);
            ThreeTopsDick.Add(257, ThreeTops[45]);
            ThreeTopsDick.Add(266, ThreeTops[46]);
            ThreeTopsDick.Add(267, ThreeTops[47]);
            ThreeTopsDick.Add(277, ThreeTops[48]);
            ThreeTopsDick.Add(333, ThreeTops[49]);
            ThreeTopsDick.Add(334, ThreeTops[50]);
            ThreeTopsDick.Add(335, ThreeTops[51]);
            ThreeTopsDick.Add(336, ThreeTops[52]);
            ThreeTopsDick.Add(337, ThreeTops[53]);
            ThreeTopsDick.Add(344, ThreeTops[54]);
            ThreeTopsDick.Add(345, ThreeTops[55]);
            ThreeTopsDick.Add(346, ThreeTops[56]);
            ThreeTopsDick.Add(347, ThreeTops[57]);
            ThreeTopsDick.Add(355, ThreeTops[58]);
            ThreeTopsDick.Add(356, ThreeTops[59]);
            ThreeTopsDick.Add(357, ThreeTops[60]);
            ThreeTopsDick.Add(366, ThreeTops[61]);
            ThreeTopsDick.Add(367, ThreeTops[62]);
            ThreeTopsDick.Add(377, ThreeTops[63]);
            ThreeTopsDick.Add(444, ThreeTops[64]);
            ThreeTopsDick.Add(445, ThreeTops[65]);
            ThreeTopsDick.Add(446, ThreeTops[66]);
            ThreeTopsDick.Add(447, ThreeTops[67]);
            ThreeTopsDick.Add(455, ThreeTops[68]);
            ThreeTopsDick.Add(456, ThreeTops[69]);
            ThreeTopsDick.Add(457, ThreeTops[70]);
            ThreeTopsDick.Add(466, ThreeTops[71]);
            ThreeTopsDick.Add(467, ThreeTops[72]);
            ThreeTopsDick.Add(477, ThreeTops[73]);
            ThreeTopsDick.Add(555, ThreeTops[74]);
            ThreeTopsDick.Add(556, ThreeTops[75]);
            ThreeTopsDick.Add(557, ThreeTops[76]);
            ThreeTopsDick.Add(566, ThreeTops[77]);
            ThreeTopsDick.Add(567, ThreeTops[78]);
            ThreeTopsDick.Add(577, ThreeTops[79]);
            ThreeTopsDick.Add(666, ThreeTops[80]);
            ThreeTopsDick.Add(667, ThreeTops[81]);
            ThreeTopsDick.Add(677, ThreeTops[82]);
            ThreeTopsDick.Add(777, ThreeTops[83]);
            #endregion
            #region 
            FourTopsDick.Add(1111, FourTops[0]);
            FourTopsDick.Add(1112, FourTops[1]);
            FourTopsDick.Add(1113, FourTops[2]);
            FourTopsDick.Add(1114, FourTops[3]);
            FourTopsDick.Add(1115, FourTops[4]);
            FourTopsDick.Add(1116, FourTops[5]);
            FourTopsDick.Add(1117, FourTops[6]);
            FourTopsDick.Add(1122, FourTops[7]);
            FourTopsDick.Add(1123, FourTops[8]);
            FourTopsDick.Add(1124, FourTops[9]);
            FourTopsDick.Add(1125, FourTops[10]);
            FourTopsDick.Add(1126, FourTops[11]);
            FourTopsDick.Add(1127, FourTops[12]);
            FourTopsDick.Add(1133, FourTops[13]);
            FourTopsDick.Add(1134, FourTops[14]);
            FourTopsDick.Add(1135, FourTops[15]);
            FourTopsDick.Add(1136, FourTops[16]);
            FourTopsDick.Add(1137, FourTops[17]);
            FourTopsDick.Add(1144, FourTops[18]);
            FourTopsDick.Add(1145, FourTops[19]);
            FourTopsDick.Add(1146, FourTops[20]);
            FourTopsDick.Add(1147, FourTops[21]);
            FourTopsDick.Add(1155, FourTops[22]);
            FourTopsDick.Add(1156, FourTops[23]);
            FourTopsDick.Add(1157, FourTops[24]);
            FourTopsDick.Add(1166, FourTops[25]);
            FourTopsDick.Add(1167, FourTops[26]);
            FourTopsDick.Add(1177, FourTops[27]);
            FourTopsDick.Add(1222, FourTops[28]);
            FourTopsDick.Add(1223, FourTops[29]);
            FourTopsDick.Add(1224, FourTops[30]);
            FourTopsDick.Add(1225, FourTops[31]);
            FourTopsDick.Add(1226, FourTops[32]);
            FourTopsDick.Add(1227, FourTops[33]);
            FourTopsDick.Add(1233, FourTops[34]);
            FourTopsDick.Add(1234, FourTops[35]);
            FourTopsDick.Add(1235, FourTops[36]);
            FourTopsDick.Add(1236, FourTops[37]);
            FourTopsDick.Add(1237, FourTops[38]);
            FourTopsDick.Add(1244, FourTops[39]);
            FourTopsDick.Add(1245, FourTops[40]);
            FourTopsDick.Add(1246, FourTops[41]);
            FourTopsDick.Add(1247, FourTops[42]);
            FourTopsDick.Add(1255, FourTops[43]);
            FourTopsDick.Add(1256, FourTops[44]);
            FourTopsDick.Add(1257, FourTops[45]);
            FourTopsDick.Add(1266, FourTops[46]);
            FourTopsDick.Add(1267, FourTops[47]);
            FourTopsDick.Add(1277, FourTops[48]);
            FourTopsDick.Add(1333, FourTops[49]);
            FourTopsDick.Add(1334, FourTops[50]);
            FourTopsDick.Add(1335, FourTops[51]);
            FourTopsDick.Add(1336, FourTops[52]);
            FourTopsDick.Add(1337, FourTops[53]);
            FourTopsDick.Add(1344, FourTops[54]);
            FourTopsDick.Add(1345, FourTops[55]);
            FourTopsDick.Add(1346, FourTops[56]);
            FourTopsDick.Add(1347, FourTops[57]);
            FourTopsDick.Add(1355, FourTops[58]);
            FourTopsDick.Add(1356, FourTops[59]);
            FourTopsDick.Add(1357, FourTops[60]);
            FourTopsDick.Add(1366, FourTops[61]);
            FourTopsDick.Add(1367, FourTops[62]);
            FourTopsDick.Add(1377, FourTops[63]);
            FourTopsDick.Add(1444, FourTops[64]);
            FourTopsDick.Add(1445, FourTops[65]);
            FourTopsDick.Add(1446, FourTops[66]);
            FourTopsDick.Add(1447, FourTops[67]);
            FourTopsDick.Add(1455, FourTops[68]);
            FourTopsDick.Add(1456, FourTops[69]);
            FourTopsDick.Add(1457, FourTops[70]);
            FourTopsDick.Add(1466, FourTops[71]);
            FourTopsDick.Add(1467, FourTops[72]);
            FourTopsDick.Add(1477, FourTops[73]);
            FourTopsDick.Add(1555, FourTops[74]);
            FourTopsDick.Add(1556, FourTops[75]);
            FourTopsDick.Add(1557, FourTops[76]);
            FourTopsDick.Add(1566, FourTops[77]);
            FourTopsDick.Add(1567, FourTops[78]);
            FourTopsDick.Add(1577, FourTops[79]);
            FourTopsDick.Add(1666, FourTops[80]);
            FourTopsDick.Add(1667, FourTops[81]);
            FourTopsDick.Add(1677, FourTops[82]);
            FourTopsDick.Add(1777, FourTops[83]);
            FourTopsDick.Add(2222, FourTops[84]);
            FourTopsDick.Add(2223, FourTops[85]);
            FourTopsDick.Add(2224, FourTops[86]);
            FourTopsDick.Add(2225, FourTops[87]);
            FourTopsDick.Add(2226, FourTops[88]);
            FourTopsDick.Add(2227, FourTops[89]);
            FourTopsDick.Add(2233, FourTops[90]);
            FourTopsDick.Add(2234, FourTops[91]);
            FourTopsDick.Add(2235, FourTops[92]);
            FourTopsDick.Add(2236, FourTops[93]);
            FourTopsDick.Add(2237, FourTops[94]);
            FourTopsDick.Add(2244, FourTops[95]);
            FourTopsDick.Add(2245, FourTops[96]);
            FourTopsDick.Add(2246, FourTops[97]);
            FourTopsDick.Add(2247, FourTops[98]);
            FourTopsDick.Add(2255, FourTops[99]);
            FourTopsDick.Add(2256, FourTops[100]);
            FourTopsDick.Add(2257, FourTops[101]);
            FourTopsDick.Add(2266, FourTops[102]);
            FourTopsDick.Add(2267, FourTops[103]);
            FourTopsDick.Add(2277, FourTops[104]);
            FourTopsDick.Add(2333, FourTops[105]);
            FourTopsDick.Add(2334, FourTops[106]);
            FourTopsDick.Add(2335, FourTops[107]);
            FourTopsDick.Add(2336, FourTops[108]);
            FourTopsDick.Add(2337, FourTops[109]);
            FourTopsDick.Add(2344, FourTops[110]);
            FourTopsDick.Add(2345, FourTops[111]);
            FourTopsDick.Add(2346, FourTops[112]);
            FourTopsDick.Add(2347, FourTops[113]);
            FourTopsDick.Add(2355, FourTops[114]);
            FourTopsDick.Add(2356, FourTops[115]);
            FourTopsDick.Add(2357, FourTops[116]);
            FourTopsDick.Add(2366, FourTops[117]);
            FourTopsDick.Add(2367, FourTops[118]);
            FourTopsDick.Add(2377, FourTops[119]);
            FourTopsDick.Add(2444, FourTops[120]);
            FourTopsDick.Add(2445, FourTops[121]);
            FourTopsDick.Add(2446, FourTops[122]);
            FourTopsDick.Add(2447, FourTops[123]);
            FourTopsDick.Add(2455, FourTops[124]);
            FourTopsDick.Add(2456, FourTops[125]);
            FourTopsDick.Add(2457, FourTops[126]);
            FourTopsDick.Add(2466, FourTops[127]);
            FourTopsDick.Add(2467, FourTops[128]);
            FourTopsDick.Add(2477, FourTops[129]);
            FourTopsDick.Add(2555, FourTops[130]);
            FourTopsDick.Add(2556, FourTops[131]);
            FourTopsDick.Add(2557, FourTops[132]);
            FourTopsDick.Add(2566, FourTops[133]);
            FourTopsDick.Add(2567, FourTops[134]);
            FourTopsDick.Add(2577, FourTops[135]);
            FourTopsDick.Add(2666, FourTops[136]);
            FourTopsDick.Add(2667, FourTops[137]);
            FourTopsDick.Add(2677, FourTops[138]);
            FourTopsDick.Add(2777, FourTops[139]);
            FourTopsDick.Add(3333, FourTops[140]);
            FourTopsDick.Add(3334, FourTops[141]);
            FourTopsDick.Add(3335, FourTops[142]);
            FourTopsDick.Add(3336, FourTops[143]);
            FourTopsDick.Add(3337, FourTops[144]);
            FourTopsDick.Add(3344, FourTops[145]);
            FourTopsDick.Add(3345, FourTops[146]);
            FourTopsDick.Add(3346, FourTops[147]);
            FourTopsDick.Add(3347, FourTops[148]);
            FourTopsDick.Add(3355, FourTops[149]);
            FourTopsDick.Add(3356, FourTops[150]);
            FourTopsDick.Add(3357, FourTops[151]);
            FourTopsDick.Add(3366, FourTops[152]);
            FourTopsDick.Add(3367, FourTops[153]);
            FourTopsDick.Add(3377, FourTops[154]);
            FourTopsDick.Add(3444, FourTops[155]);
            FourTopsDick.Add(3445, FourTops[156]);
            FourTopsDick.Add(3446, FourTops[157]);
            FourTopsDick.Add(3447, FourTops[158]);
            FourTopsDick.Add(3455, FourTops[159]);
            FourTopsDick.Add(3456, FourTops[160]);
            FourTopsDick.Add(3457, FourTops[161]);
            FourTopsDick.Add(3466, FourTops[162]);
            FourTopsDick.Add(3467, FourTops[163]);
            FourTopsDick.Add(3477, FourTops[164]);
            FourTopsDick.Add(3555, FourTops[165]);
            FourTopsDick.Add(3556, FourTops[166]);
            FourTopsDick.Add(3557, FourTops[167]);
            FourTopsDick.Add(3566, FourTops[168]);
            FourTopsDick.Add(3567, FourTops[169]);
            FourTopsDick.Add(3577, FourTops[170]);
            FourTopsDick.Add(3666, FourTops[171]);
            FourTopsDick.Add(3667, FourTops[172]);
            FourTopsDick.Add(3677, FourTops[173]);
            FourTopsDick.Add(3777, FourTops[174]);
            FourTopsDick.Add(4444, FourTops[175]);
            FourTopsDick.Add(4445, FourTops[176]);
            FourTopsDick.Add(4446, FourTops[177]);
            FourTopsDick.Add(4447, FourTops[178]);
            FourTopsDick.Add(4455, FourTops[179]);
            FourTopsDick.Add(4456, FourTops[180]);
            FourTopsDick.Add(4457, FourTops[181]);
            FourTopsDick.Add(4466, FourTops[182]);
            FourTopsDick.Add(4467, FourTops[183]);
            FourTopsDick.Add(4477, FourTops[184]);
            FourTopsDick.Add(4555, FourTops[185]);
            FourTopsDick.Add(4556, FourTops[186]);
            FourTopsDick.Add(4557, FourTops[187]);
            FourTopsDick.Add(4566, FourTops[188]);
            FourTopsDick.Add(4567, FourTops[189]);
            FourTopsDick.Add(4577, FourTops[190]);
            FourTopsDick.Add(4666, FourTops[191]);
            FourTopsDick.Add(4667, FourTops[192]);
            FourTopsDick.Add(4677, FourTops[193]);
            FourTopsDick.Add(4777, FourTops[194]);
            FourTopsDick.Add(5555, FourTops[195]);
            FourTopsDick.Add(5556, FourTops[196]);
            FourTopsDick.Add(5557, FourTops[197]);
            FourTopsDick.Add(5566, FourTops[198]);
            FourTopsDick.Add(5567, FourTops[199]);
            FourTopsDick.Add(5577, FourTops[200]);
            FourTopsDick.Add(5666, FourTops[201]);
            FourTopsDick.Add(5667, FourTops[202]);
            FourTopsDick.Add(5677, FourTops[203]);
            FourTopsDick.Add(5777, FourTops[204]);
            FourTopsDick.Add(6666, FourTops[205]);
            FourTopsDick.Add(6667, FourTops[206]);
            FourTopsDick.Add(6677, FourTops[207]);
            FourTopsDick.Add(6777, FourTops[208]);
            FourTopsDick.Add(7777, FourTops[209]);



            #endregion
            #region
            FiveTopsDick.Add(11111, FiveTops[0]);
            FiveTopsDick.Add(11112, FiveTops[1]);
            FiveTopsDick.Add(11113, FiveTops[2]);
            FiveTopsDick.Add(11114, FiveTops[3]);
            FiveTopsDick.Add(11115, FiveTops[4]);
            FiveTopsDick.Add(11116, FiveTops[5]);
            FiveTopsDick.Add(11117, FiveTops[6]);
            FiveTopsDick.Add(11122, FiveTops[7]);
            FiveTopsDick.Add(11123, FiveTops[8]);
            FiveTopsDick.Add(11124, FiveTops[9]);
            FiveTopsDick.Add(11125, FiveTops[10]);
            FiveTopsDick.Add(11126, FiveTops[11]);
            FiveTopsDick.Add(11127, FiveTops[12]);
            FiveTopsDick.Add(11133, FiveTops[13]);
            FiveTopsDick.Add(11134, FiveTops[14]);
            FiveTopsDick.Add(11135, FiveTops[15]);
            FiveTopsDick.Add(11136, FiveTops[16]);
            FiveTopsDick.Add(11137, FiveTops[17]);
            FiveTopsDick.Add(11144, FiveTops[18]);
            FiveTopsDick.Add(11145, FiveTops[19]);
            FiveTopsDick.Add(11146, FiveTops[20]);
            FiveTopsDick.Add(11147, FiveTops[21]);
            FiveTopsDick.Add(11155, FiveTops[22]);
            FiveTopsDick.Add(11156, FiveTops[23]);
            FiveTopsDick.Add(11157, FiveTops[24]);
            FiveTopsDick.Add(11166, FiveTops[25]);
            FiveTopsDick.Add(11167, FiveTops[26]);
            FiveTopsDick.Add(11177, FiveTops[27]);
            FiveTopsDick.Add(11222, FiveTops[28]);
            FiveTopsDick.Add(11223, FiveTops[29]);
            FiveTopsDick.Add(11224, FiveTops[30]);
            FiveTopsDick.Add(11225, FiveTops[31]);
            FiveTopsDick.Add(11226, FiveTops[32]);
            FiveTopsDick.Add(11227, FiveTops[33]);
            FiveTopsDick.Add(11233, FiveTops[34]);
            FiveTopsDick.Add(11234, FiveTops[35]);
            FiveTopsDick.Add(11235, FiveTops[36]);
            FiveTopsDick.Add(11236, FiveTops[37]);
            FiveTopsDick.Add(11237, FiveTops[38]);
            FiveTopsDick.Add(11244, FiveTops[39]);
            FiveTopsDick.Add(11245, FiveTops[40]);
            FiveTopsDick.Add(11246, FiveTops[41]);
            FiveTopsDick.Add(11247, FiveTops[42]);
            FiveTopsDick.Add(11255, FiveTops[43]);
            FiveTopsDick.Add(11256, FiveTops[44]);
            FiveTopsDick.Add(11257, FiveTops[45]);
            FiveTopsDick.Add(11266, FiveTops[46]);
            FiveTopsDick.Add(11267, FiveTops[47]);
            FiveTopsDick.Add(11277, FiveTops[48]);
            FiveTopsDick.Add(11333, FiveTops[49]);
            FiveTopsDick.Add(11334, FiveTops[50]);
            FiveTopsDick.Add(11335, FiveTops[51]);
            FiveTopsDick.Add(11336, FiveTops[52]);
            FiveTopsDick.Add(11337, FiveTops[53]);
            FiveTopsDick.Add(11344, FiveTops[54]);
            FiveTopsDick.Add(11345, FiveTops[55]);
            FiveTopsDick.Add(11346, FiveTops[56]);
            FiveTopsDick.Add(11347, FiveTops[57]);
            FiveTopsDick.Add(11355, FiveTops[58]);
            FiveTopsDick.Add(11356, FiveTops[59]);
            FiveTopsDick.Add(11357, FiveTops[60]);
            FiveTopsDick.Add(11366, FiveTops[61]);
            FiveTopsDick.Add(11367, FiveTops[62]);
            FiveTopsDick.Add(11377, FiveTops[63]);
            FiveTopsDick.Add(11444, FiveTops[64]);
            FiveTopsDick.Add(11445, FiveTops[65]);
            FiveTopsDick.Add(11446, FiveTops[66]);
            FiveTopsDick.Add(11447, FiveTops[67]);
            FiveTopsDick.Add(11455, FiveTops[68]);
            FiveTopsDick.Add(11456, FiveTops[69]);
            FiveTopsDick.Add(11457, FiveTops[70]);
            FiveTopsDick.Add(11466, FiveTops[71]);
            FiveTopsDick.Add(11467, FiveTops[72]);
            FiveTopsDick.Add(11477, FiveTops[73]);
            FiveTopsDick.Add(11555, FiveTops[74]);
            FiveTopsDick.Add(11556, FiveTops[75]);
            FiveTopsDick.Add(11557, FiveTops[76]);
            FiveTopsDick.Add(11566, FiveTops[77]);
            FiveTopsDick.Add(11567, FiveTops[78]);
            FiveTopsDick.Add(11577, FiveTops[79]);
            FiveTopsDick.Add(11666, FiveTops[80]);
            FiveTopsDick.Add(11667, FiveTops[81]);
            FiveTopsDick.Add(11677, FiveTops[82]);
            FiveTopsDick.Add(11777, FiveTops[83]);
            FiveTopsDick.Add(12222, FiveTops[84]);
            FiveTopsDick.Add(12223, FiveTops[85]);
            FiveTopsDick.Add(12224, FiveTops[86]);
            FiveTopsDick.Add(12225, FiveTops[87]);
            FiveTopsDick.Add(12226, FiveTops[88]);
            FiveTopsDick.Add(12227, FiveTops[89]);
            FiveTopsDick.Add(12233, FiveTops[90]);
            FiveTopsDick.Add(12234, FiveTops[91]);
            FiveTopsDick.Add(12235, FiveTops[92]);
            FiveTopsDick.Add(12236, FiveTops[93]);
            FiveTopsDick.Add(12237, FiveTops[94]);
            FiveTopsDick.Add(12244, FiveTops[95]);
            FiveTopsDick.Add(12245, FiveTops[96]);
            FiveTopsDick.Add(12246, FiveTops[97]);
            FiveTopsDick.Add(12247, FiveTops[98]);
            FiveTopsDick.Add(12255, FiveTops[99]);
            FiveTopsDick.Add(12256, FiveTops[100]);
            FiveTopsDick.Add(12257, FiveTops[101]);
            FiveTopsDick.Add(12266, FiveTops[102]);
            FiveTopsDick.Add(12267, FiveTops[103]);
            FiveTopsDick.Add(12277, FiveTops[104]);
            FiveTopsDick.Add(12333, FiveTops[105]);
            FiveTopsDick.Add(12334, FiveTops[106]);
            FiveTopsDick.Add(12335, FiveTops[107]);
            FiveTopsDick.Add(12336, FiveTops[108]);
            FiveTopsDick.Add(12337, FiveTops[109]);
            FiveTopsDick.Add(12344, FiveTops[110]);
            FiveTopsDick.Add(12345, FiveTops[111]);
            FiveTopsDick.Add(12346, FiveTops[112]);
            FiveTopsDick.Add(12347, FiveTops[113]);
            FiveTopsDick.Add(12355, FiveTops[114]);
            FiveTopsDick.Add(12356, FiveTops[115]);
            FiveTopsDick.Add(12357, FiveTops[116]);
            FiveTopsDick.Add(12366, FiveTops[117]);
            FiveTopsDick.Add(12367, FiveTops[118]);
            FiveTopsDick.Add(12377, FiveTops[119]);
            FiveTopsDick.Add(12444, FiveTops[120]);
            FiveTopsDick.Add(12445, FiveTops[121]);
            FiveTopsDick.Add(12446, FiveTops[122]);
            FiveTopsDick.Add(12447, FiveTops[123]);
            FiveTopsDick.Add(12455, FiveTops[124]);
            FiveTopsDick.Add(12456, FiveTops[125]);
            FiveTopsDick.Add(12457, FiveTops[126]);
            FiveTopsDick.Add(12466, FiveTops[127]);
            FiveTopsDick.Add(12467, FiveTops[128]);
            FiveTopsDick.Add(12477, FiveTops[129]);
            FiveTopsDick.Add(12555, FiveTops[130]);
            FiveTopsDick.Add(12556, FiveTops[131]);
            FiveTopsDick.Add(12557, FiveTops[132]);
            FiveTopsDick.Add(12566, FiveTops[133]);
            FiveTopsDick.Add(12567, FiveTops[134]);
            FiveTopsDick.Add(12577, FiveTops[135]);
            FiveTopsDick.Add(12666, FiveTops[136]);
            FiveTopsDick.Add(12667, FiveTops[137]);
            FiveTopsDick.Add(12677, FiveTops[138]);
            FiveTopsDick.Add(12777, FiveTops[139]);
            FiveTopsDick.Add(13333, FiveTops[140]);
            FiveTopsDick.Add(13334, FiveTops[141]);
            FiveTopsDick.Add(13335, FiveTops[142]);
            FiveTopsDick.Add(13336, FiveTops[143]);
            FiveTopsDick.Add(13337, FiveTops[144]);
            FiveTopsDick.Add(13344, FiveTops[145]);
            FiveTopsDick.Add(13345, FiveTops[146]);
            FiveTopsDick.Add(13346, FiveTops[147]);
            FiveTopsDick.Add(13347, FiveTops[148]);
            FiveTopsDick.Add(13355, FiveTops[149]);
            FiveTopsDick.Add(13356, FiveTops[150]);
            FiveTopsDick.Add(13357, FiveTops[151]);
            FiveTopsDick.Add(13366, FiveTops[152]);
            FiveTopsDick.Add(13367, FiveTops[153]);
            FiveTopsDick.Add(13377, FiveTops[154]);
            FiveTopsDick.Add(13444, FiveTops[155]);
            FiveTopsDick.Add(13445, FiveTops[156]);
            FiveTopsDick.Add(13446, FiveTops[157]);
            FiveTopsDick.Add(13447, FiveTops[158]);
            FiveTopsDick.Add(13455, FiveTops[159]);
            FiveTopsDick.Add(13456, FiveTops[160]);
            FiveTopsDick.Add(13457, FiveTops[161]);
            FiveTopsDick.Add(13466, FiveTops[162]);
            FiveTopsDick.Add(13467, FiveTops[163]);
            FiveTopsDick.Add(13477, FiveTops[164]);
            FiveTopsDick.Add(13555, FiveTops[165]);
            FiveTopsDick.Add(13556, FiveTops[166]);
            FiveTopsDick.Add(13557, FiveTops[167]);
            FiveTopsDick.Add(13566, FiveTops[168]);
            FiveTopsDick.Add(13567, FiveTops[169]);
            FiveTopsDick.Add(13577, FiveTops[170]);
            FiveTopsDick.Add(13666, FiveTops[171]);
            FiveTopsDick.Add(13667, FiveTops[172]);
            FiveTopsDick.Add(13677, FiveTops[173]);
            FiveTopsDick.Add(13777, FiveTops[174]);
            FiveTopsDick.Add(14444, FiveTops[175]);
            FiveTopsDick.Add(14445, FiveTops[176]);
            FiveTopsDick.Add(14446, FiveTops[177]);
            FiveTopsDick.Add(14447, FiveTops[178]);
            FiveTopsDick.Add(14455, FiveTops[179]);
            FiveTopsDick.Add(14456, FiveTops[180]);
            FiveTopsDick.Add(14457, FiveTops[181]);
            FiveTopsDick.Add(14466, FiveTops[182]);
            FiveTopsDick.Add(14467, FiveTops[183]);
            FiveTopsDick.Add(14477, FiveTops[184]);
            FiveTopsDick.Add(14555, FiveTops[185]);
            FiveTopsDick.Add(14556, FiveTops[186]);
            FiveTopsDick.Add(14557, FiveTops[187]);
            FiveTopsDick.Add(14566, FiveTops[188]);
            FiveTopsDick.Add(14567, FiveTops[189]);
            FiveTopsDick.Add(14577, FiveTops[190]);
            FiveTopsDick.Add(14666, FiveTops[191]);
            FiveTopsDick.Add(14667, FiveTops[192]);
            FiveTopsDick.Add(14677, FiveTops[193]);
            FiveTopsDick.Add(14777, FiveTops[194]);
            FiveTopsDick.Add(15555, FiveTops[195]);
            FiveTopsDick.Add(15556, FiveTops[196]);
            FiveTopsDick.Add(15557, FiveTops[197]);
            FiveTopsDick.Add(15566, FiveTops[198]);
            FiveTopsDick.Add(15567, FiveTops[199]);
            FiveTopsDick.Add(15577, FiveTops[200]);
            FiveTopsDick.Add(15666, FiveTops[201]);
            FiveTopsDick.Add(15667, FiveTops[202]);
            FiveTopsDick.Add(15677, FiveTops[203]);
            FiveTopsDick.Add(15777, FiveTops[204]);
            FiveTopsDick.Add(16666, FiveTops[205]);
            FiveTopsDick.Add(16667, FiveTops[206]);
            FiveTopsDick.Add(16677, FiveTops[207]);
            FiveTopsDick.Add(16777, FiveTops[208]);
            FiveTopsDick.Add(17777, FiveTops[209]);
            FiveTopsDick.Add(22222, FiveTops[210]);
            FiveTopsDick.Add(22223, FiveTops[211]);
            FiveTopsDick.Add(22224, FiveTops[212]);
            FiveTopsDick.Add(22225, FiveTops[213]);
            FiveTopsDick.Add(22226, FiveTops[214]);
            FiveTopsDick.Add(22227, FiveTops[215]);
            FiveTopsDick.Add(22233, FiveTops[216]);
            FiveTopsDick.Add(22234, FiveTops[217]);
            FiveTopsDick.Add(22235, FiveTops[218]);
            FiveTopsDick.Add(22236, FiveTops[219]);
            FiveTopsDick.Add(22237, FiveTops[220]);
            FiveTopsDick.Add(22244, FiveTops[221]);
            FiveTopsDick.Add(22245, FiveTops[222]);
            FiveTopsDick.Add(22246, FiveTops[223]);
            FiveTopsDick.Add(22247, FiveTops[224]);
            FiveTopsDick.Add(22255, FiveTops[225]);
            FiveTopsDick.Add(22256, FiveTops[226]);
            FiveTopsDick.Add(22257, FiveTops[227]);
            FiveTopsDick.Add(22266, FiveTops[228]);
            FiveTopsDick.Add(22267, FiveTops[229]);
            FiveTopsDick.Add(22277, FiveTops[230]);
            FiveTopsDick.Add(22333, FiveTops[231]);
            FiveTopsDick.Add(22334, FiveTops[232]);
            FiveTopsDick.Add(22335, FiveTops[233]);
            FiveTopsDick.Add(22336, FiveTops[234]);
            FiveTopsDick.Add(22337, FiveTops[235]);
            FiveTopsDick.Add(22344, FiveTops[236]);
            FiveTopsDick.Add(22345, FiveTops[237]);
            FiveTopsDick.Add(22346, FiveTops[238]);
            FiveTopsDick.Add(22347, FiveTops[239]);
            FiveTopsDick.Add(22355, FiveTops[240]);
            FiveTopsDick.Add(22356, FiveTops[241]);
            FiveTopsDick.Add(22357, FiveTops[242]);
            FiveTopsDick.Add(22366, FiveTops[243]);
            FiveTopsDick.Add(22367, FiveTops[244]);
            FiveTopsDick.Add(22377, FiveTops[245]);
            FiveTopsDick.Add(22444, FiveTops[246]);
            FiveTopsDick.Add(22445, FiveTops[247]);
            FiveTopsDick.Add(22446, FiveTops[248]);
            FiveTopsDick.Add(22447, FiveTops[249]);
            FiveTopsDick.Add(22455, FiveTops[250]);
            FiveTopsDick.Add(22456, FiveTops[251]);
            FiveTopsDick.Add(22457, FiveTops[252]);
            FiveTopsDick.Add(22466, FiveTops[253]);
            FiveTopsDick.Add(22467, FiveTops[254]);
            FiveTopsDick.Add(22477, FiveTops[255]);
            FiveTopsDick.Add(22555, FiveTops[256]);
            FiveTopsDick.Add(22556, FiveTops[257]);
            FiveTopsDick.Add(22557, FiveTops[258]);
            FiveTopsDick.Add(22566, FiveTops[259]);
            FiveTopsDick.Add(22567, FiveTops[260]);
            FiveTopsDick.Add(22577, FiveTops[261]);
            FiveTopsDick.Add(22666, FiveTops[262]);
            FiveTopsDick.Add(22667, FiveTops[263]);
            FiveTopsDick.Add(22677, FiveTops[264]);
            FiveTopsDick.Add(22777, FiveTops[265]);
            FiveTopsDick.Add(23333, FiveTops[266]);
            FiveTopsDick.Add(23334, FiveTops[267]);
            FiveTopsDick.Add(23335, FiveTops[268]);
            FiveTopsDick.Add(23336, FiveTops[269]);
            FiveTopsDick.Add(23337, FiveTops[270]);
            FiveTopsDick.Add(23344, FiveTops[271]);
            FiveTopsDick.Add(23345, FiveTops[272]);
            FiveTopsDick.Add(23346, FiveTops[273]);
            FiveTopsDick.Add(23347, FiveTops[274]);
            FiveTopsDick.Add(23355, FiveTops[275]);
            FiveTopsDick.Add(23356, FiveTops[276]);
            FiveTopsDick.Add(23357, FiveTops[277]);
            FiveTopsDick.Add(23366, FiveTops[278]);
            FiveTopsDick.Add(23367, FiveTops[279]);
            FiveTopsDick.Add(23377, FiveTops[280]);
            FiveTopsDick.Add(23444, FiveTops[281]);
            FiveTopsDick.Add(23445, FiveTops[282]);
            FiveTopsDick.Add(23446, FiveTops[283]);
            FiveTopsDick.Add(23447, FiveTops[284]);
            FiveTopsDick.Add(23455, FiveTops[285]);
            FiveTopsDick.Add(23456, FiveTops[286]);
            FiveTopsDick.Add(23457, FiveTops[287]);
            FiveTopsDick.Add(23466, FiveTops[288]);
            FiveTopsDick.Add(23467, FiveTops[289]);
            FiveTopsDick.Add(23477, FiveTops[290]);
            FiveTopsDick.Add(23555, FiveTops[291]);
            FiveTopsDick.Add(23556, FiveTops[292]);
            FiveTopsDick.Add(23557, FiveTops[293]);
            FiveTopsDick.Add(23566, FiveTops[294]);
            FiveTopsDick.Add(23567, FiveTops[295]);
            FiveTopsDick.Add(23577, FiveTops[296]);
            FiveTopsDick.Add(23666, FiveTops[297]);
            FiveTopsDick.Add(23667, FiveTops[298]);
            FiveTopsDick.Add(23677, FiveTops[299]);
            FiveTopsDick.Add(23777, FiveTops[300]);
            FiveTopsDick.Add(24444, FiveTops[301]);
            FiveTopsDick.Add(24445, FiveTops[302]);
            FiveTopsDick.Add(24446, FiveTops[303]);
            FiveTopsDick.Add(24447, FiveTops[304]);
            FiveTopsDick.Add(24455, FiveTops[305]);
            FiveTopsDick.Add(24456, FiveTops[306]);
            FiveTopsDick.Add(24457, FiveTops[307]);
            FiveTopsDick.Add(24466, FiveTops[308]);
            FiveTopsDick.Add(24467, FiveTops[309]);
            FiveTopsDick.Add(24477, FiveTops[310]);
            FiveTopsDick.Add(24555, FiveTops[311]);
            FiveTopsDick.Add(24556, FiveTops[312]);
            FiveTopsDick.Add(24557, FiveTops[313]);
            FiveTopsDick.Add(24566, FiveTops[314]);
            FiveTopsDick.Add(24567, FiveTops[315]);
            FiveTopsDick.Add(24577, FiveTops[316]);
            FiveTopsDick.Add(24666, FiveTops[317]);
            FiveTopsDick.Add(24667, FiveTops[318]);
            FiveTopsDick.Add(24677, FiveTops[319]);
            FiveTopsDick.Add(24777, FiveTops[320]);
            FiveTopsDick.Add(25555, FiveTops[321]);
            FiveTopsDick.Add(25556, FiveTops[322]);
            FiveTopsDick.Add(25557, FiveTops[323]);
            FiveTopsDick.Add(25566, FiveTops[324]);
            FiveTopsDick.Add(25567, FiveTops[325]);
            FiveTopsDick.Add(25577, FiveTops[326]);
            FiveTopsDick.Add(25666, FiveTops[327]);
            FiveTopsDick.Add(25667, FiveTops[328]);
            FiveTopsDick.Add(25677, FiveTops[329]);
            FiveTopsDick.Add(25777, FiveTops[330]);
            FiveTopsDick.Add(26666, FiveTops[331]);
            FiveTopsDick.Add(26667, FiveTops[332]);
            FiveTopsDick.Add(26677, FiveTops[333]);
            FiveTopsDick.Add(26777, FiveTops[334]);
            FiveTopsDick.Add(27777, FiveTops[335]);
            FiveTopsDick.Add(33333, FiveTops[336]);
            FiveTopsDick.Add(33334, FiveTops[337]);
            FiveTopsDick.Add(33335, FiveTops[338]);
            FiveTopsDick.Add(33336, FiveTops[339]);
            FiveTopsDick.Add(33337, FiveTops[340]);
            FiveTopsDick.Add(33344, FiveTops[341]);
            FiveTopsDick.Add(33345, FiveTops[342]);
            FiveTopsDick.Add(33346, FiveTops[343]);
            FiveTopsDick.Add(33347, FiveTops[344]);
            FiveTopsDick.Add(33355, FiveTops[345]);
            FiveTopsDick.Add(33356, FiveTops[346]);
            FiveTopsDick.Add(33357, FiveTops[347]);
            FiveTopsDick.Add(33366, FiveTops[348]);
            FiveTopsDick.Add(33367, FiveTops[349]);
            FiveTopsDick.Add(33377, FiveTops[350]);
            FiveTopsDick.Add(33444, FiveTops[351]);
            FiveTopsDick.Add(33445, FiveTops[352]);
            FiveTopsDick.Add(33446, FiveTops[353]);
            FiveTopsDick.Add(33447, FiveTops[354]);
            FiveTopsDick.Add(33455, FiveTops[355]);
            FiveTopsDick.Add(33456, FiveTops[356]);
            FiveTopsDick.Add(33457, FiveTops[357]);
            FiveTopsDick.Add(33466, FiveTops[358]);
            FiveTopsDick.Add(33467, FiveTops[359]);
            FiveTopsDick.Add(33477, FiveTops[360]);
            FiveTopsDick.Add(33555, FiveTops[361]);
            FiveTopsDick.Add(33556, FiveTops[362]);
            FiveTopsDick.Add(33557, FiveTops[363]);
            FiveTopsDick.Add(33566, FiveTops[364]);
            FiveTopsDick.Add(33567, FiveTops[365]);
            FiveTopsDick.Add(33577, FiveTops[366]);
            FiveTopsDick.Add(33666, FiveTops[367]);
            FiveTopsDick.Add(33667, FiveTops[368]);
            FiveTopsDick.Add(33677, FiveTops[369]);
            FiveTopsDick.Add(33777, FiveTops[370]);
            FiveTopsDick.Add(34444, FiveTops[371]);
            FiveTopsDick.Add(34445, FiveTops[372]);
            FiveTopsDick.Add(34446, FiveTops[373]);
            FiveTopsDick.Add(34447, FiveTops[374]);
            FiveTopsDick.Add(34455, FiveTops[375]);
            FiveTopsDick.Add(34456, FiveTops[376]);
            FiveTopsDick.Add(34457, FiveTops[377]);
            FiveTopsDick.Add(34466, FiveTops[378]);
            FiveTopsDick.Add(34467, FiveTops[379]);
            FiveTopsDick.Add(34477, FiveTops[380]);
            FiveTopsDick.Add(34555, FiveTops[381]);
            FiveTopsDick.Add(34556, FiveTops[382]);
            FiveTopsDick.Add(34557, FiveTops[383]);
            FiveTopsDick.Add(34566, FiveTops[384]);
            FiveTopsDick.Add(34567, FiveTops[385]);
            FiveTopsDick.Add(34577, FiveTops[386]);
            FiveTopsDick.Add(34666, FiveTops[387]);
            FiveTopsDick.Add(34667, FiveTops[388]);
            FiveTopsDick.Add(34677, FiveTops[389]);
            FiveTopsDick.Add(34777, FiveTops[390]);
            FiveTopsDick.Add(35555, FiveTops[391]);
            FiveTopsDick.Add(35556, FiveTops[392]);
            FiveTopsDick.Add(35557, FiveTops[393]);
            FiveTopsDick.Add(35566, FiveTops[394]);
            FiveTopsDick.Add(35567, FiveTops[395]);
            FiveTopsDick.Add(35577, FiveTops[396]);
            FiveTopsDick.Add(35666, FiveTops[397]);
            FiveTopsDick.Add(35667, FiveTops[398]);
            FiveTopsDick.Add(35677, FiveTops[399]);
            FiveTopsDick.Add(35777, FiveTops[400]);
            FiveTopsDick.Add(36666, FiveTops[401]);
            FiveTopsDick.Add(36667, FiveTops[402]);
            FiveTopsDick.Add(36677, FiveTops[403]);
            FiveTopsDick.Add(36777, FiveTops[404]);
            FiveTopsDick.Add(37777, FiveTops[405]);
            FiveTopsDick.Add(44444, FiveTops[406]);
            FiveTopsDick.Add(44445, FiveTops[407]);
            FiveTopsDick.Add(44446, FiveTops[408]);
            FiveTopsDick.Add(44447, FiveTops[409]);
            FiveTopsDick.Add(44455, FiveTops[410]);
            FiveTopsDick.Add(44456, FiveTops[411]);
            FiveTopsDick.Add(44457, FiveTops[412]);
            FiveTopsDick.Add(44466, FiveTops[413]);
            FiveTopsDick.Add(44467, FiveTops[414]);
            FiveTopsDick.Add(44477, FiveTops[415]);
            FiveTopsDick.Add(44555, FiveTops[416]);
            FiveTopsDick.Add(44556, FiveTops[417]);
            FiveTopsDick.Add(44557, FiveTops[418]);
            FiveTopsDick.Add(44566, FiveTops[419]);
            FiveTopsDick.Add(44567, FiveTops[420]);
            FiveTopsDick.Add(44577, FiveTops[421]);
            FiveTopsDick.Add(44666, FiveTops[422]);
            FiveTopsDick.Add(44667, FiveTops[423]);
            FiveTopsDick.Add(44677, FiveTops[424]);
            FiveTopsDick.Add(44777, FiveTops[425]);
            FiveTopsDick.Add(45555, FiveTops[426]);
            FiveTopsDick.Add(45556, FiveTops[427]);
            FiveTopsDick.Add(45557, FiveTops[428]);
            FiveTopsDick.Add(45566, FiveTops[429]);
            FiveTopsDick.Add(45567, FiveTops[430]);
            FiveTopsDick.Add(45577, FiveTops[431]);
            FiveTopsDick.Add(45666, FiveTops[432]);
            FiveTopsDick.Add(45667, FiveTops[433]);
            FiveTopsDick.Add(45677, FiveTops[434]);
            FiveTopsDick.Add(45777, FiveTops[435]);
            FiveTopsDick.Add(46666, FiveTops[436]);
            FiveTopsDick.Add(46667, FiveTops[437]);
            FiveTopsDick.Add(46677, FiveTops[438]);
            FiveTopsDick.Add(46777, FiveTops[439]);
            FiveTopsDick.Add(47777, FiveTops[440]);
            FiveTopsDick.Add(55555, FiveTops[441]);
            FiveTopsDick.Add(55556, FiveTops[442]);
            FiveTopsDick.Add(55557, FiveTops[443]);
            FiveTopsDick.Add(55566, FiveTops[444]);
            FiveTopsDick.Add(55567, FiveTops[445]);
            FiveTopsDick.Add(55577, FiveTops[446]);
            FiveTopsDick.Add(55666, FiveTops[447]);
            FiveTopsDick.Add(55667, FiveTops[448]);
            FiveTopsDick.Add(55677, FiveTops[449]);
            FiveTopsDick.Add(55777, FiveTops[450]);
            FiveTopsDick.Add(56666, FiveTops[451]);
            FiveTopsDick.Add(56667, FiveTops[452]);
            FiveTopsDick.Add(56677, FiveTops[453]);
            FiveTopsDick.Add(56777, FiveTops[454]);
            FiveTopsDick.Add(57777, FiveTops[455]);
            FiveTopsDick.Add(66666, FiveTops[456]);
            FiveTopsDick.Add(66667, FiveTops[457]);
            FiveTopsDick.Add(66677, FiveTops[458]);
            FiveTopsDick.Add(66777, FiveTops[459]);
            FiveTopsDick.Add(67777, FiveTops[460]);
            FiveTopsDick.Add(77777, FiveTops[461]);



            #endregion
        }
        private void Update()
        {
            caughtToppingsgo = GameObject.FindGameObjectsWithTag("Stack");
            caughtToppingsint = caughtToppingsgo.Length;
            if (caughtToppingsint == 5)
            {
                Assemble();
            }
            if (Input.GetKeyDown(KeyCode.Z) ^ Input.GetKeyDown(KeyCode.X))
            {
                if (Input.GetKeyDown(KeyCode.Z))
                    SwapSam(1);
                if (Input.GetKeyDown(KeyCode.X))
                    SwapSam(2);
            }
        }
        public void FindSam()
        {
            List<int> keyList = new List<int> { };

            for (int i = 0; i < caughtToppingsgo.Length; i++)
            {
                keyList.Add(caughtToppingsgo[i].GetComponent<FallingToppings>().ID);
            }
            keyList.Sort();

            switch (caughtToppingsint)
            {
                case 1:
                    samKey = keyList[0];
                    Sandwhich = OneTopsDick[samKey];
                    break;
                case 2:
                    samKey = SammichHelper.MakeKey(caughtToppingsint,keyList);
                    Sandwhich = TwoTopsDick[samKey];
                    break;
                case 3:
                    samKey = SammichHelper.MakeKey(caughtToppingsint, keyList);
                    Sandwhich = ThreeTopsDick[samKey];
                    
                    break;
                case 4:
                    samKey = SammichHelper.MakeKey(caughtToppingsint, keyList);
                    Sandwhich = FourTopsDick[samKey];
                    
                    break;
                case 5:
                    samKey = SammichHelper.MakeKey(caughtToppingsint, keyList);
                    Sandwhich = FiveTopsDick[samKey];
                    
                    break;
                default:
                    break;
            }
        }
        public void PutSam()
        {
            if (firstSam == true)                                           
            {
                newSamPos = SamPrefab.transform.position;              

                GameObject FinishedSam = Instantiate(SamPrefab, newSamPos, Quaternion.identity);
                finishedSams.Add(FinishedSam);                          
                firstSam = false;
                FinishedSam.GetComponent<SpriteRenderer>().sprite = Sandwhich;
                #region
                Debug.Log("Debug 1 - After if block in PutSam() \r\n" +
                "newSamPos:" + newSamPos.ToString() + "\r\n" +
                      "First Sam?:" + firstSam.ToString() + "\r\n" +
                      "listPos:  " + listPos.ToString() + "\r\n" +
                      "FinishedSams:" + finishedSams.Count + "\r\n" +
                      "samKey:       " + samKey);
                #endregion

            }
            else
            {
                listPos = finishedSams.Count - 1;                            
                samPos = finishedSams[listPos].transform.position;            
                newSamPos = samPos + temp;                                    
                GameObject FinishedSam = Instantiate(SamPrefab, newSamPos, Quaternion.identity);
                finishedSams.Add(FinishedSam);                                

                FinishedSam.GetComponent<SpriteRenderer>().sprite = Sandwhich;
                #region
                Debug.Log("Debug 2 - After else block in PutSam() \r\n" + "\r\n" +
                     "newSamPos:" + newSamPos.ToString() + "\r\n" +
                     "First Sam?:" + firstSam.ToString() + "\r\n" +
                     "listPos:  " + listPos.ToString() + "\r\n" +
                     "FinishedSams:" + finishedSams.Count + "\r\n" +
                     "samKey:       " + samKey + "\r\n" + "\r\n");
                #endregion
            }
        }
        public void SwapSam(int side)
        {
            float y = -20f;
            switch (side)
            {
                case 1:
                    if (!sideSam1Full)
                    {
                        sideSam1Full = true;
                        sideSams1 = new GameObject[caughtToppingsint];
                        System.Array.Copy(caughtToppingsgo, sideSams1, caughtToppingsgo.Length);

                        for (int i = 0; i < sideSams1.Length; i++)
                        {
                            sideSams1[i].transform.position = new Vector3(-210, 60 + y);
                            sideSams1[i].GetComponent<FallingToppings>().enabled = false;
                            sideSams1[i].GetComponent<Collider2D>().enabled = false;
                            sideSams1[i].tag = "SideSam1";
                            y -= 20f;
                        }

                    }
                    else
                    {
                        if (caughtToppingsgo.Length != 0)
                        {
                            GameObject[] tempArray = new GameObject[sideSams1.Length];
                            Array.Copy(sideSams1, tempArray, sideSams1.Length);

                            Array.Resize(ref sideSams1, caughtToppingsgo.Length);
                            Array.Copy(caughtToppingsgo, sideSams1, caughtToppingsgo.Length);

                            Array.Resize(ref caughtToppingsgo, tempArray.Length);
                            Array.Copy(tempArray, caughtToppingsgo, tempArray.Length);

                            for (int j = sideSams1.Length - 1; j > -1; j--)
                            {
                                sideSams1[j].transform.position = new Vector3(-210, 60 + y);
                                sideSams1[j].GetComponent<FallingToppings>().enabled = false;
                                sideSams1[j].GetComponent<Collider2D>().enabled = false;
                                sideSams1[j].tag = "SideSam1";
                                y -= 20f;
                            }

                            for (int n = 0; n < caughtToppingsgo.Length; n++)
                            {
                                caughtToppingsgo[n].GetComponent<FallingToppings>().enabled = true;
                                caughtToppingsgo[n].GetComponent<Collider2D>().enabled = true;
                                caughtToppingsgo[n].tag = "Stack";
                            }
                        }
                        else
                        {
                            Array.Resize(ref caughtToppingsgo, sideSams1.Length);
                            Array.Copy(sideSams1, caughtToppingsgo, sideSams1.Length);
                            Array.Clear(sideSams1, 0, sideSams1.Length);

                            for (int n = 0; n < caughtToppingsgo.Length; n++)
                            {
                                caughtToppingsgo[n].GetComponent<FallingToppings>().enabled = true;
                                caughtToppingsgo[n].GetComponent<Collider2D>().enabled = true;
                                caughtToppingsgo[n].tag = "Stack";
                            }
                            sideSam1Full = false;
                        }
                    }
                    break;
                case 2:
                    if (!sideSam2Full)
                    {
                        sideSam2Full = true;
                        sideSams2 = new GameObject[caughtToppingsint];
                        System.Array.Copy(caughtToppingsgo, sideSams2, caughtToppingsgo.Length);

                        for (int i = 0; i < sideSams2.Length; i++)
                        {
                            sideSams2[i].transform.position = new Vector3(-180, 60 + y);
                            sideSams2[i].GetComponent<FallingToppings>().enabled = false;
                            sideSams2[i].GetComponent<Collider2D>().enabled = false;
                            sideSams2[i].tag = "SideSam2";
                            y -= 20f;
                        }

                    }
                    else
                    {
                        if (caughtToppingsgo.Length != 0)
                        {
                            GameObject[] tempArray = new GameObject[sideSams2.Length];
                            Array.Copy(sideSams2, tempArray, sideSams2.Length);

                            Array.Resize(ref sideSams2, caughtToppingsgo.Length);
                            Array.Copy(caughtToppingsgo, sideSams2, caughtToppingsgo.Length);

                            Array.Resize(ref caughtToppingsgo, tempArray.Length);
                            Array.Copy(tempArray, caughtToppingsgo, tempArray.Length);

                            for (int j = sideSams2.Length - 1; j > -1; j--)
                            {
                                sideSams2[j].transform.position = new Vector3(-180, 60 + y);
                                sideSams2[j].GetComponent<FallingToppings>().enabled = false;
                                sideSams2[j].GetComponent<Collider2D>().enabled = false;
                                sideSams2[j].tag = "SideSam2";
                                y -= 20f;
                            }

                            for (int n = 0; n < caughtToppingsgo.Length; n++)
                            {
                                caughtToppingsgo[n].GetComponent<FallingToppings>().enabled = true;
                                caughtToppingsgo[n].GetComponent<Collider2D>().enabled = true;
                                caughtToppingsgo[n].tag = "Stack";
                            }
                        }
                        else
                        {
                            Array.Resize(ref caughtToppingsgo, sideSams2.Length);
                            Array.Copy(sideSams2, caughtToppingsgo, sideSams2.Length);
                            Array.Clear(sideSams2, 0, sideSams2.Length);

                            for (int n = 0; n < caughtToppingsgo.Length; n++)
                            {
                                caughtToppingsgo[n].GetComponent<FallingToppings>().enabled = true;
                                caughtToppingsgo[n].GetComponent<Collider2D>().enabled = true;
                                caughtToppingsgo[n].tag = "Stack";
                            }
                            sideSam2Full = false;
                        }
                    }
                    break;
                default:
                    break;
            }
                
        }
        public void Assemble()
        {
            ticketRail = GameObject.Find("ticketController").GetComponent<Tickets>().ticketList;
            railPos = GameObject.Find("ticketController").GetComponent<Tickets>().railPosition;
            bool gotOne = false;
            
            if ((caughtToppingsint == 5) || (Input.GetKey(KeyCode.Space) && caughtToppingsint >= 1))
            {
                FindSam();
                PutSam();

                foreach (GOTuple ticket in ticketRail)
                {
                    if (ticket == null)
                        break;
                    int index = ticket.GetComponent<Ticket>().railIndex;
                    switch (SammichHelper.SeekAndDestroy(samKey, ticket))
                    {
                        case 1:
                            gotOne = true;
                            Destroy(ticket);
                            ticketRail.Remove(ticket);
                            break;
                        case 2:
                            gotOne = true;
                            Destroy(ticket);
                            ticketRail.Remove(ticket);
                            GameObject.Find("ticketController").GetComponent<Tickets>().destroyedIndex = index;
                            GameObject.Find("ticketController").GetComponent<Tickets>().up = true;
                            break;
                        default:
                            break;
                    }
                    if (gotOne)
                        break;
                }

                foreach (GameObject topping in caughtToppingsgo)
                {
                    Destroy(topping);
                    scoreBoard.scoreHit(caughtToppingsint * scorePerTop);
                }
                samKey = 0;
            }
        }
    }
}
/* Old code, just in case*********************************************************************************************************************
 * 
 *             
            /*if (Input.GetKey(KeyCode.Space) && caughtToppingsint >= 1)
            {
                FindSam();
                PutSam();
                Ticket[] currentTickets = FindObjectsOfType<Ticket>();
                Debug.Log("NUMBER OF TICKET OBJECTS ON THE SCREEN BEFORE CLEAR ----------------> " + currentTickets.Length);
                foreach (Ticket ticket in ticketRail)
                {
                    int count_init = ticket.onTicket.Count;
                    if (SammichHelper.SeekAndDestroy(samKey, ticket))
                    {
                        ticketRail.Remove(ticket);
                        break;
                    }

                    if (count_init > ticket.onTicket.Count)
                    {
                        count_init = ticket.onTicket.Count;
                        break;
                    }
                }

                foreach (GameObject topping in caughtToppingsgo)
                 {
                     Destroy(topping);
                     scoreBoard.scoreHit(caughtToppingsint * scorePerTop);
                 }
                 samKey = 0;
            }
 *
 *             OpenTickets = GameObject.Find("ticketController").GetComponent<Tickets>().OpenTickets;
                List<string> keystuff = new List<string>(OpenTickets.Keys);
 * 
 *              newKey = SammichHelper.SeekAndDestroy(samKey, OpenTickets);
                Debug.Log("ASSEMBLE NEWKEY IN ACTION ------------------------------------------------------------->" + newKey);
                if (OpenTickets.ContainsKey(newKey))
                {
                    if (OpenTickets[newKey] != null)
                    {
                        Destroy(OpenTickets[newKey]);
                        OpenTickets.Remove(newKey);
                        Debug.Log("GOT THAT BITCH");
                    }
                }
 *
 *                          newKey = SammichHelper.SeekAndDestroy(samKey, ticketRail);

                 if (OpenTickets.ContainsKey(newKey))
                 {
                     if (OpenTickets[newKey] != null)
                     {
                         Destroy(OpenTickets[newKey]);
                         OpenTickets.Remove(newKey);
                         Debug.Log("GOT THAT BITCH");
                         List<string> keystuff2 = new List<string>(OpenTickets.Keys);
                         int count2 = 0;
                         foreach (string key in keystuff2)
                         {

                             Debug.Log("OPEN TICKETS KEYS ON ASSEMBLE 2 =================" + keystuff2[count2]);
                             count2++;
                         }
                     }
                 }

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
    }
 Find the name and asset of the assembled sandwich
Load the dick
********************************************************************************/
