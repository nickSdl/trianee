﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyLinkedList<T>
    {
        private MyNode<T> Head;
        private MyNode<T> Tail;
        public int Count { get; private set; }

        public MyLinkedList()
        {
            Count = 0;
        }

        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Add(T Value)
        {
            AddLast(Value);
        }


        public bool AddBefore(T item, T Value)
        {
            MyNode<T> previousItem = null;
            MyNode<T> currentItem = Head;
            MyNode<T> newNode = new MyNode<T>(Value);

            if (IsEmpty())//list is empty
            {
                Console.WriteLine("Can't add before the item '{0}' because the list is empty!!!");
                return false;
            }
            else
            {
                while (currentItem != null)
                {
                    if (currentItem.Value.Equals(item))//necessary item was found
                    {
                        if (Count == 1 || currentItem == Head)//there is only element in list or add before the head
                        {
                            AddFirst(Value);
                        }                        
                        else if (currentItem == Tail)//necessary item is the last element of list
                        {
                            previousItem.Next = newNode;
                            newNode.Next = Tail;
                            Count++;
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            previousItem.Next = newNode;
                            newNode.Next = currentItem;
                            Count++;
                        }
                        
                        return true;
                    }
                    previousItem = currentItem;
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't addbefore: there isn't item in list: " + item);
                return false;
            }
        }

        public bool AddAfter(T item, T Value)
        {
            MyNode<T> previousItem = null;
            MyNode<T> currentItem = Head;
            MyNode<T> newNode = new MyNode<T>(Value);



            if (IsEmpty())//list is empty
            {
                Console.WriteLine("Can't add after the item '{0}' because the list is empty!!!");
                return false;
            }
            else
            {
                while (currentItem != null)
                {
                    if (currentItem.Value.Equals(item))//necessary item was found
                    {
                        if (Count == 1 || currentItem == Head)//there is only element in list or add after the head
                        {
                            Head.Next = newNode;
                            Tail = newNode;
                            Count++;
                        }                        
                        else if (currentItem == Tail)//necessary item is the last element of list
                        {
                            AddLast(Value);
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            newNode.Next = currentItem.Next;
                            currentItem.Next = newNode;
                            Count++;
                        }

                        return true;
                    }
                    previousItem = currentItem;
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't addbefore: there isn't item in list: " + item);
                return false;
            }
        }



        public void AddFirst(T Value)
        {

            MyNode<T> newNode = new MyNode<T>(Value);
            if (IsEmpty())
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            Count++;
        }

        public void AddLast(T Value)
        {
            MyNode<T> newNode = new MyNode<T>(Value);
            if (IsEmpty())
            {
                AddFirst(Value);
            }
            else
            {
                //add element in the end ==tail
                Tail.Next = newNode;
                Tail = newNode;
                Count++;
            }
        }

        public bool Remove(T item)
        {
            MyNode<T> previousItem = null;
            MyNode<T> currentItem = Head;

            if (IsEmpty())//list is empty
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }
            else
            {
                while (currentItem != null)
                {
                    if (currentItem.Value.Equals(item))//necessary item was found
                    {
                        if (Count == 1 || currentItem == Head)//there is only element in list or remove the head
                        {
                            RemoveFirst();
                        }                       
                        else if (currentItem == Tail)//necessary item is the last element of list
                        {
                            Tail = previousItem;
                            previousItem.Next = null;
                            Count--;
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            previousItem.Next = currentItem.Next;
                            Count--;
                        }
                        
                        return true;
                    }
                    previousItem = currentItem;
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't remove: the list not contains the item: {0}", item);

                return false;
            }


        }

        public bool RemoveFirst()
        {
            if (!IsEmpty())
            {
                Head = Head.Next;
                Count--;
                return true;
            }
            else
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }         
        }

        public bool RemoveLast()
        {           
            if (IsEmpty())
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }
            else
            {
                return Remove(Tail.Value);//will work only if Tail.Value is unique

            }

        }

        public void Print()
        {
            if (Head != null)
            {
                Console.WriteLine("____________________\nLinked List:");
                MyNode<T> item = Head;

                while (item != null)
                {
                    Console.WriteLine(item.Value);
                    item = item.Next;
                }
                Console.WriteLine("____________________");

            }
            else
            {
                Console.WriteLine("Can't print: the list is empty!!!");
            }
        }


    }
}
