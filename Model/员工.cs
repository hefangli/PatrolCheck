// File:    Ա��.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class Ա��

using System;

public class Ա��
{
   public int ���;
   public string ����;
   public string ����;
   
   public System.Collections.Generic.List<��λԱ��> ��λԱ��;
   
   /// <summary>
   /// Property for collection of ��λԱ��
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<��λԱ��> ��λԱ��
   {
      get
      {
         if (��λԱ�� == null)
            ��λԱ�� = new System.Collections.Generic.List<��λԱ��>();
         return ��λԱ��;
      }
      set
      {
         RemoveAll��λԱ��();
         if (value != null)
         {
            foreach (��λԱ�� o��λԱ�� in value)
               Add��λԱ��(o��λԱ��);
         }
      }
   }
   
   /// <summary>
   /// Add a new ��λԱ�� in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void Add��λԱ��(��λԱ�� new��λԱ��)
   {
      if (new��λԱ�� == null)
         return;
      if (this.��λԱ�� == null)
         this.��λԱ�� = new System.Collections.Generic.List<��λԱ��>();
      if (!this.��λԱ��.Contains(new��λԱ��))
         this.��λԱ��.Add(new��λԱ��);
   }
   
   /// <summary>
   /// Remove an existing ��λԱ�� from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void Remove��λԱ��(��λԱ�� old��λԱ��)
   {
      if (old��λԱ�� == null)
         return;
      if (this.��λԱ�� != null)
         if (this.��λԱ��.Contains(old��λԱ��))
            this.��λԱ��.Remove(old��λԱ��);
   }
   
   /// <summary>
   /// Remove all instances of ��λԱ�� from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAll��λԱ��()
   {
      if (��λԱ�� != null)
         ��λԱ��.Clear();
   }
   public System.Collections.Generic.List<Ѳ��ƻ�> Ѳ��ƻ�;
   
   /// <summary>
   /// Property for collection of Ѳ��ƻ�
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Ѳ��ƻ�> Ѳ��ƻ�
   {
      get
      {
         if (Ѳ��ƻ� == null)
            Ѳ��ƻ� = new System.Collections.Generic.List<Ѳ��ƻ�>();
         return Ѳ��ƻ�;
      }
      set
      {
         RemoveAllѲ��ƻ�();
         if (value != null)
         {
            foreach (Ѳ��ƻ� oѲ��ƻ� in value)
               AddѲ��ƻ�(oѲ��ƻ�);
         }
      }
   }
   
   /// <summary>
   /// Add a new Ѳ��ƻ� in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddѲ��ƻ�(Ѳ��ƻ� newѲ��ƻ�)
   {
      if (newѲ��ƻ� == null)
         return;
      if (this.Ѳ��ƻ� == null)
         this.Ѳ��ƻ� = new System.Collections.Generic.List<Ѳ��ƻ�>();
      if (!this.Ѳ��ƻ�.Contains(newѲ��ƻ�))
         this.Ѳ��ƻ�.Add(newѲ��ƻ�);
   }
   
   /// <summary>
   /// Remove an existing Ѳ��ƻ� from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveѲ��ƻ�(Ѳ��ƻ� oldѲ��ƻ�)
   {
      if (oldѲ��ƻ� == null)
         return;
      if (this.Ѳ��ƻ� != null)
         if (this.Ѳ��ƻ�.Contains(oldѲ��ƻ�))
            this.Ѳ��ƻ�.Remove(oldѲ��ƻ�);
   }
   
   /// <summary>
   /// Remove all instances of Ѳ��ƻ� from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllѲ��ƻ�()
   {
      if (Ѳ��ƻ� != null)
         Ѳ��ƻ�.Clear();
   }
   public System.Collections.Generic.List<Ѳ��·�߼�¼> Ѳ��·�߼�¼;
   
   /// <summary>
   /// Property for collection of Ѳ��·�߼�¼
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Ѳ��·�߼�¼> Ѳ��·�߼�¼
   {
      get
      {
         if (Ѳ��·�߼�¼ == null)
            Ѳ��·�߼�¼ = new System.Collections.Generic.List<Ѳ��·�߼�¼>();
         return Ѳ��·�߼�¼;
      }
      set
      {
         RemoveAllѲ��·�߼�¼();
         if (value != null)
         {
            foreach (Ѳ��·�߼�¼ oѲ��·�߼�¼ in value)
               AddѲ��·�߼�¼(oѲ��·�߼�¼);
         }
      }
   }
   
   /// <summary>
   /// Add a new Ѳ��·�߼�¼ in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddѲ��·�߼�¼(Ѳ��·�߼�¼ newѲ��·�߼�¼)
   {
      if (newѲ��·�߼�¼ == null)
         return;
      if (this.Ѳ��·�߼�¼ == null)
         this.Ѳ��·�߼�¼ = new System.Collections.Generic.List<Ѳ��·�߼�¼>();
      if (!this.Ѳ��·�߼�¼.Contains(newѲ��·�߼�¼))
         this.Ѳ��·�߼�¼.Add(newѲ��·�߼�¼);
   }
   
   /// <summary>
   /// Remove an existing Ѳ��·�߼�¼ from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveѲ��·�߼�¼(Ѳ��·�߼�¼ oldѲ��·�߼�¼)
   {
      if (oldѲ��·�߼�¼ == null)
         return;
      if (this.Ѳ��·�߼�¼ != null)
         if (this.Ѳ��·�߼�¼.Contains(oldѲ��·�߼�¼))
            this.Ѳ��·�߼�¼.Remove(oldѲ��·�߼�¼);
   }
   
   /// <summary>
   /// Remove all instances of Ѳ��·�߼�¼ from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllѲ��·�߼�¼()
   {
      if (Ѳ��·�߼�¼ != null)
         Ѳ��·�߼�¼.Clear();
   }

}