## foreach文は非常に便利な制御文である
しかし、その実態はSyntax Suger(等価な別の記法にコンパイル時に置き換わる文法のこと)である。
ところで、以下の文について疑問に思ったことは無いだろうか?

```csharp
int[] a=new int[]{1,2,3,4};
List<int> b = new List<int>();
b.Add(1);
b.Add(2);
//..
foreach(int e in a)
{
  //aの内容の列挙
}

foreach(int e in b)
{
  //bの内容の列挙
}
```

上の例ではinの後に受けっとったのはint[]であるが、下の例ではList<int>だ。

実はここに記述できる型はもっと多く存在する。

* Dictionary<K,T>
* Set<T>
* Collection<T>
* Stack<T>
* Queue<T>
...等

**どのような条件を満たすものであれば、inの後に書けるだろうか?**

結論から言えば、**IEnumerable<T>**インターフェースを実装するクラスであればforeach文を使うことが可能だ。
以下はIEnumerable<T>の定義である。
```csharp
public interface IEnumerable<T>
{
   IEnumerator<T> GetEnumerator();
}

public interface IEnumerator<T>
{
   T Current{get;}
   bool MoveNext();
   void Reset();
}
```

例えば、以下の2つの文は等価である。
```csharp
int[] t = new int[]{1,2,3,4};

foreach(int e in t)//foreachを使ったパターン
{

}
//whileに展開したパターン
IEnumerator<int> it=t.GetEnumerator();
while(it.MoveNext())
{
   int e = it.Current;
}
```

つまり、すべてのforeach文は下のwhileのように展開される。
これは以下のようなアルゴリズムに則った実装である。
* 最初に対応するEnumeratorを取得する(イテレータと呼ぶことが多い)
* イテレータに対してMoveNextを実行するとCurrentが次の値に移る。次の値がない場合はfalseを返すことでループが終わる
* 実際の値はit.Currentにより取得することができる。

### 問題1
等差数列を管理するクラスArithmeticSequenceはIEnumerable&lt;double&gt;を実装する。
対応するEnumeratorも記述し、以下のようなやり方で想定される出力を得られるようなクラス、ArithmeticSequence及びそれに付随するクラスを作成せよ。

```csharp
ArithmeticSequence sequence = new ArithmeticSequence(3/*初項*/,7/*公差*/,10/*列挙数*/);
foreach(double v in sequence)
{
   Console.Write("{0} ",v);
}
Console.Write("\n");
``` 
想定される結果
```
3 10 17 24 31 38 45 52 59 66
```

### 問題2
等差数列の数列を管理するクラスArithmeticSequenceSequenceはIEnumerable&lt;???&gt;を実装する。(???の部分は自分で考えて。)
対応するEnumeratorも奇術師、以下のようなやり方で想定される出力を得られるクラス、ArithmeticSequenceSequence及びそれに付随するクラスを作成せよ。

```csharp
ArithmeticSequenceSequence ssequence = new ArithmeticSequenceSequence(3/*初項(共通)*/,7/*初公差*/,3/*交差比*/,10/*列挙数(列)*/,5/*列挙数(行)*/);
foreach(var seq in ssequence)
{
  foreach(var v in seq)
  {
     Console.Write("{0} ",v);
  }
  Console.Write("\n");
}
```
想定される結果
```
3 10 17 24 31 38 45 52 59 66
3 13 23 33 43 53 63 73 83 93
3 16 29 42 55 68 81 94 107 120
3 19 35 51 67 83 97 113 131 147
3 22 41 60 79 98 113 132 155 174
```
