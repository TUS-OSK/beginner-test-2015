## PC上のファイル・フォルダのデータ構造は以下のようになっている
```csharp
class DataEntity
{
   public string name;
}

class Folder: DataEntity
{
   public DataEntity[] children;
}

class File :DataEntity
{
   public int fileSize;
}
```

今、入力DataEntity[] Structureが与えられる。
このStructureの例は以下のようである。

```csharp
Structure = 
{
   new Folder()
   {
     name="folder1",
     children=new DataEntity[]
     {
        new Folder()
        {
          name="folder1-1",
          children =new DataEntity[]{}
        },
        new Folder()
        {
          name="folder1-2",
          children =new DataEntity[]{
          　new File()
            {
              fileSize=30,
              name="file3"
            }
          }
        },
           new File()
        {
          fileSize=12,
          name="file1"
        },
        new File()
        {
          fileSize=100,
          name="file2"
        }
     }
   },
   new Folder()
    {
      name="folder2",
      children =new DataEntity[]{}
    },
   new File()
   {
      fileSize=10,
      name="file1"
   },
   new File()
   {
      fileSize=14,
      name="file2"
   }
};
```

上の例の入力では以下のようなファイル構造を表す。
```
--folder1
  --folder1-1
    --中身なし
  --folder1-2
    --file3
  --file1
  --file2
--folder2
  --中身なし
--file1
--file2
```
この時以下の問いに答えよ。

### 問1
入力としてStructure,string fileNameが与えられる、指定されたfileNameが一つ以上存在する場合はtrue,存在しない場合はfalseを返す関数を以下の関数をうめて完成させよ。

```csharp
public static bool ExistsName(DataEntity[] Structure,string fileName)
{
  /**
  * この空欄を埋めてコードを完成させよ。このコメントの行数は実際のコードの行数と何の関係性もない。
  */
}
```

### 問2
入力としてStructure,string fileOrFolderNameが与えられる。指定されたfileOrFolderNameとマッチするファイルパスを返す関数を以下の関数を埋めて完成させよ。
例えば、上記のStructureの例では、入力がfile1であった場合、file1はfolder1の中のfile1とトップの階層のfile1があるので出力は以下のようになる。
```
folder1/file1
file1
```

```csharp
public static string FindAll(DataEntity[] Structure,string fileOrFolderName)
{
  /**
  * この空欄を埋めてコードを完成させよ。このコメントの行数は実際のコードの行数と何の関係性もない。
  */
}
```

### 問3
問2の出力を改善し、対象がfolderであった場合、中身の全ファイルの容量の合計を同時に出力する関数を以下の関数を埋めて完成させよ。
例えば、入力がfolder1だった場合、中にある子のファイルの容量の合計は142なので以下のような出力となる。
```
folder1 142
```
以下の場合に注意して空欄を埋めよ。
* 子のフォルダだけではなくさらにその子のフォルダにファイルが含まれる場合もファイル容量に加算する。(さらにその子孫も同じく)
* 名前が等しいフォルダが存在する可能性に注意する。
* ヒットしたものがフォルダでなく、ファイルの場合はそのファイルの容量を出力する。

```csharp
public static string FindAllWithSize(DataEntity[] Structure,string fileOrFolderName)
{
  /**
  * この空欄を埋めてコードを完成させよ。このコメントの行数は実際のコードの行数と何の関係性もない。
  */
}
```

### 問4
入力Structureに対して問3の内容をすべてのファイル/フォルダに対して行いツリー状にしたデータを返す関数を作成せよ。
例えば上記のStructureの例の場合出力のstringは以下のようなものである。
```
--folder1 142
  --folder1-1 0
  --folder1-2 30
    --file3 30
  --file1 12
  --file2 100
--folder2 0
--file1　10
--file2 14
```
ただし、以下の点に注意して実装すること
* 返すstringは改行及びインデントによりフォルダ構造を明瞭に示すようになっていること。
* 今までの問いで作成したメソッドを利用してよい。

```csharp
public static string StructureTree(DataEntity[] Structure)
{
  /**
  * この空欄を埋めてコードを完成させよ。このコメントの行数は実際のコードの行数と何の関係性もない。
  */
}
```
