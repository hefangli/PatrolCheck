// File:    Ѳ��·��.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class Ѳ��·��

using System;

public class Ѳ��·��
{
   public int ���;
   public string ����;
   public string ����;
   
   public System.Collections.Generic.List<�߼�Ѳ���> �߼�Ѳ���;
   
   /// <summary>
   /// Property for collection of �߼�Ѳ���
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<�߼�Ѳ���> �߼�Ѳ���
   {
      get
      {
         if (�߼�Ѳ��� == null)
            �߼�Ѳ��� = new System.Collections.Generic.List<�߼�Ѳ���>();
         return �߼�Ѳ���;
      }
      set
      {
         RemoveAll�߼�Ѳ���();
         if (value != null)
         {
            foreach (�߼�Ѳ��� o�߼�Ѳ��� in value)
               Add�߼�Ѳ���(o�߼�Ѳ���);
         }
      }
   }
   
   /// <summary>
   /// Add a new �߼�Ѳ��� in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void Add�߼�Ѳ���(�߼�Ѳ��� new�߼�Ѳ���)
   {
      if (new�߼�Ѳ��� == null)
         return;
      if (this.�߼�Ѳ��� == null)
         this.�߼�Ѳ��� = new System.Collections.Generic.List<�߼�Ѳ���>();
      if (!this.�߼�Ѳ���.Contains(new�߼�Ѳ���))
         this.�߼�Ѳ���.Add(new�߼�Ѳ���);
   }
   
   /// <summary>
   /// Remove an existing �߼�Ѳ��� from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void Remove�߼�Ѳ���(�߼�Ѳ��� old�߼�Ѳ���)
   {
      if (old�߼�Ѳ��� == null)
         return;
      if (this.�߼�Ѳ��� != null)
         if (this.�߼�Ѳ���.Contains(old�߼�Ѳ���))
            this.�߼�Ѳ���.Remove(old�߼�Ѳ���);
   }
   
   /// <summary>
   /// Remove all instances of �߼�Ѳ��� from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAll�߼�Ѳ���()
   {
      if (�߼�Ѳ��� != null)
         �߼�Ѳ���.Clear();
   }

}