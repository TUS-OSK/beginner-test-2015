# Questions
## 問1 クラスと継承

 * **問1. 以下のコードを読み、問1.1－1.6の出力を答えよ。**
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            IRunable animal1 = new Animal();
            IRunable human1 = new Human("Jone");
            Animal human2 = new Human("Judy");
            animal1.Run();  // 問1.1
            animal1.Walk(); // 問1.2
            human1.Run();   // 問1.3
            human1.Walk();  // 問1.4
            human2.Run();   // 問1.5
            human2.Walk();  // 問1.6
        }
    }
    interface IRunable
    {
        void Run();
        void Walk();
    }

    class Animal : IRunable
    {
        protected string Name;

        public virtual void Walk()
        {
            Console.WriteLine("Animal Walk");
        }

        public virtual void Run()
        {
            Console.WriteLine("Animal Run");
        }
    }

    class Human : Animal
    {
        public Human(string name)
        {
            this.Name = name;
        }
        public override void Run()
        {
            Console.WriteLine(Name + "Run");
        }
        public new void Walk()
        {
            Console.WriteLine(Name + "Scream");
        }
    }
```
## 問２ デリゲートとラムダ式
 * デリゲートはメソッドへの参照を表す型です。 メソッドを持ち運び、好きなときに呼び出すことができます。メソッドを呼び出すには、引数(パラメーターリスト)と戻り値の型が分かっていればいいので、デリゲートの生成にもそれらを指定しなくてはいけません。デリゲートを使えば、以下のように二元関数を定義できます。
```csharp
public delegate double DoubleFunc(double x, double y);
```
* ちなみに、デリゲート型は.NET Frameworkのクラス・ライブラリのAction型やFunc型でほとんど代用できるので、気になる人は調べてみてください。
*  以下のようなCalculaterクラスがあり、メンバーが計算機と同期しているとします。計算機はNumberXとNumberYに値を代入し、ボタンが押されるとCalculateメソッド呼ぶようになっています。そして計算結果であるAnswerが計算機の画面に反映されるという仕組みです。
*  **問2.1 Calculateメソッド実装せよ。**
```csharp
 class Calculater
    {
        public void Calculate()
        {
           /* 問2.1 CalculateFuncを用いてAnswerに値を代入 */         
        }
        public DoubleFunc CalculateFunc;
        public double NumberX { get; set; }
        public double NumberY { get; set; }
        public double Answer { get; set; }
    }
```
 * ここで重要なのは、**計算法を定義しないで計算機を定義した**ということです。計算法は後からいくらでも変更できるのです。
 * では、CalculateFuncに関数を代入してみましょう。
```csharp
(インスタンス名).CalculateFunc = (x,y)=>{return x + y;};
```
* これで、計算機は足し算をするようになりました。この書き方は以下と同等です。このfuncメソッドは一度しか呼ばれないため、上記のような無名のメソッドで代用できるのです。この無名メソッドを**ラムダ式**といいます。
*  **問2.1 funcメソッドを実装せよ。**
```csharp
double func(double x,double y)
{
      /* 問2.2 足し算 */ 
}
```
```csharp
(インスタンス名).CalculateFunc = func;
```
* **問2.3 以下を埋め、matrixXとmatrixYの各要素をfuncによって結合した二次元配列を返すメソッドを完成せよ。**
```csharp
double[][] MatrixCalculation(double[][] matrixX,double[][] matrixY,DoubleFunc func)
{
      /* 問2.3 matrixXとmatrixYの各要素をfuncによって結合した二次元配列を返す。*/ 
}
```

## 問3 イベント
* イベントは複数のデリゲートを一つのデリゲートのように扱う文法です。以下のようにデリゲート型を用いて定義します。**イベントが呼び出されたとき、登録された全てのデリゲートが参照するメソッドが呼び出されます**。
```csharp
public delegate void SampleEventHandler(object sender, EventArgs e);
public event SampleEventHandler sampleEvent;
```
* あるイベントが起きたとき、例えばアプリケーションを起動したときなどがイメージしやすいですが、いろんなクラスのメソッドを同時に呼び出さなくてはいけません。しかし、開発段階では呼ばなくてはいけないメソッドを全て特定することは難しいです。そこで、管理クラスに起動イベントを持たせておくのです。そうすれば、のちに起動時に呼ばなくてはいけないメソッドが出来たときに、起動イベントに登録するだけでよくなるわけです。
```csharp
/* イベントの登録 1*/
SampleEvent += new SampleEventHandler((sender, e) => { Console.WriteLine( sender.ToString() + "called 1\n"); });
/* イベントの登録 2*/
sampleEvent += (sender,e) => { Console.WriteLine( sender.ToString() + "called 2\n");};
/* イベントの登録 ３*/
public void func(object sender, EventArgs e)
{
    Console.WriteLine( sender.ToString() + "called 3\n");
}
sampleEvent += func;
```
* **問3.1 上記のようにイベントを登録し、下記のようにイベントを呼び出した。この時のコンソール出力を答えよ。**
```csharp
/*問3.1 イベントの呼び出し */
sampleEvent( "target", EventArgs.Empty );
```