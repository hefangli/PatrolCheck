// File:    Ѳ��·�߼�¼.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class Ѳ��·�߼�¼

using System;

public class Ѳ��·�߼�¼
{
   public long ���;
   public DateTime ��ʼʱ��;
   public DateTime ����ʱ��;
   public DateTime ����ʱ��;
   
   public System.Collections.Generic.List<Ѳ����¼> Ѳ����¼;
   
   /// <summary>
   /// Property for collection of Ѳ����¼
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Ѳ����¼> Ѳ����¼
   {
      get
      {
         if (Ѳ����¼ == null)
            Ѳ����¼ = new System.Collections.Generic.List<Ѳ����¼>();
         return Ѳ����¼;
      }
      set
      {
         RemoveAllѲ����¼();
         if (value != null)
         {
            foreach (Ѳ����¼ oѲ����¼ in value)
               AddѲ����¼(oѲ����¼);
         }
      }
   }
   
   /// <summary>
   /// Add a new Ѳ����¼ in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddѲ����¼(Ѳ����¼ newѲ����¼)
   {
      if (newѲ����¼ == null)
         return;
      if (this.Ѳ����¼ == null)
         this.Ѳ����¼ = new System.Collections.Generic.List<Ѳ����¼>();
      if (!this.Ѳ����¼.Contains(newѲ����¼))
         this.Ѳ����¼.Add(newѲ����¼);
   }
   
   /// <summary>
   /// Remove an existing Ѳ����¼ from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveѲ����¼(Ѳ����¼ oldѲ����¼)
   {
      if (oldѲ����¼ == null)
         return;
      if (this.Ѳ����¼ != null)
         if (this.Ѳ����¼.Contains(oldѲ����¼))
            this.Ѳ����¼.Remove(oldѲ����¼);
   }
   
   /// <summary>
   /// Remove all instances of Ѳ����¼ from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllѲ����¼()
   {
      if (Ѳ����¼ != null)
         Ѳ����¼.Clear();
   }

}