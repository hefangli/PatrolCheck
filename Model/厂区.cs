// File:    ����.cs
// Author:  John
// Created: 2012��10��8�� 10:27:04
// Purpose: Definition of Class ����

using System;

public class ����
{
   public int ���;
   public string ����;
   public string ����;
   
   public System.Collections.Generic.List<��λ> ��λ;
   
   /// <summary>
   /// Property for collection of ��λ
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<��λ> ��λ
   {
      get
      {
         if (��λ == null)
            ��λ = new System.Collections.Generic.List<��λ>();
         return ��λ;
      }
      set
      {
         RemoveAll��λ();
         if (value != null)
         {
            foreach (��λ o��λ in value)
               Add��λ(o��λ);
         }
      }
   }
   
   /// <summary>
   /// Add a new ��λ in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void Add��λ(��λ new��λ)
   {
      if (new��λ == null)
         return;
      if (this.��λ == null)
         this.��λ = new System.Collections.Generic.List<��λ>();
      if (!this.��λ.Contains(new��λ))
         this.��λ.Add(new��λ);
   }
   
   /// <summary>
   /// Remove an existing ��λ from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void Remove��λ(��λ old��λ)
   {
      if (old��λ == null)
         return;
      if (this.��λ != null)
         if (this.��λ.Contains(old��λ))
            this.��λ.Remove(old��λ);
   }
   
   /// <summary>
   /// Remove all instances of ��λ from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAll��λ()
   {
      if (��λ != null)
         ��λ.Clear();
   }
   public System.Collections.Generic.List<Ѳ��·��> Ѳ��·��;
   
   /// <summary>
   /// Property for collection of Ѳ��·��
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Ѳ��·��> Ѳ��·��
   {
      get
      {
         if (Ѳ��·�� == null)
            Ѳ��·�� = new System.Collections.Generic.List<Ѳ��·��>();
         return Ѳ��·��;
      }
      set
      {
         RemoveAllѲ��·��();
         if (value != null)
         {
            foreach (Ѳ��·�� oѲ��·�� in value)
               AddѲ��·��(oѲ��·��);
         }
      }
   }
   
   /// <summary>
   /// Add a new Ѳ��·�� in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddѲ��·��(Ѳ��·�� newѲ��·��)
   {
      if (newѲ��·�� == null)
         return;
      if (this.Ѳ��·�� == null)
         this.Ѳ��·�� = new System.Collections.Generic.List<Ѳ��·��>();
      if (!this.Ѳ��·��.Contains(newѲ��·��))
         this.Ѳ��·��.Add(newѲ��·��);
   }
   
   /// <summary>
   /// Remove an existing Ѳ��·�� from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveѲ��·��(Ѳ��·�� oldѲ��·��)
   {
      if (oldѲ��·�� == null)
         return;
      if (this.Ѳ��·�� != null)
         if (this.Ѳ��·��.Contains(oldѲ��·��))
            this.Ѳ��·��.Remove(oldѲ��·��);
   }
   
   /// <summary>
   /// Remove all instances of Ѳ��·�� from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllѲ��·��()
   {
      if (Ѳ��·�� != null)
         Ѳ��·��.Clear();
   }
   public System.Collections.Generic.List<װ��> װ��;
   
   /// <summary>
   /// Property for collection of װ��
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<װ��> װ��
   {
      get
      {
         if (װ�� == null)
            װ�� = new System.Collections.Generic.List<װ��>();
         return װ��;
      }
      set
      {
         RemoveAllװ��();
         if (value != null)
         {
            foreach (װ�� oװ�� in value)
               Addװ��(oװ��);
         }
      }
   }
   
   /// <summary>
   /// Add a new װ�� in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void Addװ��(װ�� newװ��)
   {
      if (newװ�� == null)
         return;
      if (this.װ�� == null)
         this.װ�� = new System.Collections.Generic.List<װ��>();
      if (!this.װ��.Contains(newװ��))
         this.װ��.Add(newװ��);
   }
   
   /// <summary>
   /// Remove an existing װ�� from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void Removeװ��(װ�� oldװ��)
   {
      if (oldװ�� == null)
         return;
      if (this.װ�� != null)
         if (this.װ��.Contains(oldװ��))
            this.װ��.Remove(oldװ��);
   }
   
   /// <summary>
   /// Remove all instances of װ�� from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllװ��()
   {
      if (װ�� != null)
         װ��.Clear();
   }
   public System.Collections.Generic.List<Ա��> Ա��;
   
   /// <summary>
   /// Property for collection of Ա��
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Ա��> Ա��
   {
      get
      {
         if (Ա�� == null)
            Ա�� = new System.Collections.Generic.List<Ա��>();
         return Ա��;
      }
      set
      {
         RemoveAllԱ��();
         if (value != null)
         {
            foreach (Ա�� oԱ�� in value)
               AddԱ��(oԱ��);
         }
      }
   }
   
   /// <summary>
   /// Add a new Ա�� in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddԱ��(Ա�� newԱ��)
   {
      if (newԱ�� == null)
         return;
      if (this.Ա�� == null)
         this.Ա�� = new System.Collections.Generic.List<Ա��>();
      if (!this.Ա��.Contains(newԱ��))
         this.Ա��.Add(newԱ��);
   }
   
   /// <summary>
   /// Remove an existing Ա�� from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveԱ��(Ա�� oldԱ��)
   {
      if (oldԱ�� == null)
         return;
      if (this.Ա�� != null)
         if (this.Ա��.Contains(oldԱ��))
            this.Ա��.Remove(oldԱ��);
   }
   
   /// <summary>
   /// Remove all instances of Ա�� from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllԱ��()
   {
      if (Ա�� != null)
         Ա��.Clear();
   }
   public System.Collections.Generic.List<����Ѳ���> ����Ѳ���;
   
   /// <summary>
   /// Property for collection of ����Ѳ���
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<����Ѳ���> ����Ѳ���
   {
      get
      {
         if (����Ѳ��� == null)
            ����Ѳ��� = new System.Collections.Generic.List<����Ѳ���>();
         return ����Ѳ���;
      }
      set
      {
         RemoveAll����Ѳ���();
         if (value != null)
         {
            foreach (����Ѳ��� o����Ѳ��� in value)
               Add����Ѳ���(o����Ѳ���);
         }
      }
   }
   
   /// <summary>
   /// Add a new ����Ѳ��� in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void Add����Ѳ���(����Ѳ��� new����Ѳ���)
   {
      if (new����Ѳ��� == null)
         return;
      if (this.����Ѳ��� == null)
         this.����Ѳ��� = new System.Collections.Generic.List<����Ѳ���>();
      if (!this.����Ѳ���.Contains(new����Ѳ���))
         this.����Ѳ���.Add(new����Ѳ���);
   }
   
   /// <summary>
   /// Remove an existing ����Ѳ��� from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void Remove����Ѳ���(����Ѳ��� old����Ѳ���)
   {
      if (old����Ѳ��� == null)
         return;
      if (this.����Ѳ��� != null)
         if (this.����Ѳ���.Contains(old����Ѳ���))
            this.����Ѳ���.Remove(old����Ѳ���);
   }
   
   /// <summary>
   /// Remove all instances of ����Ѳ��� from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAll����Ѳ���()
   {
      if (����Ѳ��� != null)
         ����Ѳ���.Clear();
   }

}