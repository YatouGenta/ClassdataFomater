# ClassdataFomater
クラスを外部ファイルとして保存する

<h2>概要</h2>

クラスデータをバイナリー化し外部に保存する機能

<h2>開発環境</h2>

Unity2019.1

<h2>使い方</h2>

ClassDataFomaterの以下の各関数を必要に応じて呼んでください

```
    /// <summary>
    /// クラスをバイナリーにして対象パスへ保存する
    /// </summary>
    /// <typeparam name="T">対象のクラス種類</typeparam>
    /// <param name="path">保存パス</param>
    /// <param name="obj">対象のクラスオブジェクト</param>
    public static void Seialize<T>(string path, T obj)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, obj);
        }
    }

    /// <summary>
    /// バイナリーにしたデータを復元する
    /// </summary>
    /// <typeparam name="T">対象のクラス</typeparam>
    /// <param name="path">保存パス</param>
    /// <returns></returns>
    public static T Deserialize<T>(string path)
    {
        T obj;
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            BinaryFormatter f = new BinaryFormatter();
            obj = (T)f.Deserialize(fs);
        }
        return obj;
    }

    /// <summary>
    /// 指定パスにデータが存在するかどうかをチェックする
    /// </summary>
    /// <typeparam name="T">対象のクラス</typeparam>
    /// <param name="path">保存パス</param>
    /// <returns></returns>
    public static bool DataCheack(string path)
    {
        return System.IO.File.Exists(path);
    }
```

<h2>備考</h2>

このリポジトリの物はほぼ参考サイトまんまのものです  
後々ゲームのセーブなどをこれを使って管理などできたらいいなぁ  
自分用メモとして一旦このリポジトリを作成

参考サイト  
https://simplestar-tech.hatenablog.com/entry/2018/01/07/133451
