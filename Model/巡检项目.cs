// File:    Ѳ����Ŀ.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class Ѳ����Ŀ

using System;

public class Ѳ����Ŀ
{
    public int ���;
    public string ����;
    public string ����;
    public int ֵ����;
    public string ��ע;

    private System.Collections.Generic.List<Ѳ�����¼> _Ѳ�����¼;

    /// <summary>
    /// Property for collection of Ѳ�����¼
    /// </summary>
    /// <pdGenerated>Default opposite class collection property</pdGenerated>
    public System.Collections.Generic.List<Ѳ�����¼> Ѳ�����¼
    {
        get
        {
            if (_Ѳ�����¼ == null)
                _Ѳ�����¼ = new System.Collections.Generic.List<Ѳ�����¼>();
            return _Ѳ�����¼;
        }
        set
        {
            RemoveAllѲ�����¼();
            if (value != null)
            {
                foreach (Ѳ�����¼ oѲ�����¼ in value)
                    AddѲ�����¼(oѲ�����¼);
            }
        }
    }

    /// <summary>
    /// Add a new Ѳ�����¼ in the collection
    /// </summary>
    /// <pdGenerated>Default Add</pdGenerated>
    public void AddѲ�����¼(Ѳ�����¼ newѲ�����¼)
    {
        if (newѲ�����¼ == null)
            return;
        if (this._Ѳ�����¼ == null)
            this._Ѳ�����¼ = new System.Collections.Generic.List<Ѳ�����¼>();
        if (!this._Ѳ�����¼.Contains(newѲ�����¼))
            this._Ѳ�����¼.Add(newѲ�����¼);
    }

    /// <summary>
    /// Remove an existing Ѳ�����¼ from the collection
    /// </summary>
    /// <pdGenerated>Default Remove</pdGenerated>
    public void RemoveѲ�����¼(Ѳ�����¼ oldѲ�����¼)
    {
        if (oldѲ�����¼ == null)
            return;
        if (this._Ѳ�����¼ != null)
            if (this._Ѳ�����¼.Contains(oldѲ�����¼))
                this._Ѳ�����¼.Remove(oldѲ�����¼);
    }

    /// <summary>
    /// Remove all instances of Ѳ�����¼ from the collection
    /// </summary>
    /// <pdGenerated>Default removeAll</pdGenerated>
    public void RemoveAllѲ�����¼()
    {
        if (_Ѳ�����¼ != null)
            _Ѳ�����¼.Clear();
    }

}