// File:    װ��.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class װ��

using System;

public class װ��
{
   public int ���;
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

}