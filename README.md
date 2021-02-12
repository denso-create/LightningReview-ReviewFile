# LightningReview-RevxFile

* Lightning ReviewのRevxファイルを高速に読み込みできる.NET ライブラリ、ツールです。
* .NET Standard/.NET Coreで開発をしているのでWindows/Linux/Macで動作可能です。

### LightningReview.RevxFile
* revxファイルを高速に読み書き可能なライブラリです。
* コンパクトで他への依存関係がない軽量な設計になっています。
* 現在は読み込みのみサポートしています。

```cs
using LightningReview.RevxFile;
using LightningReview.RevxFile.Models;
```

単一のレビューファイルを指定する場合
```cs
    // revxファイルを読み込むクラスです
    var reader = new RevxReader();

    // 単一のレビューファイルを指定する場合
    var review = reader.Read(revxFilePath);
    Console.WriteLine(review.AllIssues.Count());
```


フォルダにある複数のレビューファイルを指定する場合
```cs
    // フォルダにある複数のレビューファイルを指定する場合
    var reviews = reader.ReadFolder(revxFolder);
    foreach ( var review in reviews)
    {
        Console.WriteLine(review.AllIssues.Count());
    }
```


## RevxToJson
フォルダ内のrevxファイルの内容をJSONファイルに出力するコマンドラインプログラムです。

| revxToJson.exe -f revxFolder

と実行すると、現在のフォルダに `output.json` を出力します。

| revxToJson.exe -f revxFolder -o myJsonFile.json

のように `o`で出力ファイル（パス）を指定できます。

## 性能について
性能については、1000ファイルのレビューファイル(revx)の集計に1-2秒程度で処理可能と非常に高速になっています。


