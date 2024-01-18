using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int DefaultCapacity = 193; // 딱 안나눠 떨어지는 소수일수록, 분산이 더 잘 일어나서 효율이 좋음

        private struct Entry
        {
            public enum State { None,Using,Deleted}

            public State state;
            public TKey key;
            public TValue value;
        }

        private Entry[] table;

        private int usedCount;

        public Dictionary()
        {
            table=new Entry[DefaultCapacity];
            usedCount=0;
        }

        // 인덱스로 값을 참조할 수 있는 인덱서 구현
        public TValue this[TKey key]
        {
            get
            {
                if(Find(key, out int index))
                {
                    return table[index].value;
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }

            set
            {
                if(Find(key,out int index)) //있었으면 값을 바꿔줌
                {
                    table[index].value = value;
                }
                else // Add 
                {
                    if (usedCount > table.Length * 0.7f) //*배열과는 다르게 꽉 찼을때가 아닌 70% 이상 찼을 때
                    {
                        ReHashing(); //리해싱
                    }

                    table[index].key = key;
                    table[index].value = value;
                    table[index].state = Entry.State.Using;
                    usedCount++;
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            //키값을 해싱한 후 테이블의 인덱스에 넣어줌
            if(Find(key,out int index))
            {
                throw new InvalidOperationException("Already exist Key"); // 키를 찾고 이미 있으면 오류처리
            }
            else
            {
                table[index].key = key;
                table[index].value = value;
                table[index].state = Entry.State.Using;
                usedCount++;
            }
        }

        
        private bool Find(TKey key, out int index) {

            index = Hash(key); //해싱

            if (table[index].state == Entry.State.None)
            {
                return false;
            }
            else if (table[index].state == Entry.State.Using)
            {
                if (key.Equals(table[index].key)) //만약 사용 상태라면, 키 값이 동일한지 아닌지가 중요함
                {
                    return true; // 맞으면 찾은거니깐 True;
                }
                else //아니라면 다음칸으로 넘어감
                {
                    index = HashNext(index);
                }
            }
            else //... == Enrty.State.Deleted
            {
                //다음칸으로 넘어감
                index = HashNext(index);
            }
            index = -1;
            throw new InvalidOperationException();
        }

        public int Hash(TKey key)
        {
            return Math.Abs(key.GetHashCode() % table.Length);   //오브젝트가 어떤 타입이던 해시값을 얻어주는 내장 메소드...
        }

        public int HashNext(int index) //자료가 이미 있을 때, 다음 인덱스로 넘어가는 메서드
        {
            //선형탐사 기법
            return (index+1)%table.Length;

            // 제곱 탐사 기법
            // return (index + 1) * (index + 1) % table.Length;

            // 이중 해싱 기법 <== c#에서는 분산을 위해 이거 씀
            // return Math.Abs((index + 1).GetHashCode() % table.Length);
        }

        private void ReHashing()
        {
            Entry[] oldTable = table;
            table = new Entry[table.Length*2]; // 두배 크기의 새 테이블 할당
            usedCount =0 ;
            for(int i=0; i<oldTable.Length; i++)
            {
                Entry entry = oldTable[i];
                if(entry.state == Entry.State.Using) //모든 값을 복사하지 않고, 사용중인 값만 복사함
                {
                    Add(entry.key, entry.value);
                }
            }
        }
        public bool Remove(TKey key)
        {
            if(Find(key,out int index))
            {
                table[index].state = Entry.State.Deleted; 
                //실제 값은 그대로 남아있고, 상태만 dleted로 바꿈
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Contains(TKey key)
        {
            if(Find(key, out int index))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
