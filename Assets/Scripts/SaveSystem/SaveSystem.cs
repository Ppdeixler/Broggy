using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayer(Manager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/upgradess.lpd";
        FileStream stream = new FileStream(path, FileMode.Create);

        DadosJogo data = new DadosJogo(manager);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveScore(Score score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string caminho = Application.persistentDataPath + "/highscore.lxd";
        FileStream stream = new FileStream(caminho, FileMode.Create);

        DadosJogo scorezin = new DadosJogo(score);
        formatter.Serialize(stream, scorezin);
        stream.Close();
    }

    public static void SaveCoins(CoinVariable coinvariable)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string caminho = Application.persistentDataPath + "/moedas.lxd";
        FileStream stream = new FileStream(caminho, FileMode.Create);

        DadosJogo moedinhas = new DadosJogo(coinvariable);
        formatter.Serialize(stream, moedinhas);
        stream.Close();
    }


    public static DadosJogo LoadScore()
    {
        string caminho = Application.persistentDataPath + "/highscore.lxd";
        if (File.Exists(caminho))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(caminho, FileMode.Open);

            DadosJogo scorezin = formatter.Deserialize(stream) as DadosJogo;
            stream.Close();
            return scorezin;

        }
        else
        {
            Debug.LogError("ERROR NO FILE");
            return null;
        }
    }


    public static DadosJogo LoadCoins()
    {
        string caminho = Application.persistentDataPath + "/moedas.lxd";
        if (File.Exists(caminho))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(caminho, FileMode.Open);

            DadosJogo moedinhas = formatter.Deserialize(stream) as DadosJogo;
            stream.Close();
            return moedinhas;

        }
        else
        {
            Debug.LogError("ERROR NO FILE");
            return null;
        }
    }

    public static DadosJogo LoadPlayer()
    {
        string path = Application.persistentDataPath + "/upgradess.lpd";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DadosJogo data = formatter.Deserialize(stream) as DadosJogo;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("ERROR NO FILE");
            return null;
        }
    }
}
