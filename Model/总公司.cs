// File:    �ܹ�˾.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class �ܹ�˾

using System;

public class �ܹ�˾
{
   public int ���;
   public string ����;
   public string ����;
   
   public System.Collections.Generic.List<����> ����;
   
   /// <summary>
   /// Property for collection of ����
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<����> ����
   {
      get
      {
         if (���� == null)
            ���� = new System.Collections.Generic.List<����>();
         return ����;
      }
      set
      {
         RemoveAll����();
         if (value != null)
         {
            foreach (���� o���� in value)
               Add����(o����);
         }
      }
   }
   
   /// <summary>
   /// Add a new ���� in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void Add����(���� new����)
   {
      if (new���� == null)
         return;
      if (this.���� == null)
         this.���� = new System.Collections.Generic.List<����>();
      if (!this.����.Contains(new����))
         this.����.Add(new����);
   }
   
   /// <summary>
   /// Remove an existing ���� from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void Remove����(���� old����)
   {
      if (old���� == null)
         return;
      if (this.���� != null)
         if (this.����.Contains(old����))
            this.����.Remove(old����);
   }
   
   /// <summary>
   /// Remove all instances of ���� from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAll����()
   {
      if (���� != null)
         ����.Clear();
   }

}