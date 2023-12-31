【制作使用エンジン】Unity

【制作期間】2ヶ月

【バージョン管理】SourceTree

【ゲームジャンル】トランプゲーム

【ゲーム概要】
・スマートフォン対応のアプリゲームです。

・このゲームでは、３種類のトランプゲーム「ハイアンドロー」「神経衰弱」「ブラックジャック」を遊ぶことが出来ます。

・「ハイアンドロー」は、１枚目に引いたカードの数字より次に引くカードの数字が高いか低いかを予想するゲームです。
　正解するたびにスコアが加算され、一度でも間違えるとゲームオーバーになります。

・「神経衰弱」は、裏向きに置かれたカードから同じ数字のカードを2枚揃えるゲームです。

・「神経衰弱」には、「ライフモード」と「タイムアタックモード」で遊ぶことが出来ます。
　また各モード「イージー（12枚）」「ノーマル（16枚）」「ハード（20枚）」の難易度が選べます。

・「神経衰弱」の「ライフモード」は、めくったカードの数字が揃わなかった場合はハートゲージが１つ減り、５つ全て無くなるとゲームオーバーになります。

・「神経衰弱」の「タイムアタックモード」は、全てのカードを素早く揃えてタイムを競うモードです。
　このモードには、ハートゲージは無く、揃わなくてもゲームオーバーにはなりません。

・「ブラックジャック」は、ディーラー（AI）とプレイヤーの対戦ゲームです。
　カードの数字の合計数が21点に近い方が勝利となります。
　
　【ブラックジャックのルール説明】
　　勝負は5回行い、勝利回数が多い方が勝ちとなります。また、勝利回数が同数だった場合は、引き分けとなります。
　　21点を超えてしまった場合はバーストとなり、負けが確定されます。ディーラーとプレイヤーの双方がバーストしてしまった場合は引き分けとなります。
　
　【カードの点数の計算方法】
　　2～10：数字通りの点数
　　J,Q,K：10点
　　A：1点、または11点

【操作方法】
・「ハイアンドロー」は、高いと思った場合は「HIGH」ボタンを選択、低いと思った場合は「LOW」ボタンを選択する。

・「神経衰弱」は、裏向きに伏せられたカードをタップをする事でカードをめくる事が出来ます。

・「ブラックジャック」は、「HIT」ボタンを選択した場合はカードを一枚引き、「STAY」ボタンを選択した場合はカードを引かずディーラーにターンを回します。

【アピールポイント・苦労した点】
・一つのゲームに「ハイアンドロー」「神経衰弱」「ブラックジャック」の３種類のトランプゲームを選べるように制作しました。

・スマートフォンで遊ぶことを想定して、画面サイズに問題がない様に意識して制作しました。

・「ブラックジャック」にて、AIを組み込む事が初めてでしたので、AIの動作がゲーム進行に不具合が起きないよう気をつけて制作しました。