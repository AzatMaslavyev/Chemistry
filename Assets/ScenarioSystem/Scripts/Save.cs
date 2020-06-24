using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;// Используем библиотеку ввода вывода

public class Save : MonoBehaviour
{


    public string filename;

    private int t = 0;
    private int j = -1;
    

    public int timersecond;
    private float secondgametime;
    public float minedgametime;

   

    
    void Start()
    {

        if (filename == "") filename = "Data/Save/actives.dml";
        FileInfo f = new FileInfo(filename);
        if (!f.Exists) f.Create();
    }

    void Actives() // функция активности
    {

        t = j + 1;
        j = t;
        //z = j - 1;
    }

    void Update()
    {
       
        secondgametime += Time.deltaTime;
        if (secondgametime >= 1)
        {
            timersecond += 1;
            secondgametime = 0;

        }

        //if (timersecond >= 60)
        //{
        //minedgametime += 1;
        //  Debug.Log("Minute_" + minedgametime);
        //   timersecond = 0;
        //}

        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine("Активность/секунда.");
            sw.WriteLine("______________________________");
            timersecond = 0;
            j = 0;
            sw.Close();
            Debug.Log("Создан файл");
        }

        if (Input.anyKeyDown)
        {
            StreamWriter sw;
            FileInfo f = new FileInfo(filename);
            Actives();
            sw = f.AppendText();
            sw.WriteLine("");
            sw.WriteLine("<step>");
            sw.WriteLine("     <Second> " + timersecond + " </Second> ");
            sw.WriteLine("     <Active> " + j + "</<Active>> ");
            sw.WriteLine("     <mindfulness> " + " Нет переменной " + " </mindfulness> ");
            sw.WriteLine("</step>");
            sw.Close();
        }

        if (Input.GetMouseButton(2))
        {
            StreamReader sr = new StreamReader(filename);
            string str = "";

            while (!sr.EndOfStream)
            {
                str += sr.ReadLine();
                str += " ";
            }
            sr.Close();
            Debug.Log(str);
        }
    }
}