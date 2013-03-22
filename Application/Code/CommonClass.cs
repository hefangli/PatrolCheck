using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WorkStation
{
    public class CommonClass
    {
    }
    public class BoxItem
    {
        public BoxItem()
        { }
        public BoxItem(string text, Object value)
        {
            this.Text = text;
            this.Value = value;
        }
        private string _text = null;
        private object _value = null;
        public string Text { get { return this._text; } set { this._text = value; } }
        public object Value { get { return this._value; } set { this._value = value; } }
        public override string ToString()
        {
            return this._text;
        }
    }
    /// <summary>
    /// 有效状态 Codes-ValidState
    /// </summary>
    public  enum CodesValidState
    {
        /// <summary>
        /// 全选
        /// </summary>
        ChoseAll=-1,
        /// <summary>
        /// 未知
        /// </summary>
        Unknown=0, 
        /// <summary>
        /// 存在
        /// </summary>
        Exit=1,
        /// <summary>
        /// 已注销
        /// </summary>
        Cancelled=2
    }
    /// <summary>
    /// 巡检顺序-CheckSequence
    /// </summary>
    public enum CodesCheckSequence
    { 
        /// <summary>
        /// 未指定
        /// </summary>
        Unknown = 0, 
        /// <summary>
        /// 顺序巡检
        /// </summary>
        InOrder=1,
        /// <summary>
        /// 无顺序巡检
        /// </summary>
        UnInOrder=2
    }

}
