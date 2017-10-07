# Herope
H29ゲームアルゴリズム3 の課題用リポジトリ

リポジトリルール

■ブランチ

統合ブランチ
[master/(version)]　→　ゲームがプレイできる状態のバージョンを保つこと
定期的にデフォルトブランチとして設定します。

・master/v1.0.0
プロトタイプとして遊べる状態のバージョン

トピックブランチ
[(name)] →　　担当者の名前を用いたブランチにしてください。
（メンバーが２名だけなので、これでも問題ないかと）
必要があればfix系ブランチを作成するのもアリ

■コミット
【トピック名】 + 作業内容(なるべく内容が１行で済ませられるよう細かくコミットしてくれるとありがたい)

コミット作成者名について
[lastname.firstname] →　自分の名前をフルネームで設定してください。
例）
森田　勝の場合→[morita.suguru]

※設定方法
設定→グローバルユーザー設定を使う→チェックを外す
ユーザー名　→　上記のルール通りに名前を設定してください
メールアドレス　→　そのままでOK

■プッシュ
ForcePushはダメ

■マージについて
マージ担当者を決定し、その人以外は新しくマージを行わないこと

■プルリク
今回は特に求めません。

■ディレクトリ
検証用に使用するファイルやビルドに含めないファイルやフォルダーは頭文字に`_`(アンダーバー)を加えてください。
ビルド前に退避させます。
例）
pngファイルの場合　→　_〇〇.png
