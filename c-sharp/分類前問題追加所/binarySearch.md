## MMDのモーションデータは以下のようなクラスの構造の配列によって与えられる。

```csharp
class MMDMotionFrame
{
  public int time;
  public float[] position;//position.Length=3が保障されている。
}
```

今、入力としてMMDMotionFrame[] Motion;とdouble t;が与えられる。これらに与えられる条件は以下の通りである。
* tはNaNではない。
* Motion.Length>=1
* timeは必ずしも連続的ではない。(Motion[i].time+1 = Motion[i+1].timeである保証はない)
* Motion[0].time = 0 である保証はない
* Motion内の要素はtimeによって以下の条件で整理されている。
任意の配列インデックスi,jをとりだしたとき、i<j⇒Motion[i].time<Motion[j].time
即ち、timeが少ないほうから多いほうへ変化するようにソートされているものとする。

さて、この入力から、tの時点でのpositionを算出したい。
もし、tの時点でのデータが配列に存在しない場合は、そのtの時点を挟む最も近接する2つのデータから線形補完しpositionを算出する。
### 例
```csharp
Motion = {
  new MMDMotionFrame()
  {
     time=0,
     position=new []{0,0,0}
  },
    new MMDMotionFrame()
  {
     time=3,
     position=new []{3,6,9}
  },
    new MMDMotionFrame()
  {
     time=9,
     position=new []{303,72,12123}
  }
};
```
この時、入力に対する出力の値は以下の通りである。
* t=2のとき  (2,4,6)
* t=1のとき (1,2,3)
* t=3のとき (3,6,9)
* t=5のとき (103,28,4038)
* t=8のとき (253,61,10104)

また、最終フレームより後、もしくは最初のフレームより前の場合は以下のように最も近接するデータを用いる。
* t= -1のとき　(0,0,0)
* t=100のとき (303,72,12123)

### 誘導問題1
以下の関数は、引数として入力されるモーションフレームm1,m2から,t秒後のpositionを算出し、算出した値を返す関数である。
空欄を埋めて関数を完成させよ。

```csharp
public static float[] calcInterpolation(MMDMotionFrame m1,MMDMotionFrame m2)
{
   int timeDiff = m2.time - m1.time;
   /*
   * この部分のコードを答えよ。ただし、このコメントの行数に意味はない。
   */
}
```

### 誘導問題2
以下の関数は、入力Motionとtからtのときのpositionを返す関数である。誘導問題1の内容を用いてこの関数を実装せよ。
この関数は以下のアルゴリズムに従って実装すればよい。(ヒント)

1. すべてのデータをループ
2. 一つ後のデータのtimeと今のデータのtimeの間にtがあるかチェック
3. 存在したらcalcInterpolationを利用すればよい。

以下の項目に注意すること。
* 入力されたMotion.Lengthが1だった場合。
* tが与えられたMotionの範囲外にある場合

```csharp
public static float[] solveWithoutBinarySearch(MMDMotionFrame[] Motion,double t)
{
   /*
   * この部分のコードを答えよ。ただし、このコメントの行数に意味はない。
   */
}
```

### 本題
さて、誘導問題2のアルゴリズムはアルゴリズム的に優れているとは言えない。
10000個の入力があったとき、10000個めに該当するフレームがあればそれだけループをしてしまう。3DCGのアニメーションでは１秒間に60回以上も、このような関数を各関節に対して実行する。これでは致命的である。
そこで、BinarySearchというアルゴリズムがある。
このモーションは既にソートされているので、真ん中から見ていけば早いことになる。
配列の真ん中のtimeとtを比較し、tのほうが大きければ後半の配列の中から、小さければ前半の配列の中から探せばよい。
また、その際も後半/前半の配列の真ん中のtimeと比較し...としていき繰り返す。
最後に配列の要素が1つしかないときそれが最も近接するフレームであるといえる。

![](http://mrmonline.org/site/wp-content/uploads/2014/02/binary-search-wikepedia.gif)

このアルゴリズムによって誘導問題2の内容を以下の関数として実装せよ。
以下の項目に注意すること。
* 入力されたMotion.Lengthが1だった場合。
* tが与えられたMotionの範囲外にある場合
* 一般的なBinarySearchは等しいものを見つけるためにあるものである。今回は区間を探さなければならない。アルゴリズムを応用し変更して実装すること。


```csharp
public static float[] solveWithBinarySearch(MMDMotionFrame[] Motion,double t)
{
   /*
   * この部分のコードを答えよ。ただし、このコメントの行数に意味はない。
   */
}
```
