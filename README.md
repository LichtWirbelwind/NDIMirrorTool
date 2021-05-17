<!-- omit in toc -->
# NDI Mirror Tool

- [インストール方法](#インストール方法)
  - [解凍先](#解凍先)
  - [PATH](#path)
  - [実行時の警告](#実行時の警告)
- [使用方法](#使用方法)
- [使用環境](#使用環境)
- [既知の問題点](#既知の問題点)
- [技術的なこと](#技術的なこと)
- [注釈](#注釈)
- [License](#license)

NDI®<sup>[1](#note1)</sup> を使って VLC から OBS に映像を取り込む際に、リネームをして OBS 上で選びやすくるソフトです。

RTA Racing で複数の走者の配信をミラーする際に、使いやすくなることを想定して作られています。

## インストール方法
[Releases](https://github.com/LichtWirbelwind/NDIMirrorTool/releases) から最新のバージョンを選び、その Assets 3 の中の NDIMirrorTool.zip をダウンロードしてください。

### 解凍先

お好きなフォルダーに解凍してください。

### PATH

PowerShell から起動する場合はシステム環境変数の PATH に、解凍先のフォルダーを追加する必要があります。

システム環境変数の編集から解凍先のフォルダーを設定するか、もしくは解凍したファイルの中にある AddPath.ps1 を右クリックし「PowerShell で実行」をしていただくと追加されます（管理者権限を要求されます）。

### 実行時の警告

初回実行時に Windows SmartScreen が出て止められたら、詳細情報を開いて実行してください。

PowerShell から初回実行した際に、アンチウイルスソフトが動く可能性があります。

ファイアウォールが通信をブロックした場合は、プライベートネットワークのアクセスを許可してください。

## 使用方法

PowerShell から起動する際に、「PS C:\\> NDIMirroTool -t リヒト」と書き実行すると、最初から走者名にリヒトが入った状態で起動します（オプションは t でも n でも OK）。

途中で走者名を変更したい場合は、走者名変更ボタンを押して入力してください。

NDI® Sources に開いている VLC の一覧が表示されますので、クリックして選択し、プレビューを見て走者名と配信内容が一致していることを確認してください。

あとは OBS に追加した NDI™ Source のプロパティで、Soure name の一覧の中から走者名を見つけて設定すれば、出力したい配信が得られると思います。

## 使用環境

Windows 10 64bit版を想定しています。

一応 Windows 8 以降の 32bit 版でも動くようにコンパイルしてありますが、テスト環境が無いため動作が保証できません。どうしてもその環境で動かしたい場合はご連絡ください。

## 既知の問題点

NDI® Sources を頻繁に切り替えると、Access Violation Exception が発生することがあります。再生フレームの読み込み時に発生しているので致命的なエラーにはならないと思いますが、切り替えは必要最小限にしてください。

## 技術的なこと

工事中

## 注釈
<small id="note1">1.^ NDI® is a registered trademark of NewTek, Inc. https://www.ndi.tv/</small>

## License

The source code is licensed MIT. The website content is licensed CC BY 4.0,see LICENSE.
