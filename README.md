# LightningReview-ReviewFile

![Build](https://img.shields.io/github/workflow/status/denso-create/LightningReview-ReviewFile/Build) [![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=denso-create_LightningReview-ReviewFile&metric=alert_status)](https://sonarcloud.io/dashboard?id=denso-create_LightningReview-ReviewFile)

デンソークリエイトのレビュー支援ツール Lightning Review（https://www.lightning-review.com/) のレビューファイルに関するライブラリとツールです。Lightning Reviewアプリケーション不要でLightning Reviewのレビューファイルの高速なデータ読み込みが可能です。また、.NET Standard/.NET Coreで開発をしているのでWindows/Linux/Macで動作可能です。


## LightningReview.ReviewFile

[![NuGet](https://img.shields.io/nuget/v/LightningReview.ReviewFile.svg)](http://nuget.org/packages/LightningReview.ReviewFile)

Lightning Reviewのレビューファイルのレビューや指摘のデータを高速に読み込み可能なライブラリです。

* コンパクトで他への依存関係がない軽量な設計になっています。
* 複数のLightning Reviewバージョンでの分析が可能です。
  * Lightning ReviewはV1.8でレビューファイルのフォーマットが変わりましたが、このライブラリではV1.8でもそれ以前のバージョンでもどちらのファイルも対応しています。
  * V2.0で追加された以下のプロパティに対応しています。
    * レビューのカスタムフィールド1～20
    * 指摘のカスタムフィールド11～20
    * メンバのカスタムフィールド1～5、カスタムロール1～5、タグ
    * ステータスの設定日、設定者、クローズを意味するステータスか、色
* 1000ファイルのレビューファイルの読み込みに数秒程度で処理可能と非常に高速になっています。
* 複数のレビューファイルを集計して品質メトリクスを計測するようなユースケースを想定しています。従って、現時点ではレビューファイルの要素のすべてに対応しているわけではありません。主にレビューと指摘に関する情報が参照できます。また、指摘画像の読み込みは対応していません。

### Install

Nuget: [LightningReview.ReviewFile](https://www.nuget.org/packages/LightningReview.ReviewFile/)

```
C:\Project> NuGet Install LightningReview.ReviewFile
```
### 例
単一のレビューファイルを指定する場合

```cs
using LightningReview.ReviewFile;
using LightningReview.ReviewFile.Models;

//...

// レビューファイルを読み込むクラスです
var reader = new ReviewFileReader();

// 単一のレビューファイルを指定する場合
var review = reader.Read(ReviewFilePath);
Console.WriteLine(review.Issues.Count());
```

フォルダにある複数のレビューファイルを指定する場合
```cs
// フォルダにある複数のレビューファイルを指定する場合
var reviews = reader.ReadFolder(folder);
foreach ( var review in reviews)
{
    Console.WriteLine(review.Name);

    // レビューごとの指摘件数
    Console.WriteLine(review.Issues.Count());

    // 指摘毎の詳細
    foreach ( var issue in review.Issues)
    {
        Console.WriteLine(issue.Description);
    }
}
```

読み込んだレビューおよび指摘の要素にアクセスする場合
```cs
// レビューを取得する
var review = reader.Read(ReviewFilePath);

// レビューのプロジェクト名
Console.WriteLine(review.ProjectName);
// レビューの目標件数
Console.WriteLine(review.IssueCountOfGoal);
// レビューの計画実施日
Console.WriteLine(review.PlannedDate);

// レビューが持つ指摘を取得する
foreach (var issue in review.Issues)
{
    // 指摘のステータス
    Console.WriteLine(issue.Status);
    // 指摘の優先度
    Console.WriteLine(issue.Priority);
    // 指摘の修正日
    Console.WriteLine(issue.DateFixed);
}
```
### フレームワーク
.Net Standard 2.0

### 依存パッケージ
なし

### 取得可能なプロパティ

詳細は[インターフェースの一覧](/src/ReviewFile/Models)を参照してください。  

### V1.8以前で取得できないプロパティとその場合に返す値の一覧
V2.0以降で追加されたプロパティまたはそれに関連するプロパティは、V1.8以前のレビューファイルでは定義されていないため、取得できません。  
そのため、V1.8以前のレビューファイルでは、以下の一覧に示す値を返します。

<!-- テーブルデータ -->
<table>
  <thead>
    <tr>
      <th>インターフェース</th>
      <th>プロパティ</th>
      <th>V1.8以前のレビューファイルに対して取得した場合の値</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td rowspan="8">IReview</td>
      <td>string CustomText(1～20)</td>
      <td>空文字(string.Empty) (初期値)</td>
    </tr>
    <tr>
      <td>IEnumerable&lt;IReviewCustomFieldDefinition&gt; ReviewCustomFieldDefinitions</td>
      <td>空のコレクション</td>
    </tr>
    <tr>
      <td>IEnumerable&lt;IMemberCustomRoleDefinition&gt; MemberCustomRoleDefinition</td>
      <td>空のコレクション</td>
    </tr>
    <tr>
      <td>IEnumerable&lt;IMemberCustomFieldDefinition&gt; MemberCustomFieldDefinitions</td>
      <td>空のコレクション</td>
    </tr>
    <tr>
      <td>IEnumerable&lt;IIssueCustomFieldDefinition&gt; IssueCustomFieldDefinitions</td>
      <td>指摘のカスタムフィールド1～10の定義のコレクション</td>
    </tr>
    <tr>
      <td>IEnumerable&lt;IReviewMember&gt; Members</td>
      <td>`IReviewMember`の`Name`、`Reviewer`、`Reviewee`、`Moderator`を設定したうえで、それ以外は初期値のオブジェクトを返す。</td>
    </tr>
    <tr>
      <td>IStatusItem ReviewStatusItem</td>
      <td>`IStatusItem`の`Name`と`IsSelected`を設定したうえで、それ以外は初期値のオブジェクトを返す。</td>
    </tr>
    <tr>
      <td>IEnumerable&lt;IStatusItem&gt; ReviewStatusItems</td>
      <td> ステータスの定義ごとに`ReviewStatusItem`と同様のポリシーで設定し、ステータスの一覧を返す。</td>
    </tr>
    <tr>
      <td>IIssue</td>
      <td>string CustomText(11～20)</td>
      <td>空文字(string.Empty) (初期値)</td>
    </tr>
    <tr>
      <td rowspan="3">IReviewMember</td>
      <td>bool CustomRole(1～5)</td>
      <td>false (初期値)</td>
    </tr>
    <tr>
      <td>string CustomText(1～5)</td>
      <td>空文字(string.Empty) (初期値)</td>
    </tr>
    <tr>
      <td>string Tag</td>
      <td>空文字(string.Empty) (初期値)</td>
    </tr>
    <tr>
      <td rowspan="4">IStatusItem</td>
      <td>DateTime? SelectedOn</td>
      <td>null (初期値)</td>
    </tr>
    <tr>
      <td>string SelectedBy</td>
      <td>空文字(string.Empty) (初期値)</td>
    </tr>
    <tr>
      <td>bool IsClosed</td>
      <td>false (初期値)</td>
    </tr>
    <tr>
      <td>string Color</td>
      <td>"なし" (初期値)</td>
    </tr>
  </tbody>
</table>

## LightnigReview.ReviewFileToJsonService

[![NuGet](https://img.shields.io/nuget/v/LightningReview.ReviewFileToJsonService.svg)](http://nuget.org/packages/LightningReview.ReviewFileToJsonService)

フォルダ内のLightning Reviewのレビューファイルの内容を読み込んでJSONファイルに出力するライブラリです。
`LightningReview.ReviewFile` を参照して作成している軽量なライブラリです。レビューの指摘件数、メトリクスの計算などで利用して下さい。


### Install

Nuget: [LightningReview.ReviewFileToJsonService](https://www.nuget.org/packages/LightningReview.ReviewFileToJsonService/)

```
C:\Project> NuGet Install LightnigReview.ReviewFileToJsonService
```

### 例

```cs
using LightnigReview.ReviewFileToJsonService;

//...

// エクスポート処理
var exporter = new ReviewFileToJsonExporter();

// ロガーを設定しておく
exporter.Logger = (message) => Console.WriteLine(message);

// 実行
exporter.Export(folderPath, jsonFilePath);
```

### フレームワーク
- .Net Standard 2.0

### 依存パッケージ
- LightnigReview.ReviewFile  
- System.Text.Json  
- System.Text.Encodings.Web

## ReviewFileToJsonCLI

フォルダ内のレビューファイルの内容をJSONファイルに出力するコマンドラインプログラムです。

| ReviewFileToJson.exe -f folderPath

`-f`でレビューファイルが格納されたフォルダパスを指定すると、現在のフォルダに `output.json` を出力します。

| ReviewFileToJson.exe -f folderPath -o myJsonFile.json

 `-o`で出力ファイル（パス）を指定できます。

| ReviewFileToJson.exe -f folderPath -o myJsonFile.json -r

`-r`を指定するとサブフォルダまで対象にできます。

| ReviewFileToJson.exe -f folderPath -u

`-u`を指定すると出力されるJSONファイルにおいてUnicodeエスケープを行いません。

### `-u`オプションの注意点
本オプションをつけることで出力されるJSONファイルはUTF-8でエンコードされたJSONファイルとなります。  
以下はJSONファイルの指摘の重大度の出力イメージ例

```
"Importance": "\u4E2D" // -u オプションをつけず、Unicodeエスケープされた状態
"Importance": "中"     // -u オプションをつけて、UTF-8で出力された状態
```

-uをつけて出力されたJSONファイルを別ツールで読み込む場合は、ファイル内容がうまく読み取れなくなる恐れがあるため、UTF-8で読み込む必要があることに注意してください。

### 出力されるJSONファイルのフォーマット

``` 
{
    "TotalReviewCount": 3,  // 読みこんだレビューファイルの数
    "TotalIssueCount": 9,   // すべてのレビューファイルの指摘の合計
    "Reviews": [            // 読み込んだレビューの一覧 
        {
            // レビュー①のフィールド情報
            "GID": "b90a3142-2c05-4550-9ac5-008ea6461bc0",
            "FilePath": "C:\\work\\\\RevFile1.revx",
            //...
            "Issues": [
                {
                    // レビュー①に関連する指摘①のフィールド情報
                    "GID": "a74cde8d-d7e7-4948-8a60-82f0fabea5f8",
                    "LID": "1",
                    //...
                },
                {
                    // レビュー①に関連する指摘②のフィールド情報
                    "GID": "4eaf62fa-995a-45f7-9ddf-65e605bfc28c",
                    "LID": "2",
                    //...
                }
            ]  
        },
        {
            // レビュー②のフィールド情報
            "GID": "b90a3142-2c05-4550-9ac5-008ea6461bc1",
            "FilePath": "C:\\work\\\\RevFile2.revx",
            //...
            "Issues": [
                {
                    // レビュー②に関連する指摘①のフィールド情報
                    "GID": "a74cde8d-d7e7-4948-8a60-82f0fabea5f9",
                    "LID": "1",
                    //...
                }
            ]
        }
    ]
}
``` 

### 出力フィールドの説明
フィールド情報の詳細は下記クラスに記載してあります。
- レビューのフィールド情報について: [Review.cs](https://github.com/denso-create/LightningReview-ReviewFile/blob/main/src/ReviewFileToJsonService/Models/Review.cs)
- 指摘のフィールド情報について: [Issue.cs](https://github.com/denso-create/LightningReview-ReviewFile/blob/main/src/ReviewFileToJsonService/Models/Issue.cs)

### フレームワーク
- .Net Core 3.1

### 依存パッケージ
- LightningReview.ReviewFileToJsonService
- CommandLineParser

### 活用例：コマンドラインプログラムを実行してレビューファイルのデータをExcelで表示

本ライブラリの具体的な利用例を動画を使ってご紹介します。  
ここでは、以下の Step で実施します。  

- [Step1：コマンドラインプログラムを実行してレビューファイルのデータを出力します](#step1コマンドラインプログラムを実行してレビューファイルのデータを出力します)
- [Step2：出力したレビューファイルのデータをExcel上に表形式で表示します](#step2出力したレビューファイルのデータをexcel上に表形式で表示します)

#### Step1：コマンドラインプログラムを実行してレビューファイルのデータを出力します

フォルダ内に複数格納されているレビューファイルに登録されたレビューや指摘のデータを、JSON形式で出力します。  
下の動画では、Windows のコマンドプロンプトにて Lightning Review のファイルが複数格納されたフォルダを指定して実行することで、output.jsonというファイルを出力しています。

![output](https://user-images.githubusercontent.com/71699816/136491468-6979b6df-05fd-4824-8ecb-2d166cda3d6d.gif)

#### Step2：出力したレビューファイルのデータをExcel上に表形式で表示します

JSON形式で出力したoutput.jsonは、Excelの機能を利用して表形式に変換できます。  
下の動画では、Step1 にて出力したoutput.jsonファイルをExcelで表に変換して表示しています。  
Lightning Review ファイルが保持しているそのままのデータを一覧に表示できるため、その後はお好みの形に合わせて分析できます。

![data_transform](https://user-images.githubusercontent.com/71699816/136491547-6348fb81-004b-42ac-9024-55512bea407c.gif)