// File:    ����Ѳ���.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class ����Ѳ���

using System;

public class ����Ѳ���
{
   public long ���;
   public string ����;
   public string ����;
   
   public System.Collections.Generic.List<Ѳ����Ŀ> Ѳ����Ŀ;
   
   /// <summary>
   /// Property for collection of Ѳ����Ŀ
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Ѳ����Ŀ> Ѳ����Ŀ
   {
      get
      {
         if (Ѳ����Ŀ == null)
            Ѳ����Ŀ = new System.Collections.Generic.List<Ѳ����Ŀ>();
         return Ѳ����Ŀ;
      }
      set
      {
         RemoveAllѲ����Ŀ();
         if (value != null)
         {
            foreach (Ѳ����Ŀ oѲ����Ŀ in value)
               AddѲ����Ŀ(oѲ����Ŀ);
         }
      }
   }
   
   /// <summary>
   /// Add a new Ѳ����Ŀ in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddѲ����Ŀ(Ѳ����Ŀ newѲ����Ŀ)
   {
      if (newѲ����Ŀ == null)
         return;
      if (this.Ѳ����Ŀ == null)
         this.Ѳ����Ŀ = new System.Collections.Generic.List<Ѳ����Ŀ>();
      if (!this.Ѳ����Ŀ.Contains(newѲ����Ŀ))
         this.Ѳ����Ŀ.Add(newѲ����Ŀ);
   }
   
   /// <summary>
   /// Remove an existing Ѳ����Ŀ from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveѲ����Ŀ(Ѳ����Ŀ oldѲ����Ŀ)
   {
      if (oldѲ����Ŀ == null)
         return;
      if (this.Ѳ����Ŀ != null)
         if (this.Ѳ����Ŀ.Contains(oldѲ����Ŀ))
            this.Ѳ����Ŀ.Remove(oldѲ����Ŀ);
   }
   
   /// <summary>
   /// Remove all instances of Ѳ����Ŀ from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllѲ����Ŀ()
   {
      if (Ѳ����Ŀ != null)
         Ѳ����Ŀ.Clear();
   }
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