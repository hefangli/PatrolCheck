// File:    Ѳ��ƻ�.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class Ѳ��ƻ�

using System;

public class Ѳ��ƻ�
{
   public int ���;
   public string ����;
   public string ����;
   public long ��λ;
   public long ·��;
   public DateTime ��ʼʱ��;
   public DateTime ����ʱ��;
   public DateTime ����ʱ��;
   public int ����;
   public string ���ڵ�λ;
   public DateTime ������Чʱ��;
   public DateTime ����ʧЧʱ��;
   
   public System.Collections.Generic.List<��ϸѲ������> ��ϸѲ������;
   
   /// <summary>
   /// Property for collection of ��ϸѲ������
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<��ϸѲ������> ��ϸѲ������
   {
      get
      {
         if (��ϸѲ������ == null)
            ��ϸѲ������ = new System.Collections.Generic.List<��ϸѲ������>();
         return ��ϸѲ������;
      }
      set
      {
         RemoveAll��ϸѲ������();
         if (value != null)
         {
            foreach (��ϸѲ������ o��ϸѲ������ in value)
               Add��ϸѲ������(o��ϸѲ������);
         }
      }
   }
   
   /// <summary>
   /// Add a new ��ϸѲ������ in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void Add��ϸѲ������(��ϸѲ������ new��ϸѲ������)
   {
      if (new��ϸѲ������ == null)
         return;
      if (this.��ϸѲ������ == null)
         this.��ϸѲ������ = new System.Collections.Generic.List<��ϸѲ������>();
      if (!this.��ϸѲ������.Contains(new��ϸѲ������))
         this.��ϸѲ������.Add(new��ϸѲ������);
   }
   
   /// <summary>
   /// Remove an existing ��ϸѲ������ from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void Remove��ϸѲ������(��ϸѲ������ old��ϸѲ������)
   {
      if (old��ϸѲ������ == null)
         return;
      if (this.��ϸѲ������ != null)
         if (this.��ϸѲ������.Contains(old��ϸѲ������))
            this.��ϸѲ������.Remove(old��ϸѲ������);
   }
   
   /// <summary>
   /// Remove all instances of ��ϸѲ������ from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAll��ϸѲ������()
   {
      if (��ϸѲ������ != null)
         ��ϸѲ������.Clear();
   }

}