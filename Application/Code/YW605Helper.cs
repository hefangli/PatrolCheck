using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WorkStation
{
    class YW605Helper
    {
        public const char SEARCHMODE_14443A = (char)0x41;
        public const char SEARCHMODE_14443B = (char)0x42;
        public const char SEARCHMODE_15693 = (char)0x31;

        public const char REQUESTMODE_ALL = (char)0x52;
        public const char REQUESTMODE_ACTIVE = (char)0x26;

        public const char SAM_BOUND_9600 = (char)0;
        public const char SAM_BOUND_38400 = (char)1;

        public const char PASSWORD_A = (char)0x60;
        public const char PASSWORD_B = (char)0x61;

        //LED灯序号01：红灯02：绿灯04：黄灯
        //最后要亮的灯：00：全灭01：红灯02：绿灯04：黄灯
        public const int LED_RED = 1;
        public const int LED_GREEN = 2;
        public const int LED_YELLOW = 4;
        public const int LED_ClOSE_ALL = 0;

        public const char MultiMode_0=(char)0;
        public const char MultiMode_1 = (char)1;


        /// <summary>
        /// 获取库函数内部版本号
        /// </summary>
        /// <returns>大于0为版本号，小于0为错误</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_GetDLLVersion();
        /// <summary>
        /// USB无驱读写器，初始化USB
        /// </summary>
        /// <returns>1成功，0失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_USBHIDInitial();
        /// <summary>
        /// USB无驱读写器，释放USB
        /// </summary>
        /// <returns>1成功，0失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_USBHIDFree();
        /// <summary>
        /// 查询读写器设备标识
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <returns>大于等于0成功,并且为所获取的设备标示，小于0失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_GetReaderID(int ReaderID);
        /// <summary>
        /// 设置读写器设备标识
        /// </summary>
        /// <param name="OldID">老的设备标示ID，范围0x0000-0xFFFF</param>
        /// <param name="NewID">修改成新的设备标示ID，范围0x0000-0xFFFF</param>
        /// <returns>1成功，0失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_SetReaderID(int OldID, int NewID);

        /// <summary>
        /// 蜂鸣器控制函数
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="Time_ON">蜂鸣器鸣叫时间，单位：秒</param>
        /// <param name="Time_OFF">蜂鸣器静音时间，单位：秒</param>
        /// <param name="Cycle">把Time_ON和Time_OFF作为一个周期，则此参数为执行此周期的次数。</param>
        /// <returns>大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_Buzzer(int ReaderID, int Time_ON, int Time_OFF, int Cycle);

        /// <summary>
        /// LED指示灯控制
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="LEDIndex">LED灯序号01：红灯02：绿灯04：黄灯</param>
        /// <param name="Time_ON">LED灯亮时间，单位：秒</param>
        /// <param name="Time_OFF">LED灯灭时间，单位：秒</param>
        /// <param name="Cycle">把Time_ON和Time_OFF作为一个周期，则此参数为执行此周期的次数。</param>
        /// <param name="LedIndexOn">最后要亮的灯：00：全灭01：红灯02：绿灯04：黄灯</param>
        /// <returns>大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_Led(int ReaderID, int LEDIndex, int Time_ON, int Time_OFF, int Cycle, int LedIndexOn);

        /// <summary>
        /// 设置天线的状态
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="Status">True: 开天线False:关天线</param>
        /// <returns>大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_AntennaStatus(int ReaderID, bool Status);

        /// <summary>
        /// 设置寻卡模式
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="SearchMode">
        /// 卡类型0x41-----ISO14443A 
        /// 0x42----- ISO14443B 
        /// 0x31----- ISO15693
        /// 0x53------ST系列卡 
        /// 0x52------AT88RF020等</param>
        /// <returns>大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_SearchCardMode(int ReaderID, int SearchMode);

        /// <summary>
        /// 寻卡
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="RequestMode">寻卡的模式 0x52----- 所有卡 0x26----- 激活卡</param>
        /// <param name="CardType">
        /// 返回卡的类型
        /// 0x4400 = Ultralight/UltraLight C/MifarePlus(7Byte UID)
        ///0x0400 = Mifare Mini/Mifare 1K (S50) /MifarePlus(4Byte UID)
        ///0x0200 = Mifare_4K(S70)/ MifarePlus(4Byte UID)
        ///0x0800 = Mifare_Pro
        /// </param>
        /// <returns>：大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_RequestCard(int ReaderID, char RequestMode, ref short CardType);
        /// <summary>
        /// 访冲撞读卡序列号并且选定一张卡
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="MultiMode">对多张卡的处理方式
        ///0: 多张卡返回错误
        ///1：返回一张卡号</param>
        /// <param name="CardMem">卡片容量代码</param>
        /// <param name="CardNoLen">输出卡号的长度</param>
        /// <param name="SN">输出卡的序列号</param>
        /// <returns>：大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_AntiCollideAndSelect(int ReaderID, char MultiMode, ref char CardMem, ref int CardNoLen, ref Byte SN);
        /// <summary>
        /// 下载秘钥到只写区
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="KeyIndex">只写区秘钥序号0~31，共可写32个秘钥</param>
        /// <param name="Key">秘钥，每个秘钥6个字节</param>
        /// <returns>大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_DownLoadKey(int ReaderID,int KeyIndex,ref Byte Key);
        /// <summary>
        /// 用只写区秘钥验证扇区秘钥
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="KeyMode">
        /// KeyMode=0x60为A密钥
        ///KeyMode=0x61为B密钥</param>
        ///<param name="BlockAddr">要验证的绝对块号地址</param>
        ///<param name="KeyIndex">只写区秘钥序号0~31</param>
        /// <returns>大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_KeyDown_Authorization (int ReaderID,char KeyMode,int BlockAddr,int KeyIndex);
        /// <summary>
        /// 身份验证,验证某扇区密钥
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="KeyMode">
        /// KeyMode=0x60为A密钥
        ///KeyMode=0x61为B密钥</param>
        /// <param name="BlockAddr">要验证的绝对块号地址</param>
        /// <param name="Key">密钥字节（共6个字节）</param>
        /// <returns>大于0为命令发送成功，小于0为命令发送失败</returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_KeyAuthorization(int ReaderID, char KeyMode, int BlockAddr, ref Byte Key);
        /// <summary>
        /// 读取一块数据
        /// </summary>
        /// <param name="ReaderID">所要获取的设备标示ID，范围0x0000-0xFFFF，如果未知，则ReaderID=0</param>
        /// <param name="BlockAddr">绝对地址块号</param>
        /// <param name="LenData">要读出的数据的字节数，Mifare One为16个字节</param>
        /// <param name="Data">输出读到的块的数据</param>
        /// <returns></returns>
        [DllImport("YW60x.dll")]
        public static extern int YW_ReadaBlock(int ReaderID, int BlockAddr, int LenData, ref Byte Data);

        public static void start(Timer timer)
        {
            timer.Tick+=new EventHandler((new YW605Helper()).timer_Tick);
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            short CardType = 0;
            int CardNoLen = 0;
            char CardMem = (char)0;
            byte[] SN = new byte[4];
            if (YW605Helper.YW_RequestCard(1, YW605Helper.REQUESTMODE_ALL, ref CardType) > 0)
            {
                if (YW605Helper.YW_AntiCollideAndSelect(1, (char)0, ref CardMem, ref CardNoLen, ref SN[0]) > 0)
                {
                    YW605Helper.YW_Led(1, YW605Helper.LED_GREEN, 2, 2, 0, YW605Helper.LED_GREEN);
                }
                else
                {
                    YW605Helper.YW_Led(1, YW605Helper.LED_RED, 2, 2, 0, YW605Helper.LED_RED);
                }
            }
            else
            {
                YW605Helper.YW_Led(1, YW605Helper.LED_RED, 2, 2, 0, YW605Helper.LED_RED);
            }
        }
    }
}
